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
        private static readonly ConcurrentDictionary<OperationSet, RequestPath> _cache = new ConcurrentDictionary<OperationSet, RequestPath>();

        public static RequestPath GetRequestPath(this OperationSet operationSet, BuildContext<MgmtOutputLibrary> context)
        {
            if (_cache.TryGetValue(operationSet, out var requestPath))
                return requestPath;

            requestPath = GetOperation(operationSet).GetRequestPath(context);
            _cache.TryAdd(operationSet, requestPath);
            return requestPath;
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
    }
}
