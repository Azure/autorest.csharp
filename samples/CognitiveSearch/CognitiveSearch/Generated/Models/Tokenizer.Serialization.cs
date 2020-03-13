// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class Tokenizer : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static Tokenizer DeserializeTokenizer(JsonElement element)
        {
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.ClassicTokenizer": return ClassicTokenizer.DeserializeClassicTokenizer(element);
                    case "#Microsoft.Azure.Search.EdgeNGramTokenizer": return EdgeNGramTokenizer.DeserializeEdgeNGramTokenizer(element);
                    case "#Microsoft.Azure.Search.KeywordTokenizer": return KeywordTokenizer.DeserializeKeywordTokenizer(element);
                    case "#Microsoft.Azure.Search.KeywordTokenizerV2": return KeywordTokenizerV2.DeserializeKeywordTokenizerV2(element);
                    case "#Microsoft.Azure.Search.MicrosoftLanguageStemmingTokenizer": return MicrosoftLanguageStemmingTokenizer.DeserializeMicrosoftLanguageStemmingTokenizer(element);
                    case "#Microsoft.Azure.Search.MicrosoftLanguageTokenizer": return MicrosoftLanguageTokenizer.DeserializeMicrosoftLanguageTokenizer(element);
                    case "#Microsoft.Azure.Search.NGramTokenizer": return NGramTokenizer.DeserializeNGramTokenizer(element);
                    case "#Microsoft.Azure.Search.PathHierarchyTokenizer": return PathHierarchyTokenizer.DeserializePathHierarchyTokenizer(element);
                    case "#Microsoft.Azure.Search.PathHierarchyTokenizerV2": return PathHierarchyTokenizerV2.DeserializePathHierarchyTokenizerV2(element);
                    case "#Microsoft.Azure.Search.PatternTokenizer": return PatternTokenizer.DeserializePatternTokenizer(element);
                    case "#Microsoft.Azure.Search.StandardTokenizer": return StandardTokenizer.DeserializeStandardTokenizer(element);
                    case "#Microsoft.Azure.Search.StandardTokenizerV2": return StandardTokenizerV2.DeserializeStandardTokenizerV2(element);
                    case "#Microsoft.Azure.Search.UaxUrlEmailTokenizer": return UaxUrlEmailTokenizer.DeserializeUaxUrlEmailTokenizer(element);
                }
            }
            Tokenizer result = new Tokenizer();
            foreach (var property in element.EnumerateObject())
            {
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
