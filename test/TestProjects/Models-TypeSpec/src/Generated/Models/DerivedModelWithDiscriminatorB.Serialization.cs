// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    public partial class DerivedModelWithDiscriminatorB : IUtf8JsonSerializable, IJsonModel<DerivedModelWithDiscriminatorB>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DerivedModelWithDiscriminatorB>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<DerivedModelWithDiscriminatorB>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<DerivedModelWithDiscriminatorB>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<DerivedModelWithDiscriminatorB>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("requiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
            writer.WritePropertyName("discriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty);
            if (Optional.IsDefined(OptionalPropertyOnBase))
            {
                writer.WritePropertyName("optionalPropertyOnBase"u8);
                writer.WriteStringValue(OptionalPropertyOnBase);
            }
            writer.WritePropertyName("requiredPropertyOnBase"u8);
            writer.WriteNumberValue(RequiredPropertyOnBase);
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

        DerivedModelWithDiscriminatorB IJsonModel<DerivedModelWithDiscriminatorB>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DerivedModelWithDiscriminatorB)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDerivedModelWithDiscriminatorB(document.RootElement, options);
        }

        internal static DerivedModelWithDiscriminatorB DeserializeDerivedModelWithDiscriminatorB(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int requiredInt = default;
            string discriminatorProperty = default;
            Optional<string> optionalPropertyOnBase = default;
            int requiredPropertyOnBase = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredInt"u8))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("discriminatorProperty"u8))
                {
                    discriminatorProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("optionalPropertyOnBase"u8))
                {
                    optionalPropertyOnBase = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredPropertyOnBase"u8))
                {
                    requiredPropertyOnBase = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DerivedModelWithDiscriminatorB(discriminatorProperty, optionalPropertyOnBase.Value, requiredPropertyOnBase, serializedAdditionalRawData, requiredInt);
        }

        BinaryData IPersistableModel<DerivedModelWithDiscriminatorB>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DerivedModelWithDiscriminatorB)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DerivedModelWithDiscriminatorB IPersistableModel<DerivedModelWithDiscriminatorB>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DerivedModelWithDiscriminatorB)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDerivedModelWithDiscriminatorB(document.RootElement, options);
        }

        string IPersistableModel<DerivedModelWithDiscriminatorB>.GetWireFormat(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new DerivedModelWithDiscriminatorB FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDerivedModelWithDiscriminatorB(document.RootElement, ModelReaderWriterOptions.Wire);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
