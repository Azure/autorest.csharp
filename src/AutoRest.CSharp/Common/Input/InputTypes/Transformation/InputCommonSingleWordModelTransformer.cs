// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AutoRest.CSharp.Mgmt.AutoRest;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Common.Input
{
    internal class InputCommonSingleWordModelTransformer
    {
        private static readonly HashSet<string> _schemasToChange = new HashSet<string>()
        {
            "Sku",
            "SkuName",
            "SkuTier",
            "SkuFamily",
            "SkuInformation",
            "Plan",
            "Usage",
            "Resource",
            "Kind",
            // Private endpoint definitions which are defined in swagger common-types/privatelinks.json and are used by RPs
            "PrivateEndpointConnection",
            "PrivateLinkResource",
            "PrivateLinkServiceConnectionState",
            "PrivateEndpointServiceConnectionStatus",
            "PrivateEndpointConnectionProvisioningState",
            // not defined in common-types, but common in various RP
            "PrivateLinkResourceProperties",
            "PrivateLinkServiceConnectionStateProperty",
            // internal, but could be public in the future, also make the names more consistent
            "PrivateEndpointConnectionListResult",
            "PrivateLinkResourceListResult",
            "Severity"
        };

        public static void Transform(InputNamespace inputNamespace)
        {
            foreach (var schemaName in Configuration.MgmtConfiguration.PrependRPPrefix)
            {
                _schemasToChange.Add(schemaName);
            }
            foreach (var model in inputNamespace.Models)
            {
                if (TransformName(model.Name, out var newName))
                {
                    model.Name = newName;
                }
            }

            foreach (var inputEnum in inputNamespace.Enums)
            {
                if (TransformName(inputEnum.Name, out var newName))
                {
                    inputEnum.Name = newName;
                }
            }
        }

        private static bool TransformName(string name, [NotNullWhen(true)]out string? newName)
        {
            newName = null;
            if (!_schemasToChange.Contains(name))
            {
                return false;
            }

            string prefix = Configuration.Namespace.Equals(typeof(ArmClient).Namespace) ? "Arm" : MgmtContext.RPName;
            string suffix = name.EndsWith("Resource") ? "Data" : string.Empty;
            newName = $"{prefix}{name}{suffix}";
            return true;
        }
    }
}
