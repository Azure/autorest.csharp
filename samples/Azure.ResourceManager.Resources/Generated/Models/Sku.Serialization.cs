// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class Sku : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(Tier))
            {
                writer.WritePropertyName("tier");
                writer.WriteStringValue(Tier);
            }
            if (Optional.IsDefined(Size))
            {
                writer.WritePropertyName("size");
                writer.WriteStringValue(Size);
            }
            if (Optional.IsDefined(Family))
            {
                writer.WritePropertyName("family");
                writer.WriteStringValue(Family);
            }
            if (Optional.IsDefined(Model))
            {
                writer.WritePropertyName("model");
                writer.WriteStringValue(Model);
            }
            if (Optional.IsDefined(Capacity))
            {
                writer.WritePropertyName("capacity");
                writer.WriteNumberValue(Capacity.Value);
            }
            writer.WriteEndObject();
        }

        internal static Sku DeserializeSku(JsonElement element)
        {
            string name = default;
            Optional<string> tier = default;
            Optional<string> size = default;
            Optional<string> family = default;
            Optional<string> model = default;
            Optional<long> capacity = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tier"))
                {
                    tier = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("size"))
                {
                    size = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("family"))
                {
                    family = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("model"))
                {
                    model = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("capacity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    capacity = property.Value.GetInt64();
                    continue;
                }
            }
            return new Sku(name, tier.Value, size.Value, family.Value, model.Value, Optional.ToNullable(capacity));
        }
    }
}
