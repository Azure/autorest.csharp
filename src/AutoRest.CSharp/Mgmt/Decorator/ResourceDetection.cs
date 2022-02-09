// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ResourceDetection
    {
        private const string ProvidersSegment = "/providers/";
        private static ConcurrentDictionary<string, string?> _resourceDataSchemaNameCache = new ConcurrentDictionary<string, string?>();

        public static bool IsResource(this OperationSet set, MgmtConfiguration config)
        {
            return set.TryGetResourceDataSchemaName(config, out _);
        }

        public static string ResourceDataSchemaName(this OperationSet set, MgmtConfiguration config)
        {
            if (set.TryGetResourceDataSchemaName(config, out var resourceName))
                return resourceName;

            throw new InvalidOperationException($"Operation set {set.RequestPath} does not correspond to a resource");
        }

        public static bool TryGetResourceDataSchemaName(this OperationSet set, MgmtConfiguration config, [MaybeNullWhen(false)] out string resourceName)
        {
            resourceName = null;
            // get the result from cache
            if (_resourceDataSchemaNameCache.TryGetValue(set.RequestPath, out resourceName))
            {
                return resourceName != null;
            }

            // try to get result from configuration
            if (config.RequestPathToResourceData.TryGetValue(set.RequestPath, out resourceName))
            {
                _resourceDataSchemaNameCache.TryAdd(set.RequestPath, resourceName);
                return true;
            }

            // try to get another configuration to see if this is marked as not a resource
            if (config.RequestPathIsNonResource.Contains(set.RequestPath))
            {
                _resourceDataSchemaNameCache.TryAdd(set.RequestPath, null);
                return false;
            }

            // Check if the request path has even number of segments after the providers segment
            if (!CheckEvenSegments(set.RequestPath))
                return false;

            // before we are finding any operations, we need to ensure this operation set has a GET request.
            if (set.FindOperation(HttpMethod.Get) is null)
                return false;

            // try put operation to get the resource name
            if (set.TryOperationWithMethod(HttpMethod.Put, config, out resourceName))
            {
                _resourceDataSchemaNameCache.TryAdd(set.RequestPath, resourceName);
                return true;
            }

            // try get operation to get the resource name
            if (set.TryOperationWithMethod(HttpMethod.Get, config, out resourceName))
            {
                _resourceDataSchemaNameCache.TryAdd(set.RequestPath, resourceName);
                return true;
            }

            // We tried everything, this is not a resource
            _resourceDataSchemaNameCache.TryAdd(set.RequestPath, null);
            return false;
        }

        private static bool CheckEvenSegments(string requestPath)
        {
            var index = requestPath.LastIndexOf(ProvidersSegment);
            // this request path does not have providers segment - it can be a "ById" request, skip to next criteria
            if (index < 0)
                return true;
            // get whatever following the providers
            var following = requestPath.Substring(index);
            var segments = following.Split("/", StringSplitOptions.RemoveEmptyEntries);
            return segments.Length % 2 == 0;
        }

        private static bool TryOperationWithMethod(this OperationSet set, HttpMethod method, MgmtConfiguration config, [MaybeNullWhen(false)] out string resourceName)
        {
            resourceName = null;

            var operation = set.FindOperation(method);
            if (operation is null)
                return false;
            // find the response with code 200
            var response = operation.GetServiceResponse();
            if (response is null)
                return false;
            // find the response schema
            var schema = response.ResponseSchema;
            if (schema is null)
                return false;

            // we need to verify this schema has ID, type and name so that this is a resource model
            if (!schema.IsResourceModel(config))
                return false;

            resourceName = schema.Name;
            return true;
        }
    }
}
