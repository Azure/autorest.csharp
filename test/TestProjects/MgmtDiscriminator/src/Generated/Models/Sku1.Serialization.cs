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

namespace MgmtDiscriminator.Models
{
    internal partial class Sku1 : IUtf8JsonSerializable, IJsonModel<Sku1>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Sku1>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<Sku1>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Sku1>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Sku1)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Name1))
            {
                writer.WritePropertyName("name1"u8);
                writer.WriteObjectValue<Sku2>(Name1, options);
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

        Sku1 IJsonModel<Sku1>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Sku1>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Sku1)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSku1(document.RootElement, options);
        }

        internal static Sku1 DeserializeSku1(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Sku2 name1 = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name1"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    name1 = Sku2.DeserializeSku2(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Sku1(name1, serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.PropertyOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Name1), out propertyOverride);
            if (Optional.IsDefined(Name1) || hasPropertyOverride)
            {
                builder.Append("  name1: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    BicepSerializationHelpers.AppendChildObject(builder, Name1, options, 2, false, "  name1: ");
                }
            }

            if (propertyOverrides != null)
            {
                WriteFlattenedPropertiesWithOverrides(bicepOptions, propertyOverrides, builder);
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        private void WriteFlattenedPropertiesWithOverrides(BicepModelReaderWriterOptions bicepOptions, IDictionary<string, string> propertyOverrides, StringBuilder stringBuilder)
        {
            foreach (var item in propertyOverrides.ToList())
            {
                switch (item.Key)
                {
                    case "NestedName":
                        stringBuilder.AppendLine("name1: {");
                        stringBuilder.Append("  nestedName: ");
                        stringBuilder.AppendLine(item.Value);
                        stringBuilder.AppendLine("  }");
                        stringBuilder.AppendLine("}");
                        break;
                    default:
                        continue;
                }
            }
        }

        BinaryData IPersistableModel<Sku1>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Sku1>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(Sku1)} does not support writing '{options.Format}' format.");
            }
        }

        Sku1 IPersistableModel<Sku1>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Sku1>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeSku1(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(Sku1)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<Sku1>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
