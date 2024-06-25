// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Mgmt.AutoRest;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Common.Input
{
    internal class CommonSingleWordModelTransformer
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

        public static void Transform(InputNamespace input)
        {
            TransformCommonSingleWord(input);
        }

        private static void TransformCommonSingleWord(InputNamespace inputNamespace)
        {
            foreach (var schemaName in Configuration.MgmtConfiguration.PrependRPPrefix)
            {
                _schemasToChange.Add(schemaName);
            }

            foreach (var model in inputNamespace.Models)
            {
                TransformCommonSingleWord(model);
            }

            foreach (var enumType in inputNamespace.Enums)
            {
                TransformCommonSingleWord(enumType);
            }
        }

        private static void TransformCommonSingleWord(InputModelType inputModelType)
        {
            if (_schemasToChange.Contains(inputModelType.Name))
            {
                string prefix = Configuration.Namespace.Equals(typeof(ArmClient).Namespace) ? "Arm" : MgmtContext.RPName;
                string suffix = inputModelType.Name.Equals("Resource") ? "Data" : string.Empty;
                inputModelType.Name = prefix + inputModelType.Name + suffix;
            }
        }

        private static void TransformCommonSingleWord(InputEnumType inputEnumType)
        {
            if (_schemasToChange.Contains(inputEnumType.Name))
            {
                string prefix = Configuration.Namespace.Equals(typeof(ArmClient).Namespace) ? "Arm" : MgmtContext.RPName;
                string suffix = inputEnumType.Name.Equals("Resource") ? "Data" : string.Empty;
                inputEnumType.Name = prefix + inputEnumType.Name + suffix;
            }
        }
    }
}
