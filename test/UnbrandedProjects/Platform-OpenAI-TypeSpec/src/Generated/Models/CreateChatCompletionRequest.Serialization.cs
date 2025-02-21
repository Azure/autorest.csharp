// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Models
{
    internal partial class CreateChatCompletionRequest : IJsonModel<CreateChatCompletionRequest>
    {
        void IJsonModel<CreateChatCompletionRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateChatCompletionRequest)} does not support writing '{format}' format.");
            }

            if (SerializedAdditionalRawData?.ContainsKey("model") != true)
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("messages") != true)
            {
                writer.WritePropertyName("messages"u8);
                writer.WriteStartArray();
                foreach (var item in Messages)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData?.ContainsKey("functions") != true && Optional.IsCollectionDefined(Functions))
            {
                writer.WritePropertyName("functions"u8);
                writer.WriteStartArray();
                foreach (var item in Functions)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData?.ContainsKey("function_call") != true && Optional.IsDefined(FunctionCall))
            {
                writer.WritePropertyName("function_call"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(FunctionCall);
#else
                using (JsonDocument document = JsonDocument.Parse(FunctionCall, new JsonDocumentOptions { MaxDepth = 256 }))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (SerializedAdditionalRawData?.ContainsKey("temperature") != true && Optional.IsDefined(Temperature))
            {
                if (Temperature != null)
                {
                    writer.WritePropertyName("temperature"u8);
                    writer.WriteNumberValue(Temperature.Value);
                }
                else
                {
                    writer.WriteNull("temperature");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("top_p") != true && Optional.IsDefined(TopP))
            {
                if (TopP != null)
                {
                    writer.WritePropertyName("top_p"u8);
                    writer.WriteNumberValue(TopP.Value);
                }
                else
                {
                    writer.WriteNull("top_p");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("n") != true && Optional.IsDefined(N))
            {
                if (N != null)
                {
                    writer.WritePropertyName("n"u8);
                    writer.WriteNumberValue(N.Value);
                }
                else
                {
                    writer.WriteNull("n");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("max_tokens") != true && Optional.IsDefined(MaxTokens))
            {
                if (MaxTokens != null)
                {
                    writer.WritePropertyName("max_tokens"u8);
                    writer.WriteNumberValue(MaxTokens.Value);
                }
                else
                {
                    writer.WriteNull("max_tokens");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("stop") != true && Optional.IsDefined(Stop))
            {
                if (Stop != null)
                {
                    writer.WritePropertyName("stop"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Stop);
#else
                    using (JsonDocument document = JsonDocument.Parse(Stop, new JsonDocumentOptions { MaxDepth = 256 }))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                else
                {
                    writer.WriteNull("stop");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("presence_penalty") != true && Optional.IsDefined(PresencePenalty))
            {
                if (PresencePenalty != null)
                {
                    writer.WritePropertyName("presence_penalty"u8);
                    writer.WriteNumberValue(PresencePenalty.Value);
                }
                else
                {
                    writer.WriteNull("presence_penalty");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("frequency_penalty") != true && Optional.IsDefined(FrequencyPenalty))
            {
                if (FrequencyPenalty != null)
                {
                    writer.WritePropertyName("frequency_penalty"u8);
                    writer.WriteNumberValue(FrequencyPenalty.Value);
                }
                else
                {
                    writer.WriteNull("frequency_penalty");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("logit_bias") != true && Optional.IsCollectionDefined(LogitBias))
            {
                if (LogitBias != null)
                {
                    writer.WritePropertyName("logit_bias"u8);
                    writer.WriteStartObject();
                    foreach (var item in LogitBias)
                    {
                        writer.WritePropertyName(item.Key);
                        writer.WriteNumberValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
                else
                {
                    writer.WriteNull("logit_bias");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("user") != true && Optional.IsDefined(User))
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(User);
            }
            if (SerializedAdditionalRawData?.ContainsKey("stream") != true && Optional.IsDefined(Stream))
            {
                if (Stream != null)
                {
                    writer.WritePropertyName("stream"u8);
                    writer.WriteBooleanValue(Stream.Value);
                }
                else
                {
                    writer.WriteNull("stream");
                }
            }
            if (SerializedAdditionalRawData != null)
            {
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
                    using (JsonDocument document = JsonDocument.Parse(item.Value, new JsonDocumentOptions { MaxDepth = 256 }))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        CreateChatCompletionRequest IJsonModel<CreateChatCompletionRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateChatCompletionRequest)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateChatCompletionRequest(document.RootElement, options);
        }

        internal static CreateChatCompletionRequest DeserializeCreateChatCompletionRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            CreateChatCompletionRequestModel model = default;
            IReadOnlyList<ChatCompletionRequestMessage> messages = default;
            IReadOnlyList<ChatCompletionFunctions> functions = default;
            BinaryData functionCall = default;
            double? temperature = default;
            double? topP = default;
            long? n = default;
            long? maxTokens = default;
            BinaryData stop = default;
            double? presencePenalty = default;
            double? frequencyPenalty = default;
            IReadOnlyDictionary<string, long> logitBias = default;
            string user = default;
            bool? stream = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("model"u8))
                {
                    model = new CreateChatCompletionRequestModel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("messages"u8))
                {
                    List<ChatCompletionRequestMessage> array = new List<ChatCompletionRequestMessage>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChatCompletionRequestMessage.DeserializeChatCompletionRequestMessage(item, options));
                    }
                    messages = array;
                    continue;
                }
                if (property.NameEquals("functions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatCompletionFunctions> array = new List<ChatCompletionFunctions>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChatCompletionFunctions.DeserializeChatCompletionFunctions(item, options));
                    }
                    functions = array;
                    continue;
                }
                if (property.NameEquals("function_call"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    functionCall = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("temperature"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        temperature = null;
                        continue;
                    }
                    temperature = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("top_p"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        topP = null;
                        continue;
                    }
                    topP = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("n"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        n = null;
                        continue;
                    }
                    n = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("max_tokens"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxTokens = null;
                        continue;
                    }
                    maxTokens = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("stop"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        stop = null;
                        continue;
                    }
                    stop = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("presence_penalty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        presencePenalty = null;
                        continue;
                    }
                    presencePenalty = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("frequency_penalty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        frequencyPenalty = null;
                        continue;
                    }
                    frequencyPenalty = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("logit_bias"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, long> dictionary = new Dictionary<string, long>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetInt64());
                    }
                    logitBias = dictionary;
                    continue;
                }
                if (property.NameEquals("user"u8))
                {
                    user = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("stream"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        stream = null;
                        continue;
                    }
                    stream = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new CreateChatCompletionRequest(
                model,
                messages,
                functions ?? new ChangeTrackingList<ChatCompletionFunctions>(),
                functionCall,
                temperature,
                topP,
                n,
                maxTokens,
                stop,
                presencePenalty,
                frequencyPenalty,
                logitBias ?? new ChangeTrackingDictionary<string, long>(),
                user,
                stream,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateChatCompletionRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CreateChatCompletionRequest)} does not support writing '{options.Format}' format.");
            }
        }

        CreateChatCompletionRequest IPersistableModel<CreateChatCompletionRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, new JsonDocumentOptions { MaxDepth = 256 });
                        return DeserializeCreateChatCompletionRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateChatCompletionRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateChatCompletionRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateChatCompletionRequest FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content, new JsonDocumentOptions { MaxDepth = 256 });
            return DeserializeCreateChatCompletionRequest(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
