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
    internal static class OperationExtension
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
            hasSuffix = hasSuffix || words.Count() > 1;
            var wordToReplace = hasSuffix ? "Get" : "GetAll";
            var replacedWords = wordToReplace.AsIEnumerable().Concat(words.Skip(1));
            return string.Join("", replacedWords);
        }

        private static readonly ConcurrentDictionary<Operation, RequestPath> _operationToRequestPathCache = new ConcurrentDictionary<Operation, RequestPath>();

        public static RequestPath GetRequestPath(this Operation operation, BuildContext<MgmtOutputLibrary> context)
        {
            if (_operationToRequestPathCache.TryGetValue(operation, out var requestPath))
                return requestPath;

            requestPath = new RequestPath(context.Library.RestClientMethods[operation]);
            _operationToRequestPathCache.TryAdd(operation, requestPath);
            return requestPath;
        }

        public static bool IsResourceCollectionOperation(this Operation operation, BuildContext<MgmtOutputLibrary> context, [MaybeNullWhen(false)] out OperationSet operationSetOfResource)
        {
            operationSetOfResource = null;
            // first we need to ensure this operation at least returns a collection of something
            var restClientMethod = context.Library.RestClientMethods[operation];
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

        private static ISet<ResourceType> GetScopeResourceTypes(RequestPath requestPath, MgmtConfiguration config)
        {
            var scope = requestPath.GetScopePath();
            if (scope.IsParameterizedScope())
            {
                return new HashSet<ResourceType>(requestPath.GetParameterizedScopeResourceTypes(config)!);
            }

            return new HashSet<ResourceType> { scope.GetResourceType(config) };
        }

        private static bool IsScopeCompatible(RequestPath requestPath, RequestPath resourcePath, MgmtConfiguration config)
        {
            // get scope types
            var requestScopeTypes = GetScopeResourceTypes(requestPath, config);
            var resourceScopeTypes = GetScopeResourceTypes(resourcePath, config);
            if (resourceScopeTypes.Contains(ResourceType.Any))
                return true;
            return requestScopeTypes.IsSubsetOf(resourceScopeTypes);
        }

        private static OperationSet? FindOperationSetOfResource(RequestPath requestPath, BuildContext<MgmtOutputLibrary> context)
        {
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
                if (!requestPath.TrimScope().IsAncestorOf(resourceRequestPath.TrimScope()))
                    continue;
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
            if (requestPath.IsById())
                return int.MaxValue;
            if (requestPath.GetScopePath().IsParameterizedScope())
                return 0;
            return requestPath.Count;
        }

        public static string GetHttpPath(this Operation operation)
        {
            return operation.GetHttpRequest()?.Path ??
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
    }
}
