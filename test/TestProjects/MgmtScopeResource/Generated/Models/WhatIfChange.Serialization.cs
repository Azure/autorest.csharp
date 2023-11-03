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

namespace MgmtScopeResource.Models
{
    public partial class WhatIfChange : IUtf8JsonSerializable, IJsonModel<WhatIfChange>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<WhatIfChange>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<WhatIfChange>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("resourceId"u8);
            writer.WriteStringValue(ResourceId);
            writer.WritePropertyName("changeType"u8);
            writer.WriteStringValue(ChangeType.ToSerialString());
            if (Optional.IsDefined(UnsupportedReason))
            {
                writer.WritePropertyName("unsupportedReason"u8);
                writer.WriteStringValue(UnsupportedReason);
            }
            if (Optional.IsDefined(Before))
            {
                writer.WritePropertyName("before"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Before);
#else
                using (JsonDocument document = JsonDocument.Parse(Before))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (Optional.IsDefined(After))
            {
                writer.WritePropertyName("after"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(After);
#else
                using (JsonDocument document = JsonDocument.Parse(After))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
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

        WhatIfChange IJsonModel<WhatIfChange>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeWhatIfChange(document.RootElement, options);
        }

        internal static WhatIfChange DeserializeWhatIfChange(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string resourceId = default;
            ChangeType changeType = default;
            Optional<string> unsupportedReason = default;
            Optional<BinaryData> before = default;
            Optional<BinaryData> after = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resourceId"u8))
                {
                    resourceId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("changeType"u8))
                {
                    changeType = property.Value.GetString().ToChangeType();
                    continue;
                }
                if (property.NameEquals("unsupportedReason"u8))
                {
                    unsupportedReason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("before"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    before = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("after"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    after = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new WhatIfChange(resourceId, changeType, unsupportedReason.Value, before.Value, after.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<WhatIfChange>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        WhatIfChange IModel<WhatIfChange>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeWhatIfChange(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<WhatIfChange>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
