// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

namespace AutoRest.CodeModel
{
    internal class CustomPropertyNameGenerator : CSharpPropertyNameGenerator
    {
        public override string Generate(JsonSchemaProperty property)
        {
            if (property.IsArray)
            {
                property.IsRequired = true;
            }

            if (property.Name == "csharp")
            {
                return "CSharp";
            }
            return base.Generate(property);
        }
    }
}
