// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtSafeFlatten.Models
{
    internal partial class LayerOneSingle : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(LayerTwo))
            {
                writer.WritePropertyName("layerTwo"u8);
                writer.WriteObjectValue(LayerTwo);
            }
            writer.WriteEndObject();
        }

        internal static LayerOneSingle DeserializeLayerOneSingle(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<LayerTwoSingle> layerTwo = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("layerTwo"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    layerTwo = LayerTwoSingle.DeserializeLayerTwoSingle(property.Value);
                    continue;
                }
            }
            return new LayerOneSingle(layerTwo.Value);
        }
    }
}
