// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    public partial class VirtualMachineSoftwarePatchProperties : IUtf8JsonSerializable, IJsonModel<VirtualMachineSoftwarePatchProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineSoftwarePatchProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineSoftwarePatchProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineSoftwarePatchProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachineSoftwarePatchProperties)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                if (Optional.IsDefined(PatchId))
                {
                    writer.WritePropertyName("patchId"u8);
                    writer.WriteStringValue(PatchId);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Name))
                {
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(Name);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Version))
                {
                    writer.WritePropertyName("version"u8);
                    writer.WriteStringValue(Version);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Kbid))
                {
                    writer.WritePropertyName("kbid"u8);
                    writer.WriteStringValue(Kbid);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsCollectionDefined(Classifications))
                {
                    writer.WritePropertyName("classifications"u8);
                    writer.WriteStartArray();
                    foreach (var item in Classifications)
                    {
                        writer.WriteStringValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(RebootBehavior))
                {
                    writer.WritePropertyName("rebootBehavior"u8);
                    writer.WriteStringValue(RebootBehavior.Value.ToString());
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(ActivityId))
                {
                    writer.WritePropertyName("activityId"u8);
                    writer.WriteStringValue(ActivityId);
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(PublishedOn))
                {
                    writer.WritePropertyName("publishedDate"u8);
                    writer.WriteStringValue(PublishedOn.Value, "O");
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(LastModifiedOn))
                {
                    writer.WritePropertyName("lastModifiedDateTime"u8);
                    writer.WriteStringValue(LastModifiedOn.Value, "O");
                }
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(AssessmentState))
                {
                    writer.WritePropertyName("assessmentState"u8);
                    writer.WriteStringValue(AssessmentState.Value.ToString());
                }
            }
            if (_serializedAdditionalRawData != null && options.Format != "W")
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

        VirtualMachineSoftwarePatchProperties IJsonModel<VirtualMachineSoftwarePatchProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineSoftwarePatchProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(VirtualMachineSoftwarePatchProperties)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVirtualMachineSoftwarePatchProperties(document.RootElement, options);
        }

        internal static VirtualMachineSoftwarePatchProperties DeserializeVirtualMachineSoftwarePatchProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> patchId = default;
            Optional<string> name = default;
            Optional<string> version = default;
            Optional<string> kbid = default;
            Optional<IReadOnlyList<string>> classifications = default;
            Optional<SoftwareUpdateRebootBehavior> rebootBehavior = default;
            Optional<string> activityId = default;
            Optional<DateTimeOffset> publishedDate = default;
            Optional<DateTimeOffset> lastModifiedDateTime = default;
            Optional<PatchAssessmentState> assessmentState = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("patchId"u8))
                {
                    patchId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("version"u8))
                {
                    version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("kbid"u8))
                {
                    kbid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("classifications"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    classifications = array;
                    continue;
                }
                if (property.NameEquals("rebootBehavior"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rebootBehavior = new SoftwareUpdateRebootBehavior(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("activityId"u8))
                {
                    activityId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("publishedDate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    publishedDate = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastModifiedDateTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastModifiedDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("assessmentState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    assessmentState = new PatchAssessmentState(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new VirtualMachineSoftwarePatchProperties(patchId.Value, name.Value, version.Value, kbid.Value, Optional.ToList(classifications), Optional.ToNullable(rebootBehavior), activityId.Value, Optional.ToNullable(publishedDate), Optional.ToNullable(lastModifiedDateTime), Optional.ToNullable(assessmentState), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<VirtualMachineSoftwarePatchProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineSoftwarePatchProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachineSoftwarePatchProperties)} does not support '{options.Format}' format.");
            }
        }

        VirtualMachineSoftwarePatchProperties IPersistableModel<VirtualMachineSoftwarePatchProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineSoftwarePatchProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeVirtualMachineSoftwarePatchProperties(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(VirtualMachineSoftwarePatchProperties)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineSoftwarePatchProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
