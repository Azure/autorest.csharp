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
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class WindowsConfiguration : IUtf8JsonSerializable, IJsonModel<WindowsConfiguration>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<WindowsConfiguration>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<WindowsConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<WindowsConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(WindowsConfiguration)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(ProvisionVmAgent))
            {
                writer.WritePropertyName("provisionVMAgent"u8);
                writer.WriteBooleanValue(ProvisionVmAgent.Value);
            }
            if (Optional.IsDefined(EnableAutomaticUpdates))
            {
                writer.WritePropertyName("enableAutomaticUpdates"u8);
                writer.WriteBooleanValue(EnableAutomaticUpdates.Value);
            }
            if (Optional.IsDefined(TimeZone))
            {
                writer.WritePropertyName("timeZone"u8);
                writer.WriteStringValue(TimeZone);
            }
            if (Optional.IsCollectionDefined(AdditionalUnattendContent))
            {
                writer.WritePropertyName("additionalUnattendContent"u8);
                writer.WriteStartArray();
                foreach (var item in AdditionalUnattendContent)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PatchSettings))
            {
                writer.WritePropertyName("patchSettings"u8);
                writer.WriteObjectValue(PatchSettings);
            }
            if (Optional.IsDefined(WinRM))
            {
                writer.WritePropertyName("winRM"u8);
                writer.WriteObjectValue(WinRM);
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

        WindowsConfiguration IJsonModel<WindowsConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<WindowsConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(WindowsConfiguration)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeWindowsConfiguration(document.RootElement, options);
        }

        internal static WindowsConfiguration DeserializeWindowsConfiguration(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool? provisionVmAgent = default;
            bool? enableAutomaticUpdates = default;
            string timeZone = default;
            IList<AdditionalUnattendContent> additionalUnattendContent = default;
            PatchSettings patchSettings = default;
            WinRMConfiguration winRM = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("provisionVMAgent"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    provisionVmAgent = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("enableAutomaticUpdates"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enableAutomaticUpdates = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("timeZone"u8))
                {
                    timeZone = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("additionalUnattendContent"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AdditionalUnattendContent> array = new List<AdditionalUnattendContent>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Models.AdditionalUnattendContent.DeserializeAdditionalUnattendContent(item, options));
                    }
                    additionalUnattendContent = array;
                    continue;
                }
                if (property.NameEquals("patchSettings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    patchSettings = PatchSettings.DeserializePatchSettings(property.Value, options);
                    continue;
                }
                if (property.NameEquals("winRM"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    winRM = WinRMConfiguration.DeserializeWinRMConfiguration(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new WindowsConfiguration(
                provisionVmAgent,
                enableAutomaticUpdates,
                timeZone,
                additionalUnattendContent ?? new ChangeTrackingList<AdditionalUnattendContent>(),
                patchSettings,
                winRM,
                serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");

            if (Optional.IsDefined(ProvisionVmAgent))
            {
                builder.Append("  provisionVMAgent:");
                var boolValue = ProvisionVmAgent.Value == true ? "true" : "false";
                builder.AppendLine($" {boolValue}");
            }

            if (Optional.IsDefined(EnableAutomaticUpdates))
            {
                builder.Append("  enableAutomaticUpdates:");
                var boolValue = EnableAutomaticUpdates.Value == true ? "true" : "false";
                builder.AppendLine($" {boolValue}");
            }

            if (Optional.IsDefined(TimeZone))
            {
                builder.Append("  timeZone:");
                if (TimeZone.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{TimeZone}'''");
                }
                else
                {
                    builder.AppendLine($" '{TimeZone}'");
                }
            }

            if (Optional.IsCollectionDefined(AdditionalUnattendContent))
            {
                if (AdditionalUnattendContent.Any())
                {
                    builder.Append("  additionalUnattendContent:");
                    builder.AppendLine(" [");
                    foreach (var item in AdditionalUnattendContent)
                    {
                        AppendChildObject(builder, item, options, 4, true);
                    }
                    builder.AppendLine("  ]");
                }
            }

            if (Optional.IsDefined(PatchSettings))
            {
                builder.Append("  patchSettings:");
                AppendChildObject(builder, PatchSettings, options, 2, false);
            }

            if (Optional.IsDefined(WinRM))
            {
                builder.Append("  winRM:");
                AppendChildObject(builder, WinRM, options, 2, false);
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

        BinaryData IPersistableModel<WindowsConfiguration>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<WindowsConfiguration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(WindowsConfiguration)} does not support '{options.Format}' format.");
            }
        }

        WindowsConfiguration IPersistableModel<WindowsConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<WindowsConfiguration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeWindowsConfiguration(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(WindowsConfiguration)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<WindowsConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
