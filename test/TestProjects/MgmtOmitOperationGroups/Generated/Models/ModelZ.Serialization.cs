// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtOmitOperationGroups.Models
{
    public partial class ModelZ : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(H))
            {
                writer.WritePropertyName("h"u8);
                writer.WriteStringValue(H);
            }
            writer.WriteEndObject();
        }

        internal static ModelZ DeserializeModelZ(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> h = default;
            Optional<string> i = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("h"u8))
                {
                    h = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("i"u8))
                {
                    i = property.Value.GetString();
                    continue;
                }
            }
            return new ModelZ(h.Value, i.Value);
        }
    }
}
