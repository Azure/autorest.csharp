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

namespace Azure.ResourceManager.Storage.Models
{
    public partial class Encryption : IUtf8JsonSerializable, IJsonModel<Encryption>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Encryption>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<Encryption>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Services))
            {
                writer.WritePropertyName("services"u8);
                writer.WriteObjectValue(Services);
            }
            writer.WritePropertyName("keySource"u8);
            writer.WriteStringValue(KeySource.ToString());
            if (Optional.IsDefined(RequireInfrastructureEncryption))
            {
                writer.WritePropertyName("requireInfrastructureEncryption"u8);
                writer.WriteBooleanValue(RequireInfrastructureEncryption.Value);
            }
            if (Optional.IsDefined(KeyVaultProperties))
            {
                writer.WritePropertyName("keyvaultproperties"u8);
                writer.WriteObjectValue(KeyVaultProperties);
            }
            if (Optional.IsDefined(EncryptionIdentity))
            {
                writer.WritePropertyName("identity"u8);
                writer.WriteObjectValue(EncryptionIdentity);
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

        Encryption IJsonModel<Encryption>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEncryption(document.RootElement, options);
        }

        internal static Encryption DeserializeEncryption(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<EncryptionServices> services = default;
            KeySource keySource = default;
            Optional<bool> requireInfrastructureEncryption = default;
            Optional<KeyVaultProperties> keyvaultproperties = default;
            Optional<EncryptionIdentity> identity = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("services"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    services = EncryptionServices.DeserializeEncryptionServices(property.Value);
                    continue;
                }
                if (property.NameEquals("keySource"u8))
                {
                    keySource = new KeySource(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requireInfrastructureEncryption"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    requireInfrastructureEncryption = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("keyvaultproperties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    keyvaultproperties = KeyVaultProperties.DeserializeKeyVaultProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identity = EncryptionIdentity.DeserializeEncryptionIdentity(property.Value);
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Encryption(services.Value, keySource, Optional.ToNullable(requireInfrastructureEncryption), keyvaultproperties.Value, identity.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<Encryption>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.Write(this, options);
        }

        Encryption IModel<Encryption>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeEncryption(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<Encryption>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
