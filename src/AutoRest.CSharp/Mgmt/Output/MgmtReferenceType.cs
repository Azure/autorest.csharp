// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtReferenceType : MgmtObjectType
    {
        public MgmtReferenceType(MgmtOutputLibrary library, InputModelType inputModelType, TypeFactory typeFactory, SourceInputModel? sourceInputModel, string? name = default, string? nameSpace = default)
            : base(library, inputModelType, typeFactory, sourceInputModel, name, nameSpace)
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
