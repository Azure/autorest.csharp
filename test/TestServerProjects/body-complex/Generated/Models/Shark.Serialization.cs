// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class Shark : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Age != null)
            {
                writer.WritePropertyName("age");
                writer.WriteNumberValue(Age.Value);
            }
            writer.WritePropertyName("birthday");
            writer.WriteStringValue(Birthday, "S");
            writer.WritePropertyName("fishtype");
            writer.WriteStringValue(Fishtype);
            if (Species != null)
            {
                writer.WritePropertyName("species");
                writer.WriteStringValue(Species);
            }
            writer.WritePropertyName("length");
            writer.WriteNumberValue(Length);
            if (Siblings != null)
            {
                writer.WritePropertyName("siblings");
                writer.WriteStartArray();
                foreach (var item in Siblings)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static Shark DeserializeShark(JsonElement element)
        {
            if (element.TryGetProperty("fishtype", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "cookiecuttershark": return Cookiecuttershark.DeserializeCookiecuttershark(element);
                    case "goblin": return Goblinshark.DeserializeGoblinshark(element);
                    case "sawshark": return Sawshark.DeserializeSawshark(element);
                }
            }
            Shark result;
            int? age = default;
            DateTimeOffset birthday = default;
            string fishtype = default;
            string species = default;
            float length = default;
            IList<Fish> siblings = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("age"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    age = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("birthday"))
                {
                    birthday = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("fishtype"))
                {
                    fishtype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    species = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("length"))
                {
                    length = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("siblings"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Fish> array = new List<Fish>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeFish(item));
                    }
                    siblings = array;
                    continue;
                }
            }
            result = new Shark(age, birthday, fishtype, species, length, siblings);
            return result;
        }
    }
}
