// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class TenantDetection
    {
        internal static readonly string TenantName = "tenant";
        private static ConcurrentDictionary<OperationGroup, bool> _valueCache = new ConcurrentDictionary<OperationGroup, bool>();

        // True when it's a main resource directly under tenant.
        // False for extension/scope main resource whose parent is set to tenant in readme.
        public static bool IsTenantResource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            bool result;
            if (_valueCache.TryGetValue(operationGroup, out result))
                return result;

            result = IsTenantOnly(operationGroup, config);
            _valueCache.TryAdd(operationGroup, result);
            return result;
        }

        // True when it's a main resource or sub resource under tenant.
        // False for extension/scope resource whose parent/ancestor is set to tenant in readme.
        public static bool IsAncestorTenant(this OperationGroup operationGroup, BuildContext context)
        {
            while (operationGroup.ParentOperationGroup(context) != null)
            {
                operationGroup = operationGroup.ParentOperationGroup(context)!;
            }
            // This does not check readme config.
            return TenantDetection.IsTenantResource(operationGroup, context.Configuration.MgmtConfiguration);
        }

        // True when it's a main resource directly under tenant or extension/scope main resource whose parent is set to tenant in readme.
        public static bool IsParentResourceTypeTenant(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            return operationGroup.ParentResourceType(config) == TenantDetection.TenantName;
        }

        // True when it's a main resource or sub resource under tenant or extension/scope resource whose parent/ancestor is set to tenant in readme.
        public static bool IsAncestorResourceTypeTenant(this OperationGroup operationGroup, BuildContext context)
        {
            while (operationGroup.ParentOperationGroup(context) != null)
            {
                operationGroup = operationGroup.ParentOperationGroup(context)!;
            }
            // This checks the parent configuration in readme.
            return operationGroup.IsParentResourceTypeTenant(context.Configuration.MgmtConfiguration);
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

        public static bool IsParentTenant(this Operation operation)
        {
            if (!(operation.Requests.FirstOrDefault().Protocol.Http is HttpRequest httpRequest))
            {
                throw new ArgumentException($"The operation does not have an HttpRequest.");
            }
            var path = httpRequest.Path;
            bool foundTenant = false;

            var providerSegmentsList = httpRequest.ProviderSegments();
            for (int i = 0; i < providerSegmentsList?.Count; i++)
            {
                var segment = providerSegmentsList[i];
                if (segment.TokenValue.Trim('/').Equals(operation.ResourceType()) && segment.IsFullProvider)
                {
                    foundTenant = foundTenant || segment.NoPredecessor;
                    if (!segment.NoPredecessor)
                    {
                        return false;
                    }
                    break;
                }
            }

            return foundTenant;
        }
    }
}
