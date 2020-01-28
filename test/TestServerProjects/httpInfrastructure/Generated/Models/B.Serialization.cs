// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace httpInfrastructure.Models
{
    public partial class B : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (TextStatusCode != null)
            {
                writer.WritePropertyName("textStatusCode");
                writer.WriteStringValue(TextStatusCode);
            }
            if (StatusCode != null)
            {
                writer.WritePropertyName("statusCode");
                writer.WriteStringValue(StatusCode);
            }
            writer.WriteEndObject();
        }
        internal static B DeserializeB(JsonElement element)
        {
            B result = new B();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("textStatusCode"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.TextStatusCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("statusCode"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.StatusCode = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
