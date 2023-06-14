// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Inheritance.Models
{
    public partial class SomeProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(SomeProperty))
            {
                writer.WritePropertyName("SomeProperty"u8);
                writer.WriteStringValue(SomeProperty);
            }
            if (Optional.IsDefined(SomeOtherProperty))
            {
                writer.WritePropertyName("SomeOtherProperty"u8);
                writer.WriteStringValue(SomeOtherProperty);
            }
            writer.WriteEndObject();
        }

        internal static SomeProperties DeserializeSomeProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> someProperty = default;
            Optional<string> someOtherProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("SomeProperty"u8))
                {
                    someProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("SomeOtherProperty"u8))
                {
                    someOtherProperty = property.Value.GetString();
                    continue;
                }
            }
            return new SomeProperties(someProperty.Value, someOtherProperty.Value);
        }
    }
}
