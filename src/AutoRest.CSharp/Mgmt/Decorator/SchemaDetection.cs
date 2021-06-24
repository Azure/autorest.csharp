﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class SchemaDetection
    {
        /// <summary>
        /// This value caches the map from operation groups to the resource name its corresponds
        /// </summary>
        private static ConcurrentDictionary<OperationGroup, string> _valueCache = new ConcurrentDictionary<OperationGroup, string>();

        public static string Resource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            if (operationGroup.TryGetResourceName(config, out var name))
                return name;

            // otherwise we throw exception to notify the user to modify their readme.md
            throw new Exception($"Resource schema not found! Please add the {operationGroup.Key} to its schema name mapping in the `operation-group-to-resource` section of readme.md.");
        }

        public static bool TryGetResourceName(this OperationGroup operationGroup, MgmtConfiguration config, [MaybeNullWhen(false)] out string name)
        {
            name = null;
            if (_valueCache.TryGetValue(operationGroup, out var result))
            {
                name = result;
                return true;
            }

            // find in configuration and build the cache
            if (config.OperationGroupToResource.TryGetValue(operationGroup.Key, out result))
            {
                name = result;
                _valueCache.TryAdd(operationGroup, result);
                return true;
            }

            // we do not find this resource group in the configuration, we try to directly get the body parameter for its schema name
            if (operationGroup.TryGetResourceSchema(out var schema))
            {
                name = schema.Name;
                _valueCache.TryAdd(operationGroup, name);
                return true;
            }

            // we have tried everything, return false
            return false;
        }

        /// <summary>
        /// Indicates if the given operation group is a ListOnly operation group.
        /// If the operation group is a ListOnly which corresponds to a NonResource,
        /// this function will return true indicating the corresponding container, data... classes should not be generated.
        /// </summary>
        /// <param name="operationGroup">Operation group.</param>
        /// <param name="config">Management plane configuration.</param>
        /// <returns></returns>
        public static bool IsListOnly(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            // if operation count is not 1, does not meet the ListOnly criteria. Return false
            if (operationGroup.Operations.Count != 1)
            {
                return false;
            }

            var operation = operationGroup.Operations.First();

            if (!operation.IsLongRunning
                && operation.Requests.FirstOrDefault()?.Protocol.Http is HttpRequest httpRequest
                && httpRequest.Method == HttpMethod.Get)
            {
                // Check 200 return schema
                var successResponse = operation.Responses.FirstOrDefault(r => r.HttpResponse.StatusCodes.Contains(StatusCodes._200));
                var responseSchema = successResponse?.ResponseSchema as ObjectSchema;

                var arraySchemas = responseSchema?.Properties?.Where(p => p.Schema is ArraySchema)
                    ?.Select(p => p.Schema as ArraySchema);
                return arraySchemas?.Count() == 1;
            }

            return false;
        }

        /// <summary>
        /// This extension method returns whether this operation group only contains one resource definition. If true, this method
        /// will output the schema of the resource body
        /// </summary>
        /// <param name="operationGroup">the operation group to check</param>
        /// <param name="schema">the resource schema, will be null if this method returns false</param>
        /// <returns>true if the given operation group corresponds to a resource</returns>
        public static bool TryGetResourceSchema(this OperationGroup operationGroup, [MaybeNullWhen(false)] out Schema schema)
        {
            schema = null;
            if (operationGroup.OperationHttpMethodMapping().TryGetValue(HttpMethod.Put, out var output))
            {
                schema = GetBodyParameter(output.First(), operationGroup).Schema;
                return true;
            }

            return false;
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
        /// Returns true if the operation group is a resource; false otherwise (list-only ...).
        /// If the operation group is marked by <see cref="NonResourceKeyword"/> in configuration, will return false.
        /// </summary>
        /// <param name="og">Operation group.</param>
        /// <param name="config">Management plane configuration.</param>
        public static bool IsResource(this OperationGroup og, MgmtConfiguration config)
        {
            return !og.IsNonResource(config) && !og.IsListOnly(config);
        }

        /// <summary>
        /// Returns true if the operation group is marked by <see cref="NonResourceKeyword"/> in configuration.
        /// </summary>
        /// <param name="og">Operation group to test.</param>
        /// <param name="config">Management plane configuration.</param>
        public static bool IsNonResource(this OperationGroup og, MgmtConfiguration config) =>
            config.OperationGroupToResource.ContainsKey(og.Key)
                && config.OperationGroupToResource[og.Key].Equals(NonResourceKeyword);

        private const string NonResourceKeyword = "NonResource";
    }
}
