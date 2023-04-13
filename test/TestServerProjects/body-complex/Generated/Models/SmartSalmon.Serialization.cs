// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class SmartSalmon : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(CollegeDegree))
            {
                writer.WritePropertyName("college_degree"u8);
                writer.WriteStringValue(CollegeDegree);
            }
            if (Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location);
            }
            if (Optional.IsDefined(Iswild))
            {
                writer.WritePropertyName("iswild"u8);
                writer.WriteBooleanValue(Iswild.Value);
            }
            writer.WritePropertyName("fishtype"u8);
            writer.WriteStringValue(Fishtype);
            if (Optional.IsDefined(Species))
            {
                writer.WritePropertyName("species"u8);
                writer.WriteStringValue(Species);
            }
            writer.WritePropertyName("length"u8);
            writer.WriteNumberValue(Length);
            if (Optional.IsCollectionDefined(Siblings))
            {
                writer.WritePropertyName("siblings"u8);
                writer.WriteStartArray();
                foreach (var item in Siblings)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
        }

        internal static SmartSalmon DeserializeSmartSalmon(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> collegeDegree = default;
            Optional<string> location = default;
            Optional<bool> iswild = default;
            string fishtype = default;
            Optional<string> species = default;
            float length = default;
            Optional<IList<Fish>> siblings = default;
            IDictionary<string, object> additionalProperties = default;
            Dictionary<string, object> additionalPropertiesDictionary = new Dictionary<string, object>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("college_degree"u8))
                {
                    collegeDegree = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("iswild"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    iswild = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("fishtype"u8))
                {
                    fishtype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"u8))
                {
                    species = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("length"u8))
                {
                    length = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("siblings"u8))
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
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetObject());
            }
            additionalProperties = additionalPropertiesDictionary;
            return new SmartSalmon(fishtype, species.Value, length, Optional.ToList(siblings), location.Value, Optional.ToNullable(iswild), collegeDegree.Value, additionalProperties);
        }
    }
}
