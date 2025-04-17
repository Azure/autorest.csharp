// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Scm._Type.Model.Inheritance.SingleDiscriminator.Models
{
    public partial class Eagle : IJsonModel<Eagle>
    {
        void IJsonModel<Eagle>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Eagle>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Eagle)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            if (Optional.IsCollectionDefined(Friends))
            {
                writer.WritePropertyName("friends"u8);
                writer.WriteStartArray();
                foreach (var item in Friends)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Hate))
            {
                writer.WritePropertyName("hate"u8);
                writer.WriteStartObject();
                foreach (var item in Hate)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value, options);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Partner))
            {
                writer.WritePropertyName("partner"u8);
                writer.WriteObjectValue(Partner, options);
            }
        }

        Eagle IJsonModel<Eagle>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Eagle>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Eagle)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEagle(document.RootElement, options);
        }

        internal static Eagle DeserializeEagle(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<Bird> friends = default;
            IDictionary<string, Bird> hate = default;
            Bird partner = default;
            string kind = default;
            int wingspan = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("friends"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Bird> array = new List<Bird>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeBird(item, options));
                    }
                    friends = array;
                    continue;
                }
                if (property.NameEquals("hate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, Bird> dictionary = new Dictionary<string, Bird>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, DeserializeBird(property0.Value, options));
                    }
                    hate = dictionary;
                    continue;
                }
                if (property.NameEquals("partner"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    partner = DeserializeBird(property.Value, options);
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("wingspan"u8))
                {
                    wingspan = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new Eagle(
                kind,
                wingspan,
                serializedAdditionalRawData,
                friends ?? new ChangeTrackingList<Bird>(),
                hate ?? new ChangeTrackingDictionary<string, Bird>(),
                partner);
        }

        BinaryData IPersistableModel<Eagle>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Eagle>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, Scm_TypeModelInheritanceSingleDiscriminatorContext.Default);
                default:
                    throw new FormatException($"The model {nameof(Eagle)} does not support writing '{options.Format}' format.");
            }
        }

        Eagle IPersistableModel<Eagle>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Eagle>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeEagle(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(Eagle)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<Eagle>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static new Eagle FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeEagle(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
