// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ExtensionDetection
    {
        public static bool IsExtension(OperationGroup operationGroup)
        {
            foreach (var keyValue in operationGroup.OperationHttpMethodMapping)
            {
                foreach (var httpRequest in keyValue.Value)
                {
                    bool providerBefore = false;
                    var providerSegmentsList = ((HttpRequest?)httpRequest?.Protocol?.Http)?.ProviderSegments;
                    for (int i = 0; i < providerSegmentsList?.Count; i++)
                    {
                        var segment = providerSegmentsList[i];
                        var areEqual = segment.TokenValue.Equals(operationGroup.ResourceType);
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
