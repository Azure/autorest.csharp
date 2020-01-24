// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class EnumType : ISchemaType
    {
        public EnumType(Schema schema, TypeDeclarationOptions declarationOptions, string? description, IEnumerable<EnumTypeValue> values, bool isStringBased = false)
        {
            Schema = schema;
            Declaration = declarationOptions;
            Description = description;
            Values = new List<EnumTypeValue>(values);
            IsStringBased = isStringBased;
        }

        public bool IsStringBased { get; }
        public Schema Schema { get; }
        public TypeDeclarationOptions Declaration { get; }
        public string? Description { get; }
        public IList<EnumTypeValue> Values { get; }
        public CSharpType Type => new CSharpType(Declaration.Namespace, Declaration.Name, isValueType: true);
    }
}
