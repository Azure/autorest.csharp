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
    public partial class OutputModel : IUtf8JsonSerializable, IJsonModel<OutputModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<OutputModel>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<OutputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<OutputModel>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<OutputModel>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("requiredString"u8);
            writer.WriteStringValue(RequiredString);
            writer.WritePropertyName("requiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
            writer.WritePropertyName("requiredModel"u8);
            writer.WriteObjectValue(RequiredModel);
            writer.WritePropertyName("requiredList"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredList)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("requiredModelRecord"u8);
            writer.WriteStartObject();
            foreach (var item in RequiredModelRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
            if (Optional.IsCollectionDefined(OptionalList))
            {
                writer.WritePropertyName("optionalList"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalList)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(OptionalNullableList))
            {
                if (OptionalNullableList != null)
                {
                    writer.WritePropertyName("optionalNullableList"u8);
                    writer.WriteStartArray();
                    foreach (var item in OptionalNullableList)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("optionalNullableList");
                }
            }
            if (Optional.IsCollectionDefined(OptionalRecord))
            {
                writer.WritePropertyName("optionalRecord"u8);
                writer.WriteStartObject();
                foreach (var item in OptionalRecord)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsCollectionDefined(OptionalNullableRecord))
            {
                if (OptionalNullableRecord != null)
                {
                    writer.WritePropertyName("optionalNullableRecord"u8);
                    writer.WriteStartObject();
                    foreach (var item in OptionalNullableRecord)
                    {
                        writer.WritePropertyName(item.Key);
                        writer.WriteObjectValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
                else
                {
                    writer.WriteNull("optionalNullableRecord");
                }
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

        OutputModel IJsonModel<OutputModel>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(OutputModel)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOutputModel(document.RootElement, options);
        }

        internal static OutputModel DeserializeOutputModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredString = default;
            int requiredInt = default;
            DerivedModel requiredModel = default;
            IReadOnlyList<CollectionItem> requiredList = default;
            IReadOnlyDictionary<string, RecordItem> requiredModelRecord = default;
            Optional<IReadOnlyList<CollectionItem>> optionalList = default;
            Optional<IReadOnlyList<CollectionItem>> optionalNullableList = default;
            Optional<IReadOnlyDictionary<string, RecordItem>> optionalRecord = default;
            Optional<IReadOnlyDictionary<string, RecordItem>> optionalNullableRecord = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredString"u8))
                {
                    requiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredInt"u8))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredModel"u8))
                {
                    requiredModel = DerivedModel.DeserializeDerivedModel(property.Value);
                    continue;
                }
                if (property.NameEquals("requiredList"u8))
                {
                    List<CollectionItem> array = new List<CollectionItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CollectionItem.DeserializeCollectionItem(item));
                    }
                    requiredList = array;
                    continue;
                }
                if (property.NameEquals("requiredModelRecord"u8))
                {
                    Dictionary<string, RecordItem> dictionary = new Dictionary<string, RecordItem>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, RecordItem.DeserializeRecordItem(property0.Value));
                    }
                    requiredModelRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("optionalList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<CollectionItem> array = new List<CollectionItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CollectionItem.DeserializeCollectionItem(item));
                    }
                    optionalList = array;
                    continue;
                }
                if (property.NameEquals("optionalNullableList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<CollectionItem> array = new List<CollectionItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CollectionItem.DeserializeCollectionItem(item));
                    }
                    optionalNullableList = array;
                    continue;
                }
                if (property.NameEquals("optionalRecord"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, RecordItem> dictionary = new Dictionary<string, RecordItem>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, RecordItem.DeserializeRecordItem(property0.Value));
                    }
                    optionalRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("optionalNullableRecord"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, RecordItem> dictionary = new Dictionary<string, RecordItem>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, RecordItem.DeserializeRecordItem(property0.Value));
                    }
                    optionalNullableRecord = dictionary;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new OutputModel(requiredString, requiredInt, requiredModel, requiredList, requiredModelRecord, Optional.ToList(optionalList), Optional.ToList(optionalNullableList), Optional.ToDictionary(optionalRecord), Optional.ToDictionary(optionalNullableRecord), serializedAdditionalRawData);
        }

        BinaryData IModel<OutputModel>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(OutputModel)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        OutputModel IModel<OutputModel>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(OutputModel)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeOutputModel(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<OutputModel>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static OutputModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeOutputModel(document.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
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
