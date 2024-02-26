// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class LinuxConfiguration : IUtf8JsonSerializable, IJsonModel<LinuxConfiguration>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<LinuxConfiguration>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<LinuxConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LinuxConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LinuxConfiguration)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (DisablePasswordAuthentication.HasValue)
            {
                writer.WritePropertyName("disablePasswordAuthentication"u8);
                writer.WriteBooleanValue(DisablePasswordAuthentication.Value);
            }
            if (Ssh != null)
            {
                writer.WritePropertyName("ssh"u8);
                writer.WriteObjectValue(Ssh);
            }
            if (ProvisionVmAgent.HasValue)
            {
                writer.WritePropertyName("provisionVMAgent"u8);
                writer.WriteBooleanValue(ProvisionVmAgent.Value);
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

        LinuxConfiguration IJsonModel<LinuxConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LinuxConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LinuxConfiguration)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLinuxConfiguration(document.RootElement, options);
        }

        internal static LinuxConfiguration DeserializeLinuxConfiguration(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> disablePasswordAuthentication = default;
            Optional<SshConfiguration> ssh = default;
            Optional<bool> provisionVmAgent = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("disablePasswordAuthentication"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    disablePasswordAuthentication = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("ssh"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    ssh = SshConfiguration.DeserializeSshConfiguration(property.Value, options);
                    continue;
                }
                if (property.NameEquals("provisionVMAgent"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    provisionVmAgent = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new LinuxConfiguration(Optional.ToNullable(disablePasswordAuthentication), ssh.Value, Optional.ToNullable(provisionVmAgent), serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");

            if (DisablePasswordAuthentication.HasValue)
            {
                builder.Append("  disablePasswordAuthentication:");
                var boolValue = DisablePasswordAuthentication.Value == true ? "true" : "false";
                builder.AppendLine($" {boolValue}");
            }

            if (Ssh != null)
            {
                builder.Append("  ssh:");
                AppendChildObject(builder, Ssh, options, 2, false);
            }

            if (ProvisionVmAgent.HasValue)
            {
                builder.Append("  provisionVMAgent:");
                var boolValue = ProvisionVmAgent.Value == true ? "true" : "false";
                builder.AppendLine($" {boolValue}");
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

        BinaryData IPersistableModel<LinuxConfiguration>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LinuxConfiguration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(LinuxConfiguration)} does not support '{options.Format}' format.");
            }
        }

        LinuxConfiguration IPersistableModel<LinuxConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LinuxConfiguration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeLinuxConfiguration(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(LinuxConfiguration)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<LinuxConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
