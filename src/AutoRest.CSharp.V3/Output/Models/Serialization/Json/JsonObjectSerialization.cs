// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonObjectSerialization: JsonSerialization
    {
        public JsonObjectSerialization(CSharpType? type, JsonPropertySerialization[] properties, JsonDynamicPropertiesSerialization? additionalProperties, CSharpType? initializeType)
        {
            Type = type;
            Properties = properties;
            AdditionalProperties = additionalProperties;
            InitializeType = initializeType;
        }

        public override CSharpType? Type { get; }
        public CSharpType? InitializeType { get; }
        public JsonPropertySerialization[] Properties { get; }
        public JsonDynamicPropertiesSerialization? AdditionalProperties { get; }
    }
}
