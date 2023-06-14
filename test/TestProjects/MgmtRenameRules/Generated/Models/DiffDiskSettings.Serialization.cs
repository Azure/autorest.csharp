// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    public partial class DiffDiskSettings : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Option))
            {
                writer.WritePropertyName("option"u8);
                writer.WriteStringValue(Option.Value.ToString());
            }
            if (Optional.IsDefined(Placement))
            {
                writer.WritePropertyName("placement"u8);
                writer.WriteStringValue(Placement.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static DiffDiskSettings DeserializeDiffDiskSettings(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DiffDiskOption> option = default;
            Optional<DiffDiskPlacement> placement = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("option"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    option = new DiffDiskOption(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("placement"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    placement = new DiffDiskPlacement(property.Value.GetString());
                    continue;
                }
            }
            return new DiffDiskSettings(Optional.ToNullable(option), Optional.ToNullable(placement));
        }
    }
}
