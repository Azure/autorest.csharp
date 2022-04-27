// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using OmitOperationGroups.Models;

namespace OmitOperationGroups
{
    public partial class Model2Data : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(B))
            {
                writer.WritePropertyName("b");
                writer.WriteStringValue(B);
            }
            if (Optional.IsDefined(Modelx))
            {
                writer.WritePropertyName("modelx");
                writer.WriteObjectValue(Modelx);
            }
            writer.WriteEndObject();
        }

        internal static Model2Data DeserializeModel2Data(JsonElement element)
        {
            Optional<string> b = default;
            Optional<ModelX> modelx = default;
            Optional<string> f = default;
            Optional<string> g = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("b"))
                {
                    b = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modelx"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    modelx = ModelX.DeserializeModelX(property.Value);
                    continue;
                }
                if (property.NameEquals("f"))
                {
                    f = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("g"))
                {
                    g = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = (ResourceType)property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
                    continue;
                }
            }
            return new Model2Data(id, name, type, systemData, f.Value, g.Value, b.Value, modelx.Value);
        }
    }
}
