// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class EncryptionScopeKeyVaultProperties : IUtf8JsonSerializable, IJsonModel<EncryptionScopeKeyVaultProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<EncryptionScopeKeyVaultProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<EncryptionScopeKeyVaultProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<EncryptionScopeKeyVaultProperties>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<EncryptionScopeKeyVaultProperties>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(KeyUri))
            {
                writer.WritePropertyName("keyUri"u8);
                writer.WriteStringValue(KeyUri.AbsoluteUri);
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(CurrentVersionedKeyIdentifier))
                {
                    writer.WritePropertyName("currentVersionedKeyIdentifier"u8);
                    writer.WriteStringValue(CurrentVersionedKeyIdentifier);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(LastKeyRotationTimestamp))
                {
                    writer.WritePropertyName("lastKeyRotationTimestamp"u8);
                    writer.WriteStringValue(LastKeyRotationTimestamp.Value, "O");
                }
            }
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        EncryptionScopeKeyVaultProperties IJsonModel<EncryptionScopeKeyVaultProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(EncryptionScopeKeyVaultProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEncryptionScopeKeyVaultProperties(document.RootElement, options);
        }

        internal static EncryptionScopeKeyVaultProperties DeserializeEncryptionScopeKeyVaultProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Uri> keyUri = default;
            Optional<string> currentVersionedKeyIdentifier = default;
            Optional<DateTimeOffset> lastKeyRotationTimestamp = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keyUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    keyUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("currentVersionedKeyIdentifier"u8))
                {
                    currentVersionedKeyIdentifier = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("lastKeyRotationTimestamp"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastKeyRotationTimestamp = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new EncryptionScopeKeyVaultProperties(keyUri.Value, currentVersionedKeyIdentifier.Value, Optional.ToNullable(lastKeyRotationTimestamp), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<EncryptionScopeKeyVaultProperties>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(EncryptionScopeKeyVaultProperties)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        EncryptionScopeKeyVaultProperties IPersistableModel<EncryptionScopeKeyVaultProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(EncryptionScopeKeyVaultProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeEncryptionScopeKeyVaultProperties(document.RootElement, options);
        }

        string IPersistableModel<EncryptionScopeKeyVaultProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
