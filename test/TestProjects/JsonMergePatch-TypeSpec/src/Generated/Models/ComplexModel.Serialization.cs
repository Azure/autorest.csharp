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

namespace Payload.JsonMergePatch.Models
{
    public partial class ComplexModel : IUtf8JsonSerializable, IJsonModel<ComplexModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ComplexModel>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ComplexModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComplexModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ComplexModel)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("arrayOfInt"u8);
            writer.WriteStartArray();
            foreach (var item in ArrayOfInt)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("arrayOfModel"u8);
            writer.WriteStartArray();
            foreach (var item in ArrayOfModel)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("arrayOfIntArray"u8);
            writer.WriteStartArray();
            foreach (var item in ArrayOfIntArray)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteStartArray();
                foreach (var item0 in item)
                {
                    writer.WriteNumberValue(item0);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
            writer.WritePropertyName("arrayOfModelArray"u8);
            writer.WriteStartArray();
            foreach (var item in ArrayOfModelArray)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteStartArray();
                foreach (var item0 in item)
                {
                    writer.WriteObjectValue(item0);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
            writer.WritePropertyName("dictOfInt"u8);
            writer.WriteStartObject();
            foreach (var item in DictOfInt)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteNumberValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("dictOfModel"u8);
            writer.WriteStartObject();
            foreach (var item in DictOfModel)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("dictOfIntDict"u8);
            writer.WriteStartObject();
            foreach (var item in DictOfIntDict)
            {
                writer.WritePropertyName(item.Key);
                if (item.Value == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteStartObject();
                foreach (var item0 in item.Value)
                {
                    writer.WritePropertyName(item0.Key);
                    writer.WriteNumberValue(item0.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
            writer.WritePropertyName("dictOfModelDict"u8);
            writer.WriteStartObject();
            foreach (var item in DictOfModelDict)
            {
                writer.WritePropertyName(item.Key);
                if (item.Value == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteStartObject();
                foreach (var item0 in item.Value)
                {
                    writer.WritePropertyName(item0.Key);
                    writer.WriteObjectValue(item0.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
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

        ComplexModel IJsonModel<ComplexModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComplexModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ComplexModel)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeComplexModel(document.RootElement, options);
        }

        internal static ComplexModel DeserializeComplexModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<int> arrayOfInt = default;
            IList<BaseModel> arrayOfModel = default;
            IList<IList<int>> arrayOfIntArray = default;
            IList<IList<BaseModel>> arrayOfModelArray = default;
            IDictionary<string, int> dictOfInt = default;
            IDictionary<string, BaseModel> dictOfModel = default;
            IDictionary<string, IDictionary<string, int>> dictOfIntDict = default;
            IDictionary<string, IDictionary<string, BaseModel>> dictOfModelDict = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("arrayOfInt"u8))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    arrayOfInt = array;
                    continue;
                }
                if (property.NameEquals("arrayOfModel"u8))
                {
                    List<BaseModel> array = new List<BaseModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BaseModel.DeserializeBaseModel(item));
                    }
                    arrayOfModel = array;
                    continue;
                }
                if (property.NameEquals("arrayOfIntArray"u8))
                {
                    List<IList<int>> array = new List<IList<int>>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            List<int> array0 = new List<int>();
                            foreach (var item0 in item.EnumerateArray())
                            {
                                array0.Add(item0.GetInt32());
                            }
                            array.Add(array0);
                        }
                    }
                    arrayOfIntArray = array;
                    continue;
                }
                if (property.NameEquals("arrayOfModelArray"u8))
                {
                    List<IList<BaseModel>> array = new List<IList<BaseModel>>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            List<BaseModel> array0 = new List<BaseModel>();
                            foreach (var item0 in item.EnumerateArray())
                            {
                                array0.Add(BaseModel.DeserializeBaseModel(item0));
                            }
                            array.Add(array0);
                        }
                    }
                    arrayOfModelArray = array;
                    continue;
                }
                if (property.NameEquals("dictOfInt"u8))
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetInt32());
                    }
                    dictOfInt = dictionary;
                    continue;
                }
                if (property.NameEquals("dictOfModel"u8))
                {
                    Dictionary<string, BaseModel> dictionary = new Dictionary<string, BaseModel>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, BaseModel.DeserializeBaseModel(property0.Value));
                    }
                    dictOfModel = dictionary;
                    continue;
                }
                if (property.NameEquals("dictOfIntDict"u8))
                {
                    Dictionary<string, IDictionary<string, int>> dictionary = new Dictionary<string, IDictionary<string, int>>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(property0.Name, null);
                        }
                        else
                        {
                            Dictionary<string, int> dictionary0 = new Dictionary<string, int>();
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                dictionary0.Add(property1.Name, property1.Value.GetInt32());
                            }
                            dictionary.Add(property0.Name, dictionary0);
                        }
                    }
                    dictOfIntDict = dictionary;
                    continue;
                }
                if (property.NameEquals("dictOfModelDict"u8))
                {
                    Dictionary<string, IDictionary<string, BaseModel>> dictionary = new Dictionary<string, IDictionary<string, BaseModel>>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(property0.Name, null);
                        }
                        else
                        {
                            Dictionary<string, BaseModel> dictionary0 = new Dictionary<string, BaseModel>();
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                dictionary0.Add(property1.Name, BaseModel.DeserializeBaseModel(property1.Value));
                            }
                            dictionary.Add(property0.Name, dictionary0);
                        }
                    }
                    dictOfModelDict = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ComplexModel(arrayOfInt, arrayOfModel, arrayOfIntArray, arrayOfModelArray, dictOfInt, dictOfModel, dictOfIntDict, dictOfModelDict, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ComplexModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComplexModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ComplexModel)} does not support '{options.Format}' format.");
            }
        }

        ComplexModel IPersistableModel<ComplexModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ComplexModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeComplexModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ComplexModel)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ComplexModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ComplexModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeComplexModel(document.RootElement);
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
