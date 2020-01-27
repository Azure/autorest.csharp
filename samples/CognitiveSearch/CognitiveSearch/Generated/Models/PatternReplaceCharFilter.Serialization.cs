// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class PatternReplaceCharFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("pattern");
            writer.WriteStringValue(Pattern);
            writer.WritePropertyName("replacement");
            writer.WriteStringValue(Replacement);
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }
        internal static PatternReplaceCharFilter DeserializePatternReplaceCharFilter(JsonElement element)
        {
            PatternReplaceCharFilter result = new PatternReplaceCharFilter();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("pattern"))
                {
                    result.Pattern = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("replacement"))
                {
                    result.Replacement = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
