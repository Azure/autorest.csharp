// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateCompletionResponseChoiceLogprobs : IJsonModel<CreateCompletionResponseChoiceLogprobs>
    {
        void IJsonModel<CreateCompletionResponseChoiceLogprobs>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateCompletionResponseChoiceLogprobs)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (!SerializedAdditionalRawData.ContainsKey("tokens"))
            {
                writer.WritePropertyName("tokens"u8);
                writer.WriteStartArray();
                foreach (var item in Tokens)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (!SerializedAdditionalRawData.ContainsKey("token_logprobs"))
            {
                writer.WritePropertyName("token_logprobs"u8);
                writer.WriteStartArray();
                foreach (var item in TokenLogprobs)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (!SerializedAdditionalRawData.ContainsKey("top_logprobs"))
            {
                writer.WritePropertyName("top_logprobs"u8);
                writer.WriteStartArray();
                foreach (var item in TopLogprobs)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStartObject();
                    foreach (var item0 in item)
                    {
                        writer.WritePropertyName(item0.Key);
                        writer.WriteNumberValue(item0.Value);
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
            if (!SerializedAdditionalRawData.ContainsKey("text_offset"))
            {
                writer.WritePropertyName("text_offset"u8);
                writer.WriteStartArray();
                foreach (var item in TextOffset)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            foreach (var item in SerializedAdditionalRawData)
            {
                if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                {
                    continue;
                }
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
            writer.WriteEndObject();
        }

        CreateCompletionResponseChoiceLogprobs IJsonModel<CreateCompletionResponseChoiceLogprobs>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateCompletionResponseChoiceLogprobs)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateCompletionResponseChoiceLogprobs(document.RootElement, options);
        }

        internal static CreateCompletionResponseChoiceLogprobs DeserializeCreateCompletionResponseChoiceLogprobs(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<string> tokens = default;
            IReadOnlyList<double> tokenLogprobs = default;
            IReadOnlyList<IDictionary<string, long>> topLogprobs = default;
            IReadOnlyList<long> textOffset = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tokens"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    tokens = array;
                    continue;
                }
                if (property.NameEquals("token_logprobs"u8))
                {
                    List<double> array = new List<double>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetDouble());
                    }
                    tokenLogprobs = array;
                    continue;
                }
                if (property.NameEquals("top_logprobs"u8))
                {
                    List<IDictionary<string, long>> array = new List<IDictionary<string, long>>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            Dictionary<string, long> dictionary = new Dictionary<string, long>();
                            foreach (var property0 in item.EnumerateObject())
                            {
                                dictionary.Add(property0.Name, property0.Value.GetInt64());
                            }
                            array.Add(dictionary);
                        }
                    }
                    topLogprobs = array;
                    continue;
                }
                if (property.NameEquals("text_offset"u8))
                {
                    List<long> array = new List<long>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt64());
                    }
                    textOffset = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new CreateCompletionResponseChoiceLogprobs(tokens, tokenLogprobs, topLogprobs, textOffset, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateCompletionResponseChoiceLogprobs>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CreateCompletionResponseChoiceLogprobs)} does not support writing '{options.Format}' format.");
            }
        }

        CreateCompletionResponseChoiceLogprobs IPersistableModel<CreateCompletionResponseChoiceLogprobs>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionResponseChoiceLogprobs>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateCompletionResponseChoiceLogprobs(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateCompletionResponseChoiceLogprobs)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateCompletionResponseChoiceLogprobs>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateCompletionResponseChoiceLogprobs FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateCompletionResponseChoiceLogprobs(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
