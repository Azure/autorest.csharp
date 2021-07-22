// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Concurrent;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class SingletonDetection
    {
        private static string[] SingletonKeywords = { "/default", "/latest" };

        private static ConcurrentDictionary<OperationGroup, bool> _valueCache = new ConcurrentDictionary<OperationGroup, bool>();

        public static bool IsSingletonResource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            if (_valueCache.TryGetValue(operationGroup, out var result))
                return result;

            result = IsSingleton(operationGroup, config);
            _valueCache.TryAdd(operationGroup, result);
            return result;
        }

        private static bool IsSingleton(OperationGroup operationGroup, MgmtConfiguration config)
        {
            if (operationGroup.TryGetResourceName(config, out var resourceName))
            {
                foreach (var operation in operationGroup.Operations)
                {
                    // Check to see if any GET operation path ends with Singleton keywords
                    if (!operation.IsLongRunning
                        && operation.Requests.FirstOrDefault()?.Protocol.Http is HttpRequest httpRequest
                        && httpRequest.Method == HttpMethod.Get
                        // the returned data schema should be the type of the Resource of the operation group
                        && operation.GetSuccessfulQueryResponse()?.ResponseSchema?.Name == resourceName
                        && SingletonKeywords.Any(w => httpRequest.Path.EndsWith(w)))
                    {
                        return true;
                    }
                }

                // if no match found, we get the resource schema name first
                // and see if the operation group's resource has been set to singleton in config
                return config.SingletonResource.Contains(resourceName);
            }

            return false;
        }
    }
}
