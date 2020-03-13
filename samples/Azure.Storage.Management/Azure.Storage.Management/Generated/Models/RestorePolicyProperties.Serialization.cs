// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    public partial class RestorePolicyProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("enabled");
            writer.WriteBooleanValue(Enabled);
            if (Days != null)
            {
                writer.WritePropertyName("days");
                writer.WriteNumberValue(Days.Value);
            }
            writer.WriteEndObject();
        }

        internal static RestorePolicyProperties DeserializeRestorePolicyProperties(JsonElement element)
        {
            RestorePolicyProperties result = new RestorePolicyProperties();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"))
                {
                    result.Enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("days"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Days = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
    }
}
