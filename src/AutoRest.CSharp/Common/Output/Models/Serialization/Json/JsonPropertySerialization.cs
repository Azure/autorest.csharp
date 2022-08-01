// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal class JsonPropertySerialization : PropertySerialization
    {
        public JsonPropertySerialization(string propertyName, string serializedName, CSharpType propertyType, CSharpType? valueType, JsonSerialization valueSerialization, bool isRequired, bool isReadOnly, bool optionalViaNullability)
            : base(propertyName, serializedName, propertyType, valueType, isRequired, isReadOnly)
        {
            OptionalViaNullability = optionalViaNullability;
            ValueSerialization = valueSerialization;
        }

        public JsonPropertySerialization(string serializedName, bool isRequired, bool isReadOnly, ObjectTypeProperty property, JsonSerialization valueSerialization)
            : base(property.Declaration.Name, serializedName, property.Declaration.Type, property.ValueType, isRequired, isReadOnly)
        {
            OptionalViaNullability = property.OptionalViaNullability;
            ValueSerialization = valueSerialization;
        }

        public JsonPropertySerialization(string serializedName, JsonPropertySerialization[] propertySerializations)
            : base(serializedName, serializedName, typeof(object), null, false, false)
        {
            PropertySerializations = propertySerializations;
        }

        public bool OptionalViaNullability { get; }
        public JsonSerialization? ValueSerialization { get; }
        public JsonPropertySerialization[]? PropertySerializations { get; }
    }
}
