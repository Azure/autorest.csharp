// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace validation.Models
{
    public partial class Product : IUtf8JsonSerializable, IJsonModel<Product>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Product>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<Product>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(DisplayNames))
            {
                writer.WritePropertyName("display_names"u8);
                writer.WriteStartArray();
                foreach (var item in DisplayNames)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Capacity))
            {
                writer.WritePropertyName("capacity"u8);
                writer.WriteNumberValue(Capacity.Value);
            }
            if (Optional.IsDefined(Image))
            {
                writer.WritePropertyName("image"u8);
                writer.WriteStringValue(Image);
            }
            writer.WritePropertyName("child"u8);
            writer.WriteObjectValue(Child);
            writer.WritePropertyName("constChild"u8);
            writer.WriteObjectValue(ConstChild);
            writer.WritePropertyName("constInt"u8);
            writer.WriteNumberValue(ConstInt.ToSerialInt32());
            writer.WritePropertyName("constString"u8);
            writer.WriteStringValue(ConstString.ToString());
            if (Optional.IsDefined(ConstStringAsEnum))
            {
                writer.WritePropertyName("constStringAsEnum"u8);
                writer.WriteStringValue(ConstStringAsEnum.Value.ToString());
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

        Product IJsonModel<Product>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Product)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeProduct(document.RootElement, options);
        }

        internal static Product DeserializeProduct(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> displayNames = default;
            Optional<int> capacity = default;
            Optional<string> image = default;
            ChildProduct child = default;
            ConstantProduct constChild = default;
            ProductConstInt constInt = default;
            ProductConstString constString = default;
            Optional<EnumConst> constStringAsEnum = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("display_names"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    displayNames = array;
                    continue;
                }
                if (property.NameEquals("capacity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    capacity = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("image"u8))
                {
                    image = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("child"u8))
                {
                    child = ChildProduct.DeserializeChildProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("constChild"u8))
                {
                    constChild = ConstantProduct.DeserializeConstantProduct(property.Value);
                    continue;
                }
                if (property.NameEquals("constInt"u8))
                {
                    constInt = new ProductConstInt(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("constString"u8))
                {
                    constString = new ProductConstString(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("constStringAsEnum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    constStringAsEnum = new EnumConst(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Product(Optional.ToList(displayNames), Optional.ToNullable(capacity), image.Value, child, constChild, constInt, constString, Optional.ToNullable(constStringAsEnum), serializedAdditionalRawData);
        }

        BinaryData IModel<Product>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Product)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        Product IModel<Product>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Product)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeProduct(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<Product>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
