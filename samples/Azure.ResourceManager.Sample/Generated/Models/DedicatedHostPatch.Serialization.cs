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
    public partial class DedicatedHostPatch : IUtf8JsonSerializable, IModelJsonSerializable<DedicatedHostPatch>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DedicatedHostPatch>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DedicatedHostPatch>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DedicatedHostPatch>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(PlatformFaultDomain))
            {
                writer.WritePropertyName("platformFaultDomain"u8);
                writer.WriteNumberValue(PlatformFaultDomain.Value);
            }
            if (Optional.IsDefined(AutoReplaceOnFailure))
            {
                writer.WritePropertyName("autoReplaceOnFailure"u8);
                writer.WriteBooleanValue(AutoReplaceOnFailure.Value);
            }
            if (Optional.IsDefined(LicenseType))
            {
                writer.WritePropertyName("licenseType"u8);
                writer.WriteStringValue(LicenseType.Value.ToSerialString());
            }
            writer.WriteEndObject();
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

        internal static DedicatedHostPatch DeserializeDedicatedHostPatch(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IDictionary<string, string>> tags = default;
            Optional<int> platformFaultDomain = default;
            Optional<bool> autoReplaceOnFailure = default;
            Optional<string> hostId = default;
            Optional<IReadOnlyList<Resources.Models.SubResource>> virtualMachines = default;
            Optional<DedicatedHostLicenseType> licenseType = default;
            Optional<DateTimeOffset> provisioningTime = default;
            Optional<string> provisioningState = default;
            Optional<DedicatedHostInstanceView> instanceView = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("platformFaultDomain"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            platformFaultDomain = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("autoReplaceOnFailure"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            autoReplaceOnFailure = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("hostId"u8))
                        {
                            hostId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("virtualMachines"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<Resources.Models.SubResource> array = new List<Resources.Models.SubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<Resources.Models.SubResource>(item.GetRawText()));
                            }
                            virtualMachines = array;
                            continue;
                        }
                        if (property0.NameEquals("licenseType"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            licenseType = property0.Value.GetString().ToDedicatedHostLicenseType();
                            continue;
                        }
                        if (property0.NameEquals("provisioningTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("instanceView"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            instanceView = DedicatedHostInstanceView.DeserializeDedicatedHostInstanceView(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new DedicatedHostPatch(Optional.ToDictionary(tags), Optional.ToNullable(platformFaultDomain), Optional.ToNullable(autoReplaceOnFailure), hostId.Value, Optional.ToList(virtualMachines), Optional.ToNullable(licenseType), Optional.ToNullable(provisioningTime), provisioningState.Value, instanceView.Value, rawData);
        }

        DedicatedHostPatch IModelJsonSerializable<DedicatedHostPatch>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DedicatedHostPatch>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDedicatedHostPatch(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DedicatedHostPatch>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DedicatedHostPatch>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DedicatedHostPatch IModelSerializable<DedicatedHostPatch>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<DedicatedHostPatch>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDedicatedHostPatch(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="DedicatedHostPatch"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="DedicatedHostPatch"/> to convert. </param>
        public static implicit operator RequestContent(DedicatedHostPatch model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="DedicatedHostPatch"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator DedicatedHostPatch(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDedicatedHostPatch(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
