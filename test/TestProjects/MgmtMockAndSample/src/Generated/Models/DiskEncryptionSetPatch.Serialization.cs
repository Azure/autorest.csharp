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

namespace MgmtMockAndSample.Models
{
    public partial class DiskEncryptionSetPatch : IUtf8JsonSerializable, IJsonModel<DiskEncryptionSetPatch>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DiskEncryptionSetPatch>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<DiskEncryptionSetPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
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
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
                JsonSerializer.Serialize(writer, Identity, serializeOptions);
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
            if (Optional.IsDefined(RotationToLatestKeyVersionEnabled))
            {
                writer.WritePropertyName("rotationToLatestKeyVersionEnabled"u8);
                writer.WriteBooleanValue(RotationToLatestKeyVersionEnabled.Value);
            }
            if (Optional.IsDefined(FederatedClientId))
            {
                writer.WritePropertyName("federatedClientId"u8);
                writer.WriteStringValue(FederatedClientId);
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

        DiskEncryptionSetPatch IJsonModel<DiskEncryptionSetPatch>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDiskEncryptionSetPatch(document.RootElement, options);
        }

        internal static DiskEncryptionSetPatch DeserializeDiskEncryptionSetPatch(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IDictionary<string, string>> tags = default;
            Optional<ManagedServiceIdentity> identity = default;
            Optional<DiskEncryptionSetType> encryptionType = default;
            Optional<KeyForDiskEncryptionSet> activeKey = default;
            Optional<bool> rotationToLatestKeyVersionEnabled = default;
            Optional<string> federatedClientId = default;
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
                        if (property0.NameEquals("rotationToLatestKeyVersionEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            rotationToLatestKeyVersionEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("federatedClientId"u8))
                        {
                            federatedClientId = property0.Value.GetString();
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
            return new DiskEncryptionSetPatch(Optional.ToDictionary(tags), identity, Optional.ToNullable(encryptionType), activeKey.Value, Optional.ToNullable(rotationToLatestKeyVersionEnabled), federatedClientId.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<DiskEncryptionSetPatch>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        DiskEncryptionSetPatch IModel<DiskEncryptionSetPatch>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDiskEncryptionSetPatch(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<DiskEncryptionSetPatch>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
