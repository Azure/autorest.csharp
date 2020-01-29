// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.TypeReferences;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonObjectSerialization: JsonSerialization
    {
        public JsonObjectSerialization(TypeReference? type, JsonPropertySerialization[] properties, JsonDynamicPropertiesSerialization? additionalProperties)
        {
            Type = type;
            Properties = properties;
            AdditionalProperties = additionalProperties;
        }

        public override TypeReference? Type { get; }
        public JsonPropertySerialization[] Properties { get; }
        public JsonDynamicPropertiesSerialization? AdditionalProperties { get; }
    }
}
