// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Scm._Type.Property.Nullable.Models
{
    public partial class CollectionsByteProperty : IJsonModel<CollectionsByteProperty>
    {
        void IJsonModel<CollectionsByteProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsByteProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CollectionsByteProperty)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("requiredProperty"u8);
            writer.WriteStringValue(RequiredProperty);
            if (NullableProperty != null && Optional.IsCollectionDefined(NullableProperty))
            {
                writer.WritePropertyName("nullableProperty"u8);
                writer.WriteStartArray();
                foreach (var item in NullableProperty)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteBase64StringValue(item.ToArray(), "D");
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("nullableProperty");
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
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

        CollectionsByteProperty IJsonModel<CollectionsByteProperty>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsByteProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CollectionsByteProperty)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCollectionsByteProperty(document.RootElement, options);
        }

        internal static CollectionsByteProperty DeserializeCollectionsByteProperty(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredProperty = default;
            IList<BinaryData> nullableProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredProperty"u8))
                {
                    requiredProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("nullableProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nullableProperty = new ChangeTrackingList<BinaryData>();
                        continue;
                    }
                    List<BinaryData> array = new List<BinaryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(BinaryData.FromBytes(item.GetBytesFromBase64("D")));
                        }
                    }
                    nullableProperty = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new CollectionsByteProperty(requiredProperty, nullableProperty, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CollectionsByteProperty>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsByteProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CollectionsByteProperty)} does not support writing '{options.Format}' format.");
            }
        }

        CollectionsByteProperty IPersistableModel<CollectionsByteProperty>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsByteProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, new JsonDocumentOptions { MaxDepth = 256 });
                        return DeserializeCollectionsByteProperty(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CollectionsByteProperty)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CollectionsByteProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CollectionsByteProperty FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content, new JsonDocumentOptions { MaxDepth = 256 });
            return DeserializeCollectionsByteProperty(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
