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
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetNetworkProfile : IUtf8JsonSerializable, IModelJsonSerializable<VirtualMachineScaleSetNetworkProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VirtualMachineScaleSetNetworkProfile>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VirtualMachineScaleSetNetworkProfile>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(HealthProbe))
            {
                writer.WritePropertyName("healthProbe"u8);
                JsonSerializer.Serialize(writer, HealthProbe);
            }
            if (Optional.IsCollectionDefined(NetworkInterfaceConfigurations))
            {
                writer.WritePropertyName("networkInterfaceConfigurations"u8);
                writer.WriteStartArray();
                foreach (var item in NetworkInterfaceConfigurations)
                {
                    if (item is null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        ((IModelJsonSerializable<VirtualMachineScaleSetNetworkConfiguration>)item).Serialize(writer, options);
                    }
                }
                writer.WriteEndArray();
            }
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

        internal static VirtualMachineScaleSetNetworkProfile DeserializeVirtualMachineScaleSetNetworkProfile(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<WritableSubResource> healthProbe = default;
            Optional<IList<VirtualMachineScaleSetNetworkConfiguration>> networkInterfaceConfigurations = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("healthProbe"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    healthProbe = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("networkInterfaceConfigurations"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineScaleSetNetworkConfiguration> array = new List<VirtualMachineScaleSetNetworkConfiguration>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineScaleSetNetworkConfiguration.DeserializeVirtualMachineScaleSetNetworkConfiguration(item));
                    }
                    networkInterfaceConfigurations = array;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new VirtualMachineScaleSetNetworkProfile(healthProbe, Optional.ToList(networkInterfaceConfigurations), rawData);
        }

        VirtualMachineScaleSetNetworkProfile IModelJsonSerializable<VirtualMachineScaleSetNetworkProfile>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetNetworkProfile(doc.RootElement, options);
        }

        BinaryData IModelSerializable<VirtualMachineScaleSetNetworkProfile>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        VirtualMachineScaleSetNetworkProfile IModelSerializable<VirtualMachineScaleSetNetworkProfile>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeVirtualMachineScaleSetNetworkProfile(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="VirtualMachineScaleSetNetworkProfile"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="VirtualMachineScaleSetNetworkProfile"/> to convert. </param>
        public static implicit operator RequestContent(VirtualMachineScaleSetNetworkProfile model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="VirtualMachineScaleSetNetworkProfile"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator VirtualMachineScaleSetNetworkProfile(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeVirtualMachineScaleSetNetworkProfile(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
