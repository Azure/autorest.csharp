﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtReferenceType : MgmtObjectType
    {
        private static HashSet<string> PropertyReferenceTypeModels = new HashSet<string>
        {
            "Azure.ResourceManager.Models.ArmPlan",
            "Azure.ResourceManager.Models.ArmSku",
            "Azure.ResourceManager.Models.EncryptionProperties",
            "Azure.ResourceManager.Resources.Models.ExtendedLocation",
            "Azure.ResourceManager.Models.ManagedServiceIdentity",
            "Azure.ResourceManager.Models.KeyVaultProperties",
            "Azure.ResourceManager.Resources.ResourceProviderData",
            "Azure.ResourceManager.Models.SystemAssignedServiceIdentity",
            "Azure.ResourceManager.Models.SystemData",
            "Azure.ResourceManager.Models.UserAssignedIdentity",
            "Azure.ResourceManager.Resources.Models.WritableSubResource"
        };

        private static HashSet<string> TypeReferenceTypeModels = new HashSet<string>
        {
            "Azure.ResourceManager.Models.OperationStatusResult"
        };

        private static HashSet<string> ReferenceTypeModels = new HashSet<string>
        {
            "Azure.ResourceManager.Models.ResourceData",
            "Azure.ResourceManager.Models.TrackedResourceData"
        };

        public static bool IsPropertyReferenceType(Schema schema)
            => PropertyReferenceTypeModels.Contains($"{GetNamespace(schema)}.{schema.Language.Default.Name}");

        public static bool IsTypeReferenceType(Schema schema)
            => TypeReferenceTypeModels.Contains($"{GetNamespace(schema)}.{schema.Language.Default.Name}");

        public static bool IsReferenceType(ObjectType schema)
            => ReferenceTypeModels.Contains($"{schema.Declaration.Namespace}.{schema.Declaration.Name}");

        public static bool IsReferenceType(Schema schema)
            => ReferenceTypeModels.Contains($"{GetNamespace(schema)}.{schema.Language.Default.Name}");

        private static string GetNamespace(Schema schema)
        {
            if (!string.IsNullOrEmpty(schema.Extensions?.Namespace))
            {
                return schema.Extensions.Namespace;
            }

            if (!string.IsNullOrEmpty(schema.Language.Default.Namespace))
            {
                return schema.Language.Default.Namespace;
            }

            return $"{Configuration.Namespace}.Models";
        }

        public MgmtReferenceType(ObjectSchema objectSchema, string? name = default, string? nameSpace = default) : base(objectSchema, name, nameSpace)
        {
            JsonConverter = (IsPropertyReferenceType(objectSchema) || IsTypeReferenceType(ObjectSchema))
                ? new JsonConverterProvider(this, _sourceInputModel)
                : null;
        }

        protected override ObjectTypeProperty CreatePropertyType(ObjectTypeProperty objectTypeProperty)
        {
            if (objectTypeProperty.ValueType != null && objectTypeProperty.ValueType.IsFrameworkType)
            {
                var newProperty = ReferenceTypePropertyChooser.GetExactMatchForReferenceType(objectTypeProperty, objectTypeProperty.ValueType.FrameworkType);
                if (newProperty != null)
                {
                    string fullSerializedName = GetFullSerializedName(objectTypeProperty);
                    MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                        new TransformItem(TransformTypeName.ReplacePropertyType, fullSerializedName),
                       fullSerializedName,
                        "ReplacePropertyType", objectTypeProperty.Declaration.Type.ToString(), newProperty.Declaration.Type.ToString());
                    return newProperty;
                }
            }

            return objectTypeProperty;
        }

        protected override CSharpType? CreateInheritedType() => base.CreateInheritedType();

        // the reference types do not need raw data field
        public override ObjectTypeProperty? RawDataField => null;
    }
}
