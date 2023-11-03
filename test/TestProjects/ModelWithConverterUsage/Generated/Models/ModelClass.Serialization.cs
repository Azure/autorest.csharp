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

namespace ModelWithConverterUsage.Models
{
    [JsonConverter(typeof(ModelClassConverter))]
    public partial class ModelClass : IUtf8JsonSerializable, IJsonModel<ModelClass>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelClass>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ModelClass>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
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

        ModelClass IJsonModel<ModelClass>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelClass(document.RootElement, options);
        }

        internal static ModelClass DeserializeModelClass(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> stringProperty = default;
            EnumProperty enumProperty = default;
            Optional<Product> objProperty = default;
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
                    objProperty = Product.DeserializeProduct(property.Value);
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelClass(stringProperty.Value, enumProperty, objProperty.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<ModelClass>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        ModelClass IModel<ModelClass>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeModelClass(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<ModelClass>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

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
