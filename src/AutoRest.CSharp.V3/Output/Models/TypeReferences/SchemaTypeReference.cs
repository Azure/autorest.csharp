// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Input;

namespace AutoRest.CSharp.V3.Output.Models.TypeReferences
{
    internal class SchemaTypeReference: TypeReference
    {
        public SchemaTypeReference(Schema? schema, bool isNullable)
        {
            Schema = schema;
            IsNullable = isNullable;
        }

        public Schema? Schema { get; }
        public override bool IsNullable { get; }
    }
}
