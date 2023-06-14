// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    public partial class CacheExpirationActionParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("cacheBehavior"u8);
            writer.WriteStringValue(CacheBehavior.ToString());
            writer.WritePropertyName("cacheType"u8);
            writer.WriteStringValue(CacheType.ToString());
            if (Optional.IsDefined(CacheDuration))
            {
                if (CacheDuration != null)
                {
                    writer.WritePropertyName("cacheDuration"u8);
                    writer.WriteStringValue(CacheDuration.Value, "c");
                }
                else
                {
                    writer.WriteNull("cacheDuration");
                }
            }
            writer.WriteEndObject();
        }

        internal static CacheExpirationActionParameters DeserializeCacheExpirationActionParameters(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            CacheExpirationActionParametersTypeName typeName = default;
            CacheBehavior cacheBehavior = default;
            CacheType cacheType = default;
            Optional<TimeSpan?> cacheDuration = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new CacheExpirationActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("cacheBehavior"u8))
                {
                    cacheBehavior = new CacheBehavior(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("cacheType"u8))
                {
                    cacheType = new CacheType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("cacheDuration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        cacheDuration = null;
                        continue;
                    }
                    cacheDuration = property.Value.GetTimeSpan("c");
                    continue;
                }
            }
            return new CacheExpirationActionParameters(typeName, cacheBehavior, cacheType, Optional.ToNullable(cacheDuration));
        }
    }
}
