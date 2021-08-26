// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ContextualPathDetection
    {
        private const string ProviderSegment = "providers";

        private static ConcurrentDictionary<OperationGroup, string> _valueCache = new ConcurrentDictionary<OperationGroup, string>();

        public static string ContextualPath(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            if (operationGroup.TryGetContextualPath(config, out var contextualPath))
                return contextualPath;

            // otherwise we throw exception to notify the user to modify their readme.md
            throw new Exception($"Contextual Path schema not found! Please add the {operationGroup.Key} to its schema name mapping in the `operation-group-to-contextual-path` section of readme.md.");
        }

        public static bool TryGetContextualPath(this OperationGroup operationGroup, MgmtConfiguration config, [MaybeNullWhen(false)] out string contextualPath)
        {
            contextualPath = null;
            if (_valueCache.TryGetValue(operationGroup, out contextualPath))
            {
                return true;
            }

            // if this operationGroup does not correspond to a resource, return false immediately
            if (!operationGroup.IsResource(config))
                return false;

            // read the configuration first
            if (config.OperationGroupToContextualPath.TryGetValue(operationGroup.Key, out contextualPath))
            {
                _valueCache.TryAdd(operationGroup, contextualPath);
                return true;
            }

            // configuration does not set this, we should find a way to calculate this
            contextualPath = FindContextualPath(operationGroup, config);

            return contextualPath != null;
        }

        private static string? FindContextualPath(OperationGroup operationGroup, MgmtConfiguration config)
        {
            // TODO -- WIP
            return null;
        }

        public static IEnumerable<ContextualParameterMapping> BuildContextualParameterMapping(this Resource resource, BuildContext<MgmtOutputLibrary> context, string idVariableName = "Id")
        {
            var stack = new Stack<ContextualParameterMapping>();
            BuildContextualParameterMappingHierarchy(resource.OperationGroup, resource.OperationGroup.ResourceType(context.Configuration.MgmtConfiguration),
                resource.ContextualPath, context, stack, idVariableName);
            return stack;
        }

        public static IEnumerable<ContextualParameterMapping> BuildContextualParameterMapping(this ResourceContainer container, BuildContext<MgmtOutputLibrary> context, string idVariableName = "Id")
        {
            var stack = new Stack<ContextualParameterMapping>();
            // for resource container, the contextual path should be the parent of the corresponding resource
            var parent = container.OperationGroup.ParentOperationGroup(context);
            var parentType = container.OperationGroup.ParentResourceType(context.Configuration.MgmtConfiguration);
            BuildContextualParameterMappingHierarchy(parent, parentType, GetParentContextualPath(parent, parentType, context),
                context, stack, idVariableName);
            return stack;
        }

        private static void BuildContextualParameterMappingHierarchy(OperationGroup? current, string currentResourceType, string currentContextualPath,
            BuildContext<MgmtOutputLibrary> context, Stack<ContextualParameterMapping> parameterMappingStack, string idVariableName = "Id", string invocationSuffix = "")
        {
            if (current == null)
            {
                switch (currentResourceType)
                {
                    case ResourceTypeBuilder.Subscriptions:
                    case ResourceTypeBuilder.Tenant:
                        return;
                    case ResourceTypeBuilder.ResourceGroups:
                        parameterMappingStack.Push(new ContextualParameterMapping("resourceGroupName", $"{idVariableName}.ResourceGroupName"));
                        return;
                    case ResourceTypeBuilder.ManagementGroups:
                        parameterMappingStack.Push(new ContextualParameterMapping("managementGroupId", $"{idVariableName}{invocationSuffix}.Parent.Name"));
                        return;
                    default:
                        throw new Exception($"Unhandled case of terminal resource type {currentResourceType}");
                }
            }
            var parent = current.ParentOperationGroup(context);
            var parentType = current.ParentResourceType(context.Configuration.MgmtConfiguration);
            var parentContextualPath = GetParentContextualPath(parent, parentType, context);
            var suffixSegments = GetPathSuffixSegments(currentContextualPath, parentContextualPath);
            // the contextual path of the parent should be a prefix of the current
            if (suffixSegments == null)
            {
                throw new Exception($"The contextual path of the parent is not a prefix of current operation group {current.Key}");
            }
            // considering some rare conditions, we do not require we have to have a method that corresponds to the contextual path, the path can be virtual to ensure we get correct parameter invocation around the Id
            // we always need to get the "value" of the key value pair in the path
            // TODO -- we have issues on the scope resources
            var lastOddIndex = suffixSegments.Length % 2 == 0 ? suffixSegments.Length - 1 : suffixSegments.Length - 2;
            for (int i = lastOddIndex; i >= 0; i -= 2)
            {
                (var isReference, var parameterName) = IsReference(suffixSegments[i]);
                if (isReference)
                {
                    parameterMappingStack.Push(new ContextualParameterMapping(parameterName!, $"{idVariableName}{invocationSuffix}.Name"));
                }
                invocationSuffix += ".Parent";
            }
            // recursively get the parameters of its parent
            BuildContextualParameterMappingHierarchy(parent, parentType, parentContextualPath, context, parameterMappingStack, idVariableName, invocationSuffix);
        }

        private static string[]? GetPathSuffixSegments(string currentPath, string parentPath)
        {
            if (!currentPath.StartsWith(parentPath))
                return null;
            // we get the difference between currentPath and parentPath and remove leading slashes
            var suffixSegments = currentPath.Substring(parentPath.Length).TrimStart('/').Split("/");
            // we should not have 0 segments here
            if (suffixSegments.Length == 0)
                return null;
            // remove the leading providers, the providers will be ignored by the ResourceIdentifier's parenting hierarchy
            if (suffixSegments[0].Equals(ProviderSegment, StringComparison.InvariantCultureIgnoreCase))
                return suffixSegments.Skip(2).ToArray();
            // this suffix does not start with providers, directly return the segments
            return suffixSegments;
        }

        private static (bool IsReference, string? ReferenceName) IsReference(string segment)
        {
            if (segment.StartsWith("{") && segment.EndsWith("}"))
            {
                return (true, segment.Trim('{', '}'));
            }
            return (false, null);
        }

        private static string GetParentContextualPath(OperationGroup? parent, string parentType, BuildContext<MgmtOutputLibrary> context)
        {
            return parent?.ContextualPath(context.Configuration.MgmtConfiguration) ?? ResourceTypeBuilder.TypeToContextualPath[parentType];
        }

        private static RestClientMethod GetMethodOfContextualOperation(Resource resource, string contextualPath)
        {
            foreach (var method in resource.RestClient.Methods)
            {
                foreach (var req in method.Operation.Requests)
                {
                    if (req.Protocol.Http is HttpRequest request && request.Path == contextualPath)
                    {
                        return method;
                    }
                }
            }

            throw new Exception($"Cannot get the contextual path '{contextualPath}' from all the operations in operation group {resource.OperationGroup.Key}");
        }

        /// <summary>
        /// Represents how a parameter of rest operation is mapped to a parameter of a container method or an expression.
        /// </summary>
        public record ContextualParameterMapping
        {
            /// <summary>
            /// The parameter name.
            /// </summary>
            public string ParameterName;
            /// <summary>
            /// if not pass-through, this is the value to pass in <see cref="RestClientMethod"/>.
            /// </summary>
            public string ValueExpression;

            public ContextualParameterMapping(string parameterName, string valueExpression)
            {
                ParameterName = parameterName;
                ValueExpression = valueExpression;
            }
        }
    }
}
