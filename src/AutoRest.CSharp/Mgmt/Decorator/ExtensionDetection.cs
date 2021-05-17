// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Concurrent;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ExtensionDetection
    {
        private static ConcurrentDictionary<OperationGroup, bool> _valueCache = new ConcurrentDictionary<OperationGroup, bool>();

        public static bool IsExtensionResource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            bool result;
            if (_valueCache.TryGetValue(operationGroup, out result))
                return result;

            result = IsExtension(operationGroup, config);
            _valueCache.TryAdd(operationGroup, result);
            return result;
        }

        private static bool IsExtension(OperationGroup operationGroup, MgmtConfiguration config)
        {
            foreach (var keyValue in operationGroup.OperationHttpMethodMapping())
            {
                foreach (var httpRequest in keyValue.Value)
                {
                    bool providerBefore = false;
                    var providerSegmentsList = ((HttpRequest?)httpRequest?.Protocol?.Http)?.ProviderSegments();
                    for (int i = 0; i < providerSegmentsList?.Count; i++)
                    {
                        var segment = providerSegmentsList[i];
                        var areEqual = segment.TokenValue.Equals(operationGroup.ResourceType(config));
                        if (areEqual && segment.IsFullProvider && (segment.HadSpecialReference || providerBefore))
                        {
                            return true;
                        }
                        providerBefore = providerBefore || (segment.HasReferenceSuccessor && !areEqual);
                    }
                }
            }
            return false;
        }
    }
}
