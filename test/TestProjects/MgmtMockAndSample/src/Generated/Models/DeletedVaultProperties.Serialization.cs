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

namespace MgmtMockAndSample.Models
{
    public partial class DeletedVaultProperties : IUtf8JsonSerializable, IJsonModel<DeletedVaultProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DeletedVaultProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DeletedVaultProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeletedVaultProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(DeletedVaultProperties)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W")
            {
                if (Optional.IsDefined(VaultId))
                {
                    writer.WritePropertyName("vaultId"u8);
                    writer.WriteStringValue(VaultId);
                }
            }
            if (options.Format != "W")
            {
                if (Optional.IsDefined(Location))
                {
                    writer.WritePropertyName("location"u8);
                    writer.WriteStringValue(Location.Value);
                }
            }
            if (options.Format != "W")
            {
                if (Optional.IsDefined(DeletedOn))
                {
                    writer.WritePropertyName("deletionDate"u8);
                    writer.WriteStringValue(DeletedOn.Value, "O");
                }
            }
            if (options.Format != "W")
            {
                if (Optional.IsDefined(ScheduledPurgeOn))
                {
                    writer.WritePropertyName("scheduledPurgeDate"u8);
                    writer.WriteStringValue(ScheduledPurgeOn.Value, "O");
                }
            }
            if (options.Format != "W")
            {
                if (Optional.IsCollectionDefined(Tags))
                {
                    writer.WritePropertyName("tags"u8);
                    writer.WriteStartObject();
                    foreach (var item in Tags)
                    {
                        writer.WritePropertyName(item.Key);
                        writer.WriteStringValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
            }
            if (options.Format != "W")
            {
                if (Optional.IsDefined(PurgeProtectionEnabled))
                {
                    writer.WritePropertyName("purgeProtectionEnabled"u8);
                    writer.WriteBooleanValue(PurgeProtectionEnabled.Value);
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

        DeletedVaultProperties IJsonModel<DeletedVaultProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeletedVaultProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(DeletedVaultProperties)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeletedVaultProperties(document.RootElement, options);
        }

        internal static DeletedVaultProperties DeserializeDeletedVaultProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> vaultId = default;
            Optional<AzureLocation> location = default;
            Optional<DateTimeOffset> deletionDate = default;
            Optional<DateTimeOffset> scheduledPurgeDate = default;
            Optional<IReadOnlyDictionary<string, string>> tags = default;
            Optional<bool> purgeProtectionEnabled = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vaultId"u8))
                {
                    vaultId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("deletionDate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    deletionDate = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("scheduledPurgeDate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    scheduledPurgeDate = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("purgeProtectionEnabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    purgeProtectionEnabled = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DeletedVaultProperties(vaultId.Value, Optional.ToNullable(location), Optional.ToNullable(deletionDate), Optional.ToNullable(scheduledPurgeDate), Optional.ToDictionary(tags), Optional.ToNullable(purgeProtectionEnabled), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DeletedVaultProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeletedVaultProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(DeletedVaultProperties)} does not support '{options.Format}' format.");
            }
        }

        DeletedVaultProperties IPersistableModel<DeletedVaultProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DeletedVaultProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDeletedVaultProperties(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(DeletedVaultProperties)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DeletedVaultProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
