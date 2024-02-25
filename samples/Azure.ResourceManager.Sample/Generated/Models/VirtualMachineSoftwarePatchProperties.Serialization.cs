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
    public partial class VirtualMachineSoftwarePatchProperties : IUtf8JsonSerializable, IJsonModel<VirtualMachineSoftwarePatchProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<VirtualMachineSoftwarePatchProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<VirtualMachineSoftwarePatchProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineSoftwarePatchProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineSoftwarePatchProperties)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W" && PatchId != null)
            {
                writer.WritePropertyName("patchId"u8);
                writer.WriteStringValue(PatchId);
            }
            if (options.Format != "W" && Name != null)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format != "W" && Version != null)
            {
                writer.WritePropertyName("version"u8);
                writer.WriteStringValue(Version);
            }
            if (options.Format != "W" && Kbid != null)
            {
                writer.WritePropertyName("kbid"u8);
                writer.WriteStringValue(Kbid);
            }
            if (options.Format != "W" && !(Classifications is ChangeTrackingList<string> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("classifications"u8);
                writer.WriteStartArray();
                foreach (var item in Classifications)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && RebootBehavior.HasValue)
            {
                writer.WritePropertyName("rebootBehavior"u8);
                writer.WriteStringValue(RebootBehavior.Value.ToString());
            }
            if (options.Format != "W" && ActivityId != null)
            {
                writer.WritePropertyName("activityId"u8);
                writer.WriteStringValue(ActivityId);
            }
            if (options.Format != "W" && PublishedOn.HasValue)
            {
                writer.WritePropertyName("publishedDate"u8);
                writer.WriteStringValue(PublishedOn.Value, "O");
            }
            if (options.Format != "W" && LastModifiedOn.HasValue)
            {
                writer.WritePropertyName("lastModifiedDateTime"u8);
                writer.WriteStringValue(LastModifiedOn.Value, "O");
            }
            if (options.Format != "W" && AssessmentState.HasValue)
            {
                writer.WritePropertyName("assessmentState"u8);
                writer.WriteStringValue(AssessmentState.Value.ToString());
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

        VirtualMachineSoftwarePatchProperties IJsonModel<VirtualMachineSoftwarePatchProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineSoftwarePatchProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineSoftwarePatchProperties)} does not support '{format}' format.");
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
            IReadOnlyList<string> classifications = default;
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
            return new VirtualMachineSoftwarePatchProperties(patchId.Value, name.Value, version.Value, kbid.Value, classifications ?? new ChangeTrackingList<string>(), Optional.ToNullable(rebootBehavior), activityId.Value, Optional.ToNullable(publishedDate), Optional.ToNullable(lastModifiedDateTime), Optional.ToNullable(assessmentState), serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");

            if (Name != null)
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

            if (PatchId != null)
            {
                builder.Append("  patchId:");
                if (PatchId.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{PatchId}'''");
                }
                else
                {
                    builder.AppendLine($" '{PatchId}'");
                }
            }

            if (Version != null)
            {
                builder.Append("  version:");
                if (Version.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{Version}'''");
                }
                else
                {
                    builder.AppendLine($" '{Version}'");
                }
            }

            if (Kbid != null)
            {
                builder.Append("  kbid:");
                if (Kbid.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{Kbid}'''");
                }
                else
                {
                    builder.AppendLine($" '{Kbid}'");
                }
            }

            if (!(Classifications is ChangeTrackingList<string> collection && collection.IsUndefined))
            {
                if (Classifications.Any())
                {
                    builder.Append("  classifications:");
                    builder.AppendLine(" [");
                    foreach (var item in Classifications)
                    {
                        if (item == null)
                        {
                            builder.Append("null");
                            continue;
                        }
                        if (item.Contains(Environment.NewLine))
                        {
                            builder.AppendLine("    '''");
                            builder.AppendLine($"{item}'''");
                        }
                        else
                        {
                            builder.AppendLine($"    '{item}'");
                        }
                    }
                    builder.AppendLine("  ]");
                }
            }

            if (RebootBehavior.HasValue)
            {
                builder.Append("  rebootBehavior:");
                builder.AppendLine($" '{RebootBehavior.Value.ToString()}'");
            }

            if (ActivityId != null)
            {
                builder.Append("  activityId:");
                if (ActivityId.Contains(Environment.NewLine))
                {
                    builder.AppendLine(" '''");
                    builder.AppendLine($"{ActivityId}'''");
                }
                else
                {
                    builder.AppendLine($" '{ActivityId}'");
                }
            }

            if (PublishedOn.HasValue)
            {
                builder.Append("  publishedDate:");
                var formattedDateTimeString = TypeFormatters.ToString(PublishedOn.Value, "o");
                builder.AppendLine($" '{formattedDateTimeString}'");
            }

            if (LastModifiedOn.HasValue)
            {
                builder.Append("  lastModifiedDateTime:");
                var formattedDateTimeString = TypeFormatters.ToString(LastModifiedOn.Value, "o");
                builder.AppendLine($" '{formattedDateTimeString}'");
            }

            if (AssessmentState.HasValue)
            {
                builder.Append("  assessmentState:");
                builder.AppendLine($" '{AssessmentState.Value.ToString()}'");
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

        BinaryData IPersistableModel<VirtualMachineSoftwarePatchProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<VirtualMachineSoftwarePatchProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineSoftwarePatchProperties)} does not support '{options.Format}' format.");
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
                case "bicep":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(VirtualMachineSoftwarePatchProperties)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<VirtualMachineSoftwarePatchProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
