// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace CustomizationsInCadl.Models
{
    public partial class RootModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
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
            writer.WriteEndObject();
        }

        internal static RootModel DeserializeRootModel(JsonElement element)
        {
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
            }
            return new RootModel(propertyModelToMakeInternal.Value, propertyModelToRename.Value, propertyModelToChangeNamespace.Value, propertyModelWithCustomizedProperties.Value, Optional.ToNullable(propertyEnumToRename), Optional.ToNullable(propertyEnumWithValueToRename), Optional.ToNullable(propertyEnumToBeMadeExtensible), propertyModelToAddAdditionalSerializableProperty.Value);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static RootModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRootModel(document.RootElement);
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
