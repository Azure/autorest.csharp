// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class SoftDeleteColumnDeletionDetectionPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
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

        internal static SoftDeleteColumnDeletionDetectionPolicy DeserializeSoftDeleteColumnDeletionDetectionPolicy(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string softDeleteColumnName = default;
            string softDeleteMarkerValue = default;
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
            return new SoftDeleteColumnDeletionDetectionPolicy(odataType, softDeleteColumnName, softDeleteMarkerValue);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new SoftDeleteColumnDeletionDetectionPolicy FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, new JsonDocumentOptions { MaxDepth = 256 });
            return DeserializeSoftDeleteColumnDeletionDetectionPolicy(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
