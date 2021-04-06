// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;

#nullable enable

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ParentDetection
    {
        public static string GetParent(OperationGroup operationGroup)
        {
            if (operationGroup.IsTenantResource)
            {
                return TenantDetection.TenantName;
            }
            if (operationGroup.IsExtensionResource)
            {
                throw new ArgumentException($"Could not set parent for operations group {operationGroup.Key}. This an extensions resource, please add to readme.md");
            }
            var method = GetBestMethod(operationGroup.OperationHttpMethodMapping);
            if (method == null)
            {
                throw new ArgumentException($"Could not set parent for operations group {operationGroup.Key}. Please add to readme.md");
            }

            var fullProvider = GetFullProvider(method.ProviderSegments);
            if (fullProvider == null)
            {
                throw new ArgumentException($"Could not set parent for operations group {operationGroup.Key}. Please add to readme.md");
            }
            var canidateParent = ParseMethodForParent(fullProvider, method.Path, operationGroup.ResourceType);
            if (canidateParent == string.Empty)
            {
                throw new ArgumentException($"Could not set parent for operations group {operationGroup.Key}. Please add to readme.md");
            }
            return canidateParent;
        }

        public static HttpRequest? GetBestMethod(Dictionary<HttpMethod, List<ServiceRequest>> operations)
        {
            List<ServiceRequest>? requests;

            if (operations.TryGetValue(HttpMethod.Put, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            if (operations.TryGetValue(HttpMethod.Delete, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            if (operations.TryGetValue(HttpMethod.Patch, out requests))
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            if (operations.TryGetValue(HttpMethod.Get, out requests)) // optimized which get to return here
            {
                return (HttpRequest?)requests[0].Protocol?.Http;
            }
            return null;
        }

        private static ProviderSegment? GetFullProvider(List<ProviderSegment> providerSegments)
        {
            return providerSegments.Last().IsFullProvider ? providerSegments.Last() : null;
        }

        private static string ParseMethodForParent(ProviderSegment fullProvider, string path, string resourceType)
        {
            //case 1:
            // Microsoft.Network/virtualNetworks/ == lastFullProvider
            // resourceType = Microsoft.Network/virtualNetworks
            //
            if (fullProvider.TokenValue.Trim('/').Equals(resourceType))
            {
                var lastSlash = path.LastIndexOf('/', fullProvider.IndexFoundAt - 1); //ok because tenant only resources should never get here.
                var lastClosedBrace = path.LastIndexOf('}', lastSlash);
                if (path[lastSlash + 1] != '{')
                {
                    return string.Empty;
                }
                return lastClosedBrace > -1 ? path.Substring(lastClosedBrace + 1, lastSlash - lastClosedBrace).Trim('/') : path.Substring(lastClosedBrace + 1, lastSlash).Trim('/');

            }
            //case 2:
            // Microsoft.Network/virtualNetworks/ == lastFullProvider
            // resourceType = Microsoft.Network/virtualNetwork/subnets
            // expected path to be: Microsoft.Network/virtualNetworks/{}/constant/{}/constant/.... (verfied in construction of type provider)
            //
            return resourceType.StartsWith(fullProvider.TokenValue) ? resourceType.Substring(0, resourceType.LastIndexOf('/')) : string.Empty;
        }

        public static void VerfiyParents(System.Collections.Generic.ICollection<OperationGroup> operationGroups, HashSet<string> ResourceTypes)
        {
            foreach (var operationsGroup in operationGroups)
            {
                if (operationsGroup.Parent != null && !ResourceTypes.Contains(operationsGroup.Parent))
                {
                    throw new ArgumentException($"Could not set parent for operations group {operationsGroup.Key} with parent {operationsGroup.Parent}. key Please add to readme.md");
                }
            }
        }
    }
}
