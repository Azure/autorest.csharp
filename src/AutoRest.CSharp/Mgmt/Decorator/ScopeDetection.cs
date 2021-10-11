// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

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

        private static ConcurrentDictionary<RequestPath, RequestPath> _scopePathCache = new ConcurrentDictionary<RequestPath, RequestPath>();
        private static ConcurrentDictionary<RequestPath, ResourceType[]?> _scopeTypesCache = new ConcurrentDictionary<RequestPath, ResourceType[]?>();

        public static RequestPath GetScopePath(this RequestPath requestPath)
        {
            if (_scopePathCache.TryGetValue(requestPath, out var result))
                return result;

            result = CalculateScopePath(requestPath);
            _scopePathCache.TryAdd(requestPath, result);
            return result;
        }

        public static RequestPath GetScopePath(this OperationSet operationSet, BuildContext<MgmtOutputLibrary> context)
        {
            return operationSet.GetRequestPath(context).GetScopePath();
        }

        public static bool IsImplicitScope(this RequestPath requestPath, BuildContext<MgmtOutputLibrary> context)
        {
            // if a request is an implicit scope, it must only have one segment
            var scopePath = requestPath.GetScopePath();
            if (scopePath.Count > 1)
                return false;
            // then we need to ensure the corresponding parameter enables `x-ms-skip-url-encoding`
            var operation = context.Library.GetOperationSet(requestPath).First();
            var method = context.Library.RestClientMethods[operation];
            return method.Parameters.First().SkipUrlEncoding;
        }

        private static RequestPath CalculateScopePath(RequestPath requestPath)
        {
            var indexOfProvider = requestPath.ToList().LastIndexOf(Segment.Providers);
            if (indexOfProvider < 0)
                throw new System.InvalidOperationException($"Request path {requestPath} does not have providers segment in it");

            return new RequestPath(requestPath.Take(indexOfProvider).ToArray());
        }

        //public static bool IsScopeResource(this Operation operation, BuildContext<MgmtOutputLibrary> context)
        //{
        //    return operation.TryGetScopeResourceTypes(context, out _);
        //}

        //public static bool TryGetScopeResourceTypes(this Operation operation, BuildContext<MgmtOutputLibrary> context, [MaybeNullWhen(false)] out ResourceType[] resourceTypes)
        //{
        //    if (_scopeCache.TryGetValue(operation, out resourceTypes))
        //        return resourceTypes != null;

        //    resourceTypes = GetScopeResourceTypes(operation, context);
        //    _scopeCache.TryAdd(operation, resourceTypes);
        //    return resourceTypes != null;
        //}

        public static ResourceType[]? GetImplicitScopeResourceTypes(this RequestPath requestPath, BuildContext<MgmtOutputLibrary> context)
        {
            if (_scopeTypesCache.TryGetValue(requestPath, out var result))
                return result;

            result = requestPath.CalculateScopeResourceTypes(context);
            _scopeTypesCache.TryAdd(requestPath, result);
            return result;
        }

        private static ResourceType[]? CalculateScopeResourceTypes(this RequestPath requestPath, BuildContext<MgmtOutputLibrary> context)
        {
            if (!requestPath.IsImplicitScope(context))
                return null;
            if (context.Configuration.MgmtConfiguration.RequestPathToScopeResourceTypes.TryGetValue(requestPath, out var resourceTypes))
                return resourceTypes.Select(v => BuildResourceType(v)).ToArray();
            // otherwise we just assume this is scope and this scope could be anything
            return System.Array.Empty<ResourceType>();
        }

        private static ResourceType BuildResourceType(string resourceType) => resourceType switch
        {
            Subscriptions => ResourceType.Subscription,
            ResourceGroups => ResourceType.ResourceGroup,
            ManagementGroups => ResourceType.ManagementGroup,
            Tenant => ResourceType.Tenant,
            _ => new ResourceType(resourceType)
        };
    }
}
