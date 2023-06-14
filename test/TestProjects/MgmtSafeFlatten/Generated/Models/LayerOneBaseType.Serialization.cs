// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtSafeFlatten.Models
{
    public partial class LayerOneBaseType : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
            writer.WriteEndObject();
        }

        internal static LayerOneBaseType DeserializeLayerOneBaseType(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("name", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "LayerOneBar": return LayerOneBarType.DeserializeLayerOneBarType(element);
                    case "LayerOneFoo": return LayerOneFooType.DeserializeLayerOneFooType(element);
                }
            }
            return UnknownLayerOneBaseType.DeserializeUnknownLayerOneBaseType(element);
        }
    }
}
