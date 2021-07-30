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

        // True when it has a main resource directly under /{scope}
        public static bool IsScopeResource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            if (_valueCache.TryGetValue(operationGroup, out var result))
                return result;

            result = IsScope(operationGroup, config);
            _valueCache.TryAdd(operationGroup, result);
            return result;
        }

        private static bool IsScope(OperationGroup operationGroup, MgmtConfiguration config)
        {
            return operationGroup.Operations.Any(op => op.IsParentScope());
        }

        // True when it has a main resource or sub resource with the path starting with /{scope}
        public static bool IsAncestorScope(this OperationGroup operationGroup)
        {
            return operationGroup.Operations.Any(op => op.IsAncestorScope());
        }

        // True when it's a main resource or sub resource with the path starting with /{scope}
        public static bool IsAncestorScope(this Operation operation)
        {
            return operation.Requests.FirstOrDefault()?.Protocol.Http is HttpRequest httpRequest && ScopeKeywords.Any(w => httpRequest.Path.StartsWith(w));
        }

        // True when it's a main resource with the path starting with /{scope}
        public static bool IsParentScope(this Operation operation)
        {
            if (operation.Requests.FirstOrDefault()?.Protocol.Http is HttpRequest httpRequest
                    && ScopeKeywords.Any(w => httpRequest.Path.StartsWith(w)))
            {
                var providerSegmentsList = httpRequest?.ProviderSegments();
                return providerSegmentsList?.Count > 0 && providerSegmentsList[0].TokenValue.Trim('/').Equals(operation.ResourceType());
            }
            return false;
        }
    }
}
