// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal record JsonObjectSerialization
    {
        public JsonObjectSerialization(SerializableObjectType model, IReadOnlyList<Parameter> constructorParameters, IReadOnlyList<JsonPropertySerialization> properties, IReadOnlyList<JsonPropertySerialization> selfProperties, JsonAdditionalPropertiesSerialization? additionalProperties, JsonAdditionalPropertiesSerialization? rawDataField, ObjectTypeDiscriminator? discriminator, JsonConverterProvider? jsonConverter)
        {
            Type = model.Type;
            ConstructorParameters = constructorParameters;
            Properties = properties;
            SelfProperties = selfProperties;
            AdditionalProperties = additionalProperties;
            RawDataField = rawDataField;
            Discriminator = discriminator;
            JsonConverter = jsonConverter;
        }

        public CSharpType Type { get; }
        public IReadOnlyList<Parameter> ConstructorParameters { get; }
        public IReadOnlyList<JsonPropertySerialization> Properties { get; }
        public IReadOnlyList<JsonPropertySerialization> SelfProperties { get; }
        public JsonAdditionalPropertiesSerialization? AdditionalProperties { get; }
        public JsonAdditionalPropertiesSerialization? RawDataField { get; }
        public ObjectTypeDiscriminator? Discriminator { get; }
        public JsonConverterProvider? JsonConverter { get; }
    }
}
