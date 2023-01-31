// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal class JsonPropertySerialization : PropertySerialization
    {
        public JsonPropertySerialization(string parameterName, string propertyName, string serializedName, CSharpType propertyType, CSharpType? valueType, JsonSerialization valueSerialization, bool isRequired, bool shouldSkipSerialization, bool shouldSkipDeserialization, bool optionalViaNullability)
            : base(propertyName, serializedName, propertyType, valueType, isRequired, shouldSkipSerialization, shouldSkipDeserialization)
        {
            ParameterName = parameterName;
            OptionalViaNullability = optionalViaNullability;
            ValueSerialization = valueSerialization;
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
        public JsonPropertySerialization[]? PropertySerializations { get; }
    }
}
