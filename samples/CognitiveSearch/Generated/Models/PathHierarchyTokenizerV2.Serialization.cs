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

namespace CognitiveSearch.Models
{
    public partial class PathHierarchyTokenizerV2 : IUtf8JsonSerializable, IJsonModel<PathHierarchyTokenizerV2>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PathHierarchyTokenizerV2>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<PathHierarchyTokenizerV2>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<PathHierarchyTokenizerV2>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<PathHierarchyTokenizerV2>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Delimiter))
            {
                writer.WritePropertyName("delimiter"u8);
                writer.WriteStringValue(Delimiter.Value);
            }
            if (Optional.IsDefined(Replacement))
            {
                writer.WritePropertyName("replacement"u8);
                writer.WriteStringValue(Replacement.Value);
            }
            if (Optional.IsDefined(MaxTokenLength))
            {
                writer.WritePropertyName("maxTokenLength"u8);
                writer.WriteNumberValue(MaxTokenLength.Value);
            }
            if (Optional.IsDefined(ReverseTokenOrder))
            {
                writer.WritePropertyName("reverse"u8);
                writer.WriteBooleanValue(ReverseTokenOrder.Value);
            }
            if (Optional.IsDefined(NumberOfTokensToSkip))
            {
                writer.WritePropertyName("skip"u8);
                writer.WriteNumberValue(NumberOfTokensToSkip.Value);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
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

        PathHierarchyTokenizerV2 IJsonModel<PathHierarchyTokenizerV2>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PathHierarchyTokenizerV2)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePathHierarchyTokenizerV2(document.RootElement, options);
        }

        internal static PathHierarchyTokenizerV2 DeserializePathHierarchyTokenizerV2(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<char> delimiter = default;
            Optional<char> replacement = default;
            Optional<int> maxTokenLength = default;
            Optional<bool> reverse = default;
            Optional<int> skip = default;
            string odataType = default;
            string name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("delimiter"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    delimiter = property.Value.GetChar();
                    continue;
                }
                if (property.NameEquals("replacement"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    replacement = property.Value.GetChar();
                    continue;
                }
                if (property.NameEquals("maxTokenLength"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxTokenLength = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("reverse"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    reverse = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("skip"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    skip = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new PathHierarchyTokenizerV2(odataType, name, serializedAdditionalRawData, Optional.ToNullable(delimiter), Optional.ToNullable(replacement), Optional.ToNullable(maxTokenLength), Optional.ToNullable(reverse), Optional.ToNullable(skip));
        }

        BinaryData IPersistableModel<PathHierarchyTokenizerV2>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PathHierarchyTokenizerV2)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        PathHierarchyTokenizerV2 IPersistableModel<PathHierarchyTokenizerV2>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PathHierarchyTokenizerV2)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePathHierarchyTokenizerV2(document.RootElement, options);
        }

        string IPersistableModel<PathHierarchyTokenizerV2>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
