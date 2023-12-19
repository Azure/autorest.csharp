// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineAssessPatchesResult : IUtf8JsonWriteable, IJsonModel<VirtualMachineAssessPatchesResult>
    {
        void IUtf8JsonWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineAssessPatchesResult>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineAssessPatchesResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineAssessPatchesResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachineAssessPatchesResult)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W" && OptionalProperty.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (options.Format != "W" && OptionalProperty.IsDefined(AssessmentActivityId))
            {
                writer.WritePropertyName("assessmentActivityId"u8);
                writer.WriteStringValue(AssessmentActivityId);
            }
            if (options.Format != "W" && OptionalProperty.IsDefined(RebootPending))
            {
                writer.WritePropertyName("rebootPending"u8);
                writer.WriteBooleanValue(RebootPending.Value);
            }
            if (options.Format != "W" && OptionalProperty.IsDefined(CriticalAndSecurityPatchCount))
            {
                writer.WritePropertyName("criticalAndSecurityPatchCount"u8);
                writer.WriteNumberValue(CriticalAndSecurityPatchCount.Value);
            }
            if (options.Format != "W" && OptionalProperty.IsDefined(OtherPatchCount))
            {
                writer.WritePropertyName("otherPatchCount"u8);
                writer.WriteNumberValue(OtherPatchCount.Value);
            }
            if (options.Format != "W" && OptionalProperty.IsDefined(StartOn))
            {
                writer.WritePropertyName("startDateTime"u8);
                writer.WriteStringValue(StartOn.Value, "O");
            }
            if (options.Format != "W" && OptionalProperty.IsCollectionDefined(Patches))
            {
                writer.WritePropertyName("patches"u8);
                writer.WriteStartArray();
                foreach (var item in Patches)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && OptionalProperty.IsDefined(Error))
            {
                writer.WritePropertyName("error"u8);
                writer.WriteObjectValue(Error);
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

        VirtualMachineAssessPatchesResult IJsonModel<VirtualMachineAssessPatchesResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineAssessPatchesResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachineAssessPatchesResult)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineAssessPatchesResult(document.RootElement, options);
        }

        internal static VirtualMachineAssessPatchesResult DeserializeVirtualMachineAssessPatchesResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            OptionalProperty<PatchOperationStatus> status = default;
            OptionalProperty<string> assessmentActivityId = default;
            OptionalProperty<bool> rebootPending = default;
            OptionalProperty<int> criticalAndSecurityPatchCount = default;
            OptionalProperty<int> otherPatchCount = default;
            OptionalProperty<DateTimeOffset> startDateTime = default;
            OptionalProperty<IReadOnlyList<VirtualMachineSoftwarePatchProperties>> patches = default;
            OptionalProperty<ApiError> error = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new PatchOperationStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("assessmentActivityId"u8))
                {
                    assessmentActivityId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("rebootPending"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rebootPending = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("criticalAndSecurityPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    criticalAndSecurityPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("otherPatchCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    otherPatchCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("startDateTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("patches"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineSoftwarePatchProperties> array = new List<VirtualMachineSoftwarePatchProperties>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VirtualMachineSoftwarePatchProperties.DeserializeVirtualMachineSoftwarePatchProperties(item));
                    }
                    patches = array;
                    continue;
                }
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    error = ApiError.DeserializeApiError(property.Value);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineAssessPatchesResult(OptionalProperty.ToNullable(status), assessmentActivityId.Value, OptionalProperty.ToNullable(rebootPending), OptionalProperty.ToNullable(criticalAndSecurityPatchCount), OptionalProperty.ToNullable(otherPatchCount), OptionalProperty.ToNullable(startDateTime), OptionalProperty.ToList(patches), error.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VirtualMachineAssessPatchesResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineAssessPatchesResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachineAssessPatchesResult)} does not support '{options.Format}' format.");
            }
        }

        VirtualMachineAssessPatchesResult IPersistableModel<VirtualMachineAssessPatchesResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineAssessPatchesResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineAssessPatchesResult(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachineAssessPatchesResult)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineAssessPatchesResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
