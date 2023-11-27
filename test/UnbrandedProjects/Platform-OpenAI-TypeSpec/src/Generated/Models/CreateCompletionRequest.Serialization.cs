// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateCompletionRequest : IUtf8JsonWriteable, IJsonModel<CreateCompletionRequest>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<CreateCompletionRequest>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<CreateCompletionRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(CreateCompletionRequest)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("model"u8);
            writer.WriteStringValue(Model.ToString());
            writer.WritePropertyName("prompt"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Prompt);
#else
            using (JsonDocument document = JsonDocument.Parse(Prompt))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            if (OptionalProperty.IsDefined(Suffix))
            {
                if (Suffix != null)
                {
                    writer.WritePropertyName("suffix"u8);
                    writer.WriteStringValue(Suffix);
                }
                else
                {
                    writer.WriteNull("suffix");
                }
            }
            if (OptionalProperty.IsDefined(Temperature))
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
            if (OptionalProperty.IsDefined(TopP))
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
            if (OptionalProperty.IsDefined(N))
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
            if (OptionalProperty.IsDefined(MaxTokens))
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
            if (OptionalProperty.IsDefined(Stop))
            {
                writer.WritePropertyName("stop"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Stop);
#else
                using (JsonDocument document = JsonDocument.Parse(Stop))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (OptionalProperty.IsDefined(PresencePenalty))
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
            if (OptionalProperty.IsDefined(FrequencyPenalty))
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
            if (OptionalProperty.IsCollectionDefined(LogitBias))
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
            if (OptionalProperty.IsDefined(User))
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(User);
            }
            if (OptionalProperty.IsDefined(Stream))
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
            if (OptionalProperty.IsDefined(Logprobs))
            {
                if (Logprobs != null)
                {
                    writer.WritePropertyName("logprobs"u8);
                    writer.WriteNumberValue(Logprobs.Value);
                }
                else
                {
                    writer.WriteNull("logprobs");
                }
            }
            if (OptionalProperty.IsDefined(Echo))
            {
                if (Echo != null)
                {
                    writer.WritePropertyName("echo"u8);
                    writer.WriteBooleanValue(Echo.Value);
                }
                else
                {
                    writer.WriteNull("echo");
                }
            }
            if (OptionalProperty.IsDefined(BestOf))
            {
                if (BestOf != null)
                {
                    writer.WritePropertyName("best_of"u8);
                    writer.WriteNumberValue(BestOf.Value);
                }
                else
                {
                    writer.WriteNull("best_of");
                }
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

        CreateCompletionRequest IJsonModel<CreateCompletionRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(CreateCompletionRequest)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateCompletionRequest(document.RootElement, options);
        }

        internal static CreateCompletionRequest DeserializeCreateCompletionRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            CreateCompletionRequestModel model = default;
            BinaryData prompt = default;
            OptionalProperty<string> suffix = default;
            OptionalProperty<double?> temperature = default;
            OptionalProperty<double?> topP = default;
            OptionalProperty<long?> n = default;
            OptionalProperty<long?> maxTokens = default;
            OptionalProperty<BinaryData> stop = default;
            OptionalProperty<double?> presencePenalty = default;
            OptionalProperty<double?> frequencyPenalty = default;
            OptionalProperty<IDictionary<string, long>> logitBias = default;
            OptionalProperty<string> user = default;
            OptionalProperty<bool?> stream = default;
            OptionalProperty<long?> logprobs = default;
            OptionalProperty<bool?> echo = default;
            OptionalProperty<long?> bestOf = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("model"u8))
                {
                    model = new CreateCompletionRequestModel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("prompt"u8))
                {
                    prompt = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("suffix"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        suffix = null;
                        continue;
                    }
                    suffix = property.Value.GetString();
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
                if (property.NameEquals("logprobs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        logprobs = null;
                        continue;
                    }
                    logprobs = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("echo"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        echo = null;
                        continue;
                    }
                    echo = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("best_of"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        bestOf = null;
                        continue;
                    }
                    bestOf = property.Value.GetInt64();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CreateCompletionRequest(model, prompt, suffix.Value, OptionalProperty.ToNullable(temperature), OptionalProperty.ToNullable(topP), OptionalProperty.ToNullable(n), OptionalProperty.ToNullable(maxTokens), stop.Value, OptionalProperty.ToNullable(presencePenalty), OptionalProperty.ToNullable(frequencyPenalty), OptionalProperty.ToDictionary(logitBias), user.Value, OptionalProperty.ToNullable(stream), OptionalProperty.ToNullable(logprobs), OptionalProperty.ToNullable(echo), OptionalProperty.ToNullable(bestOf), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateCompletionRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(CreateCompletionRequest)} does not support '{options.Format}' format.");
            }
        }

        CreateCompletionRequest IPersistableModel<CreateCompletionRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateCompletionRequest(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(CreateCompletionRequest)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateCompletionRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateCompletionRequest FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateCompletionRequest(document.RootElement);
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
