// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class AdditionalUnattendContent : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(PassName))
            {
                writer.WritePropertyName("passName");
                writer.WriteStringValue(PassName.Value.ToString());
            }
            if (Optional.IsDefined(ComponentName))
            {
                writer.WritePropertyName("componentName");
                writer.WriteStringValue(ComponentName.Value.ToString());
            }
            if (Optional.IsDefined(SettingName))
            {
                writer.WritePropertyName("settingName");
                writer.WriteStringValue(SettingName.Value.ToSerialString());
            }
            if (Optional.IsDefined(Content))
            {
                writer.WritePropertyName("content");
                writer.WriteStringValue(Content);
            }
            writer.WriteEndObject();
        }

        internal static AdditionalUnattendContent DeserializeAdditionalUnattendContent(JsonElement element)
        {
            Optional<PassNames> passName = default;
            Optional<ComponentNames> componentName = default;
            Optional<SettingNames> settingName = default;
            Optional<string> content = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("passName"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    passName = new PassNames(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("componentName"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    componentName = new ComponentNames(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("settingName"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    settingName = property.Value.GetString().ToSettingNames();
                    continue;
                }
                if (property.NameEquals("content"))
                {
                    content = property.Value.GetString();
                    continue;
                }
            }
            return new AdditionalUnattendContent(Optional.ToNullable(passName), Optional.ToNullable(componentName), Optional.ToNullable(settingName), content.Value);
        }
    }
}
