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
        public JsonObjectSerialization(SerializableObjectType model, IReadOnlyList<Parameter> constructorParameters, IReadOnlyList<JsonPropertySerialization> properties, JsonAdditionalPropertiesSerialization? additionalProperties, ObjectTypeDiscriminator? discriminator, bool includeConverter)
        {
            Type = model.Type;
            ConstructorParameters = constructorParameters;
            Properties = properties;
            AdditionalProperties = additionalProperties;
            Discriminator = discriminator;
            IncludeConverter = includeConverter;
        }

        public CSharpType Type { get; }
        public IReadOnlyList<Parameter> ConstructorParameters { get; }
        public IReadOnlyList<JsonPropertySerialization> Properties { get; }
        public JsonAdditionalPropertiesSerialization? AdditionalProperties { get; }
        public ObjectTypeDiscriminator? Discriminator { get; }
        public bool IncludeConverter { get; }
    }
}
