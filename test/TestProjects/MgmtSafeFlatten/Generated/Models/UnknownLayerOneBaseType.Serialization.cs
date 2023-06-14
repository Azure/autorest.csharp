// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtSafeFlatten.Models
{
    internal partial class UnknownLayerOneBaseType : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
            writer.WriteEndObject();
        }

        internal static UnknownLayerOneBaseType DeserializeUnknownLayerOneBaseType(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            LayerOneTypeName name = "Unknown";
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = new LayerOneTypeName(property.Value.GetString());
                    continue;
                }
            }
            return new UnknownLayerOneBaseType(name);
        }
    }
}
