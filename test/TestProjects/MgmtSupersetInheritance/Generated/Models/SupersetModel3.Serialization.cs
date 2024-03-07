// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using MgmtSupersetInheritance;

namespace MgmtSupersetInheritance.Models
{
    public partial class SupersetModel3 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteNumberValue(Id.Value);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(SupersetModel3Type))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(SupersetModel3Type);
            }
            if (Optional.IsDefined(New))
            {
                writer.WritePropertyName("new"u8);
                writer.WriteStringValue(New);
            }
            writer.WriteEndObject();
        }

        internal static SupersetModel3 DeserializeSupersetModel3(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? id = default;
            string name = default;
            string type = default;
            string @new = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("new"u8))
                {
                    @new = property.Value.GetString();
                    continue;
                }
            }
            return new SupersetModel3(id, name, type, @new);
        }
    }
}
