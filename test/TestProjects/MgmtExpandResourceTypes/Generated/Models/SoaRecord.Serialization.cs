// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtExpandResourceTypes.Models
{
    public partial class SoaRecord : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Host != null)
            {
                writer.WritePropertyName("host"u8);
                writer.WriteStringValue(Host);
            }
            if (Email != null)
            {
                writer.WritePropertyName("email"u8);
                writer.WriteStringValue(Email);
            }
            if (SerialNumber.HasValue)
            {
                writer.WritePropertyName("serialNumber"u8);
                writer.WriteNumberValue(SerialNumber.Value);
            }
            if (RefreshTime.HasValue)
            {
                writer.WritePropertyName("refreshTime"u8);
                writer.WriteNumberValue(RefreshTime.Value);
            }
            if (RetryTime.HasValue)
            {
                writer.WritePropertyName("retryTime"u8);
                writer.WriteNumberValue(RetryTime.Value);
            }
            if (ExpireTime.HasValue)
            {
                writer.WritePropertyName("expireTime"u8);
                writer.WriteNumberValue(ExpireTime.Value);
            }
            if (MinimumTtl.HasValue)
            {
                writer.WritePropertyName("minimumTTL"u8);
                writer.WriteNumberValue(MinimumTtl.Value);
            }
            writer.WriteEndObject();
        }

        internal static SoaRecord DeserializeSoaRecord(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string host = default;
            string email = default;
            long serialNumber = default;
            long refreshTime = default;
            long retryTime = default;
            long expireTime = default;
            long minimumTTL = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("host"u8))
                {
                    host = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("email"u8))
                {
                    email = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("serialNumber"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    serialNumber = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("refreshTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    refreshTime = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("retryTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    retryTime = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("expireTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    expireTime = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("minimumTTL"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minimumTTL = property.Value.GetInt64();
                    continue;
                }
            }
            return new SoaRecord(
                host,
                email,
                serialNumber,
                refreshTime,
                retryTime,
                expireTime,
                minimumTTL);
        }
    }
}
