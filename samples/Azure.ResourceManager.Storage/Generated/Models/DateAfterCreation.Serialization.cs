// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    internal partial class DateAfterCreation : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("daysAfterCreationGreaterThan"u8);
            writer.WriteNumberValue(DaysAfterCreationGreaterThan);
            writer.WriteEndObject();
        }

        internal static DateAfterCreation DeserializeDateAfterCreation(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            float daysAfterCreationGreaterThan = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("daysAfterCreationGreaterThan"u8))
                {
                    daysAfterCreationGreaterThan = property.Value.GetSingle();
                    continue;
                }
            }
            return new DateAfterCreation(daysAfterCreationGreaterThan);
        }
    }
}
