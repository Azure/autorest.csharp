// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class CommonSingleWordModels
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
            "PrivateLinkResourceListResult"
        };

        public static void Update()
        {
            foreach (var schemaName in Configuration.MgmtConfiguration.PrependRPPrefix)
            {
                _schemasToChange.Add(schemaName);
            }
            foreach (var schema in MgmtContext.CodeModel.AllSchemas)
            {
                if (_schemasToChange.Contains(schema.Name))
                {
                    string prefix = MgmtContext.Context.DefaultNamespace.Equals(typeof(ArmClient).Namespace) ? "Arm" : MgmtContext.RPName;
                    string suffix = schema.Language.Default.Name.Equals("Resource") ? "Data" : string.Empty;
                    schema.Language.Default.Name = prefix + schema.Name + suffix;
                }
            }
        }
    }
}
