// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class SoftDeleteColumnDeletionDetectionPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (SoftDeleteColumnName != null)
            {
                writer.WritePropertyName("softDeleteColumnName");
                writer.WriteStringValue(SoftDeleteColumnName);
            }
            if (SoftDeleteMarkerValue != null)
            {
                writer.WritePropertyName("softDeleteMarkerValue");
                writer.WriteStringValue(SoftDeleteMarkerValue);
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }
        internal static SoftDeleteColumnDeletionDetectionPolicy DeserializeSoftDeleteColumnDeletionDetectionPolicy(JsonElement element)
        {
            SoftDeleteColumnDeletionDetectionPolicy result = new SoftDeleteColumnDeletionDetectionPolicy();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("softDeleteColumnName"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.SoftDeleteColumnName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("softDeleteMarkerValue"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.SoftDeleteMarkerValue = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
