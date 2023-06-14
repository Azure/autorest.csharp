// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtOmitOperationGroups.Models
{
    public partial class ModelX : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(C))
            {
                writer.WritePropertyName("c"u8);
                writer.WriteStringValue(C);
            }
            if (Optional.IsDefined(D))
            {
                writer.WritePropertyName("d"u8);
                writer.WriteStringValue(D);
            }
            if (Optional.IsDefined(E))
            {
                writer.WritePropertyName("e"u8);
                writer.WriteStringValue(E);
            }
            writer.WriteEndObject();
        }

        internal static ModelX DeserializeModelX(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> c = default;
            Optional<string> d = default;
            Optional<string> e = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("c"u8))
                {
                    c = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("d"u8))
                {
                    d = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("e"u8))
                {
                    e = property.Value.GetString();
                    continue;
                }
            }
            return new ModelX(e.Value, c.Value, d.Value);
        }
    }
}
