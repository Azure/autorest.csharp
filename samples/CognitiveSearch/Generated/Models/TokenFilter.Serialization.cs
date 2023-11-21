// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class TokenFilter : IUtf8JsonSerializable, IJsonModel<TokenFilter>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<TokenFilter>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<TokenFilter>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TokenFilter>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(TokenFilter)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (_serializedAdditionalRawData != null && options.Format != "W")
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        TokenFilter IJsonModel<TokenFilter>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TokenFilter>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(TokenFilter)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTokenFilter(document.RootElement, options);
        }

        internal static TokenFilter DeserializeTokenFilter(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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

        BinaryData IPersistableModel<TokenFilter>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TokenFilter>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(TokenFilter)} does not support '{options.Format}' format.");
            }
        }

        TokenFilter IPersistableModel<TokenFilter>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TokenFilter>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeTokenFilter(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(TokenFilter)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<TokenFilter>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
