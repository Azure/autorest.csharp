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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineExtensionInstanceView : IUtf8JsonSerializable, IJsonModel<VirtualMachineExtensionInstanceView>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineExtensionInstanceView>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineExtensionInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineExtensionInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineExtensionInstanceView)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(VirtualMachineExtensionInstanceViewType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(VirtualMachineExtensionInstanceViewType);
            }
            if (Optional.IsDefined(TypeHandlerVersion))
            {
                writer.WritePropertyName("typeHandlerVersion"u8);
                writer.WriteStringValue(TypeHandlerVersion);
            }
            if (Optional.IsCollectionDefined(Substatuses))
            {
                writer.WritePropertyName("substatuses"u8);
                writer.WriteStartArray();
                foreach (var item in Substatuses)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Statuses))
            {
                writer.WritePropertyName("statuses"u8);
                writer.WriteStartArray();
                foreach (var item in Statuses)
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

        VirtualMachineExtensionInstanceView IJsonModel<VirtualMachineExtensionInstanceView>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineExtensionInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineExtensionInstanceView)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineExtensionInstanceView(document.RootElement, options);
        }

        internal static VirtualMachineExtensionInstanceView DeserializeVirtualMachineExtensionInstanceView(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> type = default;
            Optional<string> typeHandlerVersion = default;
            Optional<IList<InstanceViewStatus>> substatuses = default;
            Optional<IList<InstanceViewStatus>> statuses = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("typeHandlerVersion"u8))
                {
                    typeHandlerVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("substatuses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InstanceViewStatus> array = new List<InstanceViewStatus>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InstanceViewStatus.DeserializeInstanceViewStatus(item));
                    }
                    substatuses = array;
                    continue;
                }
                if (property.NameEquals("statuses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InstanceViewStatus> array = new List<InstanceViewStatus>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InstanceViewStatus.DeserializeInstanceViewStatus(item));
                    }
                    statuses = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineExtensionInstanceView(name.Value, type.Value, typeHandlerVersion.Value, Optional.ToList(substatuses), Optional.ToList(statuses), serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.ParameterOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Name), out propertyOverride);
            if (Optional.IsDefined(Name) || hasPropertyOverride)
            {
                builder.Append("  name: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (Name.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Name}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Name}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(TypeHandlerVersion), out propertyOverride);
            if (Optional.IsDefined(TypeHandlerVersion) || hasPropertyOverride)
            {
                builder.Append("  typeHandlerVersion: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (TypeHandlerVersion.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{TypeHandlerVersion}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{TypeHandlerVersion}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Substatuses), out propertyOverride);
            if (Optional.IsCollectionDefined(Substatuses) || hasPropertyOverride)
            {
                if (Substatuses.Any() || hasPropertyOverride)
                {
                    builder.Append("  substatuses: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
                        builder.AppendLine("[");
                        foreach (var item in Substatuses)
                        {
                            int currentIndent = 4;
                            int emptyObjectLength = 2 + currentIndent + Environment.NewLine.Length + Environment.NewLine.Length;
                            int length = builder.Length;
                            AppendChildObject(builder, item, options, currentIndent, true);
                            if (builder.Length == length + emptyObjectLength)
                            {
                                builder.Length = builder.Length - emptyObjectLength - "  substatuses: ".Length;
                            }
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Statuses), out propertyOverride);
            if (Optional.IsCollectionDefined(Statuses) || hasPropertyOverride)
            {
                if (Statuses.Any() || hasPropertyOverride)
                {
                    builder.Append("  statuses: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
                        builder.AppendLine("[");
                        foreach (var item in Statuses)
                        {
                            int currentIndent = 4;
                            int emptyObjectLength = 2 + currentIndent + Environment.NewLine.Length + Environment.NewLine.Length;
                            int length = builder.Length;
                            AppendChildObject(builder, item, options, currentIndent, true);
                            if (builder.Length == length + emptyObjectLength)
                            {
                                builder.Length = builder.Length - emptyObjectLength - "  statuses: ".Length;
                            }
                        }
                        builder.AppendLine("  ]");
                    }
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
                    stringBuilder.AppendLine($"{line}");
                }
                else
                {
                    stringBuilder.AppendLine($"{indent}{line}");
                }
            }
        }

        BinaryData IPersistableModel<VirtualMachineExtensionInstanceView>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineExtensionInstanceView>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineExtensionInstanceView)} does not support '{options.Format}' format.");
            }
        }

        VirtualMachineExtensionInstanceView IPersistableModel<VirtualMachineExtensionInstanceView>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineExtensionInstanceView>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineExtensionInstanceView(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineExtensionInstanceView)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineExtensionInstanceView>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
