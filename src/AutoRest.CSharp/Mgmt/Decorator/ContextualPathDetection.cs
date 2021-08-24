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
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ContextualPathDetection
    {
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

        public static IEnumerable<NewParameterMapping> BuildContextualParameterMapping(this Resource resource, BuildContext<MgmtOutputLibrary> context)
        {
            // TODO -- add implementation
            var stack = new Stack<NewParameterMapping>();
            BuildContextualParameterMappingHierarchy(resource, resource.ContextualPath, context, stack);
            return stack;
        }

        private static void BuildContextualParameterMappingHierarchy(Resource currentResource, string currentContextualPath, BuildContext<MgmtOutputLibrary> context, Stack<NewParameterMapping> parameterMappingStack, string invocationSuffix = "")
        {
            var current = currentResource.OperationGroup;
            var parentContextualPath = GetParentContextualPath(current, context);
            // the contextual path of the parent should be a prefix of the current
            if (!currentContextualPath.StartsWith(parentContextualPath))
            {
                throw new Exception($"The contextual path of the parent is not a prefix of current operation group {current.Key}");
            }
            var suffix = currentContextualPath.Substring(parentContextualPath.Length).TrimStart('/'); // we get the difference between current and its parent
            // now we find the parameter that is defined in this segment, or do nothing if we find none
            var method = GetMethodOfContextualOperation(currentResource, currentContextualPath);
            // try to get the correct parameter
            var segments = suffix.Split("/");
            var parameterToFind = new Stack<Parameter>();
            // TODO -- reverse this loop, and direct add the result to stack, instead of using a temp here
            for (int i = 1; i < segments.Length; i += 2)
            {
                (var isReference, var parameterName) = IsReference(segments[i]);
                if (isReference)
                {
                    var parameter = method.Parameters.First(p => p.Name == parameterName!);
                    parameterToFind.Push(parameter);
                }
            }
            // adds the result to stack
        }

        private static (bool IsReference, string? ReferenceName) IsReference(string segment)
        {
            if (segment.StartsWith("{") && segment.EndsWith("}"))
            {
                return (true, segment.Trim('{', '}'));
            }
            return (false, null);
        }

        private static string GetParentContextualPath(OperationGroup current, BuildContext<MgmtOutputLibrary> context)
        {
            var parent = current.ParentOperationGroup(context);
            if (parent == null)
            {
                var parentType = current.ParentResourceType(context.Configuration.MgmtConfiguration);
                // The parentType here is guaranteed to be one of the Extensions
                return ResourceTypeBuilder.TypeToContextualPath[parentType];
            }
            return parent.ContextualPath(context.Configuration.MgmtConfiguration);
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
        public class NewParameterMapping
        {
            /// <summary>
            /// The parameter object in <see cref="RestClientMethod"/>.
            /// </summary>
            public Parameter Parameter;
            /// <summary>
            /// Should the parameter be passed through from the method in container class?
            /// </summary>
            public bool IsPassThru;
            /// <summary>
            /// if not pass-through, this is the value to pass in <see cref="RestClientMethod"/>.
            /// </summary>
            public string ValueExpression;

            public NewParameterMapping(Parameter parameter, bool isPassThru) : this(parameter, isPassThru, string.Empty)
            { }

            public NewParameterMapping(Parameter parameter, bool isPassThru, string valueExpression)
            {
                Parameter = parameter;
                IsPassThru = isPassThru;
                ValueExpression = valueExpression;
            }
        }
    }
}
