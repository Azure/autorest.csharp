// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtSafeFlatten.Models;

namespace MgmtSafeFlatten
{
    public partial class TypeOneData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(MyType))
            {
                writer.WritePropertyName("MyType"u8);
                writer.WriteStringValue(MyType);
            }
            if (Optional.IsDefined(LayerOne))
            {
                writer.WritePropertyName("layerOne"u8);
                writer.WriteObjectValue(LayerOne);
            }
            if (Optional.IsDefined(LayerOneType))
            {
                writer.WritePropertyName("layerOneType"u8);
                writer.WriteObjectValue(LayerOneType);
            }
            if (Optional.IsDefined(LayerOneConflict))
            {
                writer.WritePropertyName("layerOneConflict"u8);
                JsonSerializer.Serialize(writer, LayerOneConflict);
            }
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            writer.WriteEndObject();
        }

        internal static TypeOneData DeserializeTypeOneData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> myType = default;
            Optional<LayerOneSingle> layerOne = default;
            Optional<LayerOneBaseType> layerOneType = default;
            Optional<WritableSubResource> layerOneConflict = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("MyType"u8))
                {
                    myType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("layerOne"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    layerOne = LayerOneSingle.DeserializeLayerOneSingle(property.Value);
                    continue;
                }
                if (property.NameEquals("layerOneType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    layerOneType = LayerOneBaseType.DeserializeLayerOneBaseType(property.Value);
                    continue;
                }
                if (property.NameEquals("layerOneConflict"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    layerOneConflict = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
            }
            return new TypeOneData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, myType.Value, layerOne.Value, layerOneType.Value, layerOneConflict);
        }
    }
}
