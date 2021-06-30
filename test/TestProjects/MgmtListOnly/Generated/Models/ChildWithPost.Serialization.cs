// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtListOnly.Models
{
    public partial class ChildWithPost : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Bar))
            {
                writer.WritePropertyName("bar");
                writer.WriteStringValue(Bar);
            }
            writer.WriteEndObject();
        }

        internal static ChildWithPost DeserializeChildWithPost(JsonElement element)
        {
            Optional<string> bar = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("bar"))
                {
                    bar = property.Value.GetString();
                    continue;
                }
            }
            return new ChildWithPost(bar.Value);
        }
    }
}
