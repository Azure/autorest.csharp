// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtPartialResource.Models
{
    public partial class ConfigurationProfileAssignmentProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ConfigurationProfile))
            {
                writer.WritePropertyName("configurationProfile"u8);
                writer.WriteStringValue(ConfigurationProfile);
            }
            if (Optional.IsDefined(TargetId))
            {
                writer.WritePropertyName("targetId"u8);
                writer.WriteStringValue(TargetId);
            }
            writer.WriteEndObject();
        }

        internal static ConfigurationProfileAssignmentProperties DeserializeConfigurationProfileAssignmentProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> configurationProfile = default;
            Optional<string> targetId = default;
            Optional<string> status = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("configurationProfile"u8))
                {
                    configurationProfile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetId"u8))
                {
                    targetId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString();
                    continue;
                }
            }
            return new ConfigurationProfileAssignmentProperties(configurationProfile.Value, targetId.Value, status.Value);
        }
    }
}
