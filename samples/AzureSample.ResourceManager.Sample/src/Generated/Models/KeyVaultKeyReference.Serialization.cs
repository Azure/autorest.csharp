// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace AzureSample.ResourceManager.Sample.Models
{
    public partial class KeyVaultKeyReference : IUtf8JsonSerializable, IJsonModel<KeyVaultKeyReference>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<KeyVaultKeyReference>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<KeyVaultKeyReference>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<KeyVaultKeyReference>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(KeyVaultKeyReference)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("keyUrl"u8);
            writer.WriteStringValue(KeyUri.AbsoluteUri);
            writer.WritePropertyName("sourceVault"u8);
            JsonSerializer.Serialize(writer, SourceVault);
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        KeyVaultKeyReference IJsonModel<KeyVaultKeyReference>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<KeyVaultKeyReference>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(KeyVaultKeyReference)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeKeyVaultKeyReference(document.RootElement, options);
        }

        internal static KeyVaultKeyReference DeserializeKeyVaultKeyReference(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Uri keyUrl = default;
            WritableSubResource sourceVault = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keyUrl"u8))
                {
                    keyUrl = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sourceVault"u8))
                {
                    sourceVault = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new KeyVaultKeyReference(keyUrl, sourceVault, serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.PropertyOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            if (propertyOverrides != null)
            {
                TransformFlattenedOverrides(bicepOptions, propertyOverrides);
            }

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(KeyUri), out propertyOverride);
            if (Optional.IsDefined(KeyUri) || hasPropertyOverride)
            {
                builder.Append("  keyUrl: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"'{KeyUri.AbsoluteUri}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SourceVault), out propertyOverride);
            if (Optional.IsDefined(SourceVault) || hasPropertyOverride)
            {
                builder.Append("  sourceVault: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, SourceVault, options, 2, false, "  sourceVault: ");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        private void TransformFlattenedOverrides(BicepModelReaderWriterOptions bicepOptions, IDictionary<string, string> propertyOverrides)
        {
            foreach (var item in propertyOverrides.ToList())
            {
                switch (item.Key)
                {
                    case "SourceVaultId":
                        Dictionary<string, string> propertyDictionary = new Dictionary<string, string>();
                        propertyDictionary.Add("Id", item.Value);
                        bicepOptions.PropertyOverrides.Add(SourceVault, propertyDictionary);
                        break;
                    default:
                        continue;
                }
            }
        }

        BinaryData IPersistableModel<KeyVaultKeyReference>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<KeyVaultKeyReference>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(KeyVaultKeyReference)} does not support writing '{options.Format}' format.");
            }
        }

        KeyVaultKeyReference IPersistableModel<KeyVaultKeyReference>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<KeyVaultKeyReference>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeKeyVaultKeyReference(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(KeyVaultKeyReference)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<KeyVaultKeyReference>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
