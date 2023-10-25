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
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineExtensionUpdate : IUtf8JsonSerializable, IJsonModel<VirtualMachineExtensionUpdate>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineExtensionUpdate>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<VirtualMachineExtensionUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
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
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (Optional.IsDefined(ForceUpdateTag))
                {
                    writer.WritePropertyName("forceUpdateTag"u8);
                    writer.WriteStringValue(ForceUpdateTag);
                }
                if (Optional.IsDefined(Publisher))
                {
                    writer.WritePropertyName("publisher"u8);
                    writer.WriteStringValue(Publisher);
                }
                if (Optional.IsDefined(ExtensionType))
                {
                    writer.WritePropertyName("type"u8);
                    writer.WriteStringValue(ExtensionType);
                }
                if (Optional.IsDefined(TypeHandlerVersion))
                {
                    writer.WritePropertyName("typeHandlerVersion"u8);
                    writer.WriteStringValue(TypeHandlerVersion);
                }
                if (Optional.IsDefined(AutoUpgradeMinorVersion))
                {
                    writer.WritePropertyName("autoUpgradeMinorVersion"u8);
                    writer.WriteBooleanValue(AutoUpgradeMinorVersion.Value);
                }
                if (Optional.IsDefined(EnableAutomaticUpgrade))
                {
                    writer.WritePropertyName("enableAutomaticUpgrade"u8);
                    writer.WriteBooleanValue(EnableAutomaticUpgrade.Value);
                }
                if (Optional.IsDefined(Settings))
                {
                    writer.WritePropertyName("settings"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Settings);
#else
                    using (JsonDocument document = JsonDocument.Parse(Settings))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                if (Optional.IsDefined(ProtectedSettings))
                {
                    writer.WritePropertyName("protectedSettings"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(ProtectedSettings);
#else
                    using (JsonDocument document = JsonDocument.Parse(ProtectedSettings))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                writer.WriteEndObject();
            }
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

        VirtualMachineExtensionUpdate IJsonModel<VirtualMachineExtensionUpdate>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineExtensionUpdate(document.RootElement, options);
        }

        internal static VirtualMachineExtensionUpdate DeserializeVirtualMachineExtensionUpdate(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IDictionary<string, string>> tags = default;
            Optional<string> forceUpdateTag = default;
            Optional<string> publisher = default;
            Optional<string> type = default;
            Optional<string> typeHandlerVersion = default;
            Optional<bool> autoUpgradeMinorVersion = default;
            Optional<bool> enableAutomaticUpgrade = default;
            Optional<BinaryData> settings = default;
            Optional<BinaryData> protectedSettings = default;
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
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("forceUpdateTag"u8))
                        {
                            forceUpdateTag = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("publisher"u8))
                        {
                            publisher = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("type"u8))
                        {
                            type = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("typeHandlerVersion"u8))
                        {
                            typeHandlerVersion = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("autoUpgradeMinorVersion"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            autoUpgradeMinorVersion = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("enableAutomaticUpgrade"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            enableAutomaticUpgrade = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("settings"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            settings = BinaryData.FromString(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("protectedSettings"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            protectedSettings = BinaryData.FromString(property0.Value.GetRawText());
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
            return new VirtualMachineExtensionUpdate(Optional.ToDictionary(tags), serializedAdditionalRawData, forceUpdateTag.Value, publisher.Value, type.Value, typeHandlerVersion.Value, Optional.ToNullable(autoUpgradeMinorVersion), Optional.ToNullable(enableAutomaticUpgrade), settings.Value, protectedSettings.Value);
        }

        BinaryData IModel<VirtualMachineExtensionUpdate>.Write(ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.WriteCore(this, options);
        }

        VirtualMachineExtensionUpdate IModel<VirtualMachineExtensionUpdate>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVirtualMachineExtensionUpdate(document.RootElement, options);
        }
    }
}
