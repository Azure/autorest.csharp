// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class ManagedHsmSku : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("family"u8);
            writer.WriteStringValue(Family.ToString());
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToSerialString());
            writer.WriteEndObject();
        }

        internal static ManagedHsmSku DeserializeManagedHsmSku(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ManagedHsmSkuFamily family = default;
            ManagedHsmSkuName name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("family"u8))
                {
                    family = new ManagedHsmSkuFamily(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString().ToManagedHsmSkuName();
                    continue;
                }
            }
            return new ManagedHsmSku(family, name);
        }
    }
}
