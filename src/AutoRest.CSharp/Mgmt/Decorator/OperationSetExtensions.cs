// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OperationSetExtensions
    {
        private static readonly ConcurrentDictionary<RawOperationSet, RequestPath> _cache = new ConcurrentDictionary<RawOperationSet, RequestPath>();

        public static RequestPath GetRequestPath(this RawOperationSet operationSet, BuildContext<MgmtOutputLibrary> context)
        {
            if (_cache.TryGetValue(operationSet, out var requestPath))
                return requestPath;

            requestPath = new RequestPath(operationSet.GetMethod(context));
            _cache.TryAdd(operationSet, requestPath);
            return requestPath;
        }

        public static bool IsResourceCollection(this RawOperationSet operationSet, BuildContext<MgmtOutputLibrary> context)
        {
            // TODO -- should we change this check from OperationSet to Operation???
            var requestPath = operationSet.GetRequestPath(context);
            foreach (var operation in operationSet)
            {
                var restClientMethod = context.Library.RestClientMethods[operation];
                (_, var isList, var isResourceData) = restClientMethod.GetBodyTypeForList(operationSet[operation], context);
                if (isList && isResourceData)
                    return true;
            }

            return false;
        }

        private static RestClientMethod GetMethod(this RawOperationSet operationSet, BuildContext<MgmtOutputLibrary> context)
        {
            var restClientMethods = operationSet.Select(operation => context.Library.RestClientMethods[operation]);
            // find PUT method for the path
            var putRestClientMethod = restClientMethods.FirstOrDefault(method => method.Request.HttpMethod == RequestMethod.Put);
            if (putRestClientMethod is not null)
                return putRestClientMethod;

            // then find Get method for the path if we do not have a put
            var getRestClientMethod = restClientMethods.FirstOrDefault(method => method.Request.HttpMethod == RequestMethod.Get);
            if (getRestClientMethod is not null)
                return getRestClientMethod;

            // we found nothing! just whatever on the first slot
            return restClientMethods.First();
        }
    }
}
