// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Scm._Type.Property.AdditionalProperties.Models
{
    public partial class SpreadRecordForNonDiscriminatedUnion2 : IJsonModel<SpreadRecordForNonDiscriminatedUnion2>
    {
        void IJsonModel<SpreadRecordForNonDiscriminatedUnion2>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadRecordForNonDiscriminatedUnion2>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SpreadRecordForNonDiscriminatedUnion2)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            foreach (var item in AdditionalProperties)
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

        SpreadRecordForNonDiscriminatedUnion2 IJsonModel<SpreadRecordForNonDiscriminatedUnion2>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadRecordForNonDiscriminatedUnion2>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SpreadRecordForNonDiscriminatedUnion2)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSpreadRecordForNonDiscriminatedUnion2(document.RootElement, options);
        }

        internal static SpreadRecordForNonDiscriminatedUnion2 DeserializeSpreadRecordForNonDiscriminatedUnion2(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            IDictionary<string, BinaryData> additionalProperties = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
            additionalProperties = additionalPropertiesDictionary;
            return new SpreadRecordForNonDiscriminatedUnion2(name, additionalProperties);
        }

        BinaryData IPersistableModel<SpreadRecordForNonDiscriminatedUnion2>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadRecordForNonDiscriminatedUnion2>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(SpreadRecordForNonDiscriminatedUnion2)} does not support writing '{options.Format}' format.");
            }
        }

        SpreadRecordForNonDiscriminatedUnion2 IPersistableModel<SpreadRecordForNonDiscriminatedUnion2>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SpreadRecordForNonDiscriminatedUnion2>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeSpreadRecordForNonDiscriminatedUnion2(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(SpreadRecordForNonDiscriminatedUnion2)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<SpreadRecordForNonDiscriminatedUnion2>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static SpreadRecordForNonDiscriminatedUnion2 FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeSpreadRecordForNonDiscriminatedUnion2(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
