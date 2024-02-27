// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class PatternAnalyzer : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (LowerCaseTerms.HasValue)
            {
                writer.WritePropertyName("lowercase"u8);
                writer.WriteBooleanValue(LowerCaseTerms.Value);
            }
            if (Pattern != null)
            {
                writer.WritePropertyName("pattern"u8);
                writer.WriteStringValue(Pattern);
            }
            if (Flags.HasValue)
            {
                writer.WritePropertyName("flags"u8);
                writer.WriteStringValue(Flags.Value.ToString());
            }
            if (!(Stopwords is ChangeTrackingList<string> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("stopwords"u8);
                writer.WriteStartArray();
                foreach (var item in Stopwords)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static PatternAnalyzer DeserializePatternAnalyzer(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool? lowercase = default;
            string pattern = default;
            RegexFlags? flags = default;
            IList<string> stopwords = default;
            string odataType = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("lowercase"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lowercase = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("pattern"u8))
                {
                    pattern = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("flags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    flags = new RegexFlags(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("stopwords"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    stopwords = array;
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new PatternAnalyzer(
                odataType,
                name,
                lowercase,
                pattern,
                flags,
                stopwords ?? new ChangeTrackingList<string>());
        }
    }
}
