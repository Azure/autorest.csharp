// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtExactMatchFlattenInheritance.Models
{
    public partial class AzureResourceFlattenModel4 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Foo))
            {
                writer.WritePropertyName("foo"u8);
                writer.WriteNumberValue(Foo.Value);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(ResourceType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static AzureResourceFlattenModel4 DeserializeAzureResourceFlattenModel4(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> foo = default;
            Optional<string> id = default;
            Optional<string> name = default;
            Optional<string> type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("foo"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    foo = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("id"u8))
                        {
                            id = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("name"u8))
                        {
                            name = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("type"u8))
                        {
                            type = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new AzureResourceFlattenModel4(Optional.ToNullable(foo), id.Value, name.Value, type.Value);
        }
    }
}
