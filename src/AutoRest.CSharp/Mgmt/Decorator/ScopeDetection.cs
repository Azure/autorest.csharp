// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ScopeDetection
    {
        private const string Subscriptions = "subscriptions";
        private const string ResourceGroups = "resourceGroups";
        private const string Tenant = "tenant";
        private const string ManagementGroups = "managementGroups";
        private const string Any = "*";

        private static ConcurrentDictionary<RequestPath, ResourceTypeSegment[]?> _scopeTypesCache = new ConcurrentDictionary<RequestPath, ResourceTypeSegment[]?>();

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

        public static ResourceTypeSegment[]? GetParameterizedScopeResourceTypes(this RequestPath requestPath)
        {
            if (_scopeTypesCache.TryGetValue(requestPath, out var result))
                return result;

            result = requestPath.CalculateScopeResourceTypes();
            _scopeTypesCache.TryAdd(requestPath, result);
            return result;
        }

        private static ResourceTypeSegment[]? CalculateScopeResourceTypes(this RequestPath requestPath)
        {
            if (!requestPath.GetScopePath().IsParameterizedScope())
                return null;
            if (Configuration.MgmtConfiguration.RequestPathToScopeResourceTypes.TryGetValue(requestPath, out var resourceTypes))
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
