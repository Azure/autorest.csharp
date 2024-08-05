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
using Azure.ResourceManager;

namespace AzureSample.ResourceManager.Sample.Models
{
    public partial class LinuxConfiguration : IUtf8JsonSerializable, IJsonModel<LinuxConfiguration>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<LinuxConfiguration>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<LinuxConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LinuxConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LinuxConfiguration)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(DisablePasswordAuthentication))
            {
                writer.WritePropertyName("disablePasswordAuthentication"u8);
                writer.WriteBooleanValue(DisablePasswordAuthentication.Value);
            }
            if (Optional.IsDefined(Ssh))
            {
                writer.WritePropertyName("ssh"u8);
                writer.WriteObjectValue(Ssh, options);
            }
            if (Optional.IsDefined(ProvisionVmAgent))
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
        }

        LinuxConfiguration IJsonModel<LinuxConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LinuxConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LinuxConfiguration)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLinuxConfiguration(document.RootElement, options);
        }

        internal static LinuxConfiguration DeserializeLinuxConfiguration(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool? disablePasswordAuthentication = default;
            SshConfiguration ssh = default;
            bool? provisionVmAgent = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
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
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new LinuxConfiguration(disablePasswordAuthentication, ssh, provisionVmAgent, serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(DisablePasswordAuthentication), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  disablePasswordAuthentication: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(DisablePasswordAuthentication))
                {
                    builder.Append("  disablePasswordAuthentication: ");
                    var boolValue = DisablePasswordAuthentication.Value == true ? "true" : "false";
                    builder.AppendLine($"{boolValue}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue("SshPublicKeys", out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  ssh: ");
                builder.AppendLine("{");
                builder.Append("    publicKeys: ");
                builder.AppendLine(propertyOverride);
                builder.AppendLine("  }");
            }
            else
            {
                if (Optional.IsDefined(Ssh))
                {
                    builder.Append("  ssh: ");
                    BicepSerializationHelpers.AppendChildObject(builder, Ssh, options, 2, false, "  ssh: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ProvisionVmAgent), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  provisionVMAgent: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ProvisionVmAgent))
                {
                    builder.Append("  provisionVMAgent: ");
                    var boolValue = ProvisionVmAgent.Value == true ? "true" : "false";
                    builder.AppendLine($"{boolValue}");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
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
                    throw new FormatException($"The model {nameof(LinuxConfiguration)} does not support writing '{options.Format}' format.");
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
                default:
                    throw new FormatException($"The model {nameof(LinuxConfiguration)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<LinuxConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
