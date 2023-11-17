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
    public partial class Endpoints : IUtf8JsonSerializable, IJsonModel<Endpoints>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Endpoints>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<Endpoints>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<Endpoints>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<Endpoints>)} interface");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Blob))
                {
                    writer.WritePropertyName("blob"u8);
                    writer.WriteStringValue(Blob);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Queue))
                {
                    writer.WritePropertyName("queue"u8);
                    writer.WriteStringValue(Queue);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Table))
                {
                    writer.WritePropertyName("table"u8);
                    writer.WriteStringValue(Table);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(File))
                {
                    writer.WritePropertyName("file"u8);
                    writer.WriteStringValue(File);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Web))
                {
                    writer.WritePropertyName("web"u8);
                    writer.WriteStringValue(Web);
                }
            }
            if (options.Format == "J")
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

        Endpoints IJsonModel<Endpoints>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Endpoints)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEndpoints(document.RootElement, options);
        }

        internal static Endpoints DeserializeEndpoints(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Endpoints(blob.Value, queue.Value, table.Value, file.Value, web.Value, dfs.Value, microsoftEndpoints.Value, internetEndpoints.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<Endpoints>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Endpoints)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        Endpoints IPersistableModel<Endpoints>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Endpoints)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeEndpoints(document.RootElement, options);
        }

        string IPersistableModel<Endpoints>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
