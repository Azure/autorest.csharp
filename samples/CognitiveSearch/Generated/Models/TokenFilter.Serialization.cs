// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class TokenFilter : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static TokenFilter DeserializeTokenFilter(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.AsciiFoldingTokenFilter": return AsciiFoldingTokenFilter.DeserializeAsciiFoldingTokenFilter(element);
                    case "#Microsoft.Azure.Search.CjkBigramTokenFilter": return CjkBigramTokenFilter.DeserializeCjkBigramTokenFilter(element);
                    case "#Microsoft.Azure.Search.CommonGramTokenFilter": return CommonGramTokenFilter.DeserializeCommonGramTokenFilter(element);
                    case "#Microsoft.Azure.Search.DictionaryDecompounderTokenFilter": return DictionaryDecompounderTokenFilter.DeserializeDictionaryDecompounderTokenFilter(element);
                    case "#Microsoft.Azure.Search.EdgeNGramTokenFilter": return EdgeNGramTokenFilter.DeserializeEdgeNGramTokenFilter(element);
                    case "#Microsoft.Azure.Search.EdgeNGramTokenFilterV2": return EdgeNGramTokenFilterV2.DeserializeEdgeNGramTokenFilterV2(element);
                    case "#Microsoft.Azure.Search.ElisionTokenFilter": return ElisionTokenFilter.DeserializeElisionTokenFilter(element);
                    case "#Microsoft.Azure.Search.KeepTokenFilter": return KeepTokenFilter.DeserializeKeepTokenFilter(element);
                    case "#Microsoft.Azure.Search.KeywordMarkerTokenFilter": return KeywordMarkerTokenFilter.DeserializeKeywordMarkerTokenFilter(element);
                    case "#Microsoft.Azure.Search.LengthTokenFilter": return LengthTokenFilter.DeserializeLengthTokenFilter(element);
                    case "#Microsoft.Azure.Search.LimitTokenFilter": return LimitTokenFilter.DeserializeLimitTokenFilter(element);
                    case "#Microsoft.Azure.Search.NGramTokenFilter": return NGramTokenFilter.DeserializeNGramTokenFilter(element);
                    case "#Microsoft.Azure.Search.NGramTokenFilterV2": return NGramTokenFilterV2.DeserializeNGramTokenFilterV2(element);
                    case "#Microsoft.Azure.Search.PatternCaptureTokenFilter": return PatternCaptureTokenFilter.DeserializePatternCaptureTokenFilter(element);
                    case "#Microsoft.Azure.Search.PatternReplaceTokenFilter": return PatternReplaceTokenFilter.DeserializePatternReplaceTokenFilter(element);
                    case "#Microsoft.Azure.Search.PhoneticTokenFilter": return PhoneticTokenFilter.DeserializePhoneticTokenFilter(element);
                    case "#Microsoft.Azure.Search.ShingleTokenFilter": return ShingleTokenFilter.DeserializeShingleTokenFilter(element);
                    case "#Microsoft.Azure.Search.SnowballTokenFilter": return SnowballTokenFilter.DeserializeSnowballTokenFilter(element);
                    case "#Microsoft.Azure.Search.StemmerOverrideTokenFilter": return StemmerOverrideTokenFilter.DeserializeStemmerOverrideTokenFilter(element);
                    case "#Microsoft.Azure.Search.StemmerTokenFilter": return StemmerTokenFilter.DeserializeStemmerTokenFilter(element);
                    case "#Microsoft.Azure.Search.StopwordsTokenFilter": return StopwordsTokenFilter.DeserializeStopwordsTokenFilter(element);
                    case "#Microsoft.Azure.Search.SynonymTokenFilter": return SynonymTokenFilter.DeserializeSynonymTokenFilter(element);
                    case "#Microsoft.Azure.Search.TruncateTokenFilter": return TruncateTokenFilter.DeserializeTruncateTokenFilter(element);
                    case "#Microsoft.Azure.Search.UniqueTokenFilter": return UniqueTokenFilter.DeserializeUniqueTokenFilter(element);
                    case "#Microsoft.Azure.Search.WordDelimiterTokenFilter": return WordDelimiterTokenFilter.DeserializeWordDelimiterTokenFilter(element);
                }
            }
            return UnknownTokenFilter.DeserializeUnknownTokenFilter(element);
        }
    }
}
