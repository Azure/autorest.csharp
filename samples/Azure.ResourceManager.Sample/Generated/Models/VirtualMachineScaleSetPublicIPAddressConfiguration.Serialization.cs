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
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetPublicIPAddressConfiguration>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineScaleSetPublicIPAddressConfiguration>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineScaleSetPublicIPAddressConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetPublicIPAddressConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetPublicIPAddressConfiguration)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(IdleTimeoutInMinutes))
            {
                writer.WritePropertyName("idleTimeoutInMinutes"u8);
                writer.WriteNumberValue(IdleTimeoutInMinutes.Value);
            }
            if (Optional.IsDefined(DnsSettings))
            {
                writer.WritePropertyName("dnsSettings"u8);
                writer.WriteObjectValue(DnsSettings);
            }
            if (!(IPTags is ChangeTrackingList<VirtualMachineScaleSetIPTag> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("ipTags"u8);
                writer.WriteStartArray();
                foreach (var item in IPTags)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PublicIPPrefix))
            {
                writer.WritePropertyName("publicIPPrefix"u8);
                JsonSerializer.Serialize(writer, PublicIPPrefix);
            }
            if (Optional.IsDefined(PublicIPAddressVersion))
            {
                writer.WritePropertyName("publicIPAddressVersion"u8);
                writer.WriteStringValue(PublicIPAddressVersion.Value.ToString());
            }
            writer.WriteEndObject();
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

        VirtualMachineScaleSetPublicIPAddressConfiguration IJsonModel<VirtualMachineScaleSetPublicIPAddressConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetPublicIPAddressConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetPublicIPAddressConfiguration)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineScaleSetPublicIPAddressConfiguration(document.RootElement, options);
        }

        internal static VirtualMachineScaleSetPublicIPAddressConfiguration DeserializeVirtualMachineScaleSetPublicIPAddressConfiguration(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<int> idleTimeoutInMinutes = default;
            Optional<VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings> dnsSettings = default;
            Optional<IList<VirtualMachineScaleSetIPTag>> ipTags = default;
            Optional<WritableSubResource> publicIPPrefix = default;
            Optional<IPVersion> publicIPAddressVersion = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("idleTimeoutInMinutes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            idleTimeoutInMinutes = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("dnsSettings"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            dnsSettings = VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings.DeserializeVirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("ipTags"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<VirtualMachineScaleSetIPTag> array = new List<VirtualMachineScaleSetIPTag>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(VirtualMachineScaleSetIPTag.DeserializeVirtualMachineScaleSetIPTag(item));
                            }
                            ipTags = array;
                            continue;
                        }
                        if (property0.NameEquals("publicIPPrefix"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            publicIPPrefix = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("publicIPAddressVersion"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            publicIPAddressVersion = new IPVersion(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineScaleSetPublicIPAddressConfiguration(name, Optional.ToNullable(idleTimeoutInMinutes), dnsSettings.Value, Optional.ToList(ipTags), publicIPPrefix, Optional.ToNullable(publicIPAddressVersion), serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");

            if (Optional.IsDefined(Name))
            {
                builder.Append("  name:");
                if (Name.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{Name}'''");
                }
                else
                {
                    builder.AppendLine($" '{Name}'");
                }
            }

            builder.Append("  properties:");
            builder.AppendLine(" {");
            if (Optional.IsDefined(IdleTimeoutInMinutes))
            {
                builder.Append("    idleTimeoutInMinutes:");
                builder.AppendLine($" {IdleTimeoutInMinutes.Value}");
            }

            if (Optional.IsDefined(DnsSettings))
            {
                builder.Append("    dnsSettings:");
                AppendChildObject(builder, DnsSettings, options, 4, false);
            }

            if (!(IPTags is ChangeTrackingList<VirtualMachineScaleSetIPTag> collection && collection.IsUndefined))
            {
                if (IPTags.Any())
                {
                    builder.Append("    ipTags:");
                    builder.AppendLine(" [");
                    foreach (var item in IPTags)
                    {
                        AppendChildObject(builder, item, options, 6, true);
                    }
                    builder.AppendLine("    ]");
                }
            }

            if (Optional.IsDefined(PublicIPPrefix))
            {
                builder.Append("    publicIPPrefix:");
                AppendChildObject(builder, PublicIPPrefix, options, 4, false);
            }

            if (Optional.IsDefined(PublicIPAddressVersion))
            {
                builder.Append("    publicIPAddressVersion:");
                builder.AppendLine($" '{PublicIPAddressVersion.Value.ToString()}'");
            }

            builder.AppendLine("  }");
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

        BinaryData IPersistableModel<VirtualMachineScaleSetPublicIPAddressConfiguration>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetPublicIPAddressConfiguration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetPublicIPAddressConfiguration)} does not support '{options.Format}' format.");
            }
        }

        VirtualMachineScaleSetPublicIPAddressConfiguration IPersistableModel<VirtualMachineScaleSetPublicIPAddressConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetPublicIPAddressConfiguration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineScaleSetPublicIPAddressConfiguration(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineScaleSetPublicIPAddressConfiguration)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineScaleSetPublicIPAddressConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
