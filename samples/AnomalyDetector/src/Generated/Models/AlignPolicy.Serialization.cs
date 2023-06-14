// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class AlignPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(AlignMode))
            {
                writer.WritePropertyName("alignMode"u8);
                writer.WriteStringValue(AlignMode.Value.ToSerialString());
            }
            if (Optional.IsDefined(FillNAMethod))
            {
                writer.WritePropertyName("fillNAMethod"u8);
                writer.WriteStringValue(FillNAMethod.Value.ToString());
            }
            if (Optional.IsDefined(PaddingValue))
            {
                writer.WritePropertyName("paddingValue"u8);
                writer.WriteNumberValue(PaddingValue.Value);
            }
            writer.WriteEndObject();
        }

        internal static AlignPolicy DeserializeAlignPolicy(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<AlignMode> alignMode = default;
            Optional<FillNAMethod> fillNAMethod = default;
            Optional<float> paddingValue = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("alignMode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    alignMode = property.Value.GetString().ToAlignMode();
                    continue;
                }
                if (property.NameEquals("fillNAMethod"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fillNAMethod = new FillNAMethod(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("paddingValue"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    paddingValue = property.Value.GetSingle();
                    continue;
                }
            }
            return new AlignPolicy(Optional.ToNullable(alignMode), Optional.ToNullable(fillNAMethod), Optional.ToNullable(paddingValue));
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static AlignPolicy FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAlignPolicy(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
