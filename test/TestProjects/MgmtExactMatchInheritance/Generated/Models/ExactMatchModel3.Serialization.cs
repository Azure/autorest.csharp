// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtExactMatchInheritance.Models
{
    public partial class ExactMatchModel3 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (New != null)
            {
                writer.WritePropertyName("new"u8);
                writer.WriteStringValue(New);
            }
            if (Id != null)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Name != null)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Bar != null)
            {
                writer.WritePropertyName("bar"u8);
                writer.WriteStringValue(Bar);
            }
            writer.WriteEndObject();
        }

        internal static ExactMatchModel3 DeserializeExactMatchModel3(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string @new = default;
            ResourceIdentifier id = default;
            string name = default;
            string bar = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("new"u8))
                {
                    @new = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("bar"u8))
                {
                    bar = property.Value.GetString();
                    continue;
                }
            }
            return new ExactMatchModel3(id, name, bar, @new);
        }
    }
}
