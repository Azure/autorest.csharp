// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace CognitiveSearch.Models
{
    /// <summary> Defines the names of all text analyzers supported by Azure Cognitive Search. </summary>
    public readonly partial struct AnalyzerName : IEquatable<AnalyzerName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AnalyzerName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AnalyzerName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ArMicrosoftValue = "ar.microsoft";
        private const string ArLuceneValue = "ar.lucene";
        private const string HyLuceneValue = "hy.lucene";
        private const string BnMicrosoftValue = "bn.microsoft";
        private const string EuLuceneValue = "eu.lucene";
        private const string BgMicrosoftValue = "bg.microsoft";
        private const string BgLuceneValue = "bg.lucene";
        private const string CaMicrosoftValue = "ca.microsoft";
        private const string CaLuceneValue = "ca.lucene";
        private const string ZhHansMicrosoftValue = "zh-Hans.microsoft";
        private const string ZhHansLuceneValue = "zh-Hans.lucene";
        private const string ZhHantMicrosoftValue = "zh-Hant.microsoft";
        private const string ZhHantLuceneValue = "zh-Hant.lucene";
        private const string HrMicrosoftValue = "hr.microsoft";
        private const string CsMicrosoftValue = "cs.microsoft";
        private const string CsLuceneValue = "cs.lucene";
        private const string DaMicrosoftValue = "da.microsoft";
        private const string DaLuceneValue = "da.lucene";
        private const string NlMicrosoftValue = "nl.microsoft";
        private const string NlLuceneValue = "nl.lucene";
        private const string EnMicrosoftValue = "en.microsoft";
        private const string EnLuceneValue = "en.lucene";
        private const string EtMicrosoftValue = "et.microsoft";
        private const string FiMicrosoftValue = "fi.microsoft";
        private const string FiLuceneValue = "fi.lucene";
        private const string FrMicrosoftValue = "fr.microsoft";
        private const string FrLuceneValue = "fr.lucene";
        private const string GlLuceneValue = "gl.lucene";
        private const string DeMicrosoftValue = "de.microsoft";
        private const string DeLuceneValue = "de.lucene";
        private const string ElMicrosoftValue = "el.microsoft";
        private const string ElLuceneValue = "el.lucene";
        private const string GuMicrosoftValue = "gu.microsoft";
        private const string HeMicrosoftValue = "he.microsoft";
        private const string HiMicrosoftValue = "hi.microsoft";
        private const string HiLuceneValue = "hi.lucene";
        private const string HuMicrosoftValue = "hu.microsoft";
        private const string HuLuceneValue = "hu.lucene";
        private const string IsMicrosoftValue = "is.microsoft";
        private const string IdMicrosoftValue = "id.microsoft";
        private const string IdLuceneValue = "id.lucene";
        private const string GaLuceneValue = "ga.lucene";
        private const string ItMicrosoftValue = "it.microsoft";
        private const string ItLuceneValue = "it.lucene";
        private const string JaMicrosoftValue = "ja.microsoft";
        private const string JaLuceneValue = "ja.lucene";
        private const string KnMicrosoftValue = "kn.microsoft";
        private const string KoMicrosoftValue = "ko.microsoft";
        private const string KoLuceneValue = "ko.lucene";
        private const string LvMicrosoftValue = "lv.microsoft";
        private const string LvLuceneValue = "lv.lucene";
        private const string LtMicrosoftValue = "lt.microsoft";
        private const string MlMicrosoftValue = "ml.microsoft";
        private const string MsMicrosoftValue = "ms.microsoft";
        private const string MrMicrosoftValue = "mr.microsoft";
        private const string NbMicrosoftValue = "nb.microsoft";
        private const string NoLuceneValue = "no.lucene";
        private const string FaLuceneValue = "fa.lucene";
        private const string PlMicrosoftValue = "pl.microsoft";
        private const string PlLuceneValue = "pl.lucene";
        private const string PtBrMicrosoftValue = "pt-BR.microsoft";
        private const string PtBrLuceneValue = "pt-BR.lucene";
        private const string PtPtMicrosoftValue = "pt-PT.microsoft";
        private const string PtPtLuceneValue = "pt-PT.lucene";
        private const string PaMicrosoftValue = "pa.microsoft";
        private const string RoMicrosoftValue = "ro.microsoft";
        private const string RoLuceneValue = "ro.lucene";
        private const string RuMicrosoftValue = "ru.microsoft";
        private const string RuLuceneValue = "ru.lucene";
        private const string SrCyrillicMicrosoftValue = "sr-cyrillic.microsoft";
        private const string SrLatinMicrosoftValue = "sr-latin.microsoft";
        private const string SkMicrosoftValue = "sk.microsoft";
        private const string SlMicrosoftValue = "sl.microsoft";
        private const string EsMicrosoftValue = "es.microsoft";
        private const string EsLuceneValue = "es.lucene";
        private const string SvMicrosoftValue = "sv.microsoft";
        private const string SvLuceneValue = "sv.lucene";
        private const string TaMicrosoftValue = "ta.microsoft";
        private const string TeMicrosoftValue = "te.microsoft";
        private const string ThMicrosoftValue = "th.microsoft";
        private const string ThLuceneValue = "th.lucene";
        private const string TrMicrosoftValue = "tr.microsoft";
        private const string TrLuceneValue = "tr.lucene";
        private const string UkMicrosoftValue = "uk.microsoft";
        private const string UrMicrosoftValue = "ur.microsoft";
        private const string ViMicrosoftValue = "vi.microsoft";
        private const string StandardLuceneValue = "standard.lucene";
        private const string StandardAsciiFoldingLuceneValue = "standardasciifolding.lucene";
        private const string KeywordValue = "keyword";
        private const string PatternValue = "pattern";
        private const string SimpleValue = "simple";
        private const string StopValue = "stop";
        private const string WhitespaceValue = "whitespace";

        /// <summary> Microsoft analyzer for Arabic. </summary>
        public static AnalyzerName ArMicrosoft { get; } = new AnalyzerName(ArMicrosoftValue);
        /// <summary> Lucene analyzer for Arabic. </summary>
        public static AnalyzerName ArLucene { get; } = new AnalyzerName(ArLuceneValue);
        /// <summary> Lucene analyzer for Armenian. </summary>
        public static AnalyzerName HyLucene { get; } = new AnalyzerName(HyLuceneValue);
        /// <summary> Microsoft analyzer for Bangla. </summary>
        public static AnalyzerName BnMicrosoft { get; } = new AnalyzerName(BnMicrosoftValue);
        /// <summary> Lucene analyzer for Basque. </summary>
        public static AnalyzerName EuLucene { get; } = new AnalyzerName(EuLuceneValue);
        /// <summary> Microsoft analyzer for Bulgarian. </summary>
        public static AnalyzerName BgMicrosoft { get; } = new AnalyzerName(BgMicrosoftValue);
        /// <summary> Lucene analyzer for Bulgarian. </summary>
        public static AnalyzerName BgLucene { get; } = new AnalyzerName(BgLuceneValue);
        /// <summary> Microsoft analyzer for Catalan. </summary>
        public static AnalyzerName CaMicrosoft { get; } = new AnalyzerName(CaMicrosoftValue);
        /// <summary> Lucene analyzer for Catalan. </summary>
        public static AnalyzerName CaLucene { get; } = new AnalyzerName(CaLuceneValue);
        /// <summary> Microsoft analyzer for Chinese (Simplified). </summary>
        public static AnalyzerName ZhHansMicrosoft { get; } = new AnalyzerName(ZhHansMicrosoftValue);
        /// <summary> Lucene analyzer for Chinese (Simplified). </summary>
        public static AnalyzerName ZhHansLucene { get; } = new AnalyzerName(ZhHansLuceneValue);
        /// <summary> Microsoft analyzer for Chinese (Traditional). </summary>
        public static AnalyzerName ZhHantMicrosoft { get; } = new AnalyzerName(ZhHantMicrosoftValue);
        /// <summary> Lucene analyzer for Chinese (Traditional). </summary>
        public static AnalyzerName ZhHantLucene { get; } = new AnalyzerName(ZhHantLuceneValue);
        /// <summary> Microsoft analyzer for Croatian. </summary>
        public static AnalyzerName HrMicrosoft { get; } = new AnalyzerName(HrMicrosoftValue);
        /// <summary> Microsoft analyzer for Czech. </summary>
        public static AnalyzerName CsMicrosoft { get; } = new AnalyzerName(CsMicrosoftValue);
        /// <summary> Lucene analyzer for Czech. </summary>
        public static AnalyzerName CsLucene { get; } = new AnalyzerName(CsLuceneValue);
        /// <summary> Microsoft analyzer for Danish. </summary>
        public static AnalyzerName DaMicrosoft { get; } = new AnalyzerName(DaMicrosoftValue);
        /// <summary> Lucene analyzer for Danish. </summary>
        public static AnalyzerName DaLucene { get; } = new AnalyzerName(DaLuceneValue);
        /// <summary> Microsoft analyzer for Dutch. </summary>
        public static AnalyzerName NlMicrosoft { get; } = new AnalyzerName(NlMicrosoftValue);
        /// <summary> Lucene analyzer for Dutch. </summary>
        public static AnalyzerName NlLucene { get; } = new AnalyzerName(NlLuceneValue);
        /// <summary> Microsoft analyzer for English. </summary>
        public static AnalyzerName EnMicrosoft { get; } = new AnalyzerName(EnMicrosoftValue);
        /// <summary> Lucene analyzer for English. </summary>
        public static AnalyzerName EnLucene { get; } = new AnalyzerName(EnLuceneValue);
        /// <summary> Microsoft analyzer for Estonian. </summary>
        public static AnalyzerName EtMicrosoft { get; } = new AnalyzerName(EtMicrosoftValue);
        /// <summary> Microsoft analyzer for Finnish. </summary>
        public static AnalyzerName FiMicrosoft { get; } = new AnalyzerName(FiMicrosoftValue);
        /// <summary> Lucene analyzer for Finnish. </summary>
        public static AnalyzerName FiLucene { get; } = new AnalyzerName(FiLuceneValue);
        /// <summary> Microsoft analyzer for French. </summary>
        public static AnalyzerName FrMicrosoft { get; } = new AnalyzerName(FrMicrosoftValue);
        /// <summary> Lucene analyzer for French. </summary>
        public static AnalyzerName FrLucene { get; } = new AnalyzerName(FrLuceneValue);
        /// <summary> Lucene analyzer for Galician. </summary>
        public static AnalyzerName GlLucene { get; } = new AnalyzerName(GlLuceneValue);
        /// <summary> Microsoft analyzer for German. </summary>
        public static AnalyzerName DeMicrosoft { get; } = new AnalyzerName(DeMicrosoftValue);
        /// <summary> Lucene analyzer for German. </summary>
        public static AnalyzerName DeLucene { get; } = new AnalyzerName(DeLuceneValue);
        /// <summary> Microsoft analyzer for Greek. </summary>
        public static AnalyzerName ElMicrosoft { get; } = new AnalyzerName(ElMicrosoftValue);
        /// <summary> Lucene analyzer for Greek. </summary>
        public static AnalyzerName ElLucene { get; } = new AnalyzerName(ElLuceneValue);
        /// <summary> Microsoft analyzer for Gujarati. </summary>
        public static AnalyzerName GuMicrosoft { get; } = new AnalyzerName(GuMicrosoftValue);
        /// <summary> Microsoft analyzer for Hebrew. </summary>
        public static AnalyzerName HeMicrosoft { get; } = new AnalyzerName(HeMicrosoftValue);
        /// <summary> Microsoft analyzer for Hindi. </summary>
        public static AnalyzerName HiMicrosoft { get; } = new AnalyzerName(HiMicrosoftValue);
        /// <summary> Lucene analyzer for Hindi. </summary>
        public static AnalyzerName HiLucene { get; } = new AnalyzerName(HiLuceneValue);
        /// <summary> Microsoft analyzer for Hungarian. </summary>
        public static AnalyzerName HuMicrosoft { get; } = new AnalyzerName(HuMicrosoftValue);
        /// <summary> Lucene analyzer for Hungarian. </summary>
        public static AnalyzerName HuLucene { get; } = new AnalyzerName(HuLuceneValue);
        /// <summary> Microsoft analyzer for Icelandic. </summary>
        public static AnalyzerName IsMicrosoft { get; } = new AnalyzerName(IsMicrosoftValue);
        /// <summary> Microsoft analyzer for Indonesian (Bahasa). </summary>
        public static AnalyzerName IdMicrosoft { get; } = new AnalyzerName(IdMicrosoftValue);
        /// <summary> Lucene analyzer for Indonesian. </summary>
        public static AnalyzerName IdLucene { get; } = new AnalyzerName(IdLuceneValue);
        /// <summary> Lucene analyzer for Irish. </summary>
        public static AnalyzerName GaLucene { get; } = new AnalyzerName(GaLuceneValue);
        /// <summary> Microsoft analyzer for Italian. </summary>
        public static AnalyzerName ItMicrosoft { get; } = new AnalyzerName(ItMicrosoftValue);
        /// <summary> Lucene analyzer for Italian. </summary>
        public static AnalyzerName ItLucene { get; } = new AnalyzerName(ItLuceneValue);
        /// <summary> Microsoft analyzer for Japanese. </summary>
        public static AnalyzerName JaMicrosoft { get; } = new AnalyzerName(JaMicrosoftValue);
        /// <summary> Lucene analyzer for Japanese. </summary>
        public static AnalyzerName JaLucene { get; } = new AnalyzerName(JaLuceneValue);
        /// <summary> Microsoft analyzer for Kannada. </summary>
        public static AnalyzerName KnMicrosoft { get; } = new AnalyzerName(KnMicrosoftValue);
        /// <summary> Microsoft analyzer for Korean. </summary>
        public static AnalyzerName KoMicrosoft { get; } = new AnalyzerName(KoMicrosoftValue);
        /// <summary> Lucene analyzer for Korean. </summary>
        public static AnalyzerName KoLucene { get; } = new AnalyzerName(KoLuceneValue);
        /// <summary> Microsoft analyzer for Latvian. </summary>
        public static AnalyzerName LvMicrosoft { get; } = new AnalyzerName(LvMicrosoftValue);
        /// <summary> Lucene analyzer for Latvian. </summary>
        public static AnalyzerName LvLucene { get; } = new AnalyzerName(LvLuceneValue);
        /// <summary> Microsoft analyzer for Lithuanian. </summary>
        public static AnalyzerName LtMicrosoft { get; } = new AnalyzerName(LtMicrosoftValue);
        /// <summary> Microsoft analyzer for Malayalam. </summary>
        public static AnalyzerName MlMicrosoft { get; } = new AnalyzerName(MlMicrosoftValue);
        /// <summary> Microsoft analyzer for Malay (Latin). </summary>
        public static AnalyzerName MsMicrosoft { get; } = new AnalyzerName(MsMicrosoftValue);
        /// <summary> Microsoft analyzer for Marathi. </summary>
        public static AnalyzerName MrMicrosoft { get; } = new AnalyzerName(MrMicrosoftValue);
        /// <summary> Microsoft analyzer for Norwegian (Bokmål). </summary>
        public static AnalyzerName NbMicrosoft { get; } = new AnalyzerName(NbMicrosoftValue);
        /// <summary> Lucene analyzer for Norwegian. </summary>
        public static AnalyzerName NoLucene { get; } = new AnalyzerName(NoLuceneValue);
        /// <summary> Lucene analyzer for Persian. </summary>
        public static AnalyzerName FaLucene { get; } = new AnalyzerName(FaLuceneValue);
        /// <summary> Microsoft analyzer for Polish. </summary>
        public static AnalyzerName PlMicrosoft { get; } = new AnalyzerName(PlMicrosoftValue);
        /// <summary> Lucene analyzer for Polish. </summary>
        public static AnalyzerName PlLucene { get; } = new AnalyzerName(PlLuceneValue);
        /// <summary> Microsoft analyzer for Portuguese (Brazil). </summary>
        public static AnalyzerName PtBrMicrosoft { get; } = new AnalyzerName(PtBrMicrosoftValue);
        /// <summary> Lucene analyzer for Portuguese (Brazil). </summary>
        public static AnalyzerName PtBrLucene { get; } = new AnalyzerName(PtBrLuceneValue);
        /// <summary> Microsoft analyzer for Portuguese (Portugal). </summary>
        public static AnalyzerName PtPtMicrosoft { get; } = new AnalyzerName(PtPtMicrosoftValue);
        /// <summary> Lucene analyzer for Portuguese (Portugal). </summary>
        public static AnalyzerName PtPtLucene { get; } = new AnalyzerName(PtPtLuceneValue);
        /// <summary> Microsoft analyzer for Punjabi. </summary>
        public static AnalyzerName PaMicrosoft { get; } = new AnalyzerName(PaMicrosoftValue);
        /// <summary> Microsoft analyzer for Romanian. </summary>
        public static AnalyzerName RoMicrosoft { get; } = new AnalyzerName(RoMicrosoftValue);
        /// <summary> Lucene analyzer for Romanian. </summary>
        public static AnalyzerName RoLucene { get; } = new AnalyzerName(RoLuceneValue);
        /// <summary> Microsoft analyzer for Russian. </summary>
        public static AnalyzerName RuMicrosoft { get; } = new AnalyzerName(RuMicrosoftValue);
        /// <summary> Lucene analyzer for Russian. </summary>
        public static AnalyzerName RuLucene { get; } = new AnalyzerName(RuLuceneValue);
        /// <summary> Microsoft analyzer for Serbian (Cyrillic). </summary>
        public static AnalyzerName SrCyrillicMicrosoft { get; } = new AnalyzerName(SrCyrillicMicrosoftValue);
        /// <summary> Microsoft analyzer for Serbian (Latin). </summary>
        public static AnalyzerName SrLatinMicrosoft { get; } = new AnalyzerName(SrLatinMicrosoftValue);
        /// <summary> Microsoft analyzer for Slovak. </summary>
        public static AnalyzerName SkMicrosoft { get; } = new AnalyzerName(SkMicrosoftValue);
        /// <summary> Microsoft analyzer for Slovenian. </summary>
        public static AnalyzerName SlMicrosoft { get; } = new AnalyzerName(SlMicrosoftValue);
        /// <summary> Microsoft analyzer for Spanish. </summary>
        public static AnalyzerName EsMicrosoft { get; } = new AnalyzerName(EsMicrosoftValue);
        /// <summary> Lucene analyzer for Spanish. </summary>
        public static AnalyzerName EsLucene { get; } = new AnalyzerName(EsLuceneValue);
        /// <summary> Microsoft analyzer for Swedish. </summary>
        public static AnalyzerName SvMicrosoft { get; } = new AnalyzerName(SvMicrosoftValue);
        /// <summary> Lucene analyzer for Swedish. </summary>
        public static AnalyzerName SvLucene { get; } = new AnalyzerName(SvLuceneValue);
        /// <summary> Microsoft analyzer for Tamil. </summary>
        public static AnalyzerName TaMicrosoft { get; } = new AnalyzerName(TaMicrosoftValue);
        /// <summary> Microsoft analyzer for Telugu. </summary>
        public static AnalyzerName TeMicrosoft { get; } = new AnalyzerName(TeMicrosoftValue);
        /// <summary> Microsoft analyzer for Thai. </summary>
        public static AnalyzerName ThMicrosoft { get; } = new AnalyzerName(ThMicrosoftValue);
        /// <summary> Lucene analyzer for Thai. </summary>
        public static AnalyzerName ThLucene { get; } = new AnalyzerName(ThLuceneValue);
        /// <summary> Microsoft analyzer for Turkish. </summary>
        public static AnalyzerName TrMicrosoft { get; } = new AnalyzerName(TrMicrosoftValue);
        /// <summary> Lucene analyzer for Turkish. </summary>
        public static AnalyzerName TrLucene { get; } = new AnalyzerName(TrLuceneValue);
        /// <summary> Microsoft analyzer for Ukrainian. </summary>
        public static AnalyzerName UkMicrosoft { get; } = new AnalyzerName(UkMicrosoftValue);
        /// <summary> Microsoft analyzer for Urdu. </summary>
        public static AnalyzerName UrMicrosoft { get; } = new AnalyzerName(UrMicrosoftValue);
        /// <summary> Microsoft analyzer for Vietnamese. </summary>
        public static AnalyzerName ViMicrosoft { get; } = new AnalyzerName(ViMicrosoftValue);
        /// <summary> Standard Lucene analyzer. </summary>
        public static AnalyzerName StandardLucene { get; } = new AnalyzerName(StandardLuceneValue);
        /// <summary> Standard ASCII Folding Lucene analyzer. See https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search#Analyzers. </summary>
        public static AnalyzerName StandardAsciiFoldingLucene { get; } = new AnalyzerName(StandardAsciiFoldingLuceneValue);
        /// <summary> Treats the entire content of a field as a single token. This is useful for data like zip codes, ids, and some product names. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/KeywordAnalyzer.html. </summary>
        public static AnalyzerName Keyword { get; } = new AnalyzerName(KeywordValue);
        /// <summary> Flexibly separates text into terms via a regular expression pattern. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/PatternAnalyzer.html. </summary>
        public static AnalyzerName Pattern { get; } = new AnalyzerName(PatternValue);
        /// <summary> Divides text at non-letters and converts them to lower case. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/SimpleAnalyzer.html. </summary>
        public static AnalyzerName Simple { get; } = new AnalyzerName(SimpleValue);
        /// <summary> Divides text at non-letters; Applies the lowercase and stopword token filters. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/StopAnalyzer.html. </summary>
        public static AnalyzerName Stop { get; } = new AnalyzerName(StopValue);
        /// <summary> An analyzer that uses the whitespace tokenizer. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/WhitespaceAnalyzer.html. </summary>
        public static AnalyzerName Whitespace { get; } = new AnalyzerName(WhitespaceValue);
        /// <summary> Determines if two <see cref="AnalyzerName"/> values are the same. </summary>
        public static bool operator ==(AnalyzerName left, AnalyzerName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AnalyzerName"/> values are not the same. </summary>
        public static bool operator !=(AnalyzerName left, AnalyzerName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AnalyzerName"/>. </summary>
        public static implicit operator AnalyzerName(string value) => new AnalyzerName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AnalyzerName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AnalyzerName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
