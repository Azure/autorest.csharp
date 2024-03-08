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
using CustomizationsInTsp;

namespace CustomizationsInTsp.Models
{
    public partial class ModelWithCustomizedProperties : IUtf8JsonSerializable, IJsonModel<ModelWithCustomizedProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelWithCustomizedProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ModelWithCustomizedProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithCustomizedProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelWithCustomizedProperties)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("propertyToMakeInternal"u8);
            writer.WriteNumberValue(PropertyToMakeInternal);
            writer.WritePropertyName("propertyToRename"u8);
            writer.WriteNumberValue(RenamedProperty);
            writer.WritePropertyName("propertyToMakeFloat"u8);
            writer.WriteNumberValue(PropertyToMakeFloat);
            writer.WritePropertyName("propertyToMakeInt"u8);
            writer.WriteNumberValue(PropertyToMakeInt);
            writer.WritePropertyName("propertyToMakeDuration"u8);
            writer.WriteStringValue(PropertyToMakeDuration, "P");
            writer.WritePropertyName("propertyToMakeString"u8);
            writer.WriteStringValue(PropertyToMakeString);
            writer.WritePropertyName("propertyToMakeJsonElement"u8);
            PropertyToMakeJsonElement.WriteTo(writer);
            writer.WritePropertyName("propertyToField"u8);
            writer.WriteStringValue(_propertyToField);
            writer.WritePropertyName("badListName"u8);
            writer.WriteStartArray();
            foreach (var item in GoodListName)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("badDictionaryName"u8);
            writer.WriteStartObject();
            foreach (var item in GoodDictionaryName)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("badListOfListName"u8);
            writer.WriteStartArray();
            foreach (var item in GoodListOfListName)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteStartArray();
                foreach (var item0 in item)
                {
                    writer.WriteStringValue(item0);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
            writer.WritePropertyName("badListOfDictionaryName"u8);
            writer.WriteStartArray();
            foreach (var item in GoodListOfDictionaryName)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteStartObject();
                foreach (var item0 in item)
                {
                    writer.WritePropertyName(item0.Key);
                    writer.WriteStringValue(item0.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            writer.WritePropertyName("vector"u8);
            writer.WriteStartArray();
            foreach (var item in Vector.Span)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(VectorOptional))
            {
                writer.WritePropertyName("vectorOptional"u8);
                writer.WriteStartArray();
                foreach (var item in VectorOptional.Value.Span)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (VectorNullable != null)
            {
                writer.WritePropertyName("vectorNullable"u8);
                writer.WriteStartArray();
                foreach (var item in VectorNullable.Value.Span)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("vectorNullable");
            }
            if (Optional.IsDefined(VectorOptionalNullable))
            {
                if (VectorOptionalNullable != null)
                {
                    writer.WritePropertyName("vectorOptionalNullable"u8);
                    writer.WriteStartArray();
                    foreach (var item in VectorOptionalNullable.Value.Span)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("vectorOptionalNullable");
                }
            }
            if (options.Format != "W")
            {
                writer.WritePropertyName("vectorReadOnly"u8);
                writer.WriteStartArray();
                foreach (var item in VectorReadOnly.Span)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && Optional.IsDefined(VectorOptionalReadOnly))
            {
                writer.WritePropertyName("vectorOptionalReadOnly"u8);
                writer.WriteStartArray();
                foreach (var item in VectorOptionalReadOnly.Value.Span)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W")
            {
                if (VectorNullableReadOnly != null)
                {
                    writer.WritePropertyName("vectorNullableReadOnly"u8);
                    writer.WriteStartArray();
                    foreach (var item in VectorNullableReadOnly.Value.Span)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("vectorNullableReadOnly");
                }
            }
            if (options.Format != "W" && Optional.IsDefined(VectorOptionalNullableReadOnly))
            {
                if (VectorOptionalNullableReadOnly != null)
                {
                    writer.WritePropertyName("vectorOptionalNullableReadOnly"u8);
                    writer.WriteStartArray();
                    foreach (var item in VectorOptionalNullableReadOnly.Value.Span)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("vectorOptionalNullableReadOnly");
                }
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

        ModelWithCustomizedProperties IJsonModel<ModelWithCustomizedProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithCustomizedProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelWithCustomizedProperties)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithCustomizedProperties(document.RootElement, options);
        }

        internal static ModelWithCustomizedProperties DeserializeModelWithCustomizedProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int propertyToMakeInternal = default;
            int propertyToRename = default;
            float propertyToMakeFloat = default;
            int propertyToMakeInt = default;
            TimeSpan propertyToMakeDuration = default;
            string propertyToMakeString = default;
            JsonElement propertyToMakeJsonElement = default;
            string propertyToField = default;
            IList<string> badListName = default;
            IDictionary<string, string> badDictionaryName = default;
            IList<IList<string>> badListOfListName = default;
            IList<IDictionary<string, string>> badListOfDictionaryName = default;
            ReadOnlyMemory<float> vector = default;
            ReadOnlyMemory<float>? vectorOptional = default;
            ReadOnlyMemory<float>? vectorNullable = default;
            ReadOnlyMemory<float>? vectorOptionalNullable = default;
            ReadOnlyMemory<float> vectorReadOnly = default;
            ReadOnlyMemory<float>? vectorOptionalReadOnly = default;
            ReadOnlyMemory<float>? vectorNullableReadOnly = default;
            ReadOnlyMemory<float>? vectorOptionalNullableReadOnly = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("propertyToMakeInternal"u8))
                {
                    propertyToMakeInternal = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("propertyToRename"u8))
                {
                    propertyToRename = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("propertyToMakeFloat"u8))
                {
                    propertyToMakeFloat = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("propertyToMakeInt"u8))
                {
                    propertyToMakeInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("propertyToMakeDuration"u8))
                {
                    propertyToMakeDuration = property.Value.GetTimeSpan("P");
                    continue;
                }
                if (property.NameEquals("propertyToMakeString"u8))
                {
                    propertyToMakeString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("propertyToMakeJsonElement"u8))
                {
                    propertyToMakeJsonElement = property.Value.Clone();
                    continue;
                }
                if (property.NameEquals("propertyToField"u8))
                {
                    propertyToField = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("badListName"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    badListName = array;
                    continue;
                }
                if (property.NameEquals("badDictionaryName"u8))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    badDictionaryName = dictionary;
                    continue;
                }
                if (property.NameEquals("badListOfListName"u8))
                {
                    List<IList<string>> array = new List<IList<string>>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            List<string> array0 = new List<string>();
                            foreach (var item0 in item.EnumerateArray())
                            {
                                array0.Add(item0.GetString());
                            }
                            array.Add(array0);
                        }
                    }
                    badListOfListName = array;
                    continue;
                }
                if (property.NameEquals("badListOfDictionaryName"u8))
                {
                    List<IDictionary<string, string>> array = new List<IDictionary<string, string>>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            Dictionary<string, string> dictionary = new Dictionary<string, string>();
                            foreach (var property0 in item.EnumerateObject())
                            {
                                dictionary.Add(property0.Name, property0.Value.GetString());
                            }
                            array.Add(dictionary);
                        }
                    }
                    badListOfDictionaryName = array;
                    continue;
                }
                if (property.NameEquals("vector"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vector = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (property.NameEquals("vectorOptional"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorOptional = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (property.NameEquals("vectorNullable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorNullable = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (property.NameEquals("vectorOptionalNullable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorOptionalNullable = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (property.NameEquals("vectorReadOnly"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorReadOnly = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (property.NameEquals("vectorOptionalReadOnly"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorOptionalReadOnly = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (property.NameEquals("vectorNullableReadOnly"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorNullableReadOnly = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (property.NameEquals("vectorOptionalNullableReadOnly"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    int index = 0;
                    float[] array = new float[property.Value.GetArrayLength()];
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array[index] = item.GetSingle();
                        index++;
                    }
                    vectorOptionalNullableReadOnly = new ReadOnlyMemory<float>(array);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelWithCustomizedProperties(
                propertyToMakeInternal,
                propertyToRename,
                propertyToMakeFloat,
                propertyToMakeInt,
                propertyToMakeDuration,
                propertyToMakeString,
                propertyToMakeJsonElement,
                propertyToField,
                badListName,
                badDictionaryName,
                badListOfListName,
                badListOfDictionaryName,
                vector,
                vectorOptional,
                vectorNullable,
                vectorOptionalNullable,
                vectorReadOnly,
                vectorOptionalReadOnly,
                vectorNullableReadOnly,
                vectorOptionalNullableReadOnly,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ModelWithCustomizedProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithCustomizedProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ModelWithCustomizedProperties)} does not support '{options.Format}' format.");
            }
        }

        ModelWithCustomizedProperties IPersistableModel<ModelWithCustomizedProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithCustomizedProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeModelWithCustomizedProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ModelWithCustomizedProperties)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ModelWithCustomizedProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ModelWithCustomizedProperties FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeModelWithCustomizedProperties(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
