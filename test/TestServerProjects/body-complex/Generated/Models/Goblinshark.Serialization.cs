// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class GoblinsharkSerializer
    {
        internal static void Serialize(Goblinshark model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Jawsize != null)
            {
                writer.WritePropertyName("jawsize");
                writer.WriteNumberValue(model.Jawsize.Value);
            }
            if (model.Color != null)
            {
                writer.WritePropertyName("color");
                writer.WriteStringValue(model.Color.ToString());
            }

            if (model.Age != null)
            {
                writer.WritePropertyName("age");
                writer.WriteNumberValue(model.Age.Value);
            }
            writer.WritePropertyName("birthday");
            Azure.Core.Utf8JsonWriterExtensions.WriteStringValue(writer, model.Birthday, "S");

            writer.WritePropertyName("fishtype");
            writer.WriteStringValue(model.Fishtype);
            if (model.Species != null)
            {
                writer.WritePropertyName("species");
                writer.WriteStringValue(model.Species);
            }
            writer.WritePropertyName("length");
            writer.WriteNumberValue(model.Length);
            if (model.Siblings != null)
            {
                writer.WriteStartArray("siblings");
                foreach (var item in model.Siblings)
                {
                    FishSerializer.Serialize(item, writer);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static Goblinshark Deserialize(JsonElement element)
        {
            var result = new Goblinshark();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("jawsize"))
                {
                    result.Jawsize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("color"))
                {
                    result.Color = new GoblinSharkColor(property.Value.GetString());
                    continue;
                }

                if (property.NameEquals("age"))
                {
                    result.Age = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("birthday"))
                {
                    result.Birthday = Azure.Core.TypeFormatters.GetDateTimeOffset(property.Value, "S");
                    continue;
                }

                if (property.NameEquals("fishtype"))
                {
                    result.Fishtype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    result.Species = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("length"))
                {
                    result.Length = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("siblings"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Siblings.Add(FishSerializer.Deserialize(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
