// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Report;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Common.Input
{
    internal class InputTypeTransformer
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
            string serializedName = inputModelType.SpecName ?? inputModelType.Name;
            if (_schemasToChange.Contains(serializedName))
            {
                string oriName = inputModelType.Name;
                string prefix = Configuration.Namespace.Equals(typeof(ArmClient).Namespace) ? "Arm" : MgmtContext.RPName;
                string suffix = serializedName.Equals("Resource") ? "Data" : string.Empty;
                inputModelType.SpecName ??= inputModelType.Name;
                inputModelType.Name = prefix + serializedName + suffix;
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                    new TransformItem(TransformTypeName.PrependRpPrefix, serializedName), inputModelType.SpecName, "ApplyPrependRpPrefix", oriName, inputModelType.Name);
            }
        }

        private static void TransformCommonSingleWord(InputEnumType inputEnumType)
        {
            string serializedName = inputEnumType.SpecName ?? inputEnumType.Name;
            if (_schemasToChange.Contains(serializedName))
            {
                string oriName = inputEnumType.Name;
                string prefix = Configuration.Namespace.Equals(typeof(ArmClient).Namespace) ? "Arm" : MgmtContext.RPName;
                string suffix = serializedName.Equals("Resource") ? "Data" : string.Empty;
                inputEnumType.SpecName ??= inputEnumType.Name;
                inputEnumType.Name = prefix + serializedName + suffix;
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                    new TransformItem(TransformTypeName.PrependRpPrefix, serializedName), inputEnumType.SpecName, "ApplyPrependRpPrefix", oriName, inputEnumType.Name);
            }
        }
    }
}
