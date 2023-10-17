// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace TypeSchemaMapping.Models
{
    public partial class PublicModelWithInternalProperty : IUtf8JsonSerializable, IModelJsonSerializable<PublicModelWithInternalProperty>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<PublicModelWithInternalProperty>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<PublicModelWithInternalProperty>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(StringPropertyJson))
            {
                writer.WritePropertyName("InternalProperty"u8);
                StringPropertyJson.WriteTo(writer);
            }
            if (Optional.IsDefined(PublicProperty))
            {
                writer.WritePropertyName("PublicProperty"u8);
                writer.WriteStringValue(PublicProperty);
            }
            writer.WriteEndObject();
        }

        PublicModelWithInternalProperty IModelJsonSerializable<PublicModelWithInternalProperty>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePublicModelWithInternalProperty(document.RootElement, options);
        }

        BinaryData IModelSerializable<PublicModelWithInternalProperty>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        PublicModelWithInternalProperty IModelSerializable<PublicModelWithInternalProperty>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePublicModelWithInternalProperty(document.RootElement, options);
        }

        internal static PublicModelWithInternalProperty DeserializePublicModelWithInternalProperty(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<JsonElement> internalProperty = default;
            Optional<string> publicProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("InternalProperty"u8))
                {
                    internalProperty = property.Value.Clone();
                    continue;
                }
                if (property.NameEquals("PublicProperty"u8))
                {
                    publicProperty = property.Value.GetString();
                    continue;
                }
            }
            return new PublicModelWithInternalProperty(internalProperty, publicProperty.Value);
        }
    }
}
