// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ParameterMappingBuilder
    {
        public static IEnumerable<ContextualParameterMapping> BuildContextualParameters(this RequestPath requestPath, BuildContext<MgmtOutputLibrary> context, string idVariableName = "Id")
        {
            var stack = new Stack<ContextualParameterMapping>();
            BuildContextualParameterMappingHierarchy(requestPath, context, stack, idVariableName);
            return stack;
        }

        private static void BuildContextualParameterMappingHierarchy(RequestPath current, BuildContext<MgmtOutputLibrary> context, Stack<ContextualParameterMapping> parameterMappingStack, string idVariableName = "Id", string invocationSuffix = "")
        {
            // RequestPath of tenant does not have any parameter in it (actually it does not have anything), we take this as an exit
            if (current == RequestPath.Tenant)
                return;
            var parent = current.ParentRequestPath(context);
            // Subscription and ManagementGroup are not terminal states - tenant is their parent
            if (current == RequestPath.Subscription)
            {
                // using the reference name of the last segment as the parameter name, aka, subscriptionId
                parameterMappingStack.Push(new ContextualParameterMapping(current.Last().ReferenceName, $"{idVariableName}.SubscriptionId"));
                //return;
            }
            else if (current == RequestPath.ManagementGroup)
            {
                // using the reference name of the last segment as the parameter name, aka, subscriptionId
                parameterMappingStack.Push(new ContextualParameterMapping(current.Last().ReferenceName, $"{idVariableName}{invocationSuffix}.Parent.Name", false));
                //return;
            }
            // ResourceGroup is not terminal state - Subscription is its parent
            else if (current == RequestPath.ResourceGroup)
            {
                parameterMappingStack.Push(new ContextualParameterMapping("resourceGroupName", $"{idVariableName}.ResourceGroupName"));
                //return;
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
                        var referenceName = pair[1].ReferenceName;
                        if (pair[0] == Segment.Providers) // if the key is providers and the value is a parameter
                        {
                            parameterMappingStack.Push(new ContextualParameterMapping(referenceName, $"{idVariableName}.Namespace"));
                            // do not append a new .Parent to the id
                            continue;
                        }
                        else // for all other normal keys
                        {
                            parameterMappingStack.Push(new ContextualParameterMapping(referenceName, $"{idVariableName}{invocationSuffix}.Name"));
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
            /// The parameter name.
            /// </summary>
            public string ParameterName;
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

            public ContextualParameterMapping(string parameterName, string valueExpression, bool strict = true)
            {
                ParameterName = parameterName;
                ValueExpression = valueExpression;
                Strict = strict;
            }
        }
    }
}
