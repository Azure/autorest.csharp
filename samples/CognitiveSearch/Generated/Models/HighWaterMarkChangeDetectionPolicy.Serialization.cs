// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class HighWaterMarkChangeDetectionPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("highWaterMarkColumnName");
            writer.WriteStringValue(HighWaterMarkColumnName);
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }

        internal static HighWaterMarkChangeDetectionPolicy DeserializeHighWaterMarkChangeDetectionPolicy(JsonElement element)
        {
            string highWaterMarkColumnName = default;
            string odataType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("highWaterMarkColumnName"))
                {
                    highWaterMarkColumnName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
            }
            return new HighWaterMarkChangeDetectionPolicy(odataType, highWaterMarkColumnName);
        }
    }
}
