// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
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
        public static HashSet<(string NameSpace, string Name)> PropertyReferenceTypeModels = new HashSet<(string NameSpace, string Name)>
        {
            ("Azure.ResourceManager.Models", "ArmPlan"),
            ("Azure.ResourceManager.Models", "ArmSku"),
            ("Azure.ResourceManager.Models", "EncryptionProperties"),
            ("Azure.ResourceManager.Resources.Models","ExtendedLocation"),
            ("Azure.ResourceManager.Models", "ManagedServiceIdentity"),
            ("Azure.ResourceManager.Models", "KeyVaultProperties"),
            ("Azure.ResourceManager.Models", "ResourceProviderData"),
            ("Azure.ResourceManager.Models", "SubResource"),
            ("Azure.ResourceManager.Models", "SystemAssignedServiceIdentity"),
            ("Azure.ResourceManager.Models", "SystemData"),
            ("Azure.ResourceManager.Models", "UserAssignedIdentity"),
            ("Azure.ResourceManager.Models", "WritableSubResource")
        };

        public static HashSet<(string NameSpace, string Name)> TypeReferenceTypeModels = new HashSet<(string NameSpace, string Name)>
        {
            ("Azure.ResourceManager.Models", "OperationStatusResult")
        };

        // ReferenceType is only applied to ResourceData and TrackedResourceData in custom code, not handled by generator

        public MgmtReferenceType(ObjectSchema objectSchema, string? name = default, string? nameSpace = default) : base(objectSchema, name, nameSpace)
        {
            JsonConverter = (ObjectSchema.Extensions?.MgmtPropertyReferenceType == true || ObjectSchema.Extensions?.MgmtTypeReferenceType == true) && ObjectSchema.Extensions?.MgmtReferenceType != true
                ? new JsonConverterProvider(this, _sourceInputModel)
                : null;
        }

        protected override bool IsAbstract => !Configuration.SuppressAbstractBaseClasses.Contains(DefaultName) && ObjectSchema.Extensions?.MgmtReferenceType is true;

        protected override ObjectTypeProperty CreatePropertyType(ObjectTypeProperty objectTypeProperty)
        {
            if (objectTypeProperty.ValueType != null && objectTypeProperty.ValueType.IsFrameworkType)
            {
                var newProperty = ReferenceTypePropertyChooser.GetExactMatchForReferenceType(objectTypeProperty, objectTypeProperty.ValueType.FrameworkType);
                if (newProperty != null)
                {
                    string fullSerializedName = this.GetFullSerializedName(objectTypeProperty);
                    MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                        new TransformItem(TransformTypeName.ReplacePropertyType, fullSerializedName),
                       fullSerializedName,
                        "ReplacePropertyType", objectTypeProperty.Declaration.Type.ToString(), newProperty.Declaration.Type.ToString());
                    return newProperty;
                }
            }

            return objectTypeProperty;
        }

        protected override CSharpType? CreateInheritedType()
        {
            return ObjectSchema.Extensions?.MgmtReferenceType == true ? CreateInheritedTypeWithNoExtraMatch() : base.CreateInheritedType();
        }

        // the reference types do not need raw data field
        public override ObjectTypeProperty? RawDataField => null;
    }
}
