// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OperationExtensions
    {
        /// <summary>
        /// Returns the CSharpName of an operation in management plane pattern where we replace the word List with Get or GetAll depending on if there are following words
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="hasSuffix"></param>
        /// <returns></returns>
        public static string MgmtCSharpName(this Operation operation, bool hasSuffix)
        {
            var originalName = operation.CSharpName();
            var words = originalName.SplitByCamelCase();
            if (!words.First().Equals("List", StringComparison.InvariantCultureIgnoreCase))
                return originalName;
            words = words.Skip(1); // remove the word List
            if (words.Any() && words.First().Equals("All", StringComparison.InvariantCultureIgnoreCase))
                words = words.Skip(1);
            hasSuffix = hasSuffix || words.Any();
            var wordToReplace = hasSuffix ? "Get" : "GetAll";
            var replacedWords = wordToReplace.AsIEnumerable().Concat(words);
            return string.Join("", replacedWords);
        }

        /// <summary>
        /// Search the configuration for an overridden of this operation's name
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool TryGetConfigOperationName(this Operation operation, BuildContext<MgmtOutputLibrary> context, [MaybeNullWhen(false)] out string name)
        {
            var operationId = operation.OperationId(context.Library.GetRestClient(operation).OperationGroup);
            return context.Configuration.MgmtConfiguration.OverrideOperationName.TryGetValue(operationId, out name);
        }

        public static string OperationId(this Operation operation, OperationGroup operationGroup)
        {
            if (_operationIdCache.TryGetValue(operation, out var result))
                return result;
            result = operationGroup.Key.IsNullOrEmpty() ? operation.Language.Default.Name : $"{operationGroup.Key}_{operation.Language.Default.Name}";
            _operationIdCache.TryAdd(operation, result);
            return result;
        }

        private static readonly ConcurrentDictionary<Operation, string> _operationIdCache = new ConcurrentDictionary<Operation, string>();

        private static readonly ConcurrentDictionary<Operation, RequestPath> _operationToRequestPathCache = new ConcurrentDictionary<Operation, RequestPath>();

        public static RequestPath GetRequestPath(this Operation operation, BuildContext<MgmtOutputLibrary> context)
        {
            if (_operationToRequestPathCache.TryGetValue(operation, out var requestPath))
                return requestPath;

            requestPath = new RequestPath(context.Library.GetRestClientMethod(operation));
            _operationToRequestPathCache.TryAdd(operation, requestPath);
            return requestPath;
        }

        public static bool IsResourceCollectionOperation(this Operation operation, BuildContext<MgmtOutputLibrary> context, [MaybeNullWhen(false)] out OperationSet operationSetOfResource)
        {
            operationSetOfResource = null;
            // first we need to ensure this operation at least returns a collection of something
            var restClientMethod = context.Library.GetRestClientMethod(operation);
            if (!restClientMethod.IsListMethod(out var valueType))
                return false;

            // then check if its path is a prefix of which resource's operationSet
            // if there are multiple resources that share the same prefix of request path, we choose the shortest one
            var requestPath = operation.GetRequestPath(context);
            operationSetOfResource = FindOperationSetOfResource(requestPath, context);
            // if we find none, this cannot be a resource collection operation
            if (operationSetOfResource is null)
                return false;

            // then check if this method returns a collection of the corresponding resource data
            // check if valueType is the current resource data type
            var resourceData = context.Library.GetResourceData(operationSetOfResource.RequestPath);
            return valueType.EqualsByName(resourceData.Type);
        }

        private static ISet<ResourceTypeSegment> GetScopeResourceTypes(RequestPath requestPath, MgmtConfiguration config)
        {
            var scope = requestPath.GetScopePath();
            if (scope.IsParameterizedScope())
            {
                return new HashSet<ResourceTypeSegment>(requestPath.GetParameterizedScopeResourceTypes(config)!);
            }

            return new HashSet<ResourceTypeSegment> { scope.GetResourceType(config) };
        }

        private static bool IsScopeCompatible(RequestPath requestPath, RequestPath resourcePath, MgmtConfiguration config)
        {
            // get scope types
            var requestScopeTypes = GetScopeResourceTypes(requestPath, config);
            var resourceScopeTypes = GetScopeResourceTypes(resourcePath, config);
            if (resourceScopeTypes.Contains(ResourceTypeSegment.Any))
                return true;
            return requestScopeTypes.IsSubsetOf(resourceScopeTypes);
        }

        private static OperationSet? FindOperationSetOfResource(RequestPath requestPath, BuildContext<MgmtOutputLibrary> context)
        {
            if (context.Configuration.MgmtConfiguration.RequestPathToParent.TryGetValue(requestPath, out var rawPath))
                return context.Library.GetOperationSet(rawPath);
            var candidates = new List<OperationSet>();
            // we need to iterate all resources to find if this is the parent of that
            foreach (var operationSet in context.Library.ResourceOperationSets)
            {
                var resourceRequestPath = operationSet.GetRequestPath(context);
                // we compare the request with the resource request in two parts:
                // 1. Compare if they have the same scope
                // 2. Compare if they have the "compatible" remaining path
                // check if they have compatible scopes
                if (!IsScopeCompatible(requestPath, resourceRequestPath, context.Configuration.MgmtConfiguration))
                    continue;
                // check the remaining path
                var trimmedRequestPath = requestPath.TrimScope();
                var trimmedResourceRequestPath = resourceRequestPath.TrimScope();
                // For a path of a scope like /subscriptions/{subscriptionId}/resourcegroups, the trimmed path is empty. The path of its resource should also be a scope, its trimmed path should also be empty.
                if (trimmedRequestPath.Count == 0 && trimmedResourceRequestPath.Count != 0)
                    continue;
                // In the case that the full path of requestPath and resourceRequestPath are both scopes (trimmed path is empty), comparing the scope part is enough.
                // We should not compare the remaining paths as both will be empty path and Tenant.IsAncestorOf(Tenant) always returns false.
                else if (trimmedRequestPath.Count != 0 || trimmedResourceRequestPath.Count != 0)
                {
                    if (!trimmedRequestPath.IsAncestorOf(trimmedResourceRequestPath))
                        continue;
                }
                candidates.Add(operationSet);
            }

            if (candidates.Count == 0)
                return null;

            // choose the toppest of the rank
            return candidates.OrderBy(operationSet => RankRequestPath(operationSet.GetRequestPath(context))).First();
        }

        /// <summary>
        /// Rank the request path to serve that which request path to choose.
        /// For normal request paths, we just return its count, and we choose the shortest one.
        /// For request paths with parameterized scope, we rank it as 0 so that it will always be the first.
        /// For request paths that only accepts an Id, we rank it as int.MaxValue so that it will always be our last choice
        /// </summary>
        /// <param name="requestPath"></param>
        /// <returns></returns>
        private static int RankRequestPath(RequestPath requestPath)
        {
            if (requestPath.IsById)
                return int.MaxValue;
            if (requestPath.GetScopePath().IsParameterizedScope())
                return 0;
            return requestPath.Count;
        }

        public static string GetHttpPath(this Operation operation)
        {
            var path = operation.GetHttpRequest()?.Path;
            // Do not trim the tenant resource path '/'.
            return (path?.Length == 1 ? path : path?.TrimEnd('/')) ??
                throw new InvalidOperationException($"Cannot get HTTP path from operation {operation.CSharpName()}");
        }

        public static HttpRequest? GetHttpRequest(this Operation operation)
        {
            foreach (var request in operation.Requests)
            {
                var httpRequest = request.Protocol.Http as HttpRequest;
                if (httpRequest is not null)
                    return httpRequest;
            }

            return null;
        }

        public static HttpMethod GetHttpMethod(this Operation operation)
        {
            return operation.GetHttpRequest()!.Method;
        }

        public static ServiceResponse? GetServiceResponse(this Operation operation, StatusCodes code = StatusCodes._200)
        {
            return operation.Responses.FirstOrDefault(r => r.HttpResponse.StatusCodes.Contains(code));
        }

        public static bool IsGetResourceOperation(this Input.Operation operation, string? responseBodyType, ResourceData resourceData, BuildContext<MgmtOutputLibrary> context)
        {
            // first we need to be a GET operation
            var request = operation.GetHttpRequest();
            if (request == null || request.Method != HttpMethod.Get)
                return false;
            // then we get the corresponding OperationSet and see if this OperationSet corresponds to a resource
            var operationSet = context.Library.GetOperationSet(operation.GetHttpPath());
            if (!operationSet.IsResource(context.Configuration.MgmtConfiguration))
                return false;
            return responseBodyType == resourceData.Type.Name;
        }

        private static ConcurrentDictionary<Operation, Resource?> _operationToResourceCache = new ConcurrentDictionary<Operation, Resource?>();
        internal static Resource? GetResourceFromResourceType(this Operation operation, BuildContext<MgmtOutputLibrary> context)
        {
            if (_operationToResourceCache.TryGetValue(operation, out Resource? cacheResult))
                return cacheResult;

            var resourceType = operation.GetRequestPath(context).GetResourceType(context.Configuration.MgmtConfiguration);
            var candidates = context.Library.ArmResources.Where(resource => resource.ResourceType.DoesMatch(resourceType));

            int candidateCount = candidates.Count();

            Func<Resource?, Resource?> setAndReturn = (result) =>
            {
                _operationToResourceCache.TryAdd(operation, result);
                return result;
            };

            if (candidateCount == 0)
                return setAndReturn(null);

            if (candidateCount == 1)
                return setAndReturn(candidates.First());

            foreach (var candidate in candidates)
            {
                if (candidate.IsInOperationMap(operation))
                    return setAndReturn(candidate);
            }

            var parentCanddidate = candidates.First().Parent(context).FirstOrDefault();

            if (parentCanddidate is not null && parentCanddidate is Resource)
                return setAndReturn(parentCanddidate as Resource);

            throw new InvalidOperationException($"Found more than 1 candidate for {resourceType}, results were ({string.Join(',', candidates.Select(r => r.ResourceName))})");
        }
    }
}
