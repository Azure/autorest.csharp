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
    public partial class CreateEmbeddingResponse : IUtf8JsonWriteable, IJsonModel<CreateEmbeddingResponse>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<CreateEmbeddingResponse>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<CreateEmbeddingResponse>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<CreateEmbeddingResponse>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<CreateEmbeddingResponse>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("object"u8);
            writer.WriteStringValue(Object.ToString());
            writer.WritePropertyName("model"u8);
            writer.WriteStringValue(Model);
            writer.WritePropertyName("data"u8);
            writer.WriteStartArray();
            foreach (var item in Data)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("usage"u8);
            writer.WriteObjectValue(Usage);
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        CreateEmbeddingResponse IJsonModel<CreateEmbeddingResponse>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateEmbeddingResponse)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateEmbeddingResponse(document.RootElement, options);
        }

        internal static CreateEmbeddingResponse DeserializeCreateEmbeddingResponse(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            CreateEmbeddingResponseObject @object = default;
            string model = default;
            IReadOnlyList<Embedding> data = default;
            CreateUsage usage = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("object"u8))
                {
                    @object = new CreateEmbeddingResponseObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    model = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("data"u8))
                {
                    List<Embedding> array = new List<Embedding>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Embedding.DeserializeEmbedding(item));
                    }
                    data = array;
                    continue;
                }
                if (property.NameEquals("usage"u8))
                {
                    usage = CreateUsage.DeserializeCreateUsage(property.Value);
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CreateEmbeddingResponse(@object, model, data, usage, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateEmbeddingResponse>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateEmbeddingResponse)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        CreateEmbeddingResponse IPersistableModel<CreateEmbeddingResponse>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CreateEmbeddingResponse)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeCreateEmbeddingResponse(document.RootElement, options);
        }

        string IPersistableModel<CreateEmbeddingResponse>.GetWireFormat(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static CreateEmbeddingResponse FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeCreateEmbeddingResponse(document.RootElement, ModelReaderWriterOptions.Wire);
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
