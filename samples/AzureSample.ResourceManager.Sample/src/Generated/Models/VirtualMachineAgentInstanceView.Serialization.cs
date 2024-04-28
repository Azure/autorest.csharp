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

namespace AzureSample.ResourceManager.Sample.Models
{
    public partial class VirtualMachineAgentInstanceView : IUtf8JsonSerializable, IJsonModel<VirtualMachineAgentInstanceView>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineAgentInstanceView>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<VirtualMachineAgentInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineAgentInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineAgentInstanceView)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(VmAgentVersion))
            {
                writer.WritePropertyName("vmAgentVersion"u8);
                writer.WriteStringValue(VmAgentVersion);
            }
            if (Optional.IsCollectionDefined(ExtensionHandlers))
            {
                writer.WritePropertyName("extensionHandlers"u8);
                writer.WriteStartArray();
                foreach (var item in ExtensionHandlers)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Statuses))
            {
                writer.WritePropertyName("statuses"u8);
                writer.WriteStartArray();
                foreach (var item in Statuses)
                {
                    writer.WriteObjectValue(item, options);
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

        VirtualMachineAgentInstanceView IJsonModel<VirtualMachineAgentInstanceView>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineAgentInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineAgentInstanceView)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineAgentInstanceView(document.RootElement, options);
        }

        internal static VirtualMachineAgentInstanceView DeserializeVirtualMachineAgentInstanceView(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string vmAgentVersion = default;
            IReadOnlyList<VirtualMachineExtensionHandlerInstanceView> extensionHandlers = default;
            IReadOnlyList<InstanceViewStatus> statuses = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vmAgentVersion"u8))
                {
                    vmAgentVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("extensionHandlers"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineExtensionHandlerInstanceView> array = new List<VirtualMachineExtensionHandlerInstanceView>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineExtensionHandlerInstanceView.DeserializeVirtualMachineExtensionHandlerInstanceView(item, options));
                    }
                    extensionHandlers = array;
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
                        array.Add(InstanceViewStatus.DeserializeInstanceViewStatus(item, options));
                    }
                    statuses = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new VirtualMachineAgentInstanceView(vmAgentVersion, extensionHandlers ?? new ChangeTrackingList<VirtualMachineExtensionHandlerInstanceView>(), statuses ?? new ChangeTrackingList<InstanceViewStatus>(), serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(VmAgentVersion), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  vmAgentVersion: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(VmAgentVersion))
                {
                    builder.Append("  vmAgentVersion: ");
                    if (VmAgentVersion.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{VmAgentVersion}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{VmAgentVersion}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ExtensionHandlers), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  extensionHandlers: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsCollectionDefined(ExtensionHandlers))
                {
                    if (ExtensionHandlers.Any())
                    {
                        builder.Append("  extensionHandlers: ");
                        builder.AppendLine("[");
                        foreach (var item in ExtensionHandlers)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  extensionHandlers: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Statuses), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  statuses: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsCollectionDefined(Statuses))
                {
                    if (Statuses.Any())
                    {
                        builder.Append("  statuses: ");
                        builder.AppendLine("[");
                        foreach (var item in Statuses)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  statuses: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<VirtualMachineAgentInstanceView>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineAgentInstanceView>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineAgentInstanceView)} does not support writing '{options.Format}' format.");
            }
        }

        VirtualMachineAgentInstanceView IPersistableModel<VirtualMachineAgentInstanceView>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineAgentInstanceView>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineAgentInstanceView(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineAgentInstanceView)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineAgentInstanceView>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
