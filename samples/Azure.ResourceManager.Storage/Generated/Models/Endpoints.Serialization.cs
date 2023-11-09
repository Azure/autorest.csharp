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
    public partial class Endpoints : IUtf8JsonSerializable, IJsonModel<Endpoints>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Endpoints>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<Endpoints>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<Endpoints>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<Endpoints>)} interface");
            }

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
            if (Optional.IsDefined(MicrosoftEndpoints))
            {
                writer.WritePropertyName("microsoftEndpoints"u8);
                writer.WriteObjectValue(MicrosoftEndpoints);
            }
            if (Optional.IsDefined(InternetEndpoints))
            {
                writer.WritePropertyName("internetEndpoints"u8);
                writer.WriteObjectValue(InternetEndpoints);
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

        Endpoints IJsonModel<Endpoints>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Endpoints)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEndpoints(document.RootElement, options);
        }

        internal static Endpoints DeserializeEndpoints(JsonElement element, ModelReaderWriterOptions options = null)
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
            Optional<StorageAccountMicrosoftEndpoints> microsoftEndpoints = default;
            Optional<StorageAccountInternetEndpoints> internetEndpoints = default;
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
                if (property.NameEquals("microsoftEndpoints"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    microsoftEndpoints = StorageAccountMicrosoftEndpoints.DeserializeStorageAccountMicrosoftEndpoints(property.Value);
                    continue;
                }
                if (property.NameEquals("internetEndpoints"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    internetEndpoints = StorageAccountInternetEndpoints.DeserializeStorageAccountInternetEndpoints(property.Value);
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Endpoints(blob.Value, queue.Value, table.Value, file.Value, web.Value, dfs.Value, microsoftEndpoints.Value, internetEndpoints.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<Endpoints>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Endpoints)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        Endpoints IModel<Endpoints>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Endpoints)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeEndpoints(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<Endpoints>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
