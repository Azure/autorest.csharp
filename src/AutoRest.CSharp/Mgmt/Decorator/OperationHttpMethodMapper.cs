// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class OperationHttpMethodMapper
    {
        private static ConcurrentDictionary<OperationGroup, Dictionary<HttpMethod, List<ServiceRequest>>> _operationGroupCache = new ConcurrentDictionary<OperationGroup, Dictionary<HttpMethod, List<ServiceRequest>>>();

        public static Dictionary<HttpMethod, List<ServiceRequest>> OperationHttpMethodMapping(this RawOperationSet operations)
        {
            var result = new Dictionary<HttpMethod, List<ServiceRequest>>();
            foreach (var operation in operations)
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

        public static Dictionary<HttpMethod, List<ServiceRequest>> OperationHttpMethodMapping(this OperationGroup operationGroup)
        {
            Dictionary<HttpMethod, List<ServiceRequest>>? result;
            if (_operationGroupCache.TryGetValue(operationGroup, out result))
                return result;

            result = MapHttpMethodToOperation(operationGroup);
            _operationGroupCache.TryAdd(operationGroup, result);
            return result;
        }

        private static Dictionary<HttpMethod, List<ServiceRequest>> MapHttpMethodToOperation(OperationGroup operationGroup)
        {
            var result = new Dictionary<HttpMethod, List<ServiceRequest>>();
            foreach (var operation in operationGroup.Operations)
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
