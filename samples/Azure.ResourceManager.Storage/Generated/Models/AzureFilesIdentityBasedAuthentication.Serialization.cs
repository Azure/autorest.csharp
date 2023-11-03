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
    public partial class AzureFilesIdentityBasedAuthentication : IUtf8JsonSerializable, IJsonModel<AzureFilesIdentityBasedAuthentication>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AzureFilesIdentityBasedAuthentication>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<AzureFilesIdentityBasedAuthentication>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("directoryServiceOptions"u8);
            writer.WriteStringValue(DirectoryServiceOptions.ToString());
            if (Optional.IsDefined(ActiveDirectoryProperties))
            {
                writer.WritePropertyName("activeDirectoryProperties"u8);
                writer.WriteObjectValue(ActiveDirectoryProperties);
            }
            if (Optional.IsDefined(DefaultSharePermission))
            {
                writer.WritePropertyName("defaultSharePermission"u8);
                writer.WriteStringValue(DefaultSharePermission.Value.ToString());
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

        AzureFilesIdentityBasedAuthentication IJsonModel<AzureFilesIdentityBasedAuthentication>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureFilesIdentityBasedAuthentication(document.RootElement, options);
        }

        internal static AzureFilesIdentityBasedAuthentication DeserializeAzureFilesIdentityBasedAuthentication(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DirectoryServiceOption directoryServiceOptions = default;
            Optional<ActiveDirectoryProperties> activeDirectoryProperties = default;
            Optional<DefaultSharePermission> defaultSharePermission = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("directoryServiceOptions"u8))
                {
                    directoryServiceOptions = new DirectoryServiceOption(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("activeDirectoryProperties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    activeDirectoryProperties = ActiveDirectoryProperties.DeserializeActiveDirectoryProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("defaultSharePermission"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    defaultSharePermission = new DefaultSharePermission(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new AzureFilesIdentityBasedAuthentication(directoryServiceOptions, activeDirectoryProperties.Value, Optional.ToNullable(defaultSharePermission), serializedAdditionalRawData);
        }

        BinaryData IModel<AzureFilesIdentityBasedAuthentication>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        AzureFilesIdentityBasedAuthentication IModel<AzureFilesIdentityBasedAuthentication>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAzureFilesIdentityBasedAuthentication(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<AzureFilesIdentityBasedAuthentication>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
