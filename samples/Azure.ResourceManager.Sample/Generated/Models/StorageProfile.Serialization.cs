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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class StorageProfile : IUtf8JsonSerializable, IJsonModel<StorageProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<StorageProfile>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<StorageProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StorageProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StorageProfile)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(ImageReference))
            {
                writer.WritePropertyName("imageReference"u8);
                writer.WriteObjectValue(ImageReference);
            }
            if (Optional.IsDefined(OSDisk))
            {
                writer.WritePropertyName("osDisk"u8);
                writer.WriteObjectValue(OSDisk);
            }
            if (!(DataDisks is ChangeTrackingList<DataDisk> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("dataDisks"u8);
                writer.WriteStartArray();
                foreach (var item in DataDisks)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
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

        StorageProfile IJsonModel<StorageProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StorageProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StorageProfile)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeStorageProfile(document.RootElement, options);
        }

        internal static StorageProfile DeserializeStorageProfile(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ImageReference> imageReference = default;
            Optional<OSDisk> osDisk = default;
            Optional<IList<DataDisk>> dataDisks = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("imageReference"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    imageReference = ImageReference.DeserializeImageReference(property.Value, options);
                    continue;
                }
                if (property.NameEquals("osDisk"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    osDisk = OSDisk.DeserializeOSDisk(property.Value, options);
                    continue;
                }
                if (property.NameEquals("dataDisks"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DataDisk> array = new List<DataDisk>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DataDisk.DeserializeDataDisk(item, options));
                    }
                    dataDisks = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new StorageProfile(imageReference.Value, osDisk.Value, Optional.ToList(dataDisks), serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");

            if (Optional.IsDefined(ImageReference))
            {
                builder.Append("  imageReference:");
                AppendChildObject(builder, ImageReference, options, 2, false);
            }

            if (Optional.IsDefined(OSDisk))
            {
                builder.Append("  osDisk:");
                AppendChildObject(builder, OSDisk, options, 2, false);
            }

            if (!(DataDisks is ChangeTrackingList<DataDisk> collection && collection.IsUndefined))
            {
                if (DataDisks.Any())
                {
                    builder.Append("  dataDisks:");
                    builder.AppendLine(" [");
                    foreach (var item in DataDisks)
                    {
                        AppendChildObject(builder, item, options, 4, true);
                    }
                    builder.AppendLine("  ]");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        private void AppendChildObject(StringBuilder stringBuilder, object childObject, ModelReaderWriterOptions options, int spaces, bool indentFirstLine)
        {
            string indent = new string(' ', spaces);
            BinaryData data = ModelReaderWriter.Write(childObject, options);
            string[] lines = data.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            bool inMultilineString = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (inMultilineString)
                {
                    if (line.Contains("'''"))
                    {
                        inMultilineString = false;
                    }
                    stringBuilder.AppendLine(line);
                    continue;
                }
                if (line.Contains("'''"))
                {
                    inMultilineString = true;
                    stringBuilder.AppendLine($"{indent}{line}");
                    continue;
                }
                if (i == 0 && !indentFirstLine)
                {
                    stringBuilder.AppendLine($" {line}");
                }
                else
                {
                    stringBuilder.AppendLine($"{indent}{line}");
                }
            }
        }

        BinaryData IPersistableModel<StorageProfile>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StorageProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(StorageProfile)} does not support '{options.Format}' format.");
            }
        }

        StorageProfile IPersistableModel<StorageProfile>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StorageProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeStorageProfile(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(StorageProfile)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<StorageProfile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
