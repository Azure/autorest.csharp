// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    public partial class TerminateNotificationProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(NotBeforeTimeout))
            {
                writer.WritePropertyName("notBeforeTimeout"u8);
                writer.WriteStringValue(NotBeforeTimeout);
            }
            if (Optional.IsDefined(Enable))
            {
                writer.WritePropertyName("enable"u8);
                writer.WriteBooleanValue(Enable.Value);
            }
            writer.WriteEndObject();
        }

        internal static TerminateNotificationProfile DeserializeTerminateNotificationProfile(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> notBeforeTimeout = default;
            Optional<bool> enable = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("notBeforeTimeout"u8))
                {
                    notBeforeTimeout = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("enable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enable = property.Value.GetBoolean();
                    continue;
                }
            }
            return new TerminateNotificationProfile(notBeforeTimeout.Value, Optional.ToNullable(enable));
        }
    }
}
