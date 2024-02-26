// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace MgmtLRO.Models
{
    internal partial class BarProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Buzz.HasValue)
            {
                writer.WritePropertyName("buzz"u8);
                writer.WriteStringValue(Buzz.Value);
            }
            writer.WriteEndObject();
        }

        internal static BarProperties DeserializeBarProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Guid buzz = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("buzz"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    buzz = property.Value.GetGuid();
                    continue;
                }
            }
            return new BarProperties(buzz);
        }
    }
}
