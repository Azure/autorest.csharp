// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Type.Property.AdditionalProperties.Models
{
    public partial class IsUnknownAdditionalPropertiesDiscriminatedDerived : IUtf8JsonSerializable, IJsonModel<IsUnknownAdditionalPropertiesDiscriminatedDerived>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<IsUnknownAdditionalPropertiesDiscriminatedDerived>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<IsUnknownAdditionalPropertiesDiscriminatedDerived>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminatedDerived>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminatedDerived)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("index"u8);
            writer.WriteNumberValue(Index);
            if (Optional.IsDefined(Age))
            {
                writer.WritePropertyName("age"u8);
                writer.WriteNumberValue(Age.Value);
            }
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
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

        IsUnknownAdditionalPropertiesDiscriminatedDerived IJsonModel<IsUnknownAdditionalPropertiesDiscriminatedDerived>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminatedDerived>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminatedDerived)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIsUnknownAdditionalPropertiesDiscriminatedDerived(document.RootElement, options);
        }

        internal static IsUnknownAdditionalPropertiesDiscriminatedDerived DeserializeIsUnknownAdditionalPropertiesDiscriminatedDerived(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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
            return new IsUnknownAdditionalPropertiesDiscriminatedDerived(name, kind, additionalProperties, index, age);
        }

        BinaryData IPersistableModel<IsUnknownAdditionalPropertiesDiscriminatedDerived>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminatedDerived>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminatedDerived)} does not support writing '{options.Format}' format.");
            }
        }

        IsUnknownAdditionalPropertiesDiscriminatedDerived IPersistableModel<IsUnknownAdditionalPropertiesDiscriminatedDerived>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminatedDerived>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeIsUnknownAdditionalPropertiesDiscriminatedDerived(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminatedDerived)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<IsUnknownAdditionalPropertiesDiscriminatedDerived>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new IsUnknownAdditionalPropertiesDiscriminatedDerived FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeIsUnknownAdditionalPropertiesDiscriminatedDerived(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, new ModelReaderWriterOptions("W"));
            return content;
        }
    }
}
