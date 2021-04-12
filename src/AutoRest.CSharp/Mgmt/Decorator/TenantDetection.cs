// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Concurrent;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class TenantDetection
    {
        internal static readonly string TenantName = "tenant";
        private static ConcurrentDictionary<string, bool> _valueCache = new ConcurrentDictionary<string, bool>();

        public static bool IsTenantResource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            bool result;
            if (_valueCache.TryGetValue(operationGroup.Key, out result))
                return result;

            result = IsTenantOnly(operationGroup, config);
            _valueCache.TryAdd(operationGroup.Key, result);
            return result;
        }

        private static bool IsTenantOnly(OperationGroup operationGroup, MgmtConfiguration config)
        {
            bool foundTenant = false;
            foreach (var keyValue in operationGroup.OperationHttpMethodMapping())
            {
                foreach (var httpRequest in keyValue.Value)
                {
                    var providerSegmentsList = ((HttpRequest?)httpRequest?.Protocol?.Http)?.ProviderSegments();
                    for (int i = 0; i < providerSegmentsList?.Count; i++)
                    {
                        var segment = providerSegmentsList[i];
                        if (segment.TokenValue.Trim('/').Equals(operationGroup.ResourceType(config)) && segment.IsFullProvider)
                        {
                            foundTenant = foundTenant || segment.NoPredecessor;
                            if (!segment.NoPredecessor)
                            {
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            return foundTenant;
        }
    }
}
