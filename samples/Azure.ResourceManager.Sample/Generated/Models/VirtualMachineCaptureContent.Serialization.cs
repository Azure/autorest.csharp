// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineCaptureContent : IUtf8JsonWriteable, IJsonModel<VirtualMachineCaptureContent>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineCaptureContent>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineCaptureContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineCaptureContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachineCaptureContent)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("vhdPrefix"u8);
            writer.WriteStringValue(VhdPrefix);
            writer.WritePropertyName("destinationContainerName"u8);
            writer.WriteStringValue(DestinationContainerName);
            writer.WritePropertyName("overwriteVhds"u8);
            writer.WriteBooleanValue(OverwriteVhds);
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

        VirtualMachineCaptureContent IJsonModel<VirtualMachineCaptureContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineCaptureContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachineCaptureContent)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineCaptureContent(document.RootElement, options);
        }

        internal static VirtualMachineCaptureContent DeserializeVirtualMachineCaptureContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string vhdPrefix = default;
            string destinationContainerName = default;
            bool overwriteVhds = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vhdPrefix"u8))
                {
                    vhdPrefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destinationContainerName"u8))
                {
                    destinationContainerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("overwriteVhds"u8))
                {
                    overwriteVhds = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineCaptureContent(vhdPrefix, destinationContainerName, overwriteVhds, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VirtualMachineCaptureContent>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineCaptureContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachineCaptureContent)} does not support '{options.Format}' format.");
            }
        }

        VirtualMachineCaptureContent IPersistableModel<VirtualMachineCaptureContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineCaptureContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineCaptureContent(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachineCaptureContent)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineCaptureContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
