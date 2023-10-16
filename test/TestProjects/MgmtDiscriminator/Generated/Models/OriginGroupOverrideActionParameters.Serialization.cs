// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Resources.Models;

namespace MgmtDiscriminator.Models
{
    public partial class OriginGroupOverrideActionParameters : IUtf8JsonSerializable, IModelJsonSerializable<OriginGroupOverrideActionParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<OriginGroupOverrideActionParameters>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<OriginGroupOverrideActionParameters>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("originGroup"u8);
            JsonSerializer.Serialize(writer, OriginGroup);
            writer.WriteEndObject();
        }

        OriginGroupOverrideActionParameters IModelJsonSerializable<OriginGroupOverrideActionParameters>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeOriginGroupOverrideActionParameters(doc.RootElement, options);
        }

        BinaryData IModelSerializable<OriginGroupOverrideActionParameters>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        OriginGroupOverrideActionParameters IModelSerializable<OriginGroupOverrideActionParameters>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeOriginGroupOverrideActionParameters(document.RootElement, options);
        }

        internal static OriginGroupOverrideActionParameters DeserializeOriginGroupOverrideActionParameters(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            OriginGroupOverrideActionParametersTypeName typeName = default;
            WritableSubResource originGroup = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new OriginGroupOverrideActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("originGroup"u8))
                {
                    originGroup = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
            }
            return new OriginGroupOverrideActionParameters(typeName, originGroup);
        }
    }
}
