// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonObjectSerialization: JsonSerialization
    {
        public JsonObjectSerialization(CSharpType? type, JsonPropertySerialization[] properties, JsonAdditionalPropertiesSerialization? additionalProperties, CSharpType? implementationType)
        {
            Type = type;
            Properties = properties;
            AdditionalProperties = additionalProperties;
            ImplementationType = implementationType;
        }

        public override CSharpType? Type { get; }
        public CSharpType? ImplementationType { get; }
        public JsonPropertySerialization[] Properties { get; }
        public JsonAdditionalPropertiesSerialization? AdditionalProperties { get; }
    }
}
