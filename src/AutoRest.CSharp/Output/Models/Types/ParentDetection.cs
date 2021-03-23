// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License
using System;
using System.Collections.Generic;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Output.Models.Type.Decorate
{
    internal static class ParentDetection
    {
        public static string GetParent(OperationGroup operationGroup)
        {
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
            for (int i = providerSegments.Count - 1; i > -1; i--)
            {
                if (providerSegments[i].IsFullProvider)
                {
                    return providerSegments[i];
                }
            }
            return null;
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
    }
}
