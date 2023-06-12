// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class SoftDeleteColumnDeletionDetectionPolicy : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(SoftDeleteColumnName))
            {
                writer.WritePropertyName("softDeleteColumnName"u8);
                writer.WriteStringValue(SoftDeleteColumnName);
            }
            if (Optional.IsDefined(SoftDeleteMarkerValue))
            {
                writer.WritePropertyName("softDeleteMarkerValue"u8);
                writer.WriteStringValue(SoftDeleteMarkerValue);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }

        internal static SoftDeleteColumnDeletionDetectionPolicy DeserializeSoftDeleteColumnDeletionDetectionPolicy(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> softDeleteColumnName = default;
            Optional<string> softDeleteMarkerValue = default;
            string odataType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("softDeleteColumnName"u8))
                {
                    softDeleteColumnName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("softDeleteMarkerValue"u8))
                {
                    softDeleteMarkerValue = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
            }
            return new SoftDeleteColumnDeletionDetectionPolicy(odataType, softDeleteColumnName.Value, softDeleteMarkerValue.Value);
        }
    }
}
