
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License
using System;
using System.Collections.Generic;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Output.Models.Type.Decorate
{
    internal class TenantDetection
    {
        public static bool IsTenantOnly(OperationGroup operationGroup)
        {
            bool foundTenant = false;
            foreach (var keyValue in operationGroup.OperationHttpMethodMapping)
            {
                foreach (var httpRequest in keyValue.Value)
                {
                    var providerSegmentsList = ((HttpRequest?)httpRequest?.Protocol?.Http)?.ProviderSegments;
                    for (int i = 0; i < providerSegmentsList?.Count; i++)
                    {
                        var segment = providerSegmentsList[i];
                        if (segment.TokenValue.Equals(operationGroup.ResourceType) && segment.IsFullProvider)
                        {
                            foundTenant = foundTenant || segment.NoPredecessor;
                            if (!segment.NoPredecessor)
                            {
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            return foundTenant;
        }
    }
}
