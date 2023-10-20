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
    public partial class RoundTripOptionalModel : IUtf8JsonSerializable, IModelJsonSerializable<RoundTripOptionalModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RoundTripOptionalModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RoundTripOptionalModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(OptionalString))
            {
                writer.WritePropertyName("optionalString"u8);
                writer.WriteStringValue(OptionalString);
            }
            if (Optional.IsDefined(OptionalInt))
            {
                writer.WritePropertyName("optionalInt"u8);
                writer.WriteNumberValue(OptionalInt.Value);
            }
            if (Optional.IsCollectionDefined(OptionalStringList))
            {
                writer.WritePropertyName("optionalStringList"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(OptionalIntList))
            {
                writer.WritePropertyName("optionalIntList"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(OptionalModelList))
            {
                writer.WritePropertyName("optionalModelList"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalModelList)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(OptionalModel))
            {
                writer.WritePropertyName("optionalModel"u8);
                writer.WriteObjectValue(OptionalModel);
            }
            if (Optional.IsDefined(OptionalModelWithPropertiesOnBase))
            {
                writer.WritePropertyName("optionalModelWithPropertiesOnBase"u8);
                writer.WriteObjectValue(OptionalModelWithPropertiesOnBase);
            }
            if (Optional.IsDefined(OptionalFixedStringEnum))
            {
                writer.WritePropertyName("optionalFixedStringEnum"u8);
                writer.WriteStringValue(OptionalFixedStringEnum.Value.ToSerialString());
            }
            if (Optional.IsDefined(OptionalExtensibleEnum))
            {
                writer.WritePropertyName("optionalExtensibleEnum"u8);
                writer.WriteStringValue(OptionalExtensibleEnum.Value.ToString());
            }
            if (Optional.IsCollectionDefined(OptionalIntRecord))
            {
                writer.WritePropertyName("optionalIntRecord"u8);
                writer.WriteStartObject();
                foreach (var item in OptionalIntRecord)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteNumberValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsCollectionDefined(OptionalStringRecord))
            {
                writer.WritePropertyName("optionalStringRecord"u8);
                writer.WriteStartObject();
                foreach (var item in OptionalStringRecord)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsCollectionDefined(OptionalModelRecord))
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
            if (Optional.IsDefined(OptionalPlainDate))
            {
                writer.WritePropertyName("optionalPlainDate"u8);
                writer.WriteStringValue(OptionalPlainDate.Value, "D");
            }
            if (Optional.IsDefined(OptionalPlainTime))
            {
                writer.WritePropertyName("optionalPlainTime"u8);
                writer.WriteStringValue(OptionalPlainTime.Value, "T");
            }
            if (Optional.IsCollectionDefined(OptionalCollectionWithNullableIntElement))
            {
                writer.WritePropertyName("optionalCollectionWithNullableIntElement"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalCollectionWithNullableIntElement)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteNumberValue(item.Value);
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

        RoundTripOptionalModel IModelJsonSerializable<RoundTripOptionalModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRoundTripOptionalModel(document.RootElement, options);
        }

        internal static RoundTripOptionalModel DeserializeRoundTripOptionalModel(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> optionalString = default;
            Optional<int> optionalInt = default;
            Optional<IList<string>> optionalStringList = default;
            Optional<IList<int>> optionalIntList = default;
            Optional<IList<CollectionItem>> optionalModelList = default;
            Optional<DerivedModel> optionalModel = default;
            Optional<DerivedModelWithProperties> optionalModelWithPropertiesOnBase = default;
            Optional<FixedStringEnum> optionalFixedStringEnum = default;
            Optional<ExtensibleEnum> optionalExtensibleEnum = default;
            Optional<IDictionary<string, int>> optionalIntRecord = default;
            Optional<IDictionary<string, string>> optionalStringRecord = default;
            Optional<IDictionary<string, RecordItem>> optionalModelRecord = default;
            Optional<DateTimeOffset> optionalPlainDate = default;
            Optional<TimeSpan> optionalPlainTime = default;
            Optional<IList<int?>> optionalCollectionWithNullableIntElement = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("optionalString"u8))
                {
                    optionalString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("optionalInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("optionalStringList"u8))
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
                    optionalStringList = array;
                    continue;
                }
                if (property.NameEquals("optionalIntList"u8))
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
                    optionalIntList = array;
                    continue;
                }
                if (property.NameEquals("optionalModelList"u8))
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
                    optionalModelList = array;
                    continue;
                }
                if (property.NameEquals("optionalModel"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalModel = DerivedModel.DeserializeDerivedModel(property.Value);
                    continue;
                }
                if (property.NameEquals("optionalModelWithPropertiesOnBase"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalModelWithPropertiesOnBase = DerivedModelWithProperties.DeserializeDerivedModelWithProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("optionalFixedStringEnum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalFixedStringEnum = property.Value.GetString().ToFixedStringEnum();
                    continue;
                }
                if (property.NameEquals("optionalExtensibleEnum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalExtensibleEnum = new ExtensibleEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("optionalIntRecord"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetInt32());
                    }
                    optionalIntRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("optionalStringRecord"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    optionalStringRecord = dictionary;
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
                if (property.NameEquals("optionalPlainDate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalPlainDate = property.Value.GetDateTimeOffset("D");
                    continue;
                }
                if (property.NameEquals("optionalPlainTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalPlainTime = property.Value.GetTimeSpan("T");
                    continue;
                }
                if (property.NameEquals("optionalCollectionWithNullableIntElement"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
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
                    optionalCollectionWithNullableIntElement = array;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RoundTripOptionalModel(optionalString.Value, Optional.ToNullable(optionalInt), Optional.ToList(optionalStringList), Optional.ToList(optionalIntList), Optional.ToList(optionalModelList), optionalModel.Value, optionalModelWithPropertiesOnBase.Value, Optional.ToNullable(optionalFixedStringEnum), Optional.ToNullable(optionalExtensibleEnum), Optional.ToDictionary(optionalIntRecord), Optional.ToDictionary(optionalStringRecord), Optional.ToDictionary(optionalModelRecord), Optional.ToNullable(optionalPlainDate), Optional.ToNullable(optionalPlainTime), Optional.ToList(optionalCollectionWithNullableIntElement), serializedAdditionalRawData);
        }

        BinaryData IModelSerializable<RoundTripOptionalModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        RoundTripOptionalModel IModelSerializable<RoundTripOptionalModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeRoundTripOptionalModel(document.RootElement, options);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static RoundTripOptionalModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRoundTripOptionalModel(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
