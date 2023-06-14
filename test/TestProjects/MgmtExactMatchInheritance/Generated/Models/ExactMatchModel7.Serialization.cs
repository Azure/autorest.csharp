// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtExactMatchInheritance.Models
{
    public partial class ExactMatchModel7 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ID))
            {
                writer.WritePropertyName("iD"u8);
                writer.WriteStringValue(ID);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(ExactMatchModel7Type))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ExactMatchModel7Type);
            }
            writer.WriteEndObject();
        }

        internal static ExactMatchModel7 DeserializeExactMatchModel7(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> id = default;
            Optional<string> name = default;
            Optional<string> type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("iD"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
            }
            return new ExactMatchModel7(id.Value, name.Value, type.Value);
        }
    }
}
