// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class VariableState : IUtf8JsonSerializable, IJsonModel<VariableState>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VariableState>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VariableState>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VariableState>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VariableState)} does not support '{format}' format.");
            }

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
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        VariableState IJsonModel<VariableState>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VariableState>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VariableState)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVariableState(document.RootElement, options);
        }

        internal static VariableState DeserializeVariableState(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> variable = default;
            Optional<float> filledNARatio = default;
            Optional<int> effectiveCount = default;
            Optional<DateTimeOffset> firstTimestamp = default;
            Optional<DateTimeOffset> lastTimestamp = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VariableState(variable.Value, Optional.ToNullable(filledNARatio), Optional.ToNullable(effectiveCount), Optional.ToNullable(firstTimestamp), Optional.ToNullable(lastTimestamp), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VariableState>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VariableState>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(VariableState)} does not support '{options.Format}' format.");
            }
        }

        VariableState IPersistableModel<VariableState>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VariableState>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVariableState(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(VariableState)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VariableState>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static VariableState FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeVariableState(document.RootElement, new ModelReaderWriterOptions("W"));
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
