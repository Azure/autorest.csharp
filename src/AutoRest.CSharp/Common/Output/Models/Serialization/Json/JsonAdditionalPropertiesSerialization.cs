// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal class JsonAdditionalPropertiesSerialization : JsonPropertySerialization
    {
        public CSharpType Type { get; }

        public JsonAdditionalPropertiesSerialization(ObjectTypeProperty property, JsonSerialization valueSerialization, CSharpType type)
            : base(property.Declaration.Name.ToVariableName(), property.Declaration.Name, property.Declaration.Name, property.Declaration.Type, property.ValueType, valueSerialization, true, property.IsReadOnly, false, property.OptionalViaNullability)
        {
            Type = type;
        }
    }
}
