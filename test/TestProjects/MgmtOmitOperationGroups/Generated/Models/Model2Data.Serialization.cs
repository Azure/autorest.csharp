// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtOmitOperationGroups.Models;

namespace MgmtOmitOperationGroups
{
    public partial class Model2Data : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(B))
            {
                writer.WritePropertyName("b"u8);
                writer.WriteStringValue(B);
            }
            if (Optional.IsDefined(Modelx))
            {
                writer.WritePropertyName("modelx"u8);
                writer.WriteObjectValue(Modelx);
            }
            writer.WriteEndObject();
        }

        internal static Model2Data DeserializeModel2Data(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> b = default;
            Optional<ModelX> modelx = default;
            Optional<string> f = default;
            Optional<string> g = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("b"u8))
                {
                    b = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modelx"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    modelx = ModelX.DeserializeModelX(property.Value);
                    continue;
                }
                if (property.NameEquals("f"u8))
                {
                    f = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("g"u8))
                {
                    g = property.Value.GetString();
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
            return new Model2Data(id, name, type, systemData.Value, b.Value, modelx.Value, f.Value, g.Value);
        }
    }
}
