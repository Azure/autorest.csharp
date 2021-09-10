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
                return true;
            }

            // try to get another configuration to see if this is marked as not a resource
            if (config.RequestPathIsNonResource.Contains(set.RequestPath))
            {
                return false;
            }

            // calculate the resource name by ourselves
            // we need at least two operations to identify this as a resource
            if (set.Count < 2)
                return false;

            // Check if the request path has even number of segments after the providers segment
            // TODO

            // find put method
            var putOperation = FindOperation(set, HttpMethod.Put);
            if (putOperation != null)
            {
                // we get the response schema name as the resource name
                var response = putOperation.Responses.FirstOrDefault(r =>
                {
                    var statusCodes = r.HttpResponse.StatusCodes;
                    return statusCodes.Contains(Input.StatusCodes._200)
                        || statusCodes.Contains(Input.StatusCodes._201)
                        || statusCodes.Contains(Input.StatusCodes._202);
                });
                // TODO -- we should determine whether this have ID?
                resourceName = response?.ResponseSchema?.Name;
            }

            // TODO -- do we have other criteria?
            return resourceName != null;
        }

        private static Operation? FindOperation(this RawOperationSet set, HttpMethod method)
        {
            foreach (var operationTuple in set)
            {
                var request = operationTuple.Item1.GetHttpRequest();
                if (request?.Method == method)
                    return operationTuple.Item1;
            }

            return null;
        }
    }
}
