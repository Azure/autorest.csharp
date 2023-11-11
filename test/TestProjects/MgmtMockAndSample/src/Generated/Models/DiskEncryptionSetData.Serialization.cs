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
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class DiskEncryptionSetData : IUtf8JsonSerializable, IJsonModel<DiskEncryptionSetData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DiskEncryptionSetData>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<DiskEncryptionSetData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<DiskEncryptionSetData>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<DiskEncryptionSetData>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
                JsonSerializer.Serialize(writer, Identity, serializeOptions);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Location))
                {
                    writer.WritePropertyName("location"u8);
                    writer.WriteStringValue(Location.Value);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
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
            }
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
            if (Optional.IsDefined(EncryptionType))
            {
                writer.WritePropertyName("encryptionType"u8);
                writer.WriteStringValue(EncryptionType.Value.ToString());
            }
            if (Optional.IsDefined(ActiveKey))
            {
                writer.WritePropertyName("activeKey"u8);
                writer.WriteObjectValue(ActiveKey);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsCollectionDefined(PreviousKeys))
                {
                    writer.WritePropertyName("previousKeys"u8);
                    writer.WriteStartArray();
                    foreach (var item in PreviousKeys)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(ProvisioningState))
                {
                    writer.WritePropertyName("provisioningState"u8);
                    writer.WriteStringValue(ProvisioningState);
                }
            }
            if (Optional.IsDefined(RotationToLatestKeyVersionEnabled))
            {
                writer.WritePropertyName("rotationToLatestKeyVersionEnabled"u8);
                writer.WriteBooleanValue(RotationToLatestKeyVersionEnabled.Value);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(LastKeyRotationTimestamp))
                {
                    writer.WritePropertyName("lastKeyRotationTimestamp"u8);
                    writer.WriteStringValue(LastKeyRotationTimestamp.Value, "O");
                }
            }
            if (Optional.IsDefined(FederatedClientId))
            {
                writer.WritePropertyName("federatedClientId"u8);
                writer.WriteStringValue(FederatedClientId);
            }
            if (Optional.IsDefined(MinimumTlsVersion))
            {
                writer.WritePropertyName("minimumTlsVersion"u8);
                writer.WriteStringValue(MinimumTlsVersion.Value.ToString());
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

        DiskEncryptionSetData IJsonModel<DiskEncryptionSetData>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DiskEncryptionSetData)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDiskEncryptionSetData(document.RootElement, options);
        }

        internal static DiskEncryptionSetData DeserializeDiskEncryptionSetData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ManagedServiceIdentity> identity = default;
            Optional<AzureLocation> location = default;
            Optional<IReadOnlyDictionary<string, string>> tags = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<DiskEncryptionSetType> encryptionType = default;
            Optional<KeyForDiskEncryptionSet> activeKey = default;
            Optional<IReadOnlyList<KeyForDiskEncryptionSet>> previousKeys = default;
            Optional<string> provisioningState = default;
            Optional<bool> rotationToLatestKeyVersionEnabled = default;
            Optional<DateTimeOffset> lastKeyRotationTimestamp = default;
            Optional<string> federatedClientId = default;
            Optional<MinimumTlsVersion> minimumTlsVersion = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
                    identity = JsonSerializer.Deserialize<ManagedServiceIdentity>(property.Value.GetRawText(), serializeOptions);
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
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
                        if (property0.NameEquals("encryptionType"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            encryptionType = new DiskEncryptionSetType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("activeKey"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            activeKey = KeyForDiskEncryptionSet.DeserializeKeyForDiskEncryptionSet(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("previousKeys"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<KeyForDiskEncryptionSet> array = new List<KeyForDiskEncryptionSet>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(KeyForDiskEncryptionSet.DeserializeKeyForDiskEncryptionSet(item));
                            }
                            previousKeys = array;
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("rotationToLatestKeyVersionEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            rotationToLatestKeyVersionEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("lastKeyRotationTimestamp"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            lastKeyRotationTimestamp = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("federatedClientId"u8))
                        {
                            federatedClientId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("minimumTlsVersion"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            minimumTlsVersion = new MinimumTlsVersion(property0.Value.GetString());
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
            return new DiskEncryptionSetData(id, name, type, systemData.Value, identity, Optional.ToNullable(encryptionType), activeKey.Value, Optional.ToList(previousKeys), provisioningState.Value, Optional.ToNullable(rotationToLatestKeyVersionEnabled), Optional.ToNullable(lastKeyRotationTimestamp), federatedClientId.Value, Optional.ToNullable(minimumTlsVersion), Optional.ToNullable(location), Optional.ToDictionary(tags), serializedAdditionalRawData);
        }

        BinaryData IModel<DiskEncryptionSetData>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DiskEncryptionSetData)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DiskEncryptionSetData IModel<DiskEncryptionSetData>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(DiskEncryptionSetData)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDiskEncryptionSetData(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<DiskEncryptionSetData>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
