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
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class ManagedDiskParameters : IUtf8JsonSerializable, IJsonModel<ManagedDiskParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ManagedDiskParameters>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ManagedDiskParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(StorageAccountType))
            {
                writer.WritePropertyName("storageAccountType"u8);
                writer.WriteStringValue(StorageAccountType.Value.ToString());
            }
            if (Optional.IsDefined(DiskEncryptionSet))
            {
                writer.WritePropertyName("diskEncryptionSet"u8);
                JsonSerializer.Serialize(writer, DiskEncryptionSet);
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
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

        ManagedDiskParameters IJsonModel<ManagedDiskParameters>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeManagedDiskParameters(document.RootElement, options);
        }

        internal static ManagedDiskParameters DeserializeManagedDiskParameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<StorageAccountType> storageAccountType = default;
            Optional<WritableSubResource> diskEncryptionSet = default;
            Optional<string> id = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("storageAccountType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    storageAccountType = new StorageAccountType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("diskEncryptionSet"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diskEncryptionSet = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ManagedDiskParameters(id.Value, serializedAdditionalRawData, Optional.ToNullable(storageAccountType), diskEncryptionSet);
        }

        BinaryData IModel<ManagedDiskParameters>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.Write(this, options);
        }

        ManagedDiskParameters IModel<ManagedDiskParameters>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeManagedDiskParameters(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<ManagedDiskParameters>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
