// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class KeyPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("keyExpirationPeriodInDays"u8);
            writer.WriteNumberValue(KeyExpirationPeriodInDays);
            writer.WriteEndObject();
        }

        internal static KeyPolicy DeserializeKeyPolicy(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int keyExpirationPeriodInDays = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keyExpirationPeriodInDays"u8))
                {
                    keyExpirationPeriodInDays = property.Value.GetInt32();
                    continue;
                }
            }
            return new KeyPolicy(keyExpirationPeriodInDays);
        }
    }
}
