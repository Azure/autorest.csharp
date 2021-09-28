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
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ParameterMappingBuilder
    {
        /// <summary>
        /// Builds the parameter mapping for contextual paths. The parameters in the contextual path will be treated as "known information"
        /// when writing other operations in the same resource or resource container class and be passed into the corresponding RestOperation
        /// method using their "value expression"s
        /// </summary>
        /// <param name="requestPath">The contextual path, which is usually the path creating a resource</param>
        /// <param name="context">The <see cref="BuildContext"/></param>
        /// <param name="idVariableName">The variable name of the Id variable</param>
        /// <returns></returns>
        public static IEnumerable<ContextualParameterMapping> BuildContextualParameters(this RequestPath requestPath, BuildContext<MgmtOutputLibrary> context, string idVariableName = "Id")
        {
            var stack = new Stack<ContextualParameterMapping>();
            BuildContextualParameterMappingHierarchy(requestPath, context, stack, idVariableName);
            return stack;
        }

        private static void BuildContextualParameterMappingHierarchy(RequestPath current, BuildContext<MgmtOutputLibrary> context, Stack<ContextualParameterMapping> parameterMappingStack, string idVariableName = "Id", string invocationSuffix = "")
        {
            // TODO -- we are still missing the "scope" parameters
            // RequestPath of tenant does not have any parameter in it (actually it does not have anything), we take this as an exit
            if (current == RequestPath.Tenant)
                return;
            var parent = current.ParentRequestPath(context);
            // Subscription and ManagementGroup are not terminal states - tenant is their parent
            if (current == RequestPath.Subscription)
            {
                // using the reference name of the last segment as the parameter name, aka, subscriptionId
                parameterMappingStack.Push(new ContextualParameterMapping(current.Last().Reference, $"{idVariableName}.SubscriptionId"));
            }
            else if (current == RequestPath.ManagementGroup)
            {
                // using the reference name of the last segment as the parameter name, aka, groupId
                parameterMappingStack.Push(new ContextualParameterMapping(current.Last().Reference, $"{idVariableName}{invocationSuffix}.Parent.Name", false));
            }
            // ResourceGroup is not terminal state - Subscription is its parent
            else if (current == RequestPath.ResourceGroup)
            {
                // using the reference name of the last segment as the parameter name, aka, resourceGroupName
                parameterMappingStack.Push(new ContextualParameterMapping(current.Last().Reference, $"{idVariableName}.ResourceGroupName"));
            }
            // this branch is for every other cases - all the request path that corresponds to a resource in this swagger
            else
            {
                // get the diff between current and parent
                var diffSegments = parent.TrimParentFrom(current).ToList();
                // we need the segments here to be an even number
                if (diffSegments.Count() % 2 != 0)
                    throw new InvalidOperationException($"Cannot calculate contextual parameters between {current} and {parent}, we get odd number segments in the difference");
                // group the diffSegments in pairs, which is a IEnumerable of List<Segment> with two elements in reversed order
                var segmentPairs = diffSegments.Select((segment, index) => new { Index = index, Value = segment })
                    .GroupBy(pair => pair.Index / 2)
                    .Select(group => group.Select(v => v.Value).ToList())
                    .Reverse();
                // from the tail, check these segments in pairs.
                foreach (var pair in segmentPairs)
                {
                    // NOTE: we grouped the segments in pairs, therefore here pair[0] will always be the key, `resourceGroups` for instance.
                    // The key can also be variable in some scenarios
                    // pair[1] will always be the value, which is Id.Name or Id.Namespace (if its key is providers)
                    // TODO -- also consider the key is variable scenario
                    if (pair[0].IsReference)
                        throw new NotImplementedException($"Key is variable scenario is not supported yet. RequestPath: {current} and key {pair[0]}");
                    if (pair[1].IsReference)
                    {
                        var reference = pair[1].Reference;
                        if (pair[0] == Segment.Providers) // if the key is providers and the value is a parameter
                        {
                            parameterMappingStack.Push(new ContextualParameterMapping(reference, $"{idVariableName}.Namespace"));
                            // do not append a new .Parent to the id
                            continue;
                        }
                        else // for all other normal keys
                        {
                            parameterMappingStack.Push(new ContextualParameterMapping(reference, $"{idVariableName}{invocationSuffix}.Name"));
                            invocationSuffix += ".Parent";
                            continue;
                        }
                    }
                    else // in this branch pair[1] is a constant
                    {
                        if (pair[0] != Segment.Providers)
                        {
                            // if the key is not providers, we need to skip this level and increment the parent hierarchy
                            invocationSuffix += ".Parent";
                        }
                    }
                }
            }
            // recursively get the parameters of its parent
            BuildContextualParameterMappingHierarchy(parent, context, parameterMappingStack, idVariableName, invocationSuffix);
        }

        /// <summary>
        /// Represents how a parameter of rest operation is mapped to a parameter of a container method or an expression.
        /// </summary>
        public record ContextualParameterMapping
        {
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
            public string ValueExpression;
            /// <summary>
            /// Mark if the parameter matching will be strict.
            /// If true, we will match both the type and parameter name
            /// If false, we will only match the type
            /// </summary>
            public bool Strict;

            public ContextualParameterMapping(Reference reference, string valueExpression, bool strict = true) : this(reference.Name, reference.Type, valueExpression, strict)
            {
            }

            public ContextualParameterMapping(string parameterName, CSharpType parameterType, string valueExpression, bool strict = true)
            {
                ParameterName = parameterName;
                ParameterType = parameterType;
                ValueExpression = valueExpression;
                Strict = strict;
            }

            /// <summary>
            /// Returns true if the given <see cref="Parameter"/> can match this <see cref="ContextualParameterMapping"/>
            /// </summary>
            /// <param name="parameter"></param>
            /// <returns></returns>
            public bool MatchesParameter(Parameter parameter)
            {
                if (Strict)
                    return ParameterName == parameter.Name && ParameterType.Equals(parameter.Type);

                // if not strict, we only check the type ignoring the name of the parameter
                return ParameterType.Equals(parameter.Type);
            }
        }

        public static IEnumerable<ParameterMapping> BuildParameterMapping(this Operation operation, IEnumerable<ContextualParameterMapping> contextualParameterMappings, BuildContext<MgmtOutputLibrary> context)
        {
            return context.Library.RestClientMethods[operation].BuildParameterMapping(contextualParameterMappings);
        }

        public static IEnumerable<ParameterMapping> BuildParameterMapping(this RestClientMethod method, IEnumerable<ContextualParameterMapping> contextualParameterMappings)
        {
            var contextualParameterMappingCache = new List<ContextualParameterMapping>(contextualParameterMappings);
            foreach (var parameter in method.Parameters)
            {
                // Update parameter type if the method is a `ById` method
                // TODO -- we might no longer needs this since we are not generating "ById" methods
                var p = UpdateParameterTypeOfByIdMethod(method, parameter);
                // find this parameter name in the contextual parameter mappings
                // if there is one, this parameter should use the same value expression
                // if there is none of this, this parameter should be a pass through parameter
                var mapping = FindContextualParameterForMethod(p, contextualParameterMappingCache, method);
                if (mapping == null)
                {
                    yield return new ParameterMapping(p, true, "");
                }
                else
                {
                    yield return new ParameterMapping(p, false, mapping.ValueExpression);
                }
            }
        }

        // TODO -- this needs refinement
        private static Parameter UpdateParameterTypeOfByIdMethod(RestClientMethod method, Parameter parameter)
        {
            if (method.IsByIdMethod() && parameter.Name.Equals(method.Parameters[0].Name, StringComparison.InvariantCultureIgnoreCase))
            {
                return parameter with { Type = typeof(ResourceIdentifier) };
            }

            return parameter;
        }

        /// <summary>
        /// Represents how a parameter of rest operation is mapped to a parameter of a container method or an expression.
        /// </summary>
        public record ParameterMapping
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

            public ParameterMapping(Parameter parameter, bool isPassThru, string valueExpression)
            {
                Parameter = parameter;
                IsPassThru = isPassThru;
                ValueExpression = valueExpression;
            }
        }

        private static ContextualParameterMapping? FindContextualParameterForMethod(Parameter pathParameter,
            List<ContextualParameterMapping> contextualParameterMappings, RestClientMethod method)
        {
            // skip non-path parameters
            if (!pathParameter.IsInPathOf(method))
                return null;
            var result = contextualParameterMappings.FirstOrDefault(mapping => mapping.MatchesParameter(pathParameter));
            // if we match one parameter, we need to remove the matching ContextualParameterMapping from the list to avoid multiple matching
            if (result != null)
                contextualParameterMappings.Remove(result);
            return result;
        }

        public static IReadOnlyList<Parameter> GetPassThroughParameters(this IEnumerable<ParameterMapping> parameterMappings)
        {
            return parameterMappings.Where(p => p.IsPassThru).Select(p => p.Parameter).ToList();
        }
    }
}
