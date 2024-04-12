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
    public partial class InputModel : IUtf8JsonSerializable, IJsonModel<InputModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<InputModel>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<InputModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InputModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InputModel)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("requiredString"u8);
            writer.WriteStringValue(RequiredString);
            writer.WritePropertyName("requiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
            if (RequiredNullableInt != null)
            {
                writer.WritePropertyName("requiredNullableInt"u8);
                writer.WriteNumberValue(RequiredNullableInt.Value);
            }
            else
            {
                writer.WriteNull("requiredNullableInt");
            }
            if (RequiredNullableString != null)
            {
                writer.WritePropertyName("requiredNullableString"u8);
                writer.WriteStringValue(RequiredNullableString);
            }
            else
            {
                writer.WriteNull("requiredNullableString");
            }
            if (Optional.IsDefined(NonRequiredNullableInt))
            {
                if (NonRequiredNullableInt != null)
                {
                    writer.WritePropertyName("nonRequiredNullableInt"u8);
                    writer.WriteNumberValue(NonRequiredNullableInt.Value);
                }
                else
                {
                    writer.WriteNull("nonRequiredNullableInt");
                }
            }
            if (Optional.IsDefined(NonRequiredNullableString))
            {
                if (NonRequiredNullableString != null)
                {
                    writer.WritePropertyName("nonRequiredNullableString"u8);
                    writer.WriteStringValue(NonRequiredNullableString);
                }
                else
                {
                    writer.WriteNull("nonRequiredNullableString");
                }
            }
            writer.WritePropertyName("requiredModel"u8);
            writer.WriteObjectValue(RequiredModel, options);
            writer.WritePropertyName("requiredModel2"u8);
            writer.WriteObjectValue(RequiredModel2, options);
            writer.WritePropertyName("requiredIntList"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredIntList)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("requiredStringList"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredStringList)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("requiredModelList"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredModelList)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("requiredModelRecord"u8);
            writer.WriteStartObject();
            foreach (var item in RequiredModelRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value, options);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("requiredCollectionWithNullableFloatElement"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredCollectionWithNullableFloatElement)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteNumberValue(item.Value);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("requiredCollectionWithNullableBooleanElement"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredCollectionWithNullableBooleanElement)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteBooleanValue(item.Value);
            }
            writer.WriteEndArray();
            if (RequiredNullableModelList != null && Optional.IsCollectionDefined(RequiredNullableModelList))
            {
                writer.WritePropertyName("requiredNullableModelList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredNullableModelList)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("requiredNullableModelList");
            }
            if (RequiredNullableStringList != null && Optional.IsCollectionDefined(RequiredNullableStringList))
            {
                writer.WritePropertyName("requiredNullableStringList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredNullableStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("requiredNullableStringList");
            }
            if (RequiredNullableIntList != null && Optional.IsCollectionDefined(RequiredNullableIntList))
            {
                writer.WritePropertyName("requiredNullableIntList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredNullableIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("requiredNullableIntList");
            }
            if (Optional.IsCollectionDefined(NonRequiredModelList))
            {
                writer.WritePropertyName("nonRequiredModelList"u8);
                writer.WriteStartArray();
                foreach (var item in NonRequiredModelList)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(NonRequiredStringList))
            {
                writer.WritePropertyName("nonRequiredStringList"u8);
                writer.WriteStartArray();
                foreach (var item in NonRequiredStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(NonRequiredIntList))
            {
                writer.WritePropertyName("nonRequiredIntList"u8);
                writer.WriteStartArray();
                foreach (var item in NonRequiredIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(NonRequiredNullableModelList))
            {
                if (NonRequiredNullableModelList != null)
                {
                    writer.WritePropertyName("nonRequiredNullableModelList"u8);
                    writer.WriteStartArray();
                    foreach (var item in NonRequiredNullableModelList)
                    {
                        writer.WriteObjectValue(item, options);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("nonRequiredNullableModelList");
                }
            }
            if (Optional.IsCollectionDefined(NonRequiredNullableStringList))
            {
                if (NonRequiredNullableStringList != null)
                {
                    writer.WritePropertyName("nonRequiredNullableStringList"u8);
                    writer.WriteStartArray();
                    foreach (var item in NonRequiredNullableStringList)
                    {
                        writer.WriteStringValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("nonRequiredNullableStringList");
                }
            }
            if (Optional.IsCollectionDefined(NonRequiredNullableIntList))
            {
                if (NonRequiredNullableIntList != null)
                {
                    writer.WritePropertyName("nonRequiredNullableIntList"u8);
                    writer.WriteStartArray();
                    foreach (var item in NonRequiredNullableIntList)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("nonRequiredNullableIntList");
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

        InputModel IJsonModel<InputModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InputModel>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InputModel)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInputModel(document.RootElement, options);
        }

        internal static InputModel DeserializeInputModel(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredString = default;
            int requiredInt = default;
            int? requiredNullableInt = default;
            string requiredNullableString = default;
            int? nonRequiredNullableInt = default;
            string nonRequiredNullableString = default;
            BaseModel requiredModel = default;
            BaseModel requiredModel2 = default;
            IList<int> requiredIntList = default;
            IList<string> requiredStringList = default;
            IList<CollectionItem> requiredModelList = default;
            IDictionary<string, RecordItem> requiredModelRecord = default;
            IList<float?> requiredCollectionWithNullableFloatElement = default;
            IList<bool?> requiredCollectionWithNullableBooleanElement = default;
            IList<CollectionItem> requiredNullableModelList = default;
            IList<string> requiredNullableStringList = default;
            IList<int> requiredNullableIntList = default;
            IList<CollectionItem> nonRequiredModelList = default;
            IList<string> nonRequiredStringList = default;
            IList<int> nonRequiredIntList = default;
            IList<CollectionItem> nonRequiredNullableModelList = default;
            IList<string> nonRequiredNullableStringList = default;
            IList<int> nonRequiredNullableIntList = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
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
                if (property.NameEquals("requiredNullableInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableInt = null;
                        continue;
                    }
                    requiredNullableInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredNullableString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableString = null;
                        continue;
                    }
                    requiredNullableString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("nonRequiredNullableInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableInt = null;
                        continue;
                    }
                    nonRequiredNullableInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("nonRequiredNullableString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableString = null;
                        continue;
                    }
                    nonRequiredNullableString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredModel"u8))
                {
                    requiredModel = BaseModel.DeserializeBaseModel(property.Value, options);
                    continue;
                }
                if (property.NameEquals("requiredModel2"u8))
                {
                    requiredModel2 = BaseModel.DeserializeBaseModel(property.Value, options);
                    continue;
                }
                if (property.NameEquals("requiredIntList"u8))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredIntList = array;
                    continue;
                }
                if (property.NameEquals("requiredStringList"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredStringList = array;
                    continue;
                }
                if (property.NameEquals("requiredModelList"u8))
                {
                    List<CollectionItem> array = new List<CollectionItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CollectionItem.DeserializeCollectionItem(item, options));
                    }
                    requiredModelList = array;
                    continue;
                }
                if (property.NameEquals("requiredModelRecord"u8))
                {
                    Dictionary<string, RecordItem> dictionary = new Dictionary<string, RecordItem>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, RecordItem.DeserializeRecordItem(property0.Value, options));
                    }
                    requiredModelRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("requiredCollectionWithNullableFloatElement"u8))
                {
                    List<float?> array = new List<float?>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetSingle());
                        }
                    }
                    requiredCollectionWithNullableFloatElement = array;
                    continue;
                }
                if (property.NameEquals("requiredCollectionWithNullableBooleanElement"u8))
                {
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
                    requiredCollectionWithNullableBooleanElement = array;
                    continue;
                }
                if (property.NameEquals("requiredNullableModelList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableModelList = new ChangeTrackingList<CollectionItem>();
                        continue;
                    }
                    List<CollectionItem> array = new List<CollectionItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CollectionItem.DeserializeCollectionItem(item, options));
                    }
                    requiredNullableModelList = array;
                    continue;
                }
                if (property.NameEquals("requiredNullableStringList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableStringList = new ChangeTrackingList<string>();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredNullableStringList = array;
                    continue;
                }
                if (property.NameEquals("requiredNullableIntList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableIntList = new ChangeTrackingList<int>();
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredNullableIntList = array;
                    continue;
                }
                if (property.NameEquals("nonRequiredModelList"u8))
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
                    nonRequiredModelList = array;
                    continue;
                }
                if (property.NameEquals("nonRequiredStringList"u8))
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
                    nonRequiredStringList = array;
                    continue;
                }
                if (property.NameEquals("nonRequiredIntList"u8))
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
                    nonRequiredIntList = array;
                    continue;
                }
                if (property.NameEquals("nonRequiredNullableModelList"u8))
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
                    nonRequiredNullableModelList = array;
                    continue;
                }
                if (property.NameEquals("nonRequiredNullableStringList"u8))
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
                    nonRequiredNullableStringList = array;
                    continue;
                }
                if (property.NameEquals("nonRequiredNullableIntList"u8))
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
                    nonRequiredNullableIntList = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InputModel(
                requiredString,
                requiredInt,
                requiredNullableInt,
                requiredNullableString,
                nonRequiredNullableInt,
                nonRequiredNullableString,
                requiredModel,
                requiredModel2,
                requiredIntList,
                requiredStringList,
                requiredModelList,
                requiredModelRecord,
                requiredCollectionWithNullableFloatElement,
                requiredCollectionWithNullableBooleanElement,
                requiredNullableModelList,
                requiredNullableStringList,
                requiredNullableIntList,
                nonRequiredModelList ?? new ChangeTrackingList<CollectionItem>(),
                nonRequiredStringList ?? new ChangeTrackingList<string>(),
                nonRequiredIntList ?? new ChangeTrackingList<int>(),
                nonRequiredNullableModelList ?? new ChangeTrackingList<CollectionItem>(),
                nonRequiredNullableStringList ?? new ChangeTrackingList<string>(),
                nonRequiredNullableIntList ?? new ChangeTrackingList<int>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InputModel>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InputModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InputModel)} does not support writing '{options.Format}' format.");
            }
        }

        InputModel IPersistableModel<InputModel>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InputModel>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInputModel(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InputModel)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InputModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static InputModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInputModel(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            BinaryData binaryData = ModelReaderWriter.Write(this, new ModelReaderWriterOptions("W"));
            return RequestContent.Create(binaryData);
        }
    }
}
