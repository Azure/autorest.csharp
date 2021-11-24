// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ParameterMappingBuilder
    {
        /// <summary>
        /// Builds the parameter mapping for contextual paths. The parameters in the contextual path will be treated as "known information"
        /// when writing other operations in the same resource or resource collection class and be passed into the corresponding RestOperation
        /// method using their "value expression"s
        /// </summary>
        /// <param name="requestPath">The contextual path, which is usually the path creating a resource</param>
        /// <param name="context">The <see cref="BuildContext"/></param>
        /// <param name="idVariableName">The variable name of the Id variable</param>
        /// <returns></returns>
        public static IEnumerable<ContextualParameterMapping> BuildContextualParameters(this RequestPath requestPath, BuildContext<MgmtOutputLibrary> context, string idVariableName)
        {
            var stack = new Stack<ContextualParameterMapping>();
            BuildContextualParameterMappingHierarchy(requestPath, context, stack, idVariableName);
            return stack;
        }

        private static void BuildContextualParameterMappingHierarchy(RequestPath current, BuildContext<MgmtOutputLibrary> context, Stack<ContextualParameterMapping> parameterMappingStack, string idVariableName = "Id", string invocationSuffix = "")
        {
            // Check if the current path is a scope parameter
            if (current.IsParameterizedScope())
            {
                // in this case, we should only have one segment in this current path
                parameterMappingStack.Push(new ContextualParameterMapping(string.Empty, current.Last(), $"{idVariableName}{invocationSuffix}"));
                return;
            }
            // RequestPath of tenant does not have any parameter in it (actually it does not have anything), we take this as an exit
            if (current == RequestPath.Tenant)
                return;
            var parent = current.ParentRequestPath(context);
            // Subscription and ManagementGroup are not terminal states - tenant is their parent
            if (current == RequestPath.Subscription)
            {
                // using the reference name of the last segment as the parameter name, aka, subscriptionId
                parameterMappingStack.Push(new ContextualParameterMapping(current.SkipLast(1).Last().ConstantValue, current.Last(), $"{idVariableName}.SubscriptionId"));
            }
            else if (current == RequestPath.ManagementGroup)
            {
                // using the reference name of the last segment as the parameter name, aka, groupId
                parameterMappingStack.Push(new ContextualParameterMapping(current.SkipLast(1).Last().ConstantValue, current.Last(), $"{idVariableName}{invocationSuffix}.Name"));
            }
            // ResourceGroup is not terminal state - Subscription is its parent
            else if (current == RequestPath.ResourceGroup)
            {
                // using the reference name of the last segment as the parameter name, aka, resourceGroupName
                parameterMappingStack.Push(new ContextualParameterMapping(current.SkipLast(1).Last().ConstantValue, current.Last(), $"{idVariableName}.ResourceGroupName"));
            }
            // this branch is for every other cases - all the request path that corresponds to a resource in this swagger
            else
            {
                // get the diff between current and parent
                var diffPath = parent.TrimAncestorFrom(current);
                // get the segment in pairs
                var segmentPairs = SplitDiffIntoPairs(diffPath).ToList();
                var indexOfProvidersPair = segmentPairs.FindIndex(pair => pair[0] == Segment.Providers);
                // from the tail, check these segments in pairs
                for (int i = 0; i < segmentPairs.Count; i++)
                {
                    var pair = segmentPairs[i];
                    if (pair.Count == 2)
                    {
                        // we have a pair of segment, therefore here pair[0] will always be the key, `resourceGroups` for instance.
                        // The key can also be variable in some scenarios
                        // pair[1] will always be the value, which is Id.Name or Id.Namespace (if its key is providers)
                        var keySegment = pair[0];
                        var valueSegment = pair[1];
                        var appendParent = false;
                        if (valueSegment.IsReference)
                        {
                            if (keySegment == Segment.Providers) // if the key is providers and the value is a parameter
                            {
                                parameterMappingStack.Push(new ContextualParameterMapping(keySegment.ConstantValue, valueSegment, $"{idVariableName}.ResourceType.Namespace"));
                                // do not append a new .Parent to the id
                            }
                            else // for all other normal keys
                            {
                                parameterMappingStack.Push(new ContextualParameterMapping(keySegment.IsConstant ? keySegment.ConstantValue : string.Empty, valueSegment, $"{idVariableName}{invocationSuffix}.Name"));
                                appendParent = true;
                            }
                        }
                        else // in this branch pair[1] is a constant
                        {
                            if (keySegment != Segment.Providers)
                            {
                                // if the key is not providers, we need to skip this level and increment the parent hierarchy
                                appendParent = true;
                            }
                        }
                        if (keySegment.IsReference)
                        {
                            parameterMappingStack.Push(new ContextualParameterMapping(string.Empty, keySegment, $"{idVariableName}{invocationSuffix}.ResourceType.Types.Last()", new[] { "System.Linq" }));
                            appendParent = true;
                        }
                        // add .Parent suffix
                        if (appendParent)
                            invocationSuffix += ".Parent";
                    }
                    else
                    {
                        if (pair[0].IsReference && pair[0].SkipUrlEncoding)
                        {
                            // we never have a case that we need to get the substring that have a gap after the provider-namespace key pair, throw an exception when it happens
                            if (segmentPairs.Count - indexOfProvidersPair != 1)
                                throw new NotImplementedException("We have a gap between the substring to get and the provider-namespace key pair. We need to update SubstringAfterProviderNamespace function to make sure it can accept an index to adopt this");
                            // if we only have one segment in this group, it should always be a reference
                            parameterMappingStack.Push(new ContextualParameterMapping(string.Empty, pair[0], $"{idVariableName}{invocationSuffix}.SubstringAfterProviderNamespace()"));
                        }
                    }
                }
            }
            // recursively get the parameters of its parent
            BuildContextualParameterMappingHierarchy(parent, context, parameterMappingStack, idVariableName, invocationSuffix);
        }

        /// <summary>
        /// This bases on the fact that the contextual path should always be a resource identifier in its value,
        /// therefore we should always have the ability to split the contextual path into pairs.
        /// But the request path has variables in it, therefore we need to split the diff into pairs considering that some segment might have the x-ms-skip-url-encoding = true,
        /// which means it can be not only a single variable, but also at least a subset of a resource ID (virtualMachines/myVM for instance)
        /// If we have two segments with all x-ms-skip-url-encoding = false, they should be able to go into pairs
        /// A segment with x-ms-skip-url-encoding = true has the ability to go alone, since it could have multiple segments in its value.
        /// How many segment could go solo? Say we have a total number of X segments with x-ms-skip-url-encoding = true
        /// and N is the total number of the segments.
        /// If N is an odd number, we must have an odd number of segments that go solo.
        /// If N is an even number, we must have an even number of segments that go solo. (zero is an even number)
        /// </summary>
        /// <param name="diff"></param>
        /// <returns></returns>
        private static IEnumerable<List<Segment>> SplitDiffIntoPairs(RequestPath diff)
        {
            // if N is odd, we allow 1 segment to go alone. if N is even, we allow 0 segments to go alone
            int maximumNumberOfAloneSegments = diff.Count % 2 == 0 ? 0 : 1;
            var result = new Stack<List<Segment>>();
            var indices = new List<int>();
            for (int i = 0; i < diff.Count; i++)
            {
                var current = diff[i];
                if (current.IsConstant || !current.SkipUrlEncoding || maximumNumberOfAloneSegments == 0)
                {
                    // key is constant, or key is a reference but it is not enabling `x-ms-skip-url-encoding`, we could include a pair
                    if (i + 1 < diff.Count)
                    {
                        result.Push(new List<Segment> { diff[i], diff[i + 1] });
                        i++;
                    }
                    else
                    {
                        result.Push(new List<Segment> { diff[i] });
                    }
                    continue;
                }
                if (current.SkipUrlEncoding && maximumNumberOfAloneSegments > 0)
                {
                    result.Push(new List<Segment> { diff[i] });
                    maximumNumberOfAloneSegments--;
                }
            }

            return result;
        }

        public static FormattableString GetValueExpression(CSharpType type, FormattableString rawExpression)
        {
            if (type.IsStringLike())
                return rawExpression;

            if (!type.IsFrameworkType)
            {
                if (type.Implementation is EnumType enumType && !enumType.IsExtendable)
                {
                    return $"{rawExpression}.To{enumType.Declaration.Name}()";
                }
                throw new System.InvalidOperationException($"Type {type} is not supported to construct parameter mapping");
            }
            return $"{type.FrameworkType}.Parse({rawExpression})";
        }

        /// <summary>
        /// Represents how a parameter of rest operation is mapped to a parameter of a collection method or an expression.
        /// </summary>
        public record ContextualParameterMapping
        {
            public string Key;
            /// <summary>
            /// The parameter name
            /// </summary>
            public string ParameterName;
            /// <summary>
            /// The parameter type
            /// </summary>
            public CSharpType ParameterType;
            /// <summary>
            /// This is the value expression to pass in a method
            /// </summary>
            public FormattableString ValueExpression;
            /// <summary>
            /// The using statements in the ValueExpression
            /// </summary>
            public IEnumerable<string> Usings;

            public ContextualParameterMapping(string key, Segment value, FormattableString valueExpression, IEnumerable<string>? usings = default)
                : this(key, value.Reference.Name, value.Reference.Type, valueExpression, usings ?? Enumerable.Empty<string>())
            {
            }

            internal ContextualParameterMapping(string key, string parameterName, CSharpType parameterType, FormattableString valueExpression, IEnumerable<string> usings)
            {
                Key = key;
                ParameterName = parameterName;
                ParameterType = parameterType;
                ValueExpression = GetValueExpression(parameterType, valueExpression);
                Usings = usings;
            }

            /// <summary>
            /// Returns true if the given <see cref="Parameter"/> can match this <see cref="ContextualParameterMapping"/>
            /// </summary>
            /// <param name="parameter"></param>
            /// <returns></returns>
            public bool MatchesParameter(string key, Parameter parameter)
            {
                return key.Equals(Key, StringComparison.InvariantCultureIgnoreCase) && ParameterType.Equals(parameter.Type);
            }
        }

        public static IEnumerable<ParameterMapping> BuildParameterMapping(this MgmtRestOperation operation, IEnumerable<ContextualParameterMapping> contextualParameterMappings)
        {
            var method = operation.Method;
            var contextualParameterMappingCache = new List<ContextualParameterMapping>(contextualParameterMappings);
            foreach (var parameter in method.Parameters)
            {
                // find this parameter name in the contextual parameter mappings
                // if there is one, this parameter should use the same value expression
                // if there is none of this, this parameter should be a pass through parameter
                var mapping = FindContextualParameterForMethod(parameter, operation.RequestPath, contextualParameterMappingCache, method);
                // Update parameter type if the method is a `ById` method
                var p = UpdateParameterTypeOfByIdMethod(operation.RequestPath, parameter);
                if (mapping == null)
                {
                    yield return new ParameterMapping(p, true, $"", Enumerable.Empty<string>());
                }
                else
                {
                    yield return new ParameterMapping(p, false, mapping.ValueExpression, mapping.Usings);
                }
            }
        }

        private static Parameter UpdateParameterTypeOfByIdMethod(RequestPath requestPath, Parameter parameter)
        {
            if (requestPath.IsById)
            {
                var reference = requestPath.First().Reference;
                if (parameter.Name.Equals(reference.Name, StringComparison.InvariantCultureIgnoreCase) && parameter.Type.EqualsByName(reference.Type))
                {
                    return parameter with { Type = typeof(Azure.ResourceManager.ResourceIdentifier) };
                }
            }

            return parameter;
        }

        /// <summary>
        /// Represents how a parameter of rest operation is mapped to a parameter of a collection method or an expression.
        /// </summary>
        public record ParameterMapping
        {
            /// <summary>
            /// The parameter object in <see cref="RestClientMethod"/>.
            /// </summary>
            public Parameter Parameter;
            /// <summary>
            /// Should the parameter be passed through from the method in collection class?
            /// </summary>
            public bool IsPassThru;
            /// <summary>
            /// if not pass-through, this is the value to pass in <see cref="RestClientMethod"/>.
            /// </summary>
            public FormattableString ValueExpression;
            /// <summary>
            /// the using statements used in the ValueExpression
            /// </summary>
            public IEnumerable<string> Usings;

            public ParameterMapping(Parameter parameter, bool isPassThru, FormattableString valueExpression, IEnumerable<string> usings)
            {
                Parameter = parameter;
                IsPassThru = isPassThru;
                ValueExpression = valueExpression;
                Usings = usings;
            }
        }

        private static ContextualParameterMapping? FindContextualParameterForMethod(Parameter pathParameter, RequestPath requestPath,
            List<ContextualParameterMapping> contextualParameterMappings, RestClientMethod method)
        {
            // skip non-path parameters
            if (!pathParameter.IsInPathOf(method))
                return null;
            var result = contextualParameterMappings.FirstOrDefault(mapping => mapping.MatchesParameter(FindKeyOfParameter(pathParameter, requestPath), pathParameter));
            // if we match one parameter, we need to remove the matching ContextualParameterMapping from the list to avoid multiple matching
            if (result != null)
                contextualParameterMappings.Remove(result);
            return result;
        }

        private static string FindKeyOfParameter(Parameter pathParameter, RequestPath requestPath)
        {
            var segments = requestPath.ToList();
            int index = segments.FindIndex(segment => segment.IsReference && segment.ReferenceName == pathParameter.Name && segment.Reference.Type.Equals(pathParameter.Type));
            if (index < 0)
                throw new InvalidOperationException($"Cannot find the key corresponding to parameter {pathParameter.Name} in path {requestPath}");

            if (index == 0)
                return string.Empty;

            var keySegment = segments[index - 1];
            return keySegment.IsConstant ? keySegment.ConstantValue : string.Empty;
        }

        public static IReadOnlyList<Parameter> GetPassThroughParameters(this IEnumerable<ParameterMapping> parameterMappings)
        {
            return parameterMappings.Where(p => p.IsPassThru).Select(p => p.Parameter).ToList();
        }
    }
}
