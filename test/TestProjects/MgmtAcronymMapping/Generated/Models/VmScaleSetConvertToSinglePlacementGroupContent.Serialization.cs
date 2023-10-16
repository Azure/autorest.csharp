// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtAcronymMapping.Models
{
    public partial class VmScaleSetConvertToSinglePlacementGroupContent : IUtf8JsonSerializable, IModelJsonSerializable<VmScaleSetConvertToSinglePlacementGroupContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VmScaleSetConvertToSinglePlacementGroupContent>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VmScaleSetConvertToSinglePlacementGroupContent>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ActivePlacementGroupId))
            {
                writer.WritePropertyName("activePlacementGroupId"u8);
                writer.WriteStringValue(ActivePlacementGroupId);
            }
            writer.WriteEndObject();
        }

        VmScaleSetConvertToSinglePlacementGroupContent IModelJsonSerializable<VmScaleSetConvertToSinglePlacementGroupContent>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVmScaleSetConvertToSinglePlacementGroupContent(doc.RootElement, options);
        }

        BinaryData IModelSerializable<VmScaleSetConvertToSinglePlacementGroupContent>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        VmScaleSetConvertToSinglePlacementGroupContent IModelSerializable<VmScaleSetConvertToSinglePlacementGroupContent>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVmScaleSetConvertToSinglePlacementGroupContent(document.RootElement, options);
        }

        internal static VmScaleSetConvertToSinglePlacementGroupContent DeserializeVmScaleSetConvertToSinglePlacementGroupContent(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> activePlacementGroupId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("activePlacementGroupId"u8))
                {
                    activePlacementGroupId = property.Value.GetString();
                    continue;
                }
            }
            return new VmScaleSetConvertToSinglePlacementGroupContent(activePlacementGroupId.Value);
        }
    }
}
