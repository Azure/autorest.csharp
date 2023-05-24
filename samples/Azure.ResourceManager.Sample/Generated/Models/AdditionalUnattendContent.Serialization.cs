// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class AdditionalUnattendContent : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
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
            if (Optional.IsDefined(Content))
            {
                writer.WritePropertyName("content"u8);
                writer.WriteStringValue(Content);
            }
            writer.WriteEndObject();
        }

        internal static AdditionalUnattendContent DeserializeAdditionalUnattendContent(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<PassName> passName = default;
            Optional<ComponentName> componentName = default;
            Optional<SettingName> settingName = default;
            Optional<string> content = default;
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
                if (property.NameEquals("content"u8))
                {
                    content = property.Value.GetString();
                    continue;
                }
            }
            return new AdditionalUnattendContent(Optional.ToNullable(passName), Optional.ToNullable(componentName), Optional.ToNullable(settingName), content.Value);
        }
    }
}
