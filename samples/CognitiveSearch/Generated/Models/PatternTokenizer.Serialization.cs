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
    public partial class PatternTokenizer : IUtf8JsonSerializable, IJsonModel<PatternTokenizer>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PatternTokenizer>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<PatternTokenizer>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Pattern))
            {
                writer.WritePropertyName("pattern"u8);
                writer.WriteStringValue(Pattern);
            }
            if (Optional.IsDefined(Flags))
            {
                writer.WritePropertyName("flags"u8);
                writer.WriteStringValue(Flags.Value.ToString());
            }
            if (Optional.IsDefined(Group))
            {
                writer.WritePropertyName("group"u8);
                writer.WriteNumberValue(Group.Value);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
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

        PatternTokenizer IJsonModel<PatternTokenizer>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PatternTokenizer)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePatternTokenizer(document.RootElement, options);
        }

        internal static PatternTokenizer DeserializePatternTokenizer(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> pattern = default;
            Optional<RegexFlags> flags = default;
            Optional<int> group = default;
            string odataType = default;
            string name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("pattern"u8))
                {
                    pattern = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("flags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    flags = new RegexFlags(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("group"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    group = property.Value.GetInt32();
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
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new PatternTokenizer(odataType, name, serializedAdditionalRawData, pattern.Value, Optional.ToNullable(flags), Optional.ToNullable(group));
        }

        BinaryData IModel<PatternTokenizer>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PatternTokenizer)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        PatternTokenizer IModel<PatternTokenizer>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PatternTokenizer)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePatternTokenizer(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<PatternTokenizer>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
