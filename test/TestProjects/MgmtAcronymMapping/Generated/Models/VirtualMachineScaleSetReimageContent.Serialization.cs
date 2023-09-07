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

namespace MgmtAcronymMapping.Models
{
    public partial class VirtualMachineScaleSetReimageContent : IUtf8JsonSerializable, IModelJsonSerializable<VirtualMachineScaleSetReimageContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VirtualMachineScaleSetReimageContent>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VirtualMachineScaleSetReimageContent>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualMachineScaleSetReimageContent>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(InstanceIds))
            {
                writer.WritePropertyName("instanceIds"u8);
                writer.WriteStartArray();
                foreach (var item in InstanceIds)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(TempDisk))
            {
                writer.WritePropertyName("tempDisk"u8);
                writer.WriteBooleanValue(TempDisk.Value);
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

        internal static VirtualMachineScaleSetReimageContent DeserializeVirtualMachineScaleSetReimageContent(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> instanceIds = default;
            Optional<bool> tempDisk = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("instanceIds"u8))
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
                    instanceIds = array;
                    continue;
                }
                if (property.NameEquals("tempDisk"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tempDisk = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new VirtualMachineScaleSetReimageContent(Optional.ToNullable(tempDisk), Optional.ToList(instanceIds), serializedAdditionalRawData);
        }

        VirtualMachineScaleSetReimageContent IModelJsonSerializable<VirtualMachineScaleSetReimageContent>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualMachineScaleSetReimageContent>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetReimageContent(doc.RootElement, options);
        }

        BinaryData IModelSerializable<VirtualMachineScaleSetReimageContent>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualMachineScaleSetReimageContent>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        VirtualMachineScaleSetReimageContent IModelSerializable<VirtualMachineScaleSetReimageContent>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<VirtualMachineScaleSetReimageContent>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeVirtualMachineScaleSetReimageContent(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="VirtualMachineScaleSetReimageContent"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="VirtualMachineScaleSetReimageContent"/> to convert. </param>
        public static implicit operator RequestContent(VirtualMachineScaleSetReimageContent model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="VirtualMachineScaleSetReimageContent"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator VirtualMachineScaleSetReimageContent(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeVirtualMachineScaleSetReimageContent(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
