// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    public partial class AdditionalUnattendContent : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(PassName))
            {
                writer.WritePropertyName("passName"u8);
                writer.WriteStringValue(PassName.Value.ToString());
            }
            if (Optional.IsDefined(ComponentName))
            {
                writer.WritePropertyName("componentName"u8);
                writer.WriteStringValue(ComponentName.Value.ToString());
            }
            if (Optional.IsDefined(SettingName))
            {
                writer.WritePropertyName("settingName"u8);
                writer.WriteStringValue(SettingName.Value.ToSerialString());
            }
            if (Optional.IsDefined(BackupFrequency))
            {
                writer.WritePropertyName("backupFrequency"u8);
                writer.WriteNumberValue(BackupFrequency.Value);
            }
            writer.WriteEndObject();
        }

        internal static AdditionalUnattendContent DeserializeAdditionalUnattendContent(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<PassName> passName = default;
            Optional<ComponentName> componentName = default;
            Optional<SettingName> settingName = default;
            Optional<int> backupFrequency = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("passName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    passName = new PassName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("componentName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    componentName = new ComponentName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("settingName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    settingName = property.Value.GetString().ToSettingName();
                    continue;
                }
                if (property.NameEquals("backupFrequency"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    backupFrequency = property.Value.GetInt32();
                    continue;
                }
            }
            return new AdditionalUnattendContent(Optional.ToNullable(passName), Optional.ToNullable(componentName), Optional.ToNullable(settingName), Optional.ToNullable(backupFrequency));
        }
    }
}
