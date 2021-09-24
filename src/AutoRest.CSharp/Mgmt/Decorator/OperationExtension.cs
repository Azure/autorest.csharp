// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OperationExtension
    {
        private static readonly ConcurrentDictionary<Operation, RequestPath> _operationToRequestPathCache = new ConcurrentDictionary<Operation, RequestPath>();

        public static RequestPath GetRequestPath(this Operation operation, BuildContext<MgmtOutputLibrary> context)
        {
            if (_operationToRequestPathCache.TryGetValue(operation, out var requestPath))
                return requestPath;

            requestPath = new RequestPath(context.Library.RestClientMethods[operation]);
            _operationToRequestPathCache.TryAdd(operation, requestPath);
            return requestPath;
        }

        public static bool IsResourceCollectionOperation(this Operation operation, BuildContext<MgmtOutputLibrary> context, [MaybeNullWhen(false)] out RawOperationSet operationSetOfResource)
        {
            // first check if its path is a prefix of which resource's operationSet
            var requestPath = operation.GetRequestPath(context);
            operationSetOfResource = FindOperationSetOfResource(requestPath, context);
            if (operationSetOfResource is null)
                return false;

            // then check if this method returns a collection of the corresponding resource data
            var restClientMethod = context.Library.RestClientMethods[operation];
            if (!restClientMethod.IsListMethod(out var valueType, out _))
                return false;
            // check if valueType is the current resource data type
            var resourceData = context.Library.GetResourceData(operationSetOfResource.RequestPath);
            return valueType.EqualsByName(resourceData.Type);
        }

        private static RawOperationSet? FindOperationSetOfResource(RequestPath requestPath, BuildContext<MgmtOutputLibrary> context)
        {
            // we need to iterate all resources to find if this is the parent of that
            foreach (var operationSet in context.Library.ResourceOperationSets)
            {
                var segments = requestPath.TrimParentFrom(operationSet.GetRequestPath(context));
                if (segments is null)
                    continue;
                // the collection operation always have one segment less than the request path of the corresponding resource.
                if (segments.Count() == 1)
                    return operationSet;
            }

            return null;
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

        public static ServiceResponse? GetServiceResponse(this Operation operation, StatusCodes code = StatusCodes._200)
        {
            return operation.Responses.FirstOrDefault(r => r.HttpResponse.StatusCodes.Contains(code));
        }

        public static bool IsGetResourceOperation(this Input.Operation operation, string? responseBodyType, ResourceData resourceData)
        {
            return operation.Language.Default.Name.StartsWith("Get") && responseBodyType == resourceData.Type.Name;
        }
    }
}
