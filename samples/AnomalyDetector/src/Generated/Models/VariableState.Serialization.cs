// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace AnomalyDetector.Models
{
    public partial class VariableState : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Variable))
            {
                writer.WritePropertyName("variable"u8);
                writer.WriteStringValue(Variable);
            }
            if (Optional.IsDefined(FilledNARatio))
            {
                writer.WritePropertyName("filledNARatio"u8);
                writer.WriteNumberValue(FilledNARatio.Value);
            }
            if (Optional.IsDefined(EffectiveCount))
            {
                writer.WritePropertyName("effectiveCount"u8);
                writer.WriteNumberValue(EffectiveCount.Value);
            }
            if (Optional.IsDefined(FirstTimestamp))
            {
                writer.WritePropertyName("firstTimestamp"u8);
                writer.WriteStringValue(FirstTimestamp.Value, "O");
            }
            if (Optional.IsDefined(LastTimestamp))
            {
                writer.WritePropertyName("lastTimestamp"u8);
                writer.WriteStringValue(LastTimestamp.Value, "O");
            }
            writer.WriteEndObject();
        }

        internal static VariableState DeserializeVariableState(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> variable = default;
            Optional<float> filledNARatio = default;
            Optional<int> effectiveCount = default;
            Optional<DateTimeOffset> firstTimestamp = default;
            Optional<DateTimeOffset> lastTimestamp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("variable"u8))
                {
                    variable = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("filledNARatio"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    filledNARatio = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("effectiveCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    effectiveCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("firstTimestamp"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    firstTimestamp = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastTimestamp"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastTimestamp = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new VariableState(variable, Optional.ToNullable(filledNARatio), Optional.ToNullable(effectiveCount), Optional.ToNullable(firstTimestamp), Optional.ToNullable(lastTimestamp));
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static VariableState FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeVariableState(document.RootElement);
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
