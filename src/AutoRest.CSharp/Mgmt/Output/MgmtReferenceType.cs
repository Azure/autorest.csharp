// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtReferenceType : MgmtObjectType
    {
        public MgmtReferenceType(InputModelType inputModelType, TypeFactory typeFactory, string? name = default, string? nameSpace = default, SerializableObjectType? defaultDerivedType = null)
            : base(inputModelType, typeFactory, name, nameSpace, defaultDerivedType: defaultDerivedType)
        {
        }

        // TODO: handle extension later
        protected override bool IsAbstract => !Configuration.SuppressAbstractBaseClasses.Contains(DefaultName);// && InputModel.Extensions?.MgmtReferenceType is true;

        protected override ObjectTypeProperty CreatePropertyType(ObjectTypeProperty objectTypeProperty)
        {
            ObjectTypeProperty propertyTypeToUse = objectTypeProperty;

            if (objectTypeProperty.ValueType != null && objectTypeProperty.ValueType.IsFrameworkType)
            {
                var newProperty = ReferenceTypePropertyChooser.GetExactMatchForReferenceType(objectTypeProperty, objectTypeProperty.ValueType.FrameworkType);
                if (newProperty != null)
                {
                    string fullSerializedName = this.GetFullSerializedName(objectTypeProperty);
                    MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                        new TransformItem(TransformTypeName.ReplacePropertyType, fullSerializedName),
                       fullSerializedName,
                        "ReplacePropertyType", propertyTypeToUse.Declaration.Type.ToString(), newProperty.Declaration.Type.ToString());
                    propertyTypeToUse = newProperty;
                }
            }

            return propertyTypeToUse;
        }

        // TODO: handle this later
        //protected override CSharpType? CreateInheritedType()
        //{
        //    return InputModel.Extensions?.MgmtReferenceType == true ? CreateInheritedTypeWithNoExtraMatch() : base.CreateInheritedType();
        //}
    }
}
