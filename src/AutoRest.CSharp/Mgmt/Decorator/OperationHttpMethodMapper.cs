// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OperationHttpMethodMapper
    {
        private static ConcurrentDictionary<OperationGroup, Dictionary<HttpMethod, List<ServiceRequest>>> _valueCache = new ConcurrentDictionary<OperationGroup, Dictionary<HttpMethod, List<ServiceRequest>>>();

        public static Dictionary<HttpMethod, List<ServiceRequest>> OperationHttpMethodMapping(this OperationGroup operationGroup)
        {
            Dictionary<HttpMethod, List<ServiceRequest>>? result;
            if (_valueCache.TryGetValue(operationGroup, out result))
                return result;

            result = MapHttpMethodToOperation(operationGroup);
            _valueCache.TryAdd(operationGroup, result);
            return result;
        }

        private static Dictionary<HttpMethod, List<ServiceRequest>> MapHttpMethodToOperation(OperationGroup operationsGroup)
        {
            var result = new Dictionary<HttpMethod, List<ServiceRequest>>();
            foreach (var operation in operationsGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    if (serviceRequest.Protocol.Http is HttpRequest httpRequest)
                    {
                        List<ServiceRequest>? list;
                        if (!result.TryGetValue(httpRequest.Method, out list))
                        {
                            list = new List<ServiceRequest>();
                            result.Add(httpRequest.Method, list);
                        }
                        list.Add(serviceRequest);
                    }
                }
            }
            return result;
        }
    }
}
