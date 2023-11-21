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
using Azure.ResourceManager.Models;

namespace MgmtMockAndSample
{
    public partial class RoleAssignmentData : IUtf8JsonSerializable, IJsonModel<RoleAssignmentData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RoleAssignmentData>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<RoleAssignmentData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoleAssignmentData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(RoleAssignmentData)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format == "J")
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == "J")
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            if (options.Format == "J")
            {
                if (Optional.IsDefined(SystemData))
                {
                    writer.WritePropertyName("systemData"u8);
                    JsonSerializer.Serialize(writer, SystemData);
                }
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(Scope))
            {
                writer.WritePropertyName("scope"u8);
                writer.WriteStringValue(Scope);
            }
            if (Optional.IsDefined(RoleDefinitionId))
            {
                writer.WritePropertyName("roleDefinitionId"u8);
                writer.WriteStringValue(RoleDefinitionId);
            }
            if (Optional.IsDefined(PrincipalId))
            {
                writer.WritePropertyName("principalId"u8);
                writer.WriteStringValue(PrincipalId);
            }
            if (Optional.IsDefined(CanDelegate))
            {
                writer.WritePropertyName("canDelegate"u8);
                writer.WriteBooleanValue(CanDelegate.Value);
            }
            writer.WriteEndObject();
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

        RoleAssignmentData IJsonModel<RoleAssignmentData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoleAssignmentData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(RoleAssignmentData)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRoleAssignmentData(document.RootElement, options);
        }

        internal static RoleAssignmentData DeserializeRoleAssignmentData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<string> scope = default;
            Optional<string> roleDefinitionId = default;
            Optional<string> principalId = default;
            Optional<bool> canDelegate = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("scope"u8))
                        {
                            scope = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("roleDefinitionId"u8))
                        {
                            roleDefinitionId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("principalId"u8))
                        {
                            principalId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("canDelegate"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            canDelegate = property0.Value.GetBoolean();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RoleAssignmentData(id, name, type, systemData.Value, scope.Value, roleDefinitionId.Value, principalId.Value, Optional.ToNullable(canDelegate), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RoleAssignmentData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoleAssignmentData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(RoleAssignmentData)} does not support '{options.Format}' format.");
            }
        }

        RoleAssignmentData IPersistableModel<RoleAssignmentData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoleAssignmentData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRoleAssignmentData(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(RoleAssignmentData)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RoleAssignmentData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
