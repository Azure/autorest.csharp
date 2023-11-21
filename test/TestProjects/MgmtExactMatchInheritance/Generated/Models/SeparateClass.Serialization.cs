// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace MgmtExactMatchInheritance.Models
{
    [JsonConverter(typeof(SeparateClassConverter))]
    public partial class SeparateClass : IUtf8JsonSerializable, IJsonModel<SeparateClass>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SeparateClass>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<SeparateClass>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SeparateClass>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(SeparateClass)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(StringProperty))
            {
                writer.WritePropertyName("StringProperty"u8);
                writer.WriteStringValue(StringProperty);
            }
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WritePropertyName("ModelProperty"u8);
                writer.WriteObjectValue(ModelProperty);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        SeparateClass IJsonModel<SeparateClass>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SeparateClass>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(SeparateClass)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSeparateClass(document.RootElement, options);
        }

        internal static SeparateClass DeserializeSeparateClass(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> stringProperty = default;
            Optional<ExactMatchModel10> modelProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("StringProperty"u8))
                {
                    stringProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ModelProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    modelProperty = ExactMatchModel10.DeserializeExactMatchModel10(property.Value);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new SeparateClass(stringProperty.Value, modelProperty.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<SeparateClass>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SeparateClass>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(SeparateClass)} does not support '{options.Format}' format.");
            }
        }

        SeparateClass IPersistableModel<SeparateClass>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SeparateClass>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeSeparateClass(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(SeparateClass)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<SeparateClass>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal partial class SeparateClassConverter : JsonConverter<SeparateClass>
        {
            public override void Write(Utf8JsonWriter writer, SeparateClass model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override SeparateClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeSeparateClass(document.RootElement);
            }
        }
    }
}
