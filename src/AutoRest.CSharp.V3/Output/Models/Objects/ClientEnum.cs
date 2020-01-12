// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientEnum : ISchemaTypeProvider
    {
        public ClientEnum(Schema schema, string name, string? description, IEnumerable<ClientEnumValue> values, bool isStringBased = false)
        {
            Schema = schema;
            Name = name;
            Description = description;
            Values = new List<ClientEnumValue>(values);
            IsStringBased = isStringBased;
        }

        public bool IsStringBased { get; }
        public Schema Schema { get; }
        public string Name { get; }
        public string? Description { get; }
        public IList<ClientEnumValue> Values { get; }
    }
}
