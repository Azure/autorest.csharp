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
            writer.WriteStartObject();
            if (Optional.IsDefined(PropertyExtensibleEnum))
            {
                writer.WritePropertyName("propertyExtensibleEnum"u8);
                writer.WriteStringValue(PropertyExtensibleEnum.Value.ToString());
            }
            if (Optional.IsDefined(PropertyModelToMakeInternal))
            {
                writer.WritePropertyName("propertyModelToMakeInternal"u8);
                writer.WriteObjectValue(PropertyModelToMakeInternal);
            }
            if (Optional.IsDefined(PropertyModelToRename))
            {
                writer.WritePropertyName("propertyModelToRename"u8);
                writer.WriteObjectValue(PropertyModelToRename);
            }
            if (Optional.IsDefined(PropertyModelToChangeNamespace))
            {
                writer.WritePropertyName("propertyModelToChangeNamespace"u8);
                writer.WriteObjectValue(PropertyModelToChangeNamespace);
            }
            if (Optional.IsDefined(PropertyModelWithCustomizedProperties))
            {
                writer.WritePropertyName("propertyModelWithCustomizedProperties"u8);
                writer.WriteObjectValue(PropertyModelWithCustomizedProperties);
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
                writer.WriteObjectValue(PropertyModelToAddAdditionalSerializableProperty);
            }
            if (Optional.IsDefined(PropertyToMoveToCustomization))
            {
                writer.WritePropertyName("propertyToMoveToCustomization"u8);
                writer.WriteStringValue(PropertyToMoveToCustomization.Value.ToString());
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

        RootModel IModelJsonSerializable<RootModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRootModel(document.RootElement, options);
        }

        BinaryData IModelSerializable<RootModel>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        RootModel IModelSerializable<RootModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeRootModel(document.RootElement, options);
        }

        internal static RootModel DeserializeRootModel(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ExtensibleEnumWithOperator> propertyExtensibleEnum = default;
            Optional<ModelToMakeInternal> propertyModelToMakeInternal = default;
            Optional<RenamedModel> propertyModelToRename = default;
            Optional<ModelToChangeNamespace> propertyModelToChangeNamespace = default;
            Optional<ModelWithCustomizedProperties> propertyModelWithCustomizedProperties = default;
            Optional<RenamedEnum> propertyEnumToRename = default;
            Optional<EnumWithValueToRename> propertyEnumWithValueToRename = default;
            Optional<EnumToBeMadeExtensible> propertyEnumToBeMadeExtensible = default;
            Optional<ModelToAddAdditionalSerializableProperty> propertyModelToAddAdditionalSerializableProperty = default;
            Optional<NormalEnum> propertyToMoveToCustomization = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            if (options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in element.EnumerateObject())
                {
                    if (property.NameEquals("propertyExtensibleEnum"u8))
                    {
                        if (property.Value.ValueKind == JsonValueKind.Null)
                        {
                            continue;
                        }
                        propertyExtensibleEnum = new ExtensibleEnumWithOperator(property.Value.GetString());
                        continue;
                    }
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
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
                serializedAdditionalRawData = additionalPropertiesDictionary;
            }
            return new RootModel(Optional.ToNullable(propertyExtensibleEnum), propertyModelToMakeInternal.Value, propertyModelToRename.Value, propertyModelToChangeNamespace.Value, propertyModelWithCustomizedProperties.Value, Optional.ToNullable(propertyEnumToRename), Optional.ToNullable(propertyEnumWithValueToRename), Optional.ToNullable(propertyEnumToBeMadeExtensible), propertyModelToAddAdditionalSerializableProperty.Value, Optional.ToNullable(propertyToMoveToCustomization), serializedAdditionalRawData);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static RootModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRootModel(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
