// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OperationSetExtensions
    {
        private static readonly ConcurrentDictionary<(OperationSet, ResourceTypeSegment?), RequestPath> _cache = new ConcurrentDictionary<(OperationSet, ResourceTypeSegment?), RequestPath>();

        private static readonly ConcurrentDictionary<OperationSet, bool> _byIdCache = new ConcurrentDictionary<OperationSet, bool>();

        public static RequestPath GetRequestPath(this OperationSet operationSet, ResourceTypeSegment? hint = null)
        {
            if (_cache.TryGetValue((operationSet, hint), out var requestPath))
                return requestPath;

            requestPath = GetOperation(operationSet).GetRequestPath(hint);
            _cache.TryAdd((operationSet, hint), requestPath);
            return requestPath;
        }

        public static bool IsById(this OperationSet operationSet)
        {
            if (_byIdCache.TryGetValue(operationSet, out var result))
                return result;

            result = operationSet.GetRequestPath().IsById;
            _byIdCache.TryAdd(operationSet, result);
            return result;
        }

        private static Operation GetOperation(OperationSet operationSet)
        {
            // find PUT operation for the path
            var putOperation = operationSet.FirstOrDefault(operation => operation.GetHttpRequest()!.Method == HttpMethod.Put);
            if (putOperation is not null)
                return putOperation;

            // then find GET operation for the path
            var getOperation = operationSet.FirstOrDefault(operation => operation.GetHttpRequest()!.Method == HttpMethod.Get);
            if (getOperation is not null)
                return getOperation;

            // we found nothing! just whatever on the first slot
            return operationSet.First();
        }

        public static Operation? FindOperation(this OperationSet operationSet, HttpMethod method)
        {
            return operationSet.FirstOrDefault(operation => operation.GetHttpMethod() == method);
        }
    }
}
