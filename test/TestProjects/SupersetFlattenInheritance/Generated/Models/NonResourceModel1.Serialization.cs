// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace SupersetFlattenInheritance.Models
{
    public partial class NonResourceModel1 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Bar))
            {
                writer.WritePropertyName("bar");
                writer.WriteStringValue(Bar);
            }
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(Foo))
            {
                writer.WritePropertyName("foo");
                writer.WriteStringValue(Foo);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static NonResourceModel1 DeserializeNonResourceModel1(JsonElement element)
        {
            Optional<string> bar = default;
            Optional<string> foo = default;
            foreach (var property in element.EnumerateObject())
            {
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
                        if (property0.NameEquals("foo"))
                        {
                            foo = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new NonResourceModel1(bar.Value, foo.Value);
        }
    }
}
