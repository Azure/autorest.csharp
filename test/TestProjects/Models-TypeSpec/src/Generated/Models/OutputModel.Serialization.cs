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

namespace ModelsTypeSpec.Models
{
    public partial class OutputModel : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredString"u8);
            writer.WriteStringValue(RequiredString);
            writer.WritePropertyName("requiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
            writer.WritePropertyName("requiredModel"u8);
            writer.WriteObjectValue(RequiredModel);
            writer.WritePropertyName("requiredCollection"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredCollection)
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
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeOutputModel(doc.RootElement, options);
        }

        internal static OutputModel DeserializeOutputModel(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
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
            }
            return new OutputModel(requiredString, requiredInt, requiredModel, requiredList, requiredModelRecord, Optional.ToList(optionalList), Optional.ToList(optionalNullableList), Optional.ToDictionary(optionalRecord), Optional.ToDictionary(optionalNullableRecord));
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeOutputModel(doc.RootElement, options);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static OutputModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeOutputModel(document.RootElement);
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
