// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace httpInfrastructure.quirks.Models
{
    public partial class D : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (HttpStatusCode != null)
            {
                writer.WritePropertyName("httpStatusCode");
                writer.WriteStringValue(HttpStatusCode);
            }
            writer.WriteEndObject();
        }
        internal static D DeserializeD(JsonElement element)
        {
            D result = new D();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("httpStatusCode"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.HttpStatusCode = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
