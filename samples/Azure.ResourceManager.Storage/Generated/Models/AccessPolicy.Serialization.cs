// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class AccessPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(StartOn))
            {
                writer.WritePropertyName("startTime"u8);
                writer.WriteStringValue(StartOn.Value, "O");
            }
            if (Optional.IsDefined(ExpiryOn))
            {
                writer.WritePropertyName("expiryTime"u8);
                writer.WriteStringValue(ExpiryOn.Value, "O");
            }
            if (Optional.IsDefined(Permission))
            {
                writer.WritePropertyName("permission"u8);
                writer.WriteStringValue(Permission);
            }
            writer.WriteEndObject();
        }

        internal static AccessPolicy DeserializeAccessPolicy(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> expiryTime = default;
            Optional<string> permission = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("startTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("expiryTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    expiryTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("permission"u8))
                {
                    permission = property.Value.GetString();
                    continue;
                }
            }
            return new AccessPolicy(Optional.ToNullable(startTime), Optional.ToNullable(expiryTime), permission.Value);
        }
    }
}
