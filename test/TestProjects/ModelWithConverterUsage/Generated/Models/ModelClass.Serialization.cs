// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using ModelWithConverterUsage;

namespace ModelWithConverterUsage.Models
{
    [JsonConverter(typeof(ModelClassConverter))]
    public partial class ModelClass : IUtf8JsonSerializable, IJsonModel<ModelClass>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelClass>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ModelClass>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelClass>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelClass)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(StringProperty))
            {
                writer.WritePropertyName("String_Property"u8);
                writer.WriteStringValue(StringProperty);
            }
            writer.WritePropertyName("Enum_Property"u8);
            writer.WriteStringValue(EnumProperty.ToSerialString());
            if (Optional.IsDefined(ObjProperty))
            {
                writer.WritePropertyName("Obj_Property"u8);
                writer.WriteObjectValue(ObjProperty);
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

        ModelClass IJsonModel<ModelClass>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelClass>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelClass)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelClass(document.RootElement, options);
        }

        internal static ModelClass DeserializeModelClass(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string stringProperty = default;
            EnumProperty enumProperty = default;
            Product objProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("String_Property"u8))
                {
                    stringProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Enum_Property"u8))
                {
                    enumProperty = property.Value.GetString().ToEnumProperty();
                    continue;
                }
                if (property.NameEquals("Obj_Property"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    objProperty = Product.DeserializeProduct(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelClass(stringProperty, enumProperty, objProperty, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ModelClass>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelClass>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ModelClass)} does not support '{options.Format}' format.");
            }
        }

        ModelClass IPersistableModel<ModelClass>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelClass>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeModelClass(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ModelClass)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ModelClass>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal partial class ModelClassConverter : JsonConverter<ModelClass>
        {
            public override void Write(Utf8JsonWriter writer, ModelClass model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override ModelClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeModelClass(document.RootElement);
            }
        }
    }
}
