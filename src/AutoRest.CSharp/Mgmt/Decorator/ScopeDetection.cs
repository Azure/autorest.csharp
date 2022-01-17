// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ScopeDetection
    {
        public const string Subscriptions = "subscriptions";
        public const string ResourceGroups = "resourceGroups";
        public const string Tenant = "tenant";
        public const string ManagementGroups = "managementGroups";
        public const string Any = "*";
        private const string _managementGroupScopePrefix = "/providers/Microsoft.Management/managementGroups";
        private const string _resourceGroupScopePrefix = "/subscriptions/{subscriptionId}/resourceGroups";
        private const string _subscriptionScopePrefix = "/subscriptions";
        private const string _tenantScopePrefix = "/tenants";

        private static ConcurrentDictionary<RequestPath, RequestPath> _scopePathCache = new ConcurrentDictionary<RequestPath, RequestPath>();
        private static ConcurrentDictionary<RequestPath, ResourceTypeSegment[]?> _scopeTypesCache = new ConcurrentDictionary<RequestPath, ResourceTypeSegment[]?>();

        public static RequestPath GetScopePath(this RequestPath requestPath)
        {
            if (_scopePathCache.TryGetValue(requestPath, out var result))
                return result;

            result = CalculateScopePath(requestPath);
            _scopePathCache.TryAdd(requestPath, result);
            return result;
        }

        /// <summary>
        /// Returns true if this request path is a parameterized scope, like the "/{scope}" in "/{scope}/providers/M.C/virtualMachines/{vmName}"
        /// </summary>
        /// <param name="scopePath"></param>
        /// <returns></returns>
        public static bool IsParameterizedScope(this RequestPath scopePath)
        {
            // if a request is an implicit scope, it must only have one segment
            if (scopePath.Count != 1)
                return false;
            // now the path only has one segment
            var first = scopePath.First();
            // then we need to ensure the corresponding parameter enables `x-ms-skip-url-encoding`
            if (first.IsConstant)
                return false; // actually this cannot happen
            // now the first segment is a reference
            // we ensure this parameter enables x-ms-skip-url-encoding, aka Escape is false
            return first.SkipUrlEncoding;
        }

        private static RequestPath CalculateScopePath(RequestPath requestPath)
        {
            var indexOfProvider = requestPath.ToList().LastIndexOf(Segment.Providers);
            // if there is no providers segment, myself should be a scope request path. Just return myself
            if (indexOfProvider >= 0)
            {
                if (indexOfProvider == 0 && requestPath.SerializedPath.StartsWith(_managementGroupScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                    return RequestPath.ManagementGroup;
                return new RequestPath(requestPath.Take(indexOfProvider));
            }
            if (requestPath.SerializedPath.StartsWith(_resourceGroupScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                return RequestPath.ResourceGroup;
            if (requestPath.SerializedPath.StartsWith(_subscriptionScopePrefix, StringComparison.InvariantCultureIgnoreCase))
                return RequestPath.Subscription;
            if (requestPath.SerializedPath.Equals(_tenantScopePrefix))
                return RequestPath.Tenant;
            return requestPath;
        }

        public static ResourceTypeSegment[]? GetParameterizedScopeResourceTypes(this RequestPath requestPath, MgmtConfiguration config)
        {
            if (_scopeTypesCache.TryGetValue(requestPath, out var result))
                return result;

            result = requestPath.CalculateScopeResourceTypes(config);
            _scopeTypesCache.TryAdd(requestPath, result);
            return result;
        }

        private static ResourceTypeSegment[]? CalculateScopeResourceTypes(this RequestPath requestPath, MgmtConfiguration config)
        {
            if (!requestPath.GetScopePath().IsParameterizedScope())
                return null;
            if (config.RequestPathToScopeResourceTypes.TryGetValue(requestPath, out var resourceTypes))
                return resourceTypes.Select(v => BuildResourceType(v)).ToArray();
            // otherwise we just assume this is scope and this scope could be anything
            return new[] { ResourceTypeSegment.Subscription, ResourceTypeSegment.ResourceGroup, ResourceTypeSegment.ManagementGroup, ResourceTypeSegment.Tenant, ResourceTypeSegment.Any };
        }

        private static ResourceTypeSegment BuildResourceType(string resourceType) => resourceType switch
        {
            Subscriptions => ResourceTypeSegment.Subscription,
            ResourceGroups => ResourceTypeSegment.ResourceGroup,
            ManagementGroups => ResourceTypeSegment.ManagementGroup,
            Tenant => ResourceTypeSegment.Tenant,
            Any => ResourceTypeSegment.Any,
            _ => new ResourceTypeSegment(resourceType)
        };
    }
}
