﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OperationExtensions
    {
        private static readonly ConcurrentDictionary<InputOperation, string> _operationIdCache = new ConcurrentDictionary<InputOperation, string>();

        private static readonly ConcurrentDictionary<(InputOperation, ResourceTypeSegment?), RequestPath> _operationToRequestPathCache = new ConcurrentDictionary<(InputOperation, ResourceTypeSegment?), RequestPath>();

        private static readonly ConcurrentDictionary<InputOperation, IEnumerable<Resource>> _operationToResourceCache = new ConcurrentDictionary<InputOperation, IEnumerable<Resource>>();

        /// <summary>
        /// Returns the CSharpName of an operation in management plane pattern where we replace the word List with Get or GetAll depending on if there are following words
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="hasSuffix"></param>
        /// <returns></returns>
        public static string MgmtCSharpName(this InputOperation operation, bool hasSuffix)
        {
            var originalName = operation.CleanName;
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
        public static bool TryGetConfigOperationName(this InputOperation operation, [MaybeNullWhen(false)] out string name)
        {
            if (Configuration.MgmtConfiguration.OverrideOperationName.TryGetValue(operation.OperationId!, out name))
            {
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                    new TransformItem(TransformTypeName.OverrideOperationName, operation.OperationId!, name),
                    operation.GetFullSerializedName(),
                    "OverrideOperationName", operation.Name, name);
                return true;
            }

            if (operation.IsNameChanged)
            {
                name = operation.Name;
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                    new TransformItem(TransformTypeName.OverrideOperationName, operation.OperationId!, name),
                    operation.GetFullSerializedName(),
                    "OverrideOperationName", operation.Name, name);
                return true;
            }

            return false;
        }

        public static RequestPath GetRequestPath(this InputOperation operation, ResourceTypeSegment? hint = null)
        {
            if (_operationToRequestPathCache.TryGetValue((operation, hint), out var requestPath))
                return requestPath;

            requestPath = MgmtContext.Library.GetRequestPath(operation);
            if (hint.HasValue)
                requestPath = requestPath.ApplyHint(hint.Value);

            _operationToRequestPathCache.TryAdd((operation, hint), requestPath);
            return requestPath;
        }

        public static bool IsResourceCollectionOperation(this InputOperation operation, [MaybeNullWhen(false)] out OperationSet operationSetOfResource)
        {
            operationSetOfResource = null;
            // first we need to ensure this operation at least returns a collection of something
            var restClientMethod = MgmtContext.Library.GetRestClientMethod(operation);
            if (!restClientMethod.IsListMethod(out var valueType))
                return false;

            // then check if its path is a prefix of which resource's operationSet
            // if there are multiple resources that share the same prefix of request path, we choose the shortest one
            var requestPath = operation.GetRequestPath();
            operationSetOfResource = FindOperationSetOfResource(requestPath);
            // if we find none, this cannot be a resource collection operation
            if (operationSetOfResource is null)
                return false;

            // then check if this method returns a collection of the corresponding resource data
            // check if valueType is the current resource data type
            var resourceData = MgmtContext.Library.GetResourceData(operationSetOfResource.RequestPath);
            return valueType.AreNamesEqual(resourceData.Type);
        }

        private static OperationSet? FindOperationSetOfResource(RequestPath requestPath)
        {
            if (Configuration.MgmtConfiguration.RequestPathToParent.TryGetValue(requestPath, out var rawPath))
                return MgmtContext.Library.GetOperationSet(rawPath);
            var candidates = new List<OperationSet>();
            // we need to iterate all resources to find if this is the parent of that
            foreach (var operationSet in MgmtContext.Library.ResourceOperationSets)
            {
                var resourceRequestPath = operationSet.GetRequestPath();
                // we compare the request with the resource request in two parts:
                // 1. Compare if they have the same scope
                // 2. Compare if they have the "compatible" remaining path
                // check if they have compatible scopes
                if (!RequestPath.IsScopeCompatible(requestPath, resourceRequestPath))
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
            return candidates.OrderBy(operationSet => RankRequestPath(operationSet.GetRequestPath())).First();
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

        public static string GetHttpPath(this InputOperation operation)
        {
            var path = operation.Path;
            // Do not trim the tenant resource path '/'.
            return (path?.Length == 1 ? path : path?.TrimEnd('/')) ??
                throw new InvalidOperationException($"Cannot get HTTP path from operation {operation.CleanName}");
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

        public static RequestParameter? GetBodyParameter(this Operation operation)
        {
            var serviceRequest = operation.GetServiceRequest();
            return serviceRequest?.Parameters.FirstOrDefault(parameter => parameter.In == HttpParameterIn.Body);
        }

        public static InputParameter? GetBodyParameter(this InputOperation operation)
            => operation.Parameters.FirstOrDefault(parameter => parameter.Location == RequestLocation.Body);

        public static ServiceRequest? GetServiceRequest(this Operation operation)
        {
            return operation.Requests.FirstOrDefault();
        }

        public static OperationResponse? GetServiceResponse(this InputOperation operation, int code = 200)
        {
            return operation.Responses.FirstOrDefault(r => r.StatusCodes.Contains(code));
        }

        public static bool IsGetResourceOperation(this InputOperation operation, string? responseBodyType, ResourceData resourceData)
        {
            // first we need to be a GET operation
            if (operation.HttpMethod != RequestMethod.Get)
                return false;
            // then we get the corresponding OperationSet and see if this OperationSet corresponds to a resource
            var operationSet = MgmtContext.Library.GetOperationSet(operation.GetHttpPath());
            if (!operationSet.IsResource())
                return false;
            return responseBodyType == resourceData.Type.Name;
        }

        internal static IEnumerable<Resource> GetResourceFromResourceType(this InputOperation operation)
        {
            if (_operationToResourceCache.TryGetValue(operation, out var cacheResult))
                return cacheResult;

            // we expand the path here to ensure the resource types we are dealing with here are all constants (at least ensure they are constants when we are expecting to find a resource)
            var requestPaths = operation.GetRequestPath().Expand();
            var candidates = new List<Resource>();
            foreach (var path in requestPaths)
            {
                var resourceType = path.GetResourceType();
                // we find the resource with the same type of this operation, and under the same scope
                var resources = MgmtContext.Library.ArmResources.Where(resource => resource.ResourceType.DoesMatch(resourceType) && resource.RequestPath.GetScopePath().Equals(path.GetScopePath()));
                candidates.AddRange(resources);
            }

            return candidates;
        }

        internal static string GetFullSerializedName(this OperationGroup operationGroup)
        {
            return operationGroup.Language.Default.SerializedName ?? operationGroup.Language.Default.Name;
        }

        internal static string GetFullSerializedName(this Operation operation)
        {
            return operation.OperationId ?? operation.Language.Default.SerializedName ?? operation.Language.Default.Name;
        }

        internal static string GetFullSerializedName(this InputOperation operation)
        {
            return operation.SpecName;
        }

        internal static string GetFullSerializedName(this InputOperation operation, InputParameter parameter)
        {
            return $"{operation.GetFullSerializedName()}.{parameter.NameInRequest}";
        }

        internal static string GetFullSerializedName(this Operation operation, RequestParameter parameter)
        {
            return $"{operation.GetFullSerializedName()}.{parameter.GetOriginalName()}";
        }
    }
}
