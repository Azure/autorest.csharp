// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static Tokenizer DeserializeTokenizer(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
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
                    case "#Microsoft.Azure.Search.PathHierarchyTokenizerV2": return PathHierarchyTokenizerV2.DeserializePathHierarchyTokenizerV2(element);
                    case "#Microsoft.Azure.Search.PatternTokenizer": return PatternTokenizer.DeserializePatternTokenizer(element);
                    case "#Microsoft.Azure.Search.StandardTokenizer": return StandardTokenizer.DeserializeStandardTokenizer(element);
                    case "#Microsoft.Azure.Search.StandardTokenizerV2": return StandardTokenizerV2.DeserializeStandardTokenizerV2(element);
                    case "#Microsoft.Azure.Search.UaxUrlEmailTokenizer": return UaxUrlEmailTokenizer.DeserializeUaxUrlEmailTokenizer(element);
                }
            }
            return UnknownTokenizer.DeserializeUnknownTokenizer(element);
        }
    }
}
