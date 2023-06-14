// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    internal partial class ReadOnlySinglePropertyModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static ReadOnlySinglePropertyModel DeserializeReadOnlySinglePropertyModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> readOnlySomething = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("readOnlySomething"u8))
                {
                    readOnlySomething = property.Value.GetString();
                    continue;
                }
            }
            return new ReadOnlySinglePropertyModel(readOnlySomething.Value);
        }
    }
}
