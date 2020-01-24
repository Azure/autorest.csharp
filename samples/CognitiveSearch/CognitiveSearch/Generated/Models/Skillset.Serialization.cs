// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class Skillset : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WritePropertyName("description");
            writer.WriteStringValue(Description);
            writer.WritePropertyName("skills");
            writer.WriteStartArray();
            foreach (var item in Skills)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (CognitiveServicesAccount != null)
            {
                writer.WritePropertyName("cognitiveServices");
                writer.WriteObjectValue(CognitiveServicesAccount);
            }
            if (ETag != null)
            {
                writer.WritePropertyName("@odata.etag");
                writer.WriteStringValue(ETag);
            }
            writer.WriteEndObject();
        }
        internal static Skillset DeserializeSkillset(JsonElement element)
        {
            Skillset result = new Skillset();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    result.Description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("skills"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Skills.Add(Skill.DeserializeSkill(item));
                    }
                    continue;
                }
                if (property.NameEquals("cognitiveServices"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CognitiveServicesAccount = CognitiveServicesAccount.DeserializeCognitiveServicesAccount(property.Value);
                    continue;
                }
                if (property.NameEquals("@odata.etag"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ETag = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
