// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class Skillset : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("description"u8);
            writer.WriteStringValue(Description);
            writer.WritePropertyName("skills"u8);
            writer.WriteStartArray();
            foreach (var item in Skills)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(CognitiveServicesAccount))
            {
                writer.WritePropertyName("cognitiveServices"u8);
                writer.WriteObjectValue(CognitiveServicesAccount);
            }
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("@odata.etag"u8);
                writer.WriteStringValue(ETag);
            }
            writer.WriteEndObject();
        }

        internal static Skillset DeserializeSkillset(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string description = default;
            IList<Skill> skills = default;
            Optional<CognitiveServicesAccount> cognitiveServices = default;
            Optional<string> odataEtag = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("skills"u8))
                {
                    List<Skill> array = new List<Skill>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Skill.DeserializeSkill(item));
                    }
                    skills = array;
                    continue;
                }
                if (property.NameEquals("cognitiveServices"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cognitiveServices = CognitiveServicesAccount.DeserializeCognitiveServicesAccount(property.Value);
                    continue;
                }
                if (property.NameEquals("@odata.etag"u8))
                {
                    odataEtag = property.Value.GetString();
                    continue;
                }
            }
            return new Skillset(name, description, skills, cognitiveServices.Value, odataEtag.Value);
        }
    }
}
