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
    public partial class BlobInventoryPolicySchema : IUtf8JsonSerializable, IJsonModel<BlobInventoryPolicySchema>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BlobInventoryPolicySchema>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<BlobInventoryPolicySchema>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("enabled"u8);
            writer.WriteBooleanValue(Enabled);
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(InventoryRuleType.ToString());
            writer.WritePropertyName("rules"u8);
            writer.WriteStartArray();
            foreach (var item in Rules)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
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

        BlobInventoryPolicySchema IJsonModel<BlobInventoryPolicySchema>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBlobInventoryPolicySchema(document.RootElement, options);
        }

        internal static BlobInventoryPolicySchema DeserializeBlobInventoryPolicySchema(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool enabled = default;
            InventoryRuleType type = default;
            IList<BlobInventoryPolicyRule> rules = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"u8))
                {
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new InventoryRuleType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("rules"u8))
                {
                    List<BlobInventoryPolicyRule> array = new List<BlobInventoryPolicyRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BlobInventoryPolicyRule.DeserializeBlobInventoryPolicyRule(item));
                    }
                    rules = array;
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new BlobInventoryPolicySchema(enabled, type, rules, serializedAdditionalRawData);
        }

        BinaryData IModel<BlobInventoryPolicySchema>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        BlobInventoryPolicySchema IModel<BlobInventoryPolicySchema>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBlobInventoryPolicySchema(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<BlobInventoryPolicySchema>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
