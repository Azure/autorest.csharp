// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace CognitiveSearch.Models
{
    /// <summary> The language codes supported for input by ImageAnalysisSkill. </summary>
    public readonly partial struct ImageAnalysisSkillLanguage : IEquatable<ImageAnalysisSkillLanguage>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ImageAnalysisSkillLanguage"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ImageAnalysisSkillLanguage(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EnValue = "en";
        private const string EsValue = "es";
        private const string JaValue = "ja";
        private const string PtValue = "pt";
        private const string ZhValue = "zh";

        /// <summary> English. </summary>
        public static ImageAnalysisSkillLanguage En { get; } = new ImageAnalysisSkillLanguage(EnValue);
        /// <summary> Spanish. </summary>
        public static ImageAnalysisSkillLanguage Es { get; } = new ImageAnalysisSkillLanguage(EsValue);
        /// <summary> Japanese. </summary>
        public static ImageAnalysisSkillLanguage Ja { get; } = new ImageAnalysisSkillLanguage(JaValue);
        /// <summary> Portuguese. </summary>
        public static ImageAnalysisSkillLanguage Pt { get; } = new ImageAnalysisSkillLanguage(PtValue);
        /// <summary> Chinese. </summary>
        public static ImageAnalysisSkillLanguage Zh { get; } = new ImageAnalysisSkillLanguage(ZhValue);
        /// <summary> Determines if two <see cref="ImageAnalysisSkillLanguage"/> values are the same. </summary>
        public static bool operator ==(ImageAnalysisSkillLanguage left, ImageAnalysisSkillLanguage right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ImageAnalysisSkillLanguage"/> values are not the same. </summary>
        public static bool operator !=(ImageAnalysisSkillLanguage left, ImageAnalysisSkillLanguage right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ImageAnalysisSkillLanguage"/>. </summary>
        public static implicit operator ImageAnalysisSkillLanguage(string value) => new ImageAnalysisSkillLanguage(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ImageAnalysisSkillLanguage other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ImageAnalysisSkillLanguage other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
