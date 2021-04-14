// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class SchemaDetection
    {
        private static ConcurrentDictionary<OperationGroup, string> _valueCache = new ConcurrentDictionary<OperationGroup, string>();

        public static string Resource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            string? result = null;
            if (_valueCache.TryGetValue(operationGroup, out result))
                return result;

            if (!config.OperationGroupToResource.TryGetValue(operationGroup.Key, out result))
            {
                result = SchemaDetection.GetSchema(operationGroup).Name;
            }

            _valueCache.TryAdd(operationGroup, result);
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

        /// <summary>
        /// Indicates if the given operation group should skip generation or not.
        /// If the operation group is marked as "SKIP" in configuration, will return false indicating the corresponding container, data... classes should not be generated.
        /// </summary>
        /// <param name="og">Operation group.</param>
        /// <param name="config">Management plane configuration.</param>
        /// <returns></returns>
        public static bool IsResource(this OperationGroup og, MgmtConfiguration config)
        {
            return og switch
            {
                null => false,
                _ => og.Resource(config).Equals(KeywordToSkipGeneration)
            };
        }

        private const string KeywordToSkipGeneration = "NonResource";
    }
}
