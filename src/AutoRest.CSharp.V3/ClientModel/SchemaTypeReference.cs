// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.ClientModel
{
    internal class SchemaTypeReference: ClientTypeReference
    {
        public Schema Schema { get; }

        public SchemaTypeReference(Schema schema, bool isNullable)
        {
            Schema = schema;
            IsNullable = isNullable;
        }

        public override bool IsNullable { get; }
    }
}
