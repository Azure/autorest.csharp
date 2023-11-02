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
    public partial class CreateCompletionResponse : IUtf8JsonWriteable, IJsonModel<CreateCompletionResponse>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<CreateCompletionResponse>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<CreateCompletionResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
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
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (OptionalProperty.IsDefined(Usage))
            {
                writer.WritePropertyName("usage"u8);
                writer.WriteObjectValue(Usage);
            }
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

        CreateCompletionResponse IJsonModel<CreateCompletionResponse>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateCompletionResponse(document.RootElement, options);
        }

        internal static CreateCompletionResponse DeserializeCreateCompletionResponse(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            string @object = default;
            DateTimeOffset created = default;
            string model = default;
            IReadOnlyList<CreateCompletionResponseChoice> choices = default;
            OptionalProperty<CompletionUsage> usage = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                    List<CreateCompletionResponseChoice> array = new List<CreateCompletionResponseChoice>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CreateCompletionResponseChoice.DeserializeCreateCompletionResponseChoice(item));
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
                    usage = CompletionUsage.DeserializeCompletionUsage(property.Value);
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CreateCompletionResponse(id, @object, created, model, choices, usage.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<CreateCompletionResponse>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.WriteCore(this, options);
        }

        CreateCompletionResponse IModel<CreateCompletionResponse>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeCreateCompletionResponse(document.RootElement, options);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static CreateCompletionResponse FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeCreateCompletionResponse(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual RequestBody ToRequestBody()
        {
            throw new Exception();
        }
    }
}
