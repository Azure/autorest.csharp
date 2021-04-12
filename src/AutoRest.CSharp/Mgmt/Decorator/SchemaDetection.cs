// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class SchemaDetection
    {
        private static ConcurrentDictionary<string, string> _valueCache = new ConcurrentDictionary<string, string>();

        public static string Resource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            string? result = null;
            if (_valueCache.TryGetValue(operationGroup.Key, out result))
                return result;

            if (!config.OperationGroupToResource.TryGetValue(operationGroup.Key, out result))
            {
                result = SchemaDetection.GetSchema(operationGroup).MgmtName(config);
            }

            _valueCache.TryAdd(operationGroup.Key, result);
            return result;
        }

        private static Schema GetSchema(OperationGroup operationGroup)
        {
            List<ServiceRequest>? output;
            operationGroup.OperationHttpMethodMapping().TryGetValue(HttpMethod.Put, out output);
            return GetBodyParameter(output.First(), operationGroup).Schema;
            throw new Exception($"Schema not found! Please add the {operationGroup.Key} to its schema name mapping to readme.md.");
        }

        private static RequestParameter GetBodyParameter(ServiceRequest request, OperationGroup operationGroup)
        {
            foreach (var param in request.Parameters)
            {
                var httpParam = param.Protocol.Http as HttpParameter;
                if (httpParam?.In == ParameterLocation.Body)
                    return param;
            }
            throw new Exception($"No body param found! Please add the {operationGroup.Key} to its schema name mapping to readme.md.");
        }
    }
}
