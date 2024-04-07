// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateChatCompletionResponse : IJsonModel<CreateChatCompletionResponse>
    {
        void IJsonModel<CreateChatCompletionResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateChatCompletionResponse)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("object"u8);
            writer.WriteStringValue(Object);
            writer.WritePropertyName("created"u8);
            writer.WriteNumberValue(Created, "U");
            writer.WritePropertyName("model"u8);
            writer.WriteStringValue(Model);
            writer.WritePropertyName("choices"u8);
            writer.WriteStartArray();
            foreach (var item in Choices)
            {
                writer.WriteObjectValue<CreateChatCompletionResponseChoice>(item, options);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(Usage))
            {
                writer.WritePropertyName("usage"u8);
                writer.WriteObjectValue<CompletionUsage>(Usage, options);
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

        CreateChatCompletionResponse IJsonModel<CreateChatCompletionResponse>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionResponse>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateChatCompletionResponse)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateChatCompletionResponse(document.RootElement, options);
        }

        internal static CreateChatCompletionResponse DeserializeCreateChatCompletionResponse(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            string @object = default;
            DateTimeOffset created = default;
            string model = default;
            IReadOnlyList<CreateChatCompletionResponseChoice> choices = default;
            CompletionUsage usage = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("created"u8))
                {
                    created = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    model = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("choices"u8))
                {
                    List<CreateChatCompletionResponseChoice> array = new List<CreateChatCompletionResponseChoice>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CreateChatCompletionResponseChoice.DeserializeCreateChatCompletionResponseChoice(item, options));
                    }
                    choices = array;
                    continue;
                }
                if (property.NameEquals("usage"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    usage = CompletionUsage.DeserializeCompletionUsage(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new CreateChatCompletionResponse(
                id,
                @object,
                created,
                model,
                choices,
                usage,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateChatCompletionResponse>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CreateChatCompletionResponse)} does not support writing '{options.Format}' format.");
            }
        }

        CreateChatCompletionResponse IPersistableModel<CreateChatCompletionResponse>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionResponse>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateChatCompletionResponse(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateChatCompletionResponse)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateChatCompletionResponse>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateChatCompletionResponse FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateChatCompletionResponse(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual BinaryContent ToBinaryBody()
        {
            return BinaryContent.Create(this, new ModelReaderWriterOptions("W"));
        }
    }
}
