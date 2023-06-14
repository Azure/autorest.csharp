// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtExpandResourceTypes.Models
{
    public partial class PtrRecord : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Ptrdname))
            {
                writer.WritePropertyName("ptrdname"u8);
                writer.WriteStringValue(Ptrdname);
            }
            writer.WriteEndObject();
        }

        internal static PtrRecord DeserializePtrRecord(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> ptrdname = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ptrdname"u8))
                {
                    ptrdname = property.Value.GetString();
                    continue;
                }
            }
            return new PtrRecord(ptrdname.Value);
        }
    }
}
