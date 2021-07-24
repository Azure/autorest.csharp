// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Concurrent;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ScopeDetection
    {
        private static string[] ScopeKeywords = { "/{scope}"};

        private static ConcurrentDictionary<OperationGroup, bool> _valueCache = new ConcurrentDictionary<OperationGroup, bool>();

        public static bool IsScopeResource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            if (_valueCache.TryGetValue(operationGroup, out var result))
                return result;

            result = IsScope(operationGroup, config);
            _valueCache.TryAdd(operationGroup, result);
            return result;
        }

        // True when it's a main resource directly under /{scope}
        private static bool IsScope(OperationGroup operationGroup, MgmtConfiguration config)
        {
            foreach (var operation in operationGroup.Operations)
            {
                // Check to see if any operation path starts with Scope keywords
                if (operation.Requests.FirstOrDefault()?.Protocol.Http is HttpRequest httpRequest
                    && ScopeKeywords.Any(w => httpRequest.Path.StartsWith(w)))
                {
                    var providerSegmentsList = httpRequest?.ProviderSegments();
                    // Check if it's a main resource
                    return providerSegmentsList?.Count > 0 && providerSegmentsList[0].TokenValue.Trim('/').Equals(operationGroup.ResourceType(config));
                }
            }
            return false;
        }

        // True when it's a main resource or subresource that has paths starting with /{scope}
        public static bool IsAncestorScope(this OperationGroup operationGroup)
        {
            foreach (var operation in operationGroup.Operations)
            {
                // Check to see if any operation path starts with Scope keywords
                if (operation.Requests.FirstOrDefault()?.Protocol.Http is HttpRequest httpRequest
                    && ScopeKeywords.Any(w => httpRequest.Path.StartsWith(w)))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsScope(this RestClientMethod method)
        {
            return method.Operation.Requests.FirstOrDefault()?.Protocol.Http is HttpRequest httpRequest && ScopeKeywords.Any(w => httpRequest.Path.StartsWith(w));
        }
    }
}
