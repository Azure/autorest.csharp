// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ResourceTypeBuilder
    {
        private static ConcurrentDictionary<OperationGroup, string> _valueCache = new ConcurrentDictionary<OperationGroup, string>();

        private static ConcurrentDictionary<string, string> _operationPathValueCache = new ConcurrentDictionary<string, string>();

        private static ConcurrentDictionary<RequestPath, ResourceType> _requestPathToResourceTypeCache = new ConcurrentDictionary<RequestPath, ResourceType>();

        static ResourceTypeBuilder()
        {
            _requestPathToResourceTypeCache.TryAdd(RequestPath.Subscription, Models.ResourceType.Subscription);
            _requestPathToResourceTypeCache.TryAdd(RequestPath.ResourceGroup, Models.ResourceType.ResourceGroup);
            _requestPathToResourceTypeCache.TryAdd(RequestPath.Tenant, Models.ResourceType.Tenant);
            _requestPathToResourceTypeCache.TryAdd(RequestPath.ManagementGroup, Models.ResourceType.ManagementGroup);
        }

        public static ResourceType GetResourceType(this RequestPath requestPath, MgmtConfiguration config)
        {
            if (_requestPathToResourceTypeCache.TryGetValue(requestPath, out var resourceType))
                return resourceType;

            resourceType = CalculateResourceType(requestPath, config);
            _requestPathToResourceTypeCache.TryAdd(requestPath, resourceType);
            return resourceType;
        }

        private static ResourceType CalculateResourceType(RequestPath requestPath, MgmtConfiguration config)
        {
            if (config.RequestPathToResourceType.TryGetValue(requestPath.SerializedPath, out var resourceType))
                return new ResourceType(resourceType);

            // we cannot directly return the new ResourceType here, the requestPath here can be a parameterized scope, which does not have a resource type.
            if (requestPath.IsParameterizedScope())
                return ResourceType.Null;
            return new ResourceType(requestPath);
        }
    }
}
