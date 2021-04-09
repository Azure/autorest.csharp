// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class SchemaDetection
    {
        public static Schema GetSchema(OperationGroup operationGroup)
        {
            List<ServiceRequest>? output;
            operationGroup.OperationHttpMethodMapping.TryGetValue(HttpMethod.Put, out output);
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
