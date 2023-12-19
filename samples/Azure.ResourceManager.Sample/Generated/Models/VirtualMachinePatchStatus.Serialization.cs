// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachinePatchStatus : IUtf8JsonWriteable, IJsonModel<VirtualMachinePatchStatus>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachinePatchStatus>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachinePatchStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachinePatchStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachinePatchStatus)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (OptionalProperty.IsDefined(AvailablePatchSummary))
            {
                writer.WritePropertyName("availablePatchSummary"u8);
                writer.WriteObjectValue(AvailablePatchSummary);
            }
            if (OptionalProperty.IsDefined(LastPatchInstallationSummary))
            {
                writer.WritePropertyName("lastPatchInstallationSummary"u8);
                writer.WriteObjectValue(LastPatchInstallationSummary);
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

        VirtualMachinePatchStatus IJsonModel<VirtualMachinePatchStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachinePatchStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachinePatchStatus)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachinePatchStatus(document.RootElement, options);
        }

        internal static VirtualMachinePatchStatus DeserializeVirtualMachinePatchStatus(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            OptionalProperty<AvailablePatchSummary> availablePatchSummary = default;
            OptionalProperty<LastPatchInstallationSummary> lastPatchInstallationSummary = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("availablePatchSummary"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    availablePatchSummary = AvailablePatchSummary.DeserializeAvailablePatchSummary(property.Value);
                    continue;
                }
                if (property.NameEquals("lastPatchInstallationSummary"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastPatchInstallationSummary = LastPatchInstallationSummary.DeserializeLastPatchInstallationSummary(property.Value);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachinePatchStatus(availablePatchSummary.Value, lastPatchInstallationSummary.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VirtualMachinePatchStatus>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachinePatchStatus>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachinePatchStatus)} does not support '{options.Format}' format.");
            }
        }

        VirtualMachinePatchStatus IPersistableModel<VirtualMachinePatchStatus>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachinePatchStatus>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachinePatchStatus(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachinePatchStatus)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachinePatchStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
