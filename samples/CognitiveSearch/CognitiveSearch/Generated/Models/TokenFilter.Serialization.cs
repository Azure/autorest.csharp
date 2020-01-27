// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class TokenFilter : Azure.Core.IUtf8JsonSerializable
    {
        void Azure.Core.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }
        internal static CognitiveSearch.Models.TokenFilter DeserializeTokenFilter(System.Text.Json.JsonElement element)
        {
            if (element.TryGetProperty("@odata.type", out System.Text.Json.JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.AsciiFoldingTokenFilter": return CognitiveSearch.Models.AsciiFoldingTokenFilter.DeserializeAsciiFoldingTokenFilter(element);
                    case "#Microsoft.Azure.Search.CjkBigramTokenFilter": return CognitiveSearch.Models.CjkBigramTokenFilter.DeserializeCjkBigramTokenFilter(element);
                    case "#Microsoft.Azure.Search.CommonGramTokenFilter": return CognitiveSearch.Models.CommonGramTokenFilter.DeserializeCommonGramTokenFilter(element);
                    case "#Microsoft.Azure.Search.DictionaryDecompounderTokenFilter": return CognitiveSearch.Models.DictionaryDecompounderTokenFilter.DeserializeDictionaryDecompounderTokenFilter(element);
                    case "#Microsoft.Azure.Search.EdgeNGramTokenFilter": return CognitiveSearch.Models.EdgeNGramTokenFilter.DeserializeEdgeNGramTokenFilter(element);
                    case "#Microsoft.Azure.Search.EdgeNGramTokenFilterV2": return CognitiveSearch.Models.EdgeNGramTokenFilterV2.DeserializeEdgeNGramTokenFilterV2(element);
                    case "#Microsoft.Azure.Search.ElisionTokenFilter": return CognitiveSearch.Models.ElisionTokenFilter.DeserializeElisionTokenFilter(element);
                    case "#Microsoft.Azure.Search.KeepTokenFilter": return CognitiveSearch.Models.KeepTokenFilter.DeserializeKeepTokenFilter(element);
                    case "#Microsoft.Azure.Search.KeywordMarkerTokenFilter": return CognitiveSearch.Models.KeywordMarkerTokenFilter.DeserializeKeywordMarkerTokenFilter(element);
                    case "#Microsoft.Azure.Search.LengthTokenFilter": return CognitiveSearch.Models.LengthTokenFilter.DeserializeLengthTokenFilter(element);
                    case "#Microsoft.Azure.Search.LimitTokenFilter": return CognitiveSearch.Models.LimitTokenFilter.DeserializeLimitTokenFilter(element);
                    case "#Microsoft.Azure.Search.NGramTokenFilter": return CognitiveSearch.Models.NGramTokenFilter.DeserializeNGramTokenFilter(element);
                    case "#Microsoft.Azure.Search.NGramTokenFilterV2": return CognitiveSearch.Models.NGramTokenFilterV2.DeserializeNGramTokenFilterV2(element);
                    case "#Microsoft.Azure.Search.PatternCaptureTokenFilter": return CognitiveSearch.Models.PatternCaptureTokenFilter.DeserializePatternCaptureTokenFilter(element);
                    case "#Microsoft.Azure.Search.PatternReplaceTokenFilter": return CognitiveSearch.Models.PatternReplaceTokenFilter.DeserializePatternReplaceTokenFilter(element);
                    case "#Microsoft.Azure.Search.PhoneticTokenFilter": return CognitiveSearch.Models.PhoneticTokenFilter.DeserializePhoneticTokenFilter(element);
                    case "#Microsoft.Azure.Search.ShingleTokenFilter": return CognitiveSearch.Models.ShingleTokenFilter.DeserializeShingleTokenFilter(element);
                    case "#Microsoft.Azure.Search.SnowballTokenFilter": return CognitiveSearch.Models.SnowballTokenFilter.DeserializeSnowballTokenFilter(element);
                    case "#Microsoft.Azure.Search.StemmerOverrideTokenFilter": return CognitiveSearch.Models.StemmerOverrideTokenFilter.DeserializeStemmerOverrideTokenFilter(element);
                    case "#Microsoft.Azure.Search.StemmerTokenFilter": return CognitiveSearch.Models.StemmerTokenFilter.DeserializeStemmerTokenFilter(element);
                    case "#Microsoft.Azure.Search.StopwordsTokenFilter": return CognitiveSearch.Models.StopwordsTokenFilter.DeserializeStopwordsTokenFilter(element);
                    case "#Microsoft.Azure.Search.SynonymTokenFilter": return CognitiveSearch.Models.SynonymTokenFilter.DeserializeSynonymTokenFilter(element);
                    case "#Microsoft.Azure.Search.TruncateTokenFilter": return CognitiveSearch.Models.TruncateTokenFilter.DeserializeTruncateTokenFilter(element);
                    case "#Microsoft.Azure.Search.UniqueTokenFilter": return CognitiveSearch.Models.UniqueTokenFilter.DeserializeUniqueTokenFilter(element);
                    case "#Microsoft.Azure.Search.WordDelimiterTokenFilter": return CognitiveSearch.Models.WordDelimiterTokenFilter.DeserializeWordDelimiterTokenFilter(element);
                }
            }
            CognitiveSearch.Models.TokenFilter result = new CognitiveSearch.Models.TokenFilter();
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
