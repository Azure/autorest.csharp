// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Inheritance.Models
{
    [JsonConverter(typeof(BaseClassWithExtensibleEnumDiscriminatorConverter))]
    [PersistableModelProxy(typeof(UnknownBaseClassWithExtensibleEnumDiscriminator))]
    public partial class BaseClassWithExtensibleEnumDiscriminator : IUtf8JsonSerializable, IJsonModel<BaseClassWithExtensibleEnumDiscriminator>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BaseClassWithExtensibleEnumDiscriminator>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<BaseClassWithExtensibleEnumDiscriminator>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<BaseClassWithExtensibleEnumDiscriminator>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<BaseClassWithExtensibleEnumDiscriminator>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("DiscriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty.ToString());
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

        BaseClassWithExtensibleEnumDiscriminator IJsonModel<BaseClassWithExtensibleEnumDiscriminator>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BaseClassWithExtensibleEnumDiscriminator)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBaseClassWithExtensibleEnumDiscriminator(document.RootElement, options);
        }

        internal static BaseClassWithExtensibleEnumDiscriminator DeserializeBaseClassWithExtensibleEnumDiscriminator(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("DiscriminatorProperty", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "derived": return DerivedClassWithExtensibleEnumDiscriminator.DeserializeDerivedClassWithExtensibleEnumDiscriminator(element);
                    case "random value": return AnotherDerivedClassWithExtensibleEnumDiscriminator.DeserializeAnotherDerivedClassWithExtensibleEnumDiscriminator(element);
                }
            }
            return UnknownBaseClassWithExtensibleEnumDiscriminator.DeserializeUnknownBaseClassWithExtensibleEnumDiscriminator(element);
        }

        BinaryData IPersistableModel<BaseClassWithExtensibleEnumDiscriminator>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BaseClassWithExtensibleEnumDiscriminator)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        BaseClassWithExtensibleEnumDiscriminator IPersistableModel<BaseClassWithExtensibleEnumDiscriminator>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BaseClassWithExtensibleEnumDiscriminator)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBaseClassWithExtensibleEnumDiscriminator(document.RootElement, options);
        }

        string IPersistableModel<BaseClassWithExtensibleEnumDiscriminator>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal partial class BaseClassWithExtensibleEnumDiscriminatorConverter : JsonConverter<BaseClassWithExtensibleEnumDiscriminator>
        {
            public override void Write(Utf8JsonWriter writer, BaseClassWithExtensibleEnumDiscriminator model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override BaseClassWithExtensibleEnumDiscriminator Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeBaseClassWithExtensibleEnumDiscriminator(document.RootElement);
            }
        }
    }
}
