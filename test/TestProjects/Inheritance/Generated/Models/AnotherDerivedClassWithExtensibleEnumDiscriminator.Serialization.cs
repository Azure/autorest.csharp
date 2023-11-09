// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Inheritance.Models
{
    [JsonConverter(typeof(AnotherDerivedClassWithExtensibleEnumDiscriminatorConverter))]
    public partial class AnotherDerivedClassWithExtensibleEnumDiscriminator : IUtf8JsonSerializable, IJsonModel<AnotherDerivedClassWithExtensibleEnumDiscriminator>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AnotherDerivedClassWithExtensibleEnumDiscriminator>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<AnotherDerivedClassWithExtensibleEnumDiscriminator>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<AnotherDerivedClassWithExtensibleEnumDiscriminator>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<AnotherDerivedClassWithExtensibleEnumDiscriminator>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("DiscriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty.ToString());
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

        AnotherDerivedClassWithExtensibleEnumDiscriminator IJsonModel<AnotherDerivedClassWithExtensibleEnumDiscriminator>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AnotherDerivedClassWithExtensibleEnumDiscriminator)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(document.RootElement, options);
        }

        internal static AnotherDerivedClassWithExtensibleEnumDiscriminator DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BaseClassWithEntensibleEnumDiscriminatorEnum discriminatorProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("DiscriminatorProperty"u8))
                {
                    discriminatorProperty = new BaseClassWithEntensibleEnumDiscriminatorEnum(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new AnotherDerivedClassWithExtensibleEnumDiscriminator(discriminatorProperty, serializedAdditionalRawData);
        }

        BinaryData IModel<AnotherDerivedClassWithExtensibleEnumDiscriminator>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AnotherDerivedClassWithExtensibleEnumDiscriminator)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        AnotherDerivedClassWithExtensibleEnumDiscriminator IModel<AnotherDerivedClassWithExtensibleEnumDiscriminator>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AnotherDerivedClassWithExtensibleEnumDiscriminator)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<AnotherDerivedClassWithExtensibleEnumDiscriminator>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        internal partial class AnotherDerivedClassWithExtensibleEnumDiscriminatorConverter : JsonConverter<AnotherDerivedClassWithExtensibleEnumDiscriminator>
        {
            public override void Write(Utf8JsonWriter writer, AnotherDerivedClassWithExtensibleEnumDiscriminator model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override AnotherDerivedClassWithExtensibleEnumDiscriminator Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(document.RootElement);
            }
        }
    }
}
