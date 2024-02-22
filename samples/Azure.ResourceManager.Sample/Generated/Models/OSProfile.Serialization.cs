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
    public partial class OSProfile : IUtf8JsonSerializable, IJsonModel<OSProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<OSProfile>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<OSProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OSProfile)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(ComputerName))
            {
                writer.WritePropertyName("computerName"u8);
                writer.WriteStringValue(ComputerName);
            }
            if (Optional.IsDefined(AdminUsername))
            {
                writer.WritePropertyName("adminUsername"u8);
                writer.WriteStringValue(AdminUsername);
            }
            if (Optional.IsDefined(AdminPassword))
            {
                writer.WritePropertyName("adminPassword"u8);
                writer.WriteStringValue(AdminPassword);
            }
            if (Optional.IsDefined(CustomData))
            {
                writer.WritePropertyName("customData"u8);
                writer.WriteStringValue(CustomData);
            }
            if (Optional.IsDefined(WindowsConfiguration))
            {
                writer.WritePropertyName("windowsConfiguration"u8);
                writer.WriteObjectValue(WindowsConfiguration);
            }
            if (Optional.IsDefined(LinuxConfiguration))
            {
                writer.WritePropertyName("linuxConfiguration"u8);
                writer.WriteObjectValue(LinuxConfiguration);
            }
            if (!(Secrets is ChangeTrackingList<VaultSecretGroup> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("secrets"u8);
                writer.WriteStartArray();
                foreach (var item in Secrets)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(AllowExtensionOperations))
            {
                writer.WritePropertyName("allowExtensionOperations"u8);
                writer.WriteBooleanValue(AllowExtensionOperations.Value);
            }
            if (Optional.IsDefined(RequireGuestProvisionSignal))
            {
                writer.WritePropertyName("requireGuestProvisionSignal"u8);
                writer.WriteBooleanValue(RequireGuestProvisionSignal.Value);
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

        OSProfile IJsonModel<OSProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSProfile>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OSProfile)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOSProfile(document.RootElement, options);
        }

        internal static OSProfile DeserializeOSProfile(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> computerName = default;
            Optional<string> adminUsername = default;
            Optional<string> adminPassword = default;
            Optional<string> customData = default;
            Optional<WindowsConfiguration> windowsConfiguration = default;
            Optional<LinuxConfiguration> linuxConfiguration = default;
            Optional<IList<VaultSecretGroup>> secrets = default;
            Optional<bool> allowExtensionOperations = default;
            Optional<bool> requireGuestProvisionSignal = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("computerName"u8))
                {
                    computerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("adminUsername"u8))
                {
                    adminUsername = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("adminPassword"u8))
                {
                    adminPassword = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customData"u8))
                {
                    customData = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("windowsConfiguration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    windowsConfiguration = WindowsConfiguration.DeserializeWindowsConfiguration(property.Value);
                    continue;
                }
                if (property.NameEquals("linuxConfiguration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    linuxConfiguration = LinuxConfiguration.DeserializeLinuxConfiguration(property.Value);
                    continue;
                }
                if (property.NameEquals("secrets"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VaultSecretGroup> array = new List<VaultSecretGroup>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VaultSecretGroup.DeserializeVaultSecretGroup(item));
                    }
                    secrets = array;
                    continue;
                }
                if (property.NameEquals("allowExtensionOperations"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    allowExtensionOperations = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("requireGuestProvisionSignal"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    requireGuestProvisionSignal = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new OSProfile(computerName.Value, adminUsername.Value, adminPassword.Value, customData.Value, windowsConfiguration.Value, linuxConfiguration.Value, Optional.ToList(secrets), Optional.ToNullable(allowExtensionOperations), Optional.ToNullable(requireGuestProvisionSignal), serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");

            if (Optional.IsDefined(ComputerName))
            {
                builder.Append("  computerName:");
                if (ComputerName.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{ComputerName}'''");
                }
                else
                {
                    builder.AppendLine($" '{ComputerName}'");
                }
            }

            if (Optional.IsDefined(AdminUsername))
            {
                builder.Append("  adminUsername:");
                if (AdminUsername.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{AdminUsername}'''");
                }
                else
                {
                    builder.AppendLine($" '{AdminUsername}'");
                }
            }

            if (Optional.IsDefined(AdminPassword))
            {
                builder.Append("  adminPassword:");
                if (AdminPassword.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{AdminPassword}'''");
                }
                else
                {
                    builder.AppendLine($" '{AdminPassword}'");
                }
            }

            if (Optional.IsDefined(CustomData))
            {
                builder.Append("  customData:");
                if (CustomData.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{CustomData}'''");
                }
                else
                {
                    builder.AppendLine($" '{CustomData}'");
                }
            }

            if (Optional.IsDefined(WindowsConfiguration))
            {
                builder.Append("  windowsConfiguration:");
                AppendChildObject(builder, WindowsConfiguration, options, 2, false);
            }

            if (Optional.IsDefined(LinuxConfiguration))
            {
                builder.Append("  linuxConfiguration:");
                AppendChildObject(builder, LinuxConfiguration, options, 2, false);
            }

            if (!(Secrets is ChangeTrackingList<VaultSecretGroup> collection && collection.IsUndefined))
            {
                if (Secrets.Any())
                {
                    builder.Append("  secrets:");
                    builder.AppendLine(" [");
                    foreach (var item in Secrets)
                    {
                        AppendChildObject(builder, item, options, 4, true);
                    }
                    builder.AppendLine("  ]");
                }
            }

            if (Optional.IsDefined(AllowExtensionOperations))
            {
                builder.Append("  allowExtensionOperations:");
                var boolValue = AllowExtensionOperations.Value == true ? "true" : "false";
                builder.AppendLine($" {boolValue}");
            }

            if (Optional.IsDefined(RequireGuestProvisionSignal))
            {
                builder.Append("  requireGuestProvisionSignal:");
                var boolValue = RequireGuestProvisionSignal.Value == true ? "true" : "false";
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

        BinaryData IPersistableModel<OSProfile>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(OSProfile)} does not support '{options.Format}' format.");
            }
        }

        OSProfile IPersistableModel<OSProfile>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSProfile>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeOSProfile(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(OSProfile)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<OSProfile>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
