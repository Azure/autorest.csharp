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
    public partial class RootModel : IUtf8JsonSerializable, IModelJsonSerializable<RootModel>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RootModel>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RootModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(PropertyModelToMakeInternal))
            {
                writer.WritePropertyName("propertyModelToMakeInternal"u8);
                if (PropertyModelToMakeInternal is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<ModelToMakeInternal>)PropertyModelToMakeInternal).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(PropertyModelToRename))
            {
                writer.WritePropertyName("propertyModelToRename"u8);
                if (PropertyModelToRename is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<RenamedModel>)PropertyModelToRename).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(PropertyModelToChangeNamespace))
            {
                writer.WritePropertyName("propertyModelToChangeNamespace"u8);
                if (PropertyModelToChangeNamespace is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<ModelToChangeNamespace>)PropertyModelToChangeNamespace).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(PropertyModelWithCustomizedProperties))
            {
                writer.WritePropertyName("propertyModelWithCustomizedProperties"u8);
                if (PropertyModelWithCustomizedProperties is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<ModelWithCustomizedProperties>)PropertyModelWithCustomizedProperties).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(PropertyEnumToRename))
            {
                writer.WritePropertyName("propertyEnumToRename"u8);
                writer.WriteStringValue(PropertyEnumToRename.Value.ToSerialString());
            }
            if (Optional.IsDefined(PropertyEnumWithValueToRename))
            {
                writer.WritePropertyName("propertyEnumWithValueToRename"u8);
                writer.WriteStringValue(PropertyEnumWithValueToRename.Value.ToSerialString());
            }
            if (Optional.IsDefined(PropertyEnumToBeMadeExtensible))
            {
                writer.WritePropertyName("propertyEnumToBeMadeExtensible"u8);
                writer.WriteStringValue(PropertyEnumToBeMadeExtensible.Value.ToString());
            }
            if (Optional.IsDefined(PropertyModelToAddAdditionalSerializableProperty))
            {
                writer.WritePropertyName("propertyModelToAddAdditionalSerializableProperty"u8);
                if (PropertyModelToAddAdditionalSerializableProperty is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<ModelToAddAdditionalSerializableProperty>)PropertyModelToAddAdditionalSerializableProperty).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(PropertyToMoveToCustomization))
            {
                writer.WritePropertyName("propertyToMoveToCustomization"u8);
                writer.WriteStringValue(PropertyToMoveToCustomization.Value.ToString());
            }
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
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

        internal static RootModel DeserializeRootModel(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ModelToMakeInternal> propertyModelToMakeInternal = default;
            Optional<RenamedModel> propertyModelToRename = default;
            Optional<ModelToChangeNamespace> propertyModelToChangeNamespace = default;
            Optional<ModelWithCustomizedProperties> propertyModelWithCustomizedProperties = default;
            Optional<RenamedEnum> propertyEnumToRename = default;
            Optional<EnumWithValueToRename> propertyEnumWithValueToRename = default;
            Optional<EnumToBeMadeExtensible> propertyEnumToBeMadeExtensible = default;
            Optional<ModelToAddAdditionalSerializableProperty> propertyModelToAddAdditionalSerializableProperty = default;
            Optional<NormalEnum> propertyToMoveToCustomization = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("propertyModelToMakeInternal"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    propertyModelToMakeInternal = ModelToMakeInternal.DeserializeModelToMakeInternal(property.Value);
                    continue;
                }
                if (property.NameEquals("propertyModelToRename"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    propertyModelToRename = RenamedModel.DeserializeRenamedModel(property.Value);
                    continue;
                }
                if (property.NameEquals("propertyModelToChangeNamespace"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    propertyModelToChangeNamespace = ModelToChangeNamespace.DeserializeModelToChangeNamespace(property.Value);
                    continue;
                }
                if (property.NameEquals("propertyModelWithCustomizedProperties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    propertyModelWithCustomizedProperties = ModelWithCustomizedProperties.DeserializeModelWithCustomizedProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("propertyEnumToRename"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    propertyEnumToRename = property.Value.GetString().ToRenamedEnum();
                    continue;
                }
                if (property.NameEquals("propertyEnumWithValueToRename"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    propertyEnumWithValueToRename = property.Value.GetString().ToEnumWithValueToRename();
                    continue;
                }
                if (property.NameEquals("propertyEnumToBeMadeExtensible"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    propertyEnumToBeMadeExtensible = new EnumToBeMadeExtensible(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("propertyModelToAddAdditionalSerializableProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    propertyModelToAddAdditionalSerializableProperty = ModelToAddAdditionalSerializableProperty.DeserializeModelToAddAdditionalSerializableProperty(property.Value);
                    continue;
                }
                if (property.NameEquals("propertyToMoveToCustomization"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    propertyToMoveToCustomization = new NormalEnum(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new RootModel(propertyModelToMakeInternal.Value, propertyModelToRename.Value, propertyModelToChangeNamespace.Value, propertyModelWithCustomizedProperties.Value, Optional.ToNullable(propertyEnumToRename), Optional.ToNullable(propertyEnumWithValueToRename), Optional.ToNullable(propertyEnumToBeMadeExtensible), propertyModelToAddAdditionalSerializableProperty.Value, Optional.ToNullable(propertyToMoveToCustomization), serializedAdditionalRawData);
        }

        RootModel IModelJsonSerializable<RootModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeRootModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<RootModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        RootModel IModelSerializable<RootModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeRootModel(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="RootModel"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="RootModel"/> to convert. </param>
        public static implicit operator RequestContent(RootModel model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="RootModel"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator RootModel(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeRootModel(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
