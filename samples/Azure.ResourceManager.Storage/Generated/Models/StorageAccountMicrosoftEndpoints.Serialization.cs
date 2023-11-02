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
    public partial class StorageAccountMicrosoftEndpoints : IUtf8JsonSerializable, IJsonModel<StorageAccountMicrosoftEndpoints>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<StorageAccountMicrosoftEndpoints>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<StorageAccountMicrosoftEndpoints>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Blob))
                {
                    writer.WritePropertyName("blob"u8);
                    writer.WriteStringValue(Blob);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Queue))
                {
                    writer.WritePropertyName("queue"u8);
                    writer.WriteStringValue(Queue);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Table))
                {
                    writer.WritePropertyName("table"u8);
                    writer.WriteStringValue(Table);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(File))
                {
                    writer.WritePropertyName("file"u8);
                    writer.WriteStringValue(File);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Web))
                {
                    writer.WritePropertyName("web"u8);
                    writer.WriteStringValue(Web);
                }
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                if (Optional.IsDefined(Dfs))
                {
                    writer.WritePropertyName("dfs"u8);
                    writer.WriteStringValue(Dfs);
                }
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

        StorageAccountMicrosoftEndpoints IJsonModel<StorageAccountMicrosoftEndpoints>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeStorageAccountMicrosoftEndpoints(document.RootElement, options);
        }

        internal static StorageAccountMicrosoftEndpoints DeserializeStorageAccountMicrosoftEndpoints(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> blob = default;
            Optional<string> queue = default;
            Optional<string> table = default;
            Optional<string> file = default;
            Optional<string> web = default;
            Optional<string> dfs = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("blob"u8))
                {
                    blob = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("queue"u8))
                {
                    queue = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("table"u8))
                {
                    table = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("file"u8))
                {
                    file = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("web"u8))
                {
                    web = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("dfs"u8))
                {
                    dfs = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new StorageAccountMicrosoftEndpoints(blob.Value, queue.Value, table.Value, file.Value, web.Value, dfs.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<StorageAccountMicrosoftEndpoints>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.WriteCore(this, options);
        }

        StorageAccountMicrosoftEndpoints IModel<StorageAccountMicrosoftEndpoints>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeStorageAccountMicrosoftEndpoints(document.RootElement, options);
        }
    }
}
