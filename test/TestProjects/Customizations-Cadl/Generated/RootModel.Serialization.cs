// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;
using CustomizationsInCadlOther;

namespace CustomizationsInCadl
{
    public partial class RootModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(PropertyModelToMakeInternal))
            {
                writer.WritePropertyName("propertyModelToMakeInternal");
                writer.WriteObjectValue(PropertyModelToMakeInternal);
            }
            if (Optional.IsDefined(PropertyModelToRename))
            {
                writer.WritePropertyName("propertyModelToRename");
                writer.WriteObjectValue(PropertyModelToRename);
            }
            if (Optional.IsDefined(PropertyModelToChangeNamespace))
            {
                writer.WritePropertyName("propertyModelToChangeNamespace");
                writer.WriteObjectValue(PropertyModelToChangeNamespace);
            }
            if (Optional.IsDefined(PropertyModelWithCustomizedProperties))
            {
                writer.WritePropertyName("propertyModelWithCustomizedProperties");
                writer.WriteObjectValue(PropertyModelWithCustomizedProperties);
            }
            if (Optional.IsDefined(PropertyEnumToRename))
            {
                if (PropertyEnumToRename != null)
                {
                    writer.WritePropertyName("propertyEnumToRename");
                    writer.WriteStringValue(PropertyEnumToRename.Value.ToSerialString());
                }
                else
                {
                    writer.WriteNull("propertyEnumToRename");
                }
            }
            if (Optional.IsDefined(PropertyEnumWithValueToRename))
            {
                if (PropertyEnumWithValueToRename != null)
                {
                    writer.WritePropertyName("propertyEnumWithValueToRename");
                    writer.WriteStringValue(PropertyEnumWithValueToRename.Value.ToSerialString());
                }
                else
                {
                    writer.WriteNull("propertyEnumWithValueToRename");
                }
            }
            if (Optional.IsDefined(PropertyEnumToBeMadeExtensible))
            {
                if (PropertyEnumToBeMadeExtensible != null)
                {
                    writer.WritePropertyName("propertyEnumToBeMadeExtensible");
                    writer.WriteStringValue(PropertyEnumToBeMadeExtensible.Value.ToString());
                }
                else
                {
                    writer.WriteNull("propertyEnumToBeMadeExtensible");
                }
            }
            writer.WriteEndObject();
        }

        internal static RootModel DeserializeRootModel(JsonElement element)
        {
            Optional<ModelToMakeInternal> propertyModelToMakeInternal = default;
            Optional<RenamedModel> propertyModelToRename = default;
            Optional<ModelToChangeNamespace> propertyModelToChangeNamespace = default;
            Optional<ModelWithCustomizedProperties> propertyModelWithCustomizedProperties = default;
            Optional<RenamedEnum?> propertyEnumToRename = default;
            Optional<EnumWithValueToRename?> propertyEnumWithValueToRename = default;
            Optional<EnumToBeMadeExtensible?> propertyEnumToBeMadeExtensible = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("propertyModelToMakeInternal"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    propertyModelToMakeInternal = ModelToMakeInternal.DeserializeModelToMakeInternal(property.Value);
                    continue;
                }
                if (property.NameEquals("propertyModelToRename"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    propertyModelToRename = RenamedModel.DeserializeRenamedModel(property.Value);
                    continue;
                }
                if (property.NameEquals("propertyModelToChangeNamespace"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    propertyModelToChangeNamespace = ModelToChangeNamespace.DeserializeModelToChangeNamespace(property.Value);
                    continue;
                }
                if (property.NameEquals("propertyModelWithCustomizedProperties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    propertyModelWithCustomizedProperties = ModelWithCustomizedProperties.DeserializeModelWithCustomizedProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("propertyEnumToRename"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        propertyEnumToRename = null;
                        continue;
                    }
                    propertyEnumToRename = property.Value.GetString().ToRenamedEnum();
                    continue;
                }
                if (property.NameEquals("propertyEnumWithValueToRename"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        propertyEnumWithValueToRename = null;
                        continue;
                    }
                    propertyEnumWithValueToRename = property.Value.GetString().ToEnumWithValueToRename();
                    continue;
                }
                if (property.NameEquals("propertyEnumToBeMadeExtensible"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        propertyEnumToBeMadeExtensible = null;
                        continue;
                    }
                    propertyEnumToBeMadeExtensible = new EnumToBeMadeExtensible(property.Value.GetString());
                    continue;
                }
            }
            return new RootModel(propertyModelToMakeInternal, propertyModelToRename, propertyModelToChangeNamespace, propertyModelWithCustomizedProperties, Optional.ToNullable(propertyEnumToRename), Optional.ToNullable(propertyEnumWithValueToRename), Optional.ToNullable(propertyEnumToBeMadeExtensible));
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
