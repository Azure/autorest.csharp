// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtReferenceType : MgmtObjectType
    {
        public MgmtReferenceType(ObjectSchema objectSchema, BuildContext<MgmtOutputLibrary> context)
            : base(objectSchema, context)
        {
        }

        public override bool IncludeConverter => ObjectSchema.Extensions?.MgmtPropertyReferenceType == true && ObjectSchema.Extensions?.MgmtReferenceType != true || base.IncludeConverter;

        protected override ObjectTypeProperty CreatePropertyType(ObjectTypeProperty objectTypeProperty)
        {
            ObjectTypeProperty propertyTypeToUse = objectTypeProperty;

            if (objectTypeProperty.ValueType != null && objectTypeProperty.ValueType.IsFrameworkType && objectTypeProperty.ValueType.FrameworkType == typeof(string))
            {
                propertyTypeToUse = ReferenceTypePropertyChooser.GetExactMatchForReferenceType(objectTypeProperty, Context) ?? propertyTypeToUse;
            }

            return propertyTypeToUse;
        }
    }
}
