// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Scm._Type.Property.Nullable.Models
{
    public partial class CollectionsStringProperty : IJsonModel<CollectionsStringProperty>
    {
        void IJsonModel<CollectionsStringProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsStringProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CollectionsStringProperty)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("requiredProperty"u8);
            writer.WriteStringValue(RequiredProperty);
            if (NullableProperty != null && Optional.IsCollectionDefined(NullableProperty))
            {
                writer.WritePropertyName("nullableProperty"u8);
                writer.WriteStartArray();
                foreach (var item in NullableProperty)
                {
                    writer.WriteStringValue(item);
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
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        CollectionsStringProperty IJsonModel<CollectionsStringProperty>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsStringProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CollectionsStringProperty)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCollectionsStringProperty(document.RootElement, options);
        }

        internal static CollectionsStringProperty DeserializeCollectionsStringProperty(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredProperty = default;
            IList<string> nullableProperty = default;
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
                        nullableProperty = new ChangeTrackingList<string>();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
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
            return new CollectionsStringProperty(requiredProperty, nullableProperty, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CollectionsStringProperty>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsStringProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, Scm_TypePropertyNullableContext.Default);
                default:
                    throw new FormatException($"The model {nameof(CollectionsStringProperty)} does not support writing '{options.Format}' format.");
            }
        }

        CollectionsStringProperty IPersistableModel<CollectionsStringProperty>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CollectionsStringProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeCollectionsStringProperty(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CollectionsStringProperty)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CollectionsStringProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CollectionsStringProperty FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeCollectionsStringProperty(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
