// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class SmartSalmon : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (CollegeDegree != null)
            {
                writer.WritePropertyName("college_degree");
                writer.WriteStringValue(CollegeDegree);
            }
            if (Location != null)
            {
                writer.WritePropertyName("location");
                writer.WriteStringValue(Location);
            }
            if (Iswild != null)
            {
                writer.WritePropertyName("iswild");
                writer.WriteBooleanValue(Iswild.Value);
            }
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
            foreach (var item in this)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
        }
        internal static SmartSalmon DeserializeSmartSalmon(JsonElement element)
        {
            SmartSalmon result = new SmartSalmon();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("college_degree"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.CollegeDegree = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("location"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("iswild"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Iswild = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("fishtype"))
                {
                    result.Fishtype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
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
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Siblings = new List<Fish>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Siblings.Add(Fish.DeserializeFish(item));
                    }
                    continue;
                }
                result.Add(property.Name, property.Value.GetObject());
            }
            return result;
        }
    }
}
