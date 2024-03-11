// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtReferenceType : MgmtObjectType
    {
        public MgmtReferenceType(InputModelType inputModel, string? name = default, string? nameSpace = default) : base(inputModel, name, nameSpace)
        {
        }

        protected override bool IsAbstract => !Configuration.SuppressAbstractBaseClasses.Contains(DefaultName); // TODO: && InputModel.Extensions?.MgmtReferenceType is true;

        private JsonConverterProvider? _jsonConverter;
        public override JsonConverterProvider? JsonConverter => _jsonConverter ??= BuildJsonConverter();

        private JsonConverterProvider? BuildJsonConverter()
        {
            if (base.JsonConverter != null)
                return base.JsonConverter;

            // TODO: handle the extensions somehow
            //return (ObjectSchema.Extensions?.MgmtPropertyReferenceType == true || ObjectSchema.Extensions?.MgmtTypeReferenceType == true) && ObjectSchema.Extensions?.MgmtReferenceType != true ? new JsonConverterProvider(this, _sourceInputModel) : null;
            return null;
        }

        protected override ObjectTypeProperty CreatePropertyType(ObjectTypeProperty objectTypeProperty)
        {
            ObjectTypeProperty propertyTypeToUse = objectTypeProperty;

            if (objectTypeProperty.ValueType != null && objectTypeProperty.ValueType.IsFrameworkType)
            {
                var newProperty = ReferenceTypePropertyChooser.GetExactMatchForReferenceType(objectTypeProperty, objectTypeProperty.ValueType.FrameworkType, MgmtContext.Context);
                if (newProperty != null)
                {
                    string fullSerializedName = GetFullSerializedName(objectTypeProperty);
                    MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                        new TransformItem(TransformTypeName.ReplacePropertyType, fullSerializedName),
                       fullSerializedName,
                        "ReplacePropertyType", propertyTypeToUse.Declaration.Type.ToString(), newProperty.Declaration.Type.ToString());
                    propertyTypeToUse = newProperty;
                }
            }

            return propertyTypeToUse;
        }

        protected override CSharpType? CreateInheritedType()
        {
            return base.CreateInheritedType();
            // TODO: return InputModel.Extensions?.MgmtReferenceType == true ? CreateInheritedTypeWithNoExtraMatch() : base.CreateInheritedType();
        }

        // the reference types do not need raw data field
        public override ObjectTypeProperty? RawDataField => null;
    }
}
