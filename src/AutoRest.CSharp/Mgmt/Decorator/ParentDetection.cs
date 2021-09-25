// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ParentDetection
    {
        private static ConcurrentDictionary<OperationGroup, string> _valueCache = new ConcurrentDictionary<OperationGroup, string>();

        private static ConcurrentDictionary<OperationGroup, OperationGroup?> _parentCache = new ConcurrentDictionary<OperationGroup, OperationGroup?>();

        private static ConcurrentDictionary<string, string> _operationPathAncestorCache = new ConcurrentDictionary<string, string>();
        private static ConcurrentDictionary<string, string> _operationPathParentCache = new ConcurrentDictionary<string, string>();

        private static ConcurrentDictionary<RequestPath, RequestPath> _requestPathToParentCache = new ConcurrentDictionary<RequestPath, RequestPath>();
        private static ConcurrentDictionary<Operation, RequestPath> _operationToParentRequestPathCache = new ConcurrentDictionary<Operation, RequestPath>();

        public static RequestPath ParentRequestPath(this OperationSet operationSet, BuildContext<MgmtOutputLibrary> context)
        {
            // escape the calculation if this is configured in the configuration
            if (context.Configuration.MgmtConfiguration.RequestPathToParent.TryGetValue(operationSet.RequestPath, out var rawPath))
                return GetRequestPathFromRawPath(rawPath, context);

            return operationSet.GetRequestPath(context).ParentRequestPath(context);
        }

        private static RequestPath GetRequestPathFromRawPath(string rawPath, BuildContext<MgmtOutputLibrary> context)
        {
            var parentSet = context.Library.GetOperationSet(rawPath);
            return parentSet.GetRequestPath(context);
        }

        /// <summary>
        /// This method gives the proper grouping of the given operation by testing the following:
        /// 1. If this operation comes from a resource operation set, return the request path of the resource
        /// 2. If this operation is a collection operation of a resource, return the request path of the resource
        /// 3. If neither of above meets, return the parent request path of an existing resource
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static RequestPath ParentRequestPath(this Operation operation, BuildContext<MgmtOutputLibrary> context)
        {
            if (_operationToParentRequestPathCache.TryGetValue(operation, out var result))
                return result;

            result = operation.GetParentRequestPath(context);
            _operationToParentRequestPathCache.TryAdd(operation, result);
            return result;
        }

        private static RequestPath GetParentRequestPath(this Operation operation, BuildContext<MgmtOutputLibrary> context)
        {
            // escape the calculation if this is configured in the configuration
            if (context.Configuration.MgmtConfiguration.RequestPathToParent.TryGetValue(operation.GetHttpPath(), out var rawPath))
                return GetRequestPathFromRawPath(rawPath, context);

            var currentRequestPath = operation.GetRequestPath(context);
            var currentOperationSet = context.Library.GetOperationSet(currentRequestPath);
            // if this operation comes from a resource, return itself
            if (currentOperationSet.IsResource(context.Configuration.MgmtConfiguration))
                return currentRequestPath;

            // if this operation corresponds to a collection operation of a resource, return the path of the resource
            if (operation.IsResourceCollectionOperation(context, out var operationSetOfResource))
                return operationSetOfResource.GetRequestPath(context);

            // if neither of the above, we find a request path that is the longest parent of this, and belongs to a resource
            return currentRequestPath.ParentRequestPath(context);
        }

        internal static RequestPath ParentRequestPath(this RequestPath requestPath, BuildContext<MgmtOutputLibrary> context)
        {
            if (_requestPathToParentCache.TryGetValue(requestPath, out var result))
            {
                return result;
            }

            result = GetParent(requestPath, context);
            _requestPathToParentCache.TryAdd(requestPath, result);

            return result;
        }

        private static RequestPath GetParent(this RequestPath requestPath, BuildContext<MgmtOutputLibrary> context)
        {
            // find a parent resource in the resource list
            // we are taking the resource with a path that is the child of this operationSet and taking the longest candidate
            // or null if none matched
            var candidates = context.Library.ResourceOperationSets.Select(operationSet => operationSet.GetRequestPath(context))
                .Where(r => r.IsParentOf(requestPath)).OrderBy(r => r.Count);
            if (candidates.Any())
                return candidates.Last();
            // if we cannot find one, we try the 4 extensions
            // first try management group
            // We use strict = false because we usually see the name of management group is different in different RPs. Some of them are groupId, some of them are groupName, etc
            if (RequestPath.ManagementGroup.IsParentOf(requestPath, false))
                return RequestPath.ManagementGroup;
            // then try resourceGroup
            if (RequestPath.ResourceGroup.IsParentOf(requestPath))
                return RequestPath.ResourceGroup;
            // then try subscriptions
            if (RequestPath.Subscription.IsParentOf(requestPath))
                return RequestPath.Subscription;
            // we do not have much choice to make, return tenant as the parent
            return RequestPath.Tenant;
        }

        public static string ParentResourceType(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            string? result = null;
            if (_valueCache.TryGetValue(operationGroup, out result))
                return result;

            if (!config.OperationGroupToParent.TryGetValue(operationGroup.Key, out result))
            {
                result = ParentDetection.GetParent(operationGroup, config);
            }

            _valueCache.TryAdd(operationGroup, result);
            return result;
        }

        // Get the parent operation group. If the parent is resource group, subscription or tenant, it will return null.
        public static OperationGroup? ParentOperationGroup(this OperationGroup operationGroup, BuildContext context)
        {
            OperationGroup? result = null;
            if (_parentCache.TryGetValue(operationGroup, out result))
                return result;
            var config = context.Configuration.MgmtConfiguration;
            var parentResourceType = operationGroup.ParentResourceType(config);

            foreach (var opGroup in context.CodeModel.OperationGroups)
            {
                if (opGroup.ResourceType(config).Equals(parentResourceType))
                {
                    result = opGroup;
                    break;
                }
            }
            _parentCache.TryAdd(operationGroup, result);
            return result;
        }

        private static string GetParent(OperationGroup operationGroup, MgmtConfiguration config)
        {
            if (operationGroup.IsTenantResource(config))
            {
                return ResourceTypeBuilder.Tenant;
            }
            if (operationGroup.IsExtensionResource(config))
            {
                throw new ArgumentException($"Could not set parent for operations group {operationGroup.Key}. This an extensions resource, please add to readme.md");
            }
            var method = GetBestMethod(operationGroup.OperationHttpMethodMapping());
            if (method == null)
            {
                throw new ArgumentException($"Could not set parent for operations group {operationGroup.Key}. Please add to readme.md");
            }

            var fullProvider = GetFullProvider(method.ProviderSegments());
            if (fullProvider == null)
            {
                throw new ArgumentException($"Could not set parent for operations group {operationGroup.Key}. Please add to readme.md");
            }
            var canidateParent = ParseMethodForParent(fullProvider, method.Path, operationGroup.ResourceType(config));
            if (canidateParent == string.Empty)
            {
                throw new ArgumentException($"Could not set parent for operations group {operationGroup.Key}. Please add to readme.md");
            }
            return canidateParent;
        }

        public static string AncestorResourceType(this Operation operation)
        {
            //TODO: use PathSegment to get resource type?
            string? result = null;
            if (!(operation.Requests.FirstOrDefault().Protocol.Http is HttpRequest httpRequest))
            {
                throw new ArgumentException($"The operation does not have an HttpRequest.");
            }
            var path = httpRequest.Path;
            if (_operationPathAncestorCache.TryGetValue(path, out result))
                return result;

            if (path.Contains("/resourcegroups/", StringComparison.InvariantCultureIgnoreCase))
            {
                result = ResourceTypeBuilder.ResourceGroups;
            }
            else if (path.Contains("/subscriptions/", StringComparison.InvariantCultureIgnoreCase))
            {
                result = ResourceTypeBuilder.Subscriptions;
            }
            else if (path.StartsWith("/providers/Microsoft.Management/managementGroups", StringComparison.InvariantCultureIgnoreCase))
            {
                result = ResourceTypeBuilder.ManagementGroups;
            }
            else
            {
                result = ResourceTypeBuilder.Tenant;
            }
            _operationPathAncestorCache.TryAdd(path, result);
            return result;
        }

        public static string ParentResourceType(this Operation operation)
        {
            string? result = null;
            if (!(operation.Requests.FirstOrDefault().Protocol.Http is HttpRequest httpRequest))
            {
                throw new ArgumentException($"The operation does not have an HttpRequest.");
            }
            var path = httpRequest.Path;
            if (_operationPathParentCache.TryGetValue(path, out result))
                return result;

            if (operation.IsParentTenant() || operation.IsParentScope())
            {
                result = ResourceTypeBuilder.Tenant;
            }
            else if (path.StartsWith("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers", StringComparison.InvariantCultureIgnoreCase))
            {
                // TODO: rethink about how to represent and get the resource type for this case
                result = ResourceTypeBuilder.ResourceGroupResources;
            }
            else
            {
                var fullProvider = GetFullProvider(httpRequest.ProviderSegments());
                if (fullProvider == null)
                {
                    // fullProvider is null in the case of /{resourceId}
                    // For other unkown cases, use tenant for now
                    result = ResourceTypeBuilder.Tenant;
                }
                else
                {
                    result = ParseMethodForParent(fullProvider, httpRequest.Path, operation.ResourceType());
                    if (result == string.Empty)
                    {
                        // If the parent is unknown, return tenant
                        // Eventually we should be able to get a parent for every operation
                        // This also aligns the behavior with AncestorResourceType().
                        result = ResourceTypeBuilder.Tenant;
                    }
                }
            }
            _operationPathParentCache.TryAdd(path, result);
            return result;
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
            if (providerSegments.Count == 0)
            {
                return null;
            }
            return providerSegments.Last().IsFullProvider ? providerSegments.Last() : null;
        }

        private static string ParseMethodForParent(ProviderSegment fullProvider, string path, string resourceType)
        {
            // Microsoft.Resources/deployments/ == lastFullProvider
            // resourceType = Microsoft.Management/managementGroups/providers/Microsoft.Resources/deployments
            // TODO: Fix in ResourceType()?
            var fullProviderToken = fullProvider.TokenValue;
            if (resourceType.StartsWith("Microsoft.Management/managementGroups/providers/"))
            {
                fullProviderToken = $"Microsoft.Management/managementGroups/providers/{fullProvider.TokenValue}";
            }
            //case 1:
            // Microsoft.Network/virtualNetworks/ == lastFullProvider
            // resourceType = Microsoft.Network/virtualNetworks
            //
            if (fullProviderToken.Trim('/').Equals(resourceType))
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
            return resourceType.StartsWith(fullProviderToken) ? resourceType.Substring(0, resourceType.LastIndexOf('/')) : string.Empty;
        }

        public static void VerifyParents(System.Collections.Generic.ICollection<OperationGroup> operationGroups, HashSet<string> ResourceTypes, MgmtConfiguration config)
        {
            foreach (var operationsGroup in operationGroups)
            {
                if (!operationsGroup.IsResource(config))
                    continue;

                if (operationsGroup.ParentResourceType(config) != null && !ResourceTypes.Contains(operationsGroup.ParentResourceType(config)))
                {
                    throw new ArgumentException($"Could not set parent for operations group {operationsGroup.Key} with parent {operationsGroup.ParentResourceType(config)}. key Please add to readme.md");
                }
            }
        }
    }
}
