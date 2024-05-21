// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Scm._Type.Property.AdditionalProperties.Models
{
    internal partial class UnknownIsUnknownAdditionalPropertiesDiscriminated : IJsonModel<IsUnknownAdditionalPropertiesDiscriminated>
    {
        void IJsonModel<IsUnknownAdditionalPropertiesDiscriminated>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminated)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
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
            writer.WriteEndObject();
        }

        IsUnknownAdditionalPropertiesDiscriminated IJsonModel<IsUnknownAdditionalPropertiesDiscriminated>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminated)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIsUnknownAdditionalPropertiesDiscriminated(document.RootElement, options);
        }

        internal static UnknownIsUnknownAdditionalPropertiesDiscriminated DeserializeUnknownIsUnknownAdditionalPropertiesDiscriminated(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string kind = "Unknown";
            string name = default;
            IDictionary<string, BinaryData> additionalProperties = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
            additionalProperties = additionalPropertiesDictionary;
            return new UnknownIsUnknownAdditionalPropertiesDiscriminated(kind, name, additionalProperties);
        }

        BinaryData IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminated)} does not support writing '{options.Format}' format.");
            }
        }

        IsUnknownAdditionalPropertiesDiscriminated IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeIsUnknownAdditionalPropertiesDiscriminated(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminated)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static new UnknownIsUnknownAdditionalPropertiesDiscriminated FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUnknownIsUnknownAdditionalPropertiesDiscriminated(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal override BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create<IsUnknownAdditionalPropertiesDiscriminated>(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
