// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ResourceDetection
    {
        private static ConcurrentDictionary<string, string?> _rawCache = new ConcurrentDictionary<string, string?>();

        public static bool IsResource(this RawOperationSet set, MgmtConfiguration config)
        {
            return set.TryGetResourceName(config, out _);
        }

        public static bool TryGetResourceName(this RawOperationSet set, MgmtConfiguration config, [MaybeNullWhen(false)] out string resourceName)
        {
            resourceName = null;
            // get the result from cache
            if (_rawCache.TryGetValue(set.RequestPath, out resourceName))
            {
                return resourceName != null;
            }

            // try to get result from configuration
            if (config.RequestPathToResource.TryGetValue(set.RequestPath, out resourceName))
            {
                _rawCache.TryAdd(set.RequestPath, resourceName);
                return true;
            }

            // try to get another configuration to see if this is marked as not a resource
            if (config.RequestPathIsNonResource.Contains(set.RequestPath))
            {
                _rawCache.TryAdd(set.RequestPath, null);
                return false;
            }

            // Check if the request path has even number of segments after the providers segment
            // TODO -- do we need this criteria?

            // try put operation to get the resource name
            if (set.TryOperationWithMethod(HttpMethod.Put, out resourceName))
            {
                _rawCache.TryAdd(set.RequestPath, resourceName);
                return true;
            }

            // try get operation to get the resource name
            if (set.TryOperationWithMethod(HttpMethod.Get, out resourceName))
            {
                _rawCache.TryAdd(set.RequestPath, resourceName);
                return true;
            }

            // We tried everything, this is not a resource
            _rawCache.TryAdd(set.RequestPath, null);
            return false;
        }

        private static bool TryOperationWithMethod(this RawOperationSet set, HttpMethod method, [MaybeNullWhen(false)] out string resourceName)
        {
            resourceName = null;

            var operation = FindOperation(set, method);
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
            if (!CheckSchemaIsResourceModel(schema))
                return false;

            resourceName = schema.Name;
            return true;
        }

        private static Operation? FindOperation(this RawOperationSet set, HttpMethod method)
        {
            foreach (var operation in set)
            {
                var request = operation.GetHttpRequest();
                if (request?.Method == method)
                    return operation;
            }

            return null;
        }

        private static bool CheckSchemaIsResourceModel(Schema schema)
        {
            if (schema is not ObjectSchema objSchema)
                return false;
            Property? idProperty = null, typeProperty = null, nameProperty = null;

            foreach (var property in objSchema.Properties)
            {
                // check if this property is flattened from lower level, we should only consider first level properties in this model
                // therefore if flattenedNames is not empty, this property is flattened, we skip this property
                if (property.FlattenedNames.Any())
                    continue;
                switch (property.SerializedName)
                {
                    case "id":
                        idProperty = property;
                        continue;
                    case "type":
                        // we require type is read-only
                        if (property.IsReadOnly)
                            typeProperty = property;
                        continue;
                    case "name":
                        // we require name is read-only
                        if (property.IsReadOnly)
                            nameProperty = property;
                        continue;
                }
            }

            return idProperty != null && typeProperty != null && nameProperty != null;
        }
    }
}
