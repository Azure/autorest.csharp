// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal class JsonPropertySerialization : PropertySerialization
    {
        public JsonPropertySerialization(string parameterName, string propertyName, string serializedName, CSharpType propertyType, CSharpType? valueType, JsonSerialization valueSerialization, bool isRequired, bool shouldSkipSerialization, bool shouldSkipDeserialization, bool optionalViaNullability, string? serializationHook = null, string? serializationValueHook = null, string? deserializationValueHook = null)
            : base(propertyName, serializedName, propertyType, valueType, isRequired, shouldSkipSerialization, shouldSkipDeserialization)
        {
            ParameterName = parameterName;
            OptionalViaNullability = optionalViaNullability;
            ValueSerialization = valueSerialization;
            SerializationHook = serializationHook;
            SerializationValueHook = serializationValueHook;
            DeserializationValueHook = deserializationValueHook;
        }

        public JsonPropertySerialization(string serializedName, JsonPropertySerialization[] propertySerializations)
            : base(serializedName, serializedName, typeof(object), null, false, false)
        {
            ParameterName = string.Empty;
            PropertySerializations = propertySerializations;
        }

        public string ParameterName { get;  }
        public bool OptionalViaNullability { get; }
        public JsonSerialization? ValueSerialization { get; }
        /// <summary>
        /// This is not null when the property is flattened in generated client SDK `x-ms-client-flatten: true`
        /// </summary>
        public JsonPropertySerialization[]? PropertySerializations { get; }

        public string? SerializationHook { get; }

        public string? SerializationValueHook { get; }

        public string? DeserializationValueHook { get; }
    }
}
