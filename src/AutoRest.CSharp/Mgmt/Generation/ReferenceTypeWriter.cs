// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ReferenceTypeWriter : ModelWriter
    {
        protected override void AddClassAttributes(CodeWriter writer, ObjectType objectType)
        {
            if (objectType is not SchemaObjectType schema)
                return;

            if (MgmtReferenceType.IsPropertyReferenceType(schema.InputModel))
            {
                if (Configuration.IsBranded)
                {
                    writer.UseNamespace("Azure.Core");
                }
                writer.Line($"[{ReferenceClassFinder.PropertyReferenceTypeAttribute}]");
            }
            else if (MgmtReferenceType.IsTypeReferenceType(schema.InputModel))
            {
                if (Configuration.IsBranded)
                {
                    writer.UseNamespace("Azure.Core");
                }
                writer.Line($"[{ReferenceClassFinder.TypeReferenceTypeAttribute}]");
            }
            else if (MgmtReferenceType.IsReferenceType(schema.InputModel))
            {
                if (Configuration.IsBranded)
                {
                    writer.UseNamespace("Azure.Core");
                }

                // The hard-coded string input is needed for ReferenceTypeAttribute to work, and this only applies to ResourceData and TrackedResourceData now.
                writer.Line($"[{ReferenceClassFinder.ReferenceTypeAttribute}(new string[]{{\"SystemData\"}})]");
            }
        }

        protected override void AddCtorAttribute(CodeWriter writer, ObjectType schema, ObjectTypeConstructor constructor)
        {
            if (constructor == schema.InitializationConstructor)
            {
                writer.Line($"[{ReferenceClassFinder.InitializationCtorAttribute}]");
            }
            else if (constructor == schema.SerializationConstructor)
            {
                writer.Line($"[{ReferenceClassFinder.SerializationCtorAttribute}]");
            }
        }
    }
}
