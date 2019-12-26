// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class LinkedEntity : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WritePropertyName("matches");
            writer.WriteStartArray();
            foreach (var item in Matches)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("language");
            writer.WriteStringValue(Language);
            if (Id != null)
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("url");
            writer.WriteStringValue(Url);
            writer.WritePropertyName("dataSource");
            writer.WriteStringValue(DataSource);
            writer.WriteEndObject();
        }
        internal static LinkedEntity DeserializeLinkedEntity(JsonElement element)
        {
            LinkedEntity result = new LinkedEntity();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("matches"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Matches.Add(Match.DeserializeMatch(item));
                    }
                    continue;
                }
                if (property.NameEquals("language"))
                {
                    result.Language = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("url"))
                {
                    result.Url = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("dataSource"))
                {
                    result.DataSource = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
