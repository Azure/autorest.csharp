// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace httpInfrastructure.quirks.Models
{
    public partial class C : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (HttpCode != null)
            {
                writer.WritePropertyName("httpCode");
                writer.WriteStringValue(HttpCode);
            }
            writer.WriteEndObject();
        }
        internal static C DeserializeC(JsonElement element)
        {
            C result = new C();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("httpCode"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.HttpCode = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
