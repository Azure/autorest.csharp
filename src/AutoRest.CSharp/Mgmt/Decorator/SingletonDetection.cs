// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Concurrent;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Resources.Models;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class SingletonDetection
    {
        private static ConcurrentDictionary<string, bool> _valueCache = new ConcurrentDictionary<string, bool>();

        public static bool IsSingletonResource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            return SingletonDetection.IsSingletonResource(operationGroup.Resource(config), config);
        }

        public static bool IsSingletonResource(this TypeProvider resource, MgmtConfiguration config)
        {
            return SingletonDetection.IsSingletonResource(resource.Type.Name, config);
        }

        private static bool IsSingletonResource(string resourceName, MgmtConfiguration config)
        {
            if (_valueCache.TryGetValue(resourceName, out var result))
                return result;

            result = config.SingletonResource.Contains(resourceName);
            _valueCache.TryAdd(resourceName, result);
            return result;
        }
    }
}
