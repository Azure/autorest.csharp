// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace CognitiveSearch.Models
{
    /// <summary> The language codes supported for input text by SentimentSkill. </summary>
    public readonly partial struct SentimentSkillLanguage : IEquatable<SentimentSkillLanguage>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SentimentSkillLanguage"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SentimentSkillLanguage(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DaValue = "da";
        private const string NlValue = "nl";
        private const string EnValue = "en";
        private const string FiValue = "fi";
        private const string FrValue = "fr";
        private const string DeValue = "de";
        private const string ElValue = "el";
        private const string ItValue = "it";
        private const string NoValue = "no";
        private const string PlValue = "pl";
        private const string PtPTValue = "pt-PT";
        private const string RuValue = "ru";
        private const string EsValue = "es";
        private const string SvValue = "sv";
        private const string TrValue = "tr";

        /// <summary> Danish. </summary>
        public static SentimentSkillLanguage Da { get; } = new SentimentSkillLanguage(DaValue);
        /// <summary> Dutch. </summary>
        public static SentimentSkillLanguage Nl { get; } = new SentimentSkillLanguage(NlValue);
        /// <summary> English. </summary>
        public static SentimentSkillLanguage En { get; } = new SentimentSkillLanguage(EnValue);
        /// <summary> Finnish. </summary>
        public static SentimentSkillLanguage Fi { get; } = new SentimentSkillLanguage(FiValue);
        /// <summary> French. </summary>
        public static SentimentSkillLanguage Fr { get; } = new SentimentSkillLanguage(FrValue);
        /// <summary> German. </summary>
        public static SentimentSkillLanguage De { get; } = new SentimentSkillLanguage(DeValue);
        /// <summary> Greek. </summary>
        public static SentimentSkillLanguage El { get; } = new SentimentSkillLanguage(ElValue);
        /// <summary> Italian. </summary>
        public static SentimentSkillLanguage It { get; } = new SentimentSkillLanguage(ItValue);
        /// <summary> Norwegian (Bokmaal). </summary>
        public static SentimentSkillLanguage No { get; } = new SentimentSkillLanguage(NoValue);
        /// <summary> Polish. </summary>
        public static SentimentSkillLanguage Pl { get; } = new SentimentSkillLanguage(PlValue);
        /// <summary> Portuguese (Portugal). </summary>
        public static SentimentSkillLanguage PtPT { get; } = new SentimentSkillLanguage(PtPTValue);
        /// <summary> Russian. </summary>
        public static SentimentSkillLanguage Ru { get; } = new SentimentSkillLanguage(RuValue);
        /// <summary> Spanish. </summary>
        public static SentimentSkillLanguage Es { get; } = new SentimentSkillLanguage(EsValue);
        /// <summary> Swedish. </summary>
        public static SentimentSkillLanguage Sv { get; } = new SentimentSkillLanguage(SvValue);
        /// <summary> Turkish. </summary>
        public static SentimentSkillLanguage Tr { get; } = new SentimentSkillLanguage(TrValue);
        /// <summary> Determines if two <see cref="SentimentSkillLanguage"/> values are the same. </summary>
        public static bool operator ==(SentimentSkillLanguage left, SentimentSkillLanguage right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SentimentSkillLanguage"/> values are not the same. </summary>
        public static bool operator !=(SentimentSkillLanguage left, SentimentSkillLanguage right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SentimentSkillLanguage"/>. </summary>
        public static implicit operator SentimentSkillLanguage(string value) => new SentimentSkillLanguage(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SentimentSkillLanguage other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SentimentSkillLanguage other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
