// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Concurrent;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class TenantDetection
    {
        internal static readonly string TenantName = "tenant";
        private static ConcurrentDictionary<OperationGroup, bool> _valueCache = new ConcurrentDictionary<OperationGroup, bool>();

        public static bool IsTenantResource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            bool result;
            if (_valueCache.TryGetValue(operationGroup, out result))
                return result;

            result = IsTenantOnly(operationGroup, config);
            _valueCache.TryAdd(operationGroup, result);
            return result;
        }

        public static bool IsAncestorTenant(this OperationGroup operationGroup, BuildContext context)
        {
            while (operationGroup.ParentOperationGroup(context) != null)
            {
                operationGroup = operationGroup.ParentOperationGroup(context)!;
            }

            // This does not check readme config on purpose.
            return operationGroup.ParentResourceType(context.Configuration.MgmtConfiguration) == TenantDetection.TenantName;
           //return TenantDetection.IsTenantResource(operationGroup, context.Configuration.MgmtConfiguration);
        }

        public static bool IsParentResourceTypeTenant(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            // This considers the parent configuration in readme.
            return operationGroup.ParentResourceType(config) == TenantDetection.TenantName;
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
