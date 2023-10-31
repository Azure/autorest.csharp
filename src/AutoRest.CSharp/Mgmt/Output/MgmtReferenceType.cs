// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtReferenceType : MgmtObjectType
    {
        public MgmtReferenceType(InputModelType inputModelType, TypeFactory typeFactory, string? name = default, string? nameSpace = default) : base(inputModelType, typeFactory, name, nameSpace)
        {
        }

        protected override bool IsAbstract => !Configuration.SuppressAbstractBaseClasses.Contains(DefaultName) && InputModel.Extensions?.MgmtReferenceType is true;

        public override bool IncludeConverter => (InputModel.Extensions?.MgmtPropertyReferenceType == true || InputModel.Extensions?.MgmtTypeReferenceType == true) && InputModel.Extensions?.MgmtReferenceType != true || base.IncludeConverter;

        protected override ObjectTypeProperty CreatePropertyType(ObjectTypeProperty objectTypeProperty)
        {
            ObjectTypeProperty propertyTypeToUse = objectTypeProperty;

            if (objectTypeProperty.ValueType != null && objectTypeProperty.ValueType.IsFrameworkType)
            {
                propertyTypeToUse = ReferenceTypePropertyChooser.GetExactMatchForReferenceType(objectTypeProperty, objectTypeProperty.ValueType.FrameworkType, MgmtContext.Context) ?? propertyTypeToUse;
            }

            return propertyTypeToUse;
        }

        protected override CSharpType? CreateInheritedType()
        {
            return InputModel.Extensions?.MgmtReferenceType == true ? CreateInheritedTypeWithNoExtraMatch() : base.CreateInheritedType();
        }
    }
}
