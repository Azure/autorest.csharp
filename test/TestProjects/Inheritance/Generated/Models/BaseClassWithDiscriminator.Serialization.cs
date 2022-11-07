// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Inheritance.Models
{
    public partial class BaseClassWithDiscriminator : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("DiscriminatorProperty");
            writer.WriteStringValue(DiscriminatorProperty);
            if (Optional.IsDefined(BaseClassProperty))
            {
                writer.WritePropertyName("BaseClassProperty");
                writer.WriteStringValue(BaseClassProperty);
            }
            writer.WriteEndObject();
        }

        internal static BaseClassWithDiscriminator DeserializeBaseClassWithDiscriminator(JsonElement element)
        {
            if (element.TryGetProperty("DiscriminatorProperty", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "ClassThatInheritsFromBaseClassWithDiscriminator": return ClassThatInheritsFromBaseClassWithDiscriminator.DeserializeClassThatInheritsFromBaseClassWithDiscriminator(element);
                    case "ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties": return ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties.DeserializeClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties(element);
                }
            }
            return UnknownBaseClassWithDiscriminator.DeserializeUnknownBaseClassWithDiscriminator(element);
        }
    }
}
