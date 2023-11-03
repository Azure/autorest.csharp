// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    public partial class VirtualMachineScaleSetRollingUpgradeData : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetRollingUpgradeData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetRollingUpgradeData>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<VirtualMachineScaleSetRollingUpgradeData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
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
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(SystemData))
                {
                    writer.WritePropertyName("systemData"u8);
                    JsonSerializer.Serialize(writer, SystemData);
                }
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Policy))
                {
                    writer.WritePropertyName("policy"u8);
                    writer.WriteObjectValue(Policy);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(RunningStatus))
                {
                    writer.WritePropertyName("runningStatus"u8);
                    writer.WriteObjectValue(RunningStatus);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Progress))
                {
                    writer.WritePropertyName("progress"u8);
                    writer.WriteObjectValue(Progress);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Error))
                {
                    writer.WritePropertyName("error"u8);
                    writer.WriteObjectValue(Error);
                }
            }
            writer.WriteEndObject();
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        VirtualMachineScaleSetRollingUpgradeData IJsonModel<VirtualMachineScaleSetRollingUpgradeData>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetRollingUpgradeData(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetRollingUpgradeData DeserializeVirtualMachineScaleSetRollingUpgradeData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<RollingUpgradePolicy> policy = default;
            Optional<RollingUpgradeRunningStatus> runningStatus = default;
            Optional<RollingUpgradeProgressInfo> progress = default;
            Optional<ApiError> error = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
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
                        if (property0.NameEquals("policy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            policy = RollingUpgradePolicy.DeserializeRollingUpgradePolicy(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("runningStatus"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            runningStatus = RollingUpgradeRunningStatus.DeserializeRollingUpgradeRunningStatus(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("progress"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            progress = RollingUpgradeProgressInfo.DeserializeRollingUpgradeProgressInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("error"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            error = ApiError.DeserializeApiError(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineScaleSetRollingUpgradeData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, policy.Value, runningStatus.Value, progress.Value, error.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<VirtualMachineScaleSetRollingUpgradeData>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        VirtualMachineScaleSetRollingUpgradeData IModel<VirtualMachineScaleSetRollingUpgradeData>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVirtualMachineScaleSetRollingUpgradeData(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<VirtualMachineScaleSetRollingUpgradeData>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
