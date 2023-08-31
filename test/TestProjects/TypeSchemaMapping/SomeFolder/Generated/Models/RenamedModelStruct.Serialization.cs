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
using NamespaceForEnums;

namespace CustomNamespace
{
    internal partial struct RenamedModelStruct : IUtf8JsonSerializable, IModelJsonSerializable<RenamedModelStruct>, IModelJsonSerializable<object>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RenamedModelStruct>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RenamedModelStruct>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<RenamedModelStruct>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("ModelProperty"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(CustomizedFlattenedStringProperty))
            {
                writer.WritePropertyName("ModelProperty"u8);
                writer.WriteStringValue(CustomizedFlattenedStringProperty);
            }
            if (Optional.IsDefined(PropertyToField))
            {
                writer.WritePropertyName("PropertyToField"u8);
                writer.WriteStringValue(PropertyToField);
            }
            if (Optional.IsDefined(Fruit))
            {
                writer.WritePropertyName("Fruit"u8);
                writer.WriteStringValue(Fruit.Value.ToSerialString());
            }
            if (Optional.IsDefined(DaysOfWeek))
            {
                writer.WritePropertyName("DaysOfWeek"u8);
                writer.WriteStringValue(DaysOfWeek.Value.ToString());
            }
            writer.WriteEndObject();
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        void IModelJsonSerializable<object>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<RenamedModelStruct>(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("ModelProperty"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(CustomizedFlattenedStringProperty))
            {
                writer.WritePropertyName("ModelProperty"u8);
                writer.WriteStringValue(CustomizedFlattenedStringProperty);
            }
            if (Optional.IsDefined(PropertyToField))
            {
                writer.WritePropertyName("PropertyToField"u8);
                writer.WriteStringValue(PropertyToField);
            }
            if (Optional.IsDefined(Fruit))
            {
                writer.WritePropertyName("Fruit"u8);
                writer.WriteStringValue(Fruit.Value.ToSerialString());
            }
            if (Optional.IsDefined(DaysOfWeek))
            {
                writer.WritePropertyName("DaysOfWeek"u8);
                writer.WriteStringValue(DaysOfWeek.Value.ToString());
            }
            writer.WriteEndObject();
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static RenamedModelStruct DeserializeRenamedModelStruct(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            Optional<string> modelProperty = default;
            Optional<string> propertyToField = default;
            Optional<CustomFruitEnum> fruit = default;
            Optional<CustomDaysOfWeek> daysOfWeek = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("ModelProperty"u8))
                        {
                            modelProperty = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("PropertyToField"u8))
                        {
                            propertyToField = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("Fruit"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            fruit = property0.Value.GetString().ToCustomFruitEnum();
                            continue;
                        }
                        if (property0.NameEquals("DaysOfWeek"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            daysOfWeek = new CustomDaysOfWeek(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new RenamedModelStruct(modelProperty.Value, propertyToField.Value, Optional.ToNullable(fruit), Optional.ToNullable(daysOfWeek), rawData);
        }

        RenamedModelStruct IModelJsonSerializable<RenamedModelStruct>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<RenamedModelStruct>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeRenamedModelStruct(doc.RootElement, options);
        }

        object IModelJsonSerializable<object>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<RenamedModelStruct>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeRenamedModelStruct(doc.RootElement, options);
        }

        BinaryData IModelSerializable<RenamedModelStruct>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<RenamedModelStruct>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        RenamedModelStruct IModelSerializable<RenamedModelStruct>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<RenamedModelStruct>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeRenamedModelStruct(doc.RootElement, options);
        }

        BinaryData IModelSerializable<object>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<RenamedModelStruct>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        object IModelSerializable<object>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<RenamedModelStruct>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeRenamedModelStruct(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="RenamedModelStruct"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="RenamedModelStruct"/> to convert. </param>
        public static implicit operator RequestContent(RenamedModelStruct model)
        {
            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="RenamedModelStruct"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator RenamedModelStruct(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeRenamedModelStruct(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
