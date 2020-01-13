// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.V3.Input.Generated;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class EnumType : ISchemaType
    {
        public EnumType(Schema schema, string name, string? description, IEnumerable<EnumTypeValue> values, bool isStringBased = false)
        {
            Schema = schema;
            Name = name;
            Description = description;
            Values = new List<EnumTypeValue>(values);
            IsStringBased = isStringBased;
        }

        public bool IsStringBased { get; }
        public Schema Schema { get; }
        public string Name { get; }
        public string? Description { get; }
        public IList<EnumTypeValue> Values { get; }
    }
}
