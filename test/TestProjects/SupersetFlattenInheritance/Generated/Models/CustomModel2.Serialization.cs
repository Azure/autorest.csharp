// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace SupersetFlattenInheritance.Models
{
    public partial class CustomModel2 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(Bar))
            {
                writer.WritePropertyName("bar");
                writer.WriteStringValue(Bar);
            }
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(IdPropertiesId))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(IdPropertiesId);
            }
            if (Optional.IsDefined(Foo))
            {
                writer.WritePropertyName("foo");
                writer.WriteStringValue(Foo);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static CustomModel2 DeserializeCustomModel2(JsonElement element)
        {
            Optional<string> id = default;
            Optional<string> bar = default;
            Optional<string> id0 = default;
            Optional<string> foo = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("bar"))
                {
                    bar = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("id"))
                        {
                            id0 = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("foo"))
                        {
                            foo = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new CustomModel2(id.Value, bar.Value, id0.Value, foo.Value);
        }
    }
}
