// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    internal partial class WinRMConfiguration : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Listeners))
            {
                writer.WritePropertyName("listeners"u8);
                writer.WriteStartArray();
                foreach (var item in Listeners)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static WinRMConfiguration DeserializeWinRMConfiguration(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<WinRMListener>> listeners = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("listeners"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<WinRMListener> array = new List<WinRMListener>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(WinRMListener.DeserializeWinRMListener(item));
                    }
                    listeners = array;
                    continue;
                }
            }
            return new WinRMConfiguration(Optional.ToList(listeners));
        }
    }
}
