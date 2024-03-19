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
using AzureSample.ResourceManager.Sample;

namespace AzureSample.ResourceManager.Sample.Models
{
    public partial class MaintenanceRedeployStatus : IUtf8JsonSerializable, IJsonModel<MaintenanceRedeployStatus>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MaintenanceRedeployStatus>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<MaintenanceRedeployStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MaintenanceRedeployStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MaintenanceRedeployStatus)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(IsCustomerInitiatedMaintenanceAllowed))
            {
                writer.WritePropertyName("isCustomerInitiatedMaintenanceAllowed"u8);
                writer.WriteBooleanValue(IsCustomerInitiatedMaintenanceAllowed.Value);
            }
            if (Optional.IsDefined(PreMaintenanceWindowStartOn))
            {
                writer.WritePropertyName("preMaintenanceWindowStartTime"u8);
                writer.WriteStringValue(PreMaintenanceWindowStartOn.Value, "O");
            }
            if (Optional.IsDefined(PreMaintenanceWindowEndOn))
            {
                writer.WritePropertyName("preMaintenanceWindowEndTime"u8);
                writer.WriteStringValue(PreMaintenanceWindowEndOn.Value, "O");
            }
            if (Optional.IsDefined(MaintenanceWindowStartOn))
            {
                writer.WritePropertyName("maintenanceWindowStartTime"u8);
                writer.WriteStringValue(MaintenanceWindowStartOn.Value, "O");
            }
            if (Optional.IsDefined(MaintenanceWindowEndOn))
            {
                writer.WritePropertyName("maintenanceWindowEndTime"u8);
                writer.WriteStringValue(MaintenanceWindowEndOn.Value, "O");
            }
            if (Optional.IsDefined(LastOperationResultCode))
            {
                writer.WritePropertyName("lastOperationResultCode"u8);
                writer.WriteStringValue(LastOperationResultCode.Value.ToSerialString());
            }
            if (Optional.IsDefined(LastOperationMessage))
            {
                writer.WritePropertyName("lastOperationMessage"u8);
                writer.WriteStringValue(LastOperationMessage);
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

        MaintenanceRedeployStatus IJsonModel<MaintenanceRedeployStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MaintenanceRedeployStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MaintenanceRedeployStatus)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMaintenanceRedeployStatus(document.RootElement, options);
        }

        internal static MaintenanceRedeployStatus DeserializeMaintenanceRedeployStatus(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool? isCustomerInitiatedMaintenanceAllowed = default;
            DateTimeOffset? preMaintenanceWindowStartTime = default;
            DateTimeOffset? preMaintenanceWindowEndTime = default;
            DateTimeOffset? maintenanceWindowStartTime = default;
            DateTimeOffset? maintenanceWindowEndTime = default;
            MaintenanceOperationResultCodeType? lastOperationResultCode = default;
            string lastOperationMessage = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("isCustomerInitiatedMaintenanceAllowed"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isCustomerInitiatedMaintenanceAllowed = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("preMaintenanceWindowStartTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    preMaintenanceWindowStartTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("preMaintenanceWindowEndTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    preMaintenanceWindowEndTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("maintenanceWindowStartTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maintenanceWindowStartTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("maintenanceWindowEndTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maintenanceWindowEndTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastOperationResultCode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastOperationResultCode = property.Value.GetString().ToMaintenanceOperationResultCodeType();
                    continue;
                }
                if (property.NameEquals("lastOperationMessage"u8))
                {
                    lastOperationMessage = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new MaintenanceRedeployStatus(
                isCustomerInitiatedMaintenanceAllowed,
                preMaintenanceWindowStartTime,
                preMaintenanceWindowEndTime,
                maintenanceWindowStartTime,
                maintenanceWindowEndTime,
                lastOperationResultCode,
                lastOperationMessage,
                serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(IsCustomerInitiatedMaintenanceAllowed), out propertyOverride);
            if (Optional.IsDefined(IsCustomerInitiatedMaintenanceAllowed) || hasPropertyOverride)
            {
                builder.Append("  isCustomerInitiatedMaintenanceAllowed: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var boolValue = IsCustomerInitiatedMaintenanceAllowed.Value == true ? "true" : "false";
                    builder.AppendLine($"{boolValue}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PreMaintenanceWindowStartOn), out propertyOverride);
            if (Optional.IsDefined(PreMaintenanceWindowStartOn) || hasPropertyOverride)
            {
                builder.Append("  preMaintenanceWindowStartTime: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var formattedDateTimeString = TypeFormatters.ToString(PreMaintenanceWindowStartOn.Value, "o");
                    builder.AppendLine($"'{formattedDateTimeString}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PreMaintenanceWindowEndOn), out propertyOverride);
            if (Optional.IsDefined(PreMaintenanceWindowEndOn) || hasPropertyOverride)
            {
                builder.Append("  preMaintenanceWindowEndTime: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var formattedDateTimeString = TypeFormatters.ToString(PreMaintenanceWindowEndOn.Value, "o");
                    builder.AppendLine($"'{formattedDateTimeString}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(MaintenanceWindowStartOn), out propertyOverride);
            if (Optional.IsDefined(MaintenanceWindowStartOn) || hasPropertyOverride)
            {
                builder.Append("  maintenanceWindowStartTime: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var formattedDateTimeString = TypeFormatters.ToString(MaintenanceWindowStartOn.Value, "o");
                    builder.AppendLine($"'{formattedDateTimeString}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(MaintenanceWindowEndOn), out propertyOverride);
            if (Optional.IsDefined(MaintenanceWindowEndOn) || hasPropertyOverride)
            {
                builder.Append("  maintenanceWindowEndTime: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var formattedDateTimeString = TypeFormatters.ToString(MaintenanceWindowEndOn.Value, "o");
                    builder.AppendLine($"'{formattedDateTimeString}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(LastOperationResultCode), out propertyOverride);
            if (Optional.IsDefined(LastOperationResultCode) || hasPropertyOverride)
            {
                builder.Append("  lastOperationResultCode: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    builder.AppendLine($"'{LastOperationResultCode.Value.ToSerialString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(LastOperationMessage), out propertyOverride);
            if (Optional.IsDefined(LastOperationMessage) || hasPropertyOverride)
            {
                builder.Append("  lastOperationMessage: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (LastOperationMessage.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{LastOperationMessage}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{LastOperationMessage}'");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<MaintenanceRedeployStatus>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MaintenanceRedeployStatus>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(MaintenanceRedeployStatus)} does not support '{options.Format}' format.");
            }
        }

        MaintenanceRedeployStatus IPersistableModel<MaintenanceRedeployStatus>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MaintenanceRedeployStatus>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeMaintenanceRedeployStatus(document.RootElement, options);
                    }
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(MaintenanceRedeployStatus)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<MaintenanceRedeployStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
