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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetVmProtectionPolicy : IUtf8JsonSerializable, IModelJsonSerializable<VirtualMachineScaleSetVmProtectionPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VirtualMachineScaleSetVmProtectionPolicy>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VirtualMachineScaleSetVmProtectionPolicy>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(ProtectFromScaleIn))
            {
                writer.WritePropertyName("protectFromScaleIn"u8);
                writer.WriteBooleanValue(ProtectFromScaleIn.Value);
            }
            if (Optional.IsDefined(ProtectFromScaleSetActions))
            {
                writer.WritePropertyName("protectFromScaleSetActions"u8);
                writer.WriteBooleanValue(ProtectFromScaleSetActions.Value);
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

        internal static VirtualMachineScaleSetVmProtectionPolicy DeserializeVirtualMachineScaleSetVmProtectionPolicy(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> protectFromScaleIn = default;
            Optional<bool> protectFromScaleSetActions = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("protectFromScaleIn"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectFromScaleIn = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("protectFromScaleSetActions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectFromScaleSetActions = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new VirtualMachineScaleSetVmProtectionPolicy(Optional.ToNullable(protectFromScaleIn), Optional.ToNullable(protectFromScaleSetActions), serializedAdditionalRawData);
        }

        VirtualMachineScaleSetVmProtectionPolicy IModelJsonSerializable<VirtualMachineScaleSetVmProtectionPolicy>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetVmProtectionPolicy(doc.RootElement, options);
        }

        BinaryData IModelSerializable<VirtualMachineScaleSetVmProtectionPolicy>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        VirtualMachineScaleSetVmProtectionPolicy IModelSerializable<VirtualMachineScaleSetVmProtectionPolicy>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeVirtualMachineScaleSetVmProtectionPolicy(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="VirtualMachineScaleSetVmProtectionPolicy"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="VirtualMachineScaleSetVmProtectionPolicy"/> to convert. </param>
        public static implicit operator RequestContent(VirtualMachineScaleSetVmProtectionPolicy model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="VirtualMachineScaleSetVmProtectionPolicy"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator VirtualMachineScaleSetVmProtectionPolicy(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeVirtualMachineScaleSetVmProtectionPolicy(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
