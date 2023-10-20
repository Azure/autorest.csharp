// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace CustomizationsInTsp.Models
{
    public partial class ModelWithCustomizedProperties : IUtf8JsonSerializable, IModelJsonSerializable<ModelWithCustomizedProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelWithCustomizedProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ModelWithCustomizedProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
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
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        ModelWithCustomizedProperties IModelJsonSerializable<ModelWithCustomizedProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithCustomizedProperties(document.RootElement, options);
        }

        internal static ModelWithCustomizedProperties DeserializeModelWithCustomizedProperties(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelWithCustomizedProperties(propertyToMakeInternal, propertyToRename, propertyToMakeFloat, propertyToMakeInt, propertyToMakeDuration, propertyToMakeString, propertyToMakeJsonElement, propertyToField, badListName, badDictionaryName, badListOfListName, badListOfDictionaryName, serializedAdditionalRawData);
        }

        BinaryData IModelSerializable<ModelWithCustomizedProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ModelWithCustomizedProperties IModelSerializable<ModelWithCustomizedProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeModelWithCustomizedProperties(document.RootElement, options);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ModelWithCustomizedProperties FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeModelWithCustomizedProperties(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
