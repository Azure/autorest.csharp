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
    public partial class RoundTripReadOnlyModel : IUtf8JsonSerializable, IModelJsonSerializable<RoundTripReadOnlyModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RoundTripReadOnlyModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RoundTripReadOnlyModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("requiredReadonlyString"u8);
                writer.WriteStringValue(RequiredReadonlyString);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("requiredReadonlyInt"u8);
                writer.WriteNumberValue(RequiredReadonlyInt);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(OptionalReadonlyString))
            {
                writer.WritePropertyName("optionalReadonlyString"u8);
                writer.WriteStringValue(OptionalReadonlyString);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(OptionalReadonlyInt))
            {
                writer.WritePropertyName("optionalReadonlyInt"u8);
                writer.WriteNumberValue(OptionalReadonlyInt.Value);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("requiredReadonlyModel"u8);
                writer.WriteObjectValue(RequiredReadonlyModel);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(OptionalReadonlyModel))
            {
                writer.WritePropertyName("optionalReadonlyModel"u8);
                writer.WriteObjectValue(OptionalReadonlyModel);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("requiredReadonlyFixedStringEnum"u8);
                writer.WriteStringValue(RequiredReadonlyFixedStringEnum.ToSerialString());
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("requiredReadonlyExtensibleEnum"u8);
                writer.WriteStringValue(RequiredReadonlyExtensibleEnum.ToString());
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("optionalReadonlyFixedStringEnum"u8);
                writer.WriteStringValue(OptionalReadonlyFixedStringEnum.ToSerialString());
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("optionalReadonlyExtensibleEnum"u8);
                writer.WriteStringValue(OptionalReadonlyExtensibleEnum.ToString());
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("requiredReadonlyStringList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredReadonlyStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("requiredReadonlyIntList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredReadonlyIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("requiredReadOnlyModelList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredReadOnlyModelList)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("requiredReadOnlyIntRecord"u8);
                writer.WriteStartObject();
                foreach (var item in RequiredReadOnlyIntRecord)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteNumberValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("requiredStringRecord"u8);
                writer.WriteStartObject();
                foreach (var item in RequiredStringRecord)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("requiredReadOnlyModelRecord"u8);
                writer.WriteStartObject();
                foreach (var item in RequiredReadOnlyModelRecord)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(OptionalReadonlyStringList))
            {
                writer.WritePropertyName("optionalReadonlyStringList"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalReadonlyStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(OptionalReadonlyIntList))
            {
                writer.WritePropertyName("optionalReadonlyIntList"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalReadonlyIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(OptionalReadOnlyModelList))
            {
                writer.WritePropertyName("optionalReadOnlyModelList"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalReadOnlyModelList)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("optionalReadOnlyIntRecord"u8);
            writer.WriteStartObject();
            foreach (var item in OptionalReadOnlyIntRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteNumberValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("optionalReadOnlyStringRecord"u8);
            writer.WriteStartObject();
            foreach (var item in OptionalReadOnlyStringRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(OptionalModelRecord))
            {
                writer.WritePropertyName("optionalModelRecord"u8);
                writer.WriteStartObject();
                foreach (var item in OptionalModelRecord)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("requiredCollectionWithNullableIntElement"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredCollectionWithNullableIntElement)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteNumberValue(item.Value);
            }
            writer.WriteEndArray();
            if (Optional.IsCollectionDefined(OptionalCollectionWithNullableBooleanElement))
            {
                writer.WritePropertyName("optionalCollectionWithNullableBooleanElement"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalCollectionWithNullableBooleanElement)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteBooleanValue(item.Value);
                }
                writer.WriteEndArray();
            }
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

        RoundTripReadOnlyModel IModelJsonSerializable<RoundTripReadOnlyModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRoundTripReadOnlyModel(document.RootElement, options);
        }

        BinaryData IModelSerializable<RoundTripReadOnlyModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        RoundTripReadOnlyModel IModelSerializable<RoundTripReadOnlyModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeRoundTripReadOnlyModel(document.RootElement, options);
        }

        internal static RoundTripReadOnlyModel DeserializeRoundTripReadOnlyModel(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredReadonlyString = default;
            int requiredReadonlyInt = default;
            Optional<string> optionalReadonlyString = default;
            Optional<int> optionalReadonlyInt = default;
            DerivedModel requiredReadonlyModel = default;
            Optional<DerivedModel> optionalReadonlyModel = default;
            FixedStringEnum requiredReadonlyFixedStringEnum = default;
            ExtensibleEnum requiredReadonlyExtensibleEnum = default;
            FixedStringEnum optionalReadonlyFixedStringEnum = default;
            ExtensibleEnum optionalReadonlyExtensibleEnum = default;
            IReadOnlyList<string> requiredReadonlyStringList = default;
            IReadOnlyList<int> requiredReadonlyIntList = default;
            IReadOnlyList<CollectionItem> requiredReadOnlyModelList = default;
            IReadOnlyDictionary<string, int> requiredReadOnlyIntRecord = default;
            IReadOnlyDictionary<string, string> requiredStringRecord = default;
            IReadOnlyDictionary<string, RecordItem> requiredReadOnlyModelRecord = default;
            Optional<IReadOnlyList<string>> optionalReadonlyStringList = default;
            Optional<IReadOnlyList<int>> optionalReadonlyIntList = default;
            Optional<IReadOnlyList<CollectionItem>> optionalReadOnlyModelList = default;
            IReadOnlyDictionary<string, int> optionalReadOnlyIntRecord = default;
            IReadOnlyDictionary<string, string> optionalReadOnlyStringRecord = default;
            Optional<IReadOnlyDictionary<string, RecordItem>> optionalModelRecord = default;
            IReadOnlyList<int?> requiredCollectionWithNullableIntElement = default;
            Optional<IReadOnlyList<bool?>> optionalCollectionWithNullableBooleanElement = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredReadonlyString"u8))
                {
                    requiredReadonlyString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredReadonlyInt"u8))
                {
                    requiredReadonlyInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("optionalReadonlyString"u8))
                {
                    optionalReadonlyString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("optionalReadonlyInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalReadonlyInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredReadonlyModel"u8))
                {
                    requiredReadonlyModel = DerivedModel.DeserializeDerivedModel(property.Value);
                    continue;
                }
                if (property.NameEquals("optionalReadonlyModel"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalReadonlyModel = DerivedModel.DeserializeDerivedModel(property.Value);
                    continue;
                }
                if (property.NameEquals("requiredReadonlyFixedStringEnum"u8))
                {
                    requiredReadonlyFixedStringEnum = property.Value.GetString().ToFixedStringEnum();
                    continue;
                }
                if (property.NameEquals("requiredReadonlyExtensibleEnum"u8))
                {
                    requiredReadonlyExtensibleEnum = new ExtensibleEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("optionalReadonlyFixedStringEnum"u8))
                {
                    optionalReadonlyFixedStringEnum = property.Value.GetString().ToFixedStringEnum();
                    continue;
                }
                if (property.NameEquals("optionalReadonlyExtensibleEnum"u8))
                {
                    optionalReadonlyExtensibleEnum = new ExtensibleEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requiredReadonlyStringList"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredReadonlyStringList = array;
                    continue;
                }
                if (property.NameEquals("requiredReadonlyIntList"u8))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredReadonlyIntList = array;
                    continue;
                }
                if (property.NameEquals("requiredReadOnlyModelList"u8))
                {
                    List<CollectionItem> array = new List<CollectionItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CollectionItem.DeserializeCollectionItem(item));
                    }
                    requiredReadOnlyModelList = array;
                    continue;
                }
                if (property.NameEquals("requiredReadOnlyIntRecord"u8))
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetInt32());
                    }
                    requiredReadOnlyIntRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("requiredStringRecord"u8))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    requiredStringRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("requiredReadOnlyModelRecord"u8))
                {
                    Dictionary<string, RecordItem> dictionary = new Dictionary<string, RecordItem>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, RecordItem.DeserializeRecordItem(property0.Value));
                    }
                    requiredReadOnlyModelRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("optionalReadonlyStringList"u8))
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
                    optionalReadonlyStringList = array;
                    continue;
                }
                if (property.NameEquals("optionalReadonlyIntList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    optionalReadonlyIntList = array;
                    continue;
                }
                if (property.NameEquals("optionalReadOnlyModelList"u8))
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
                    optionalReadOnlyModelList = array;
                    continue;
                }
                if (property.NameEquals("optionalReadOnlyIntRecord"u8))
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetInt32());
                    }
                    optionalReadOnlyIntRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("optionalReadOnlyStringRecord"u8))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    optionalReadOnlyStringRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("optionalModelRecord"u8))
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
                    optionalModelRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("requiredCollectionWithNullableIntElement"u8))
                {
                    List<int?> array = new List<int?>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetInt32());
                        }
                    }
                    requiredCollectionWithNullableIntElement = array;
                    continue;
                }
                if (property.NameEquals("optionalCollectionWithNullableBooleanElement"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<bool?> array = new List<bool?>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetBoolean());
                        }
                    }
                    optionalCollectionWithNullableBooleanElement = array;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RoundTripReadOnlyModel(requiredReadonlyString, requiredReadonlyInt, optionalReadonlyString.Value, Optional.ToNullable(optionalReadonlyInt), requiredReadonlyModel, optionalReadonlyModel.Value, requiredReadonlyFixedStringEnum, requiredReadonlyExtensibleEnum, optionalReadonlyFixedStringEnum, optionalReadonlyExtensibleEnum, requiredReadonlyStringList, requiredReadonlyIntList, requiredReadOnlyModelList, requiredReadOnlyIntRecord, requiredStringRecord, requiredReadOnlyModelRecord, Optional.ToList(optionalReadonlyStringList), Optional.ToList(optionalReadonlyIntList), Optional.ToList(optionalReadOnlyModelList), optionalReadOnlyIntRecord, optionalReadOnlyStringRecord, Optional.ToDictionary(optionalModelRecord), requiredCollectionWithNullableIntElement, Optional.ToList(optionalCollectionWithNullableBooleanElement), serializedAdditionalRawData);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static RoundTripReadOnlyModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRoundTripReadOnlyModel(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
