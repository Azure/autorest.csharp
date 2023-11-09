// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateLogprobs : IUtf8JsonWriteable, IJsonModel<CreateLogprobs>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<CreateLogprobs>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<CreateLogprobs>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<CreateLogprobs>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<CreateLogprobs>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("tokens"u8);
            writer.WriteStartArray();
            foreach (var item in Tokens)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("token_logprobs"u8);
            writer.WriteStartArray();
            foreach (var item in TokenLogprobs)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
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
            writer.WritePropertyName("text_offset"u8);
            writer.WriteStartArray();
            foreach (var item in TextOffset)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
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

        CreateLogprobs IJsonModel<CreateLogprobs>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateLogprobs)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateLogprobs(document.RootElement, options);
        }

        internal static CreateLogprobs DeserializeCreateLogprobs(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<string> tokens = default;
            IReadOnlyList<double> tokenLogprobs = default;
            IReadOnlyList<IDictionary<string, long>> topLogprobs = default;
            IReadOnlyList<long> textOffset = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CreateLogprobs(tokens, tokenLogprobs, topLogprobs, textOffset, serializedAdditionalRawData);
        }

        BinaryData IModel<CreateLogprobs>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateLogprobs)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        CreateLogprobs IModel<CreateLogprobs>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateLogprobs)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeCreateLogprobs(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<CreateLogprobs>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static CreateLogprobs FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeCreateLogprobs(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual RequestBody ToRequestBody()
        {
            var content = new Utf8JsonRequestBody();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
