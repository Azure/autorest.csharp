// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Scm._Type.Property.AdditionalProperties.Models
{
    public partial class ExtendsUnknownAdditionalPropertiesDiscriminatedDerived : IJsonModel<ExtendsUnknownAdditionalPropertiesDiscriminatedDerived>
    {
        void IJsonModel<ExtendsUnknownAdditionalPropertiesDiscriminatedDerived>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminatedDerived>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtendsUnknownAdditionalPropertiesDiscriminatedDerived)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("index"u8);
            writer.WriteNumberValue(Index);
            if (Optional.IsDefined(Age))
            {
                writer.WritePropertyName("age"u8);
                writer.WriteNumberValue(Age.Value);
            }
            foreach (var item in AdditionalProperties)
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

        ExtendsUnknownAdditionalPropertiesDiscriminatedDerived IJsonModel<ExtendsUnknownAdditionalPropertiesDiscriminatedDerived>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminatedDerived>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtendsUnknownAdditionalPropertiesDiscriminatedDerived)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeExtendsUnknownAdditionalPropertiesDiscriminatedDerived(document.RootElement, options);
        }

        internal static ExtendsUnknownAdditionalPropertiesDiscriminatedDerived DeserializeExtendsUnknownAdditionalPropertiesDiscriminatedDerived(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int index = default;
            float? age = default;
            string name = default;
            string kind = default;
            IDictionary<string, BinaryData> additionalProperties = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("index"u8))
                {
                    index = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("age"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    age = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
            additionalProperties = additionalPropertiesDictionary;
            return new ExtendsUnknownAdditionalPropertiesDiscriminatedDerived(name, kind, additionalProperties, index, age);
        }

        BinaryData IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminatedDerived>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminatedDerived>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, Scm_TypePropertyAdditionalPropertiesContext.Default);
                default:
                    throw new FormatException($"The model {nameof(ExtendsUnknownAdditionalPropertiesDiscriminatedDerived)} does not support writing '{options.Format}' format.");
            }
        }

        ExtendsUnknownAdditionalPropertiesDiscriminatedDerived IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminatedDerived>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminatedDerived>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeExtendsUnknownAdditionalPropertiesDiscriminatedDerived(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ExtendsUnknownAdditionalPropertiesDiscriminatedDerived)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminatedDerived>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static new ExtendsUnknownAdditionalPropertiesDiscriminatedDerived FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeExtendsUnknownAdditionalPropertiesDiscriminatedDerived(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
