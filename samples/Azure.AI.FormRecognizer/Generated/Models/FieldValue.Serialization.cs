// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class FieldValue : IUtf8JsonSerializable, IModelJsonSerializable<FieldValue>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<FieldValue>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<FieldValue>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToSerialString());
            if (Optional.IsDefined(ValueString))
            {
                writer.WritePropertyName("valueString"u8);
                writer.WriteStringValue(ValueString);
            }
            if (Optional.IsDefined(ValueDate))
            {
                writer.WritePropertyName("valueDate"u8);
                writer.WriteStringValue(ValueDate.Value, "D");
            }
            if (Optional.IsDefined(ValueTime))
            {
                writer.WritePropertyName("valueTime"u8);
                writer.WriteStringValue(ValueTime.Value, "T");
            }
            if (Optional.IsDefined(ValuePhoneNumber))
            {
                writer.WritePropertyName("valuePhoneNumber"u8);
                writer.WriteStringValue(ValuePhoneNumber);
            }
            if (Optional.IsDefined(ValueNumber))
            {
                writer.WritePropertyName("valueNumber"u8);
                writer.WriteNumberValue(ValueNumber.Value);
            }
            if (Optional.IsDefined(ValueInteger))
            {
                writer.WritePropertyName("valueInteger"u8);
                writer.WriteNumberValue(ValueInteger.Value);
            }
            if (Optional.IsCollectionDefined(ValueArray))
            {
                writer.WritePropertyName("valueArray"u8);
                writer.WriteStartArray();
                foreach (var item in ValueArray)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ValueObject))
            {
                writer.WritePropertyName("valueObject"u8);
                writer.WriteStartObject();
                foreach (var item in ValueObject)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Text))
            {
                writer.WritePropertyName("text"u8);
                writer.WriteStringValue(Text);
            }
            if (Optional.IsCollectionDefined(BoundingBox))
            {
                writer.WritePropertyName("boundingBox"u8);
                writer.WriteStartArray();
                foreach (var item in BoundingBox)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Confidence))
            {
                writer.WritePropertyName("confidence"u8);
                writer.WriteNumberValue(Confidence.Value);
            }
            if (Optional.IsCollectionDefined(Elements))
            {
                writer.WritePropertyName("elements"u8);
                writer.WriteStartArray();
                foreach (var item in Elements)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Page))
            {
                writer.WritePropertyName("page"u8);
                writer.WriteNumberValue(Page.Value);
            }
            writer.WriteEndObject();
        }

        FieldValue IModelJsonSerializable<FieldValue>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFieldValue(document.RootElement, options);
        }

        BinaryData IModelSerializable<FieldValue>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        FieldValue IModelSerializable<FieldValue>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFieldValue(document.RootElement, options);
        }

        internal static FieldValue DeserializeFieldValue(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            FieldValueType type = default;
            Optional<string> valueString = default;
            Optional<DateTimeOffset> valueDate = default;
            Optional<TimeSpan> valueTime = default;
            Optional<string> valuePhoneNumber = default;
            Optional<float> valueNumber = default;
            Optional<int> valueInteger = default;
            Optional<IReadOnlyList<FieldValue>> valueArray = default;
            Optional<IReadOnlyDictionary<string, FieldValue>> valueObject = default;
            Optional<string> text = default;
            Optional<IReadOnlyList<float>> boundingBox = default;
            Optional<float> confidence = default;
            Optional<IReadOnlyList<string>> elements = default;
            Optional<int> page = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString().ToFieldValueType();
                    continue;
                }
                if (property.NameEquals("valueString"u8))
                {
                    valueString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("valueDate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    valueDate = property.Value.GetDateTimeOffset("D");
                    continue;
                }
                if (property.NameEquals("valueTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    valueTime = property.Value.GetTimeSpan("T");
                    continue;
                }
                if (property.NameEquals("valuePhoneNumber"u8))
                {
                    valuePhoneNumber = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("valueNumber"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    valueNumber = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("valueInteger"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    valueInteger = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("valueArray"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FieldValue> array = new List<FieldValue>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeFieldValue(item));
                    }
                    valueArray = array;
                    continue;
                }
                if (property.NameEquals("valueObject"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, FieldValue> dictionary = new Dictionary<string, FieldValue>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, DeserializeFieldValue(property0.Value));
                    }
                    valueObject = dictionary;
                    continue;
                }
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boundingBox"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    boundingBox = array;
                    continue;
                }
                if (property.NameEquals("confidence"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    confidence = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("elements"u8))
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
                    elements = array;
                    continue;
                }
                if (property.NameEquals("page"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    page = property.Value.GetInt32();
                    continue;
                }
            }
            return new FieldValue(type, valueString.Value, Optional.ToNullable(valueDate), Optional.ToNullable(valueTime), valuePhoneNumber.Value, Optional.ToNullable(valueNumber), Optional.ToNullable(valueInteger), Optional.ToList(valueArray), Optional.ToDictionary(valueObject), text.Value, Optional.ToList(boundingBox), Optional.ToNullable(confidence), Optional.ToList(elements), Optional.ToNullable(page));
        }
    }
}
