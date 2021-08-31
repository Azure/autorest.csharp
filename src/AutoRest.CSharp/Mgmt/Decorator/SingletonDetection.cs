// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class SingletonDetection
    {
        private static string[] SingletonKeywords = { "/default", "/latest" };

        private static ConcurrentDictionary<OperationGroup, string?> _valueCache = new ConcurrentDictionary<OperationGroup, string?>();

        public static bool IsSingletonResource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            return TryGetSingletonResourceSuffix(operationGroup, config, out _);
        }

        public static bool TryGetSingletonResourceSuffix(this OperationGroup operationGroup, MgmtConfiguration config, [MaybeNullWhen(false)] out string resourceSuffix)
        {
            resourceSuffix = null;
            if (_valueCache.TryGetValue(operationGroup, out resourceSuffix))
            {
                return resourceSuffix != null;
            }

            bool result = IsSingleton(operationGroup, config, out resourceSuffix);
            _valueCache.TryAdd(operationGroup, resourceSuffix);
            return result;
        }

        private static bool IsSingleton(OperationGroup operationGroup, MgmtConfiguration config, [MaybeNullWhen(false)] out string resourceSuffix)
        {
            // we should first check the configuration for the singleton settings, if we get none, we could try to deduce this from its path
            if (config.OperationGroupToSingletonResource.TryGetValue(operationGroup.Key, out resourceSuffix))
            {
                // ensure the resourceSuffix does not a slash at the beginning
                resourceSuffix = resourceSuffix.TrimStart('/');
                return true;
            }

            // we cannot find the corresponding operation group in the configuration, trying to deduce from the path
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
                        // the path ends with our singleton keyword, now we need to get the last two segments of it
                        var segments = httpRequest.Path.Split("/");
                        if (segments.Length < 2)
                            return false;
                        resourceSuffix = string.Join('/', segments.TakeLast(2));
                        return true;
                    }
                }
            }

            // if no match found, return false and null
            return false;
        }
    }
}
