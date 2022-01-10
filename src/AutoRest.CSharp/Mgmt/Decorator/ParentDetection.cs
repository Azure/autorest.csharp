// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ParentDetection
    {
        private static ConcurrentDictionary<RequestPath, RequestPath> _requestPathToParentCache = new ConcurrentDictionary<RequestPath, RequestPath>();
        private static ConcurrentDictionary<Operation, RequestPath> _operationToParentRequestPathCache = new ConcurrentDictionary<Operation, RequestPath>();

        private static ConcurrentDictionary<MgmtTypeProvider, IEnumerable<MgmtTypeProvider>> _resourceParentCache = new ConcurrentDictionary<MgmtTypeProvider, IEnumerable<MgmtTypeProvider>>();

        /// <summary>
        /// Returns the collection of the parent of the given resource.
        /// This is not initialized while the TypeProviders are constructing and can only be used in the writers.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IEnumerable<MgmtTypeProvider> Parent(this Resource resource, BuildContext<MgmtOutputLibrary> context)
        {
            if (_resourceParentCache.TryGetValue(resource, out var parentList))
                return parentList;

            parentList = resource.GetParent(context);
            _resourceParentCache.TryAdd(resource, parentList);
            return parentList;
        }

        private static IEnumerable<MgmtTypeProvider> GetParent(this Resource resource, BuildContext<MgmtOutputLibrary> context)
        {
            return resource.OperationSets.SelectMany(resourceOperationSet => resourceOperationSet.GetParent(context));
        }

        private static IEnumerable<MgmtTypeProvider> GetParent(this OperationSet resourceOperationSet, BuildContext<MgmtOutputLibrary> context)
        {
            var parentRequestPath = resourceOperationSet.ParentRequestPath(context);
            if (context.Library.TryGetArmResource(parentRequestPath, out var parent))
            {
                return parent.AsIEnumerable();
            }
            // if we cannot find a resource as its parent, its parent must be one of the Extensions
            if (parentRequestPath.Equals(RequestPath.ManagementGroup))
                return context.Library.ManagementGroupExtensions.AsIEnumerable();
            if (parentRequestPath.Equals(RequestPath.ResourceGroup))
                return context.Library.ResourceGroupExtensions.AsIEnumerable();
            if (parentRequestPath.Equals(RequestPath.Subscription))
                return context.Library.SubscriptionExtensions.AsIEnumerable();
            // the only option left is the tenant. But we have our last chance that its parent could be the scope of this
            var scope = parentRequestPath.GetScopePath();
            // if the scope of this request path is parameterized, we return the scope as its parent
            if (scope.IsParameterizedScope())
            {
                // we already verified that the scope is parameterized, therefore we assert the type can never be null
                var types = resourceOperationSet.GetRequestPath(context).GetParameterizedScopeResourceTypes(context.Configuration.MgmtConfiguration)!;
                return FindScopeParents(types, context);
            }
            return context.Library.TenantExtensions.AsIEnumerable();
        }

        private static IEnumerable<MgmtTypeProvider> FindScopeParents(ResourceTypeSegment[] parameterizedScopeTypes, BuildContext<MgmtOutputLibrary> context)
        {
            if (parameterizedScopeTypes.Contains(ResourceTypeSegment.Any))
            {
                yield return context.Library.ArmResourceExtensions;
                yield break;
            }
            // try all the possible extensions one by one
            if (parameterizedScopeTypes.Contains(ResourceTypeSegment.ManagementGroup))
                yield return context.Library.ManagementGroupExtensions;
            if (parameterizedScopeTypes.Contains(ResourceTypeSegment.ResourceGroup))
                yield return context.Library.ResourceGroupExtensions;
            if (parameterizedScopeTypes.Contains(ResourceTypeSegment.Subscription))
                yield return context.Library.SubscriptionExtensions;
            if (parameterizedScopeTypes.Contains(ResourceTypeSegment.Tenant))
                yield return context.Library.TenantExtensions;
            // tenant is not quite a concrete resource, therefore we do not include it here
        }

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
            // NOTE that we are always using fuzzy match in the IsAncestorOf method, we need to block the ById operations - they literally can be anyone's ancestor when there is no better choice.
            // We will never want this
            var scope = requestPath.GetScopePath();
            var candidates = context.Library.ResourceOperationSets.Select(operationSet => operationSet.GetRequestPath(context))
                .Concat(new List<RequestPath>{RequestPath.ResourceGroup, RequestPath.Subscription, RequestPath.ManagementGroup}) // When generating management group in management.json, the path is /providers/Microsoft.Management/managementGroups/{groupId} while RequestPath.ManagementGroup is /providers/Microsoft.Management/managementGroups/{managementGroupId}. We pick the first one.
                .Where(r => r.IsAncestorOf(requestPath)).OrderByDescending(r => r.Count);
            if (candidates.Any())
            {
                var parent = candidates.First();
                if (parent == RequestPath.Tenant)
                {
                    // when generating for tenant and a scope path like policy assignment in Azure.ResourceManager, Tenant could be the only parent in context.Library.ResourceOperationSets.
                    // we need to return the parameterized scope instead.
                    if (scope != requestPath && scope.IsParameterizedScope())
                        parent = scope;
                }
                return parent;
            }
            // the only option left is the tenant. But we have our last chance that its parent could be the scope of this
            // if the scope of this request path is parameterized, we return the scope as its parent
            if (scope != requestPath && scope.IsParameterizedScope())
                return scope;
            // we do not have much choice to make, return tenant as the parent
            return RequestPath.Tenant;
        }
    }
}
