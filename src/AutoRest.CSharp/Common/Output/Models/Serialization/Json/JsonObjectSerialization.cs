// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal class JsonObjectSerialization
    {
        public JsonObjectSerialization(CSharpType type, ConstructorSignature constructor, JsonPropertySerialization[] properties, JsonAdditionalPropertiesSerialization? additionalProperties, ObjectTypeDiscriminator? discriminator, bool includeConverter)
        {
            Type = type;
            Constructor = constructor;
            Properties = properties;
            AdditionalProperties = additionalProperties;
            Discriminator = discriminator;
            IncludeConverter = includeConverter;
        }

        public CSharpType Type { get; }
        public ConstructorSignature Constructor { get; }
        public JsonPropertySerialization[] Properties { get; }
        public JsonAdditionalPropertiesSerialization? AdditionalProperties { get; }
        public ObjectTypeDiscriminator? Discriminator { get; }
        public bool IncludeConverter { get; }
    }
}
