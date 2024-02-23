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

namespace ModelsTypeSpec.Models
{
    public partial class RoundTripOptionalModel : IUtf8JsonSerializable, IJsonModel<RoundTripOptionalModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RoundTripOptionalModel>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<RoundTripOptionalModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoundTripOptionalModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RoundTripOptionalModel)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (OptionalString != null)
            {
                writer.WritePropertyName("optionalString"u8);
                writer.WriteStringValue(OptionalString);
            }
            if (OptionalInt.HasValue)
            {
                writer.WritePropertyName("optionalInt"u8);
                writer.WriteNumberValue(OptionalInt.Value);
            }
            if (!(OptionalStringList is ChangeTrackingList<string> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("optionalStringList"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (!(OptionalIntList is ChangeTrackingList<int> collection0 && collection0.IsUndefined))
            {
                writer.WritePropertyName("optionalIntList"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (!(OptionalModelList is ChangeTrackingList<CollectionItem> collection1 && collection1.IsUndefined))
            {
                writer.WritePropertyName("optionalModelList"u8);
                writer.WriteStartArray();
                foreach (var item in OptionalModelList)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (OptionalModel != null)
            {
                writer.WritePropertyName("optionalModel"u8);
                writer.WriteObjectValue(OptionalModel);
            }
            if (OptionalModelWithPropertiesOnBase != null)
            {
                writer.WritePropertyName("optionalModelWithPropertiesOnBase"u8);
                writer.WriteObjectValue(OptionalModelWithPropertiesOnBase);
            }
            if (OptionalFixedStringEnum.HasValue)
            {
                writer.WritePropertyName("optionalFixedStringEnum"u8);
                writer.WriteStringValue(OptionalFixedStringEnum.Value.ToSerialString());
            }
            if (OptionalExtensibleEnum.HasValue)
            {
                writer.WritePropertyName("optionalExtensibleEnum"u8);
                writer.WriteStringValue(OptionalExtensibleEnum.Value.ToString());
            }
            if (!(OptionalIntRecord is ChangeTrackingDictionary<string, int> collection2 && collection2.IsUndefined))
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
            if (!(OptionalStringRecord is ChangeTrackingDictionary<string, string> collection3 && collection3.IsUndefined))
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
            if (!(OptionalModelRecord is ChangeTrackingDictionary<string, RecordItem> collection4 && collection4.IsUndefined))
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
            if (OptionalPlainDate.HasValue)
            {
                writer.WritePropertyName("optionalPlainDate"u8);
                writer.WriteStringValue(OptionalPlainDate.Value, "D");
            }
            if (OptionalPlainTime.HasValue)
            {
                writer.WritePropertyName("optionalPlainTime"u8);
                writer.WriteStringValue(OptionalPlainTime.Value, "T");
            }
            if (!(OptionalCollectionWithNullableIntElement is ChangeTrackingList<int?> collection5 && collection5.IsUndefined))
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

        RoundTripOptionalModel IJsonModel<RoundTripOptionalModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoundTripOptionalModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RoundTripOptionalModel)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRoundTripOptionalModel(document.RootElement, options);
        }

        internal static RoundTripOptionalModel DeserializeRoundTripOptionalModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> optionalString = default;
            Optional<int> optionalInt = default;
            IList<string> optionalStringList = default;
            IList<int> optionalIntList = default;
            IList<CollectionItem> optionalModelList = default;
            Optional<DerivedModel> optionalModel = default;
            Optional<DerivedModelWithProperties> optionalModelWithPropertiesOnBase = default;
            Optional<FixedStringEnum> optionalFixedStringEnum = default;
            Optional<ExtensibleEnum> optionalExtensibleEnum = default;
            IDictionary<string, int> optionalIntRecord = default;
            IDictionary<string, string> optionalStringRecord = default;
            IDictionary<string, RecordItem> optionalModelRecord = default;
            Optional<DateTimeOffset> optionalPlainDate = default;
            Optional<TimeSpan> optionalPlainTime = default;
            IList<int?> optionalCollectionWithNullableIntElement = default;
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
                        array.Add(CollectionItem.DeserializeCollectionItem(item, options));
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
                    optionalModel = DerivedModel.DeserializeDerivedModel(property.Value, options);
                    continue;
                }
                if (property.NameEquals("optionalModelWithPropertiesOnBase"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalModelWithPropertiesOnBase = DerivedModelWithProperties.DeserializeDerivedModelWithProperties(property.Value, options);
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
                        dictionary.Add(property0.Name, RecordItem.DeserializeRecordItem(property0.Value, options));
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
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RoundTripOptionalModel(optionalString.Value, Optional.ToNullable(optionalInt), optionalStringList ?? new ChangeTrackingList<string>(), optionalIntList ?? new ChangeTrackingList<int>(), optionalModelList ?? new ChangeTrackingList<CollectionItem>(), optionalModel.Value, optionalModelWithPropertiesOnBase.Value, Optional.ToNullable(optionalFixedStringEnum), Optional.ToNullable(optionalExtensibleEnum), optionalIntRecord ?? new ChangeTrackingDictionary<string, int>(), optionalStringRecord ?? new ChangeTrackingDictionary<string, string>(), optionalModelRecord ?? new ChangeTrackingDictionary<string, RecordItem>(), Optional.ToNullable(optionalPlainDate), Optional.ToNullable(optionalPlainTime), optionalCollectionWithNullableIntElement ?? new ChangeTrackingList<int?>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RoundTripOptionalModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoundTripOptionalModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RoundTripOptionalModel)} does not support '{options.Format}' format.");
            }
        }

        RoundTripOptionalModel IPersistableModel<RoundTripOptionalModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoundTripOptionalModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRoundTripOptionalModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RoundTripOptionalModel)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RoundTripOptionalModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static RoundTripOptionalModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRoundTripOptionalModel(document.RootElement);
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
