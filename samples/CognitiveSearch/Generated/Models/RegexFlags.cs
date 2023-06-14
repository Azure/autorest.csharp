// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace CognitiveSearch.Models
{
    /// <summary> Defines flags that can be combined to control how regular expressions are used in the pattern analyzer and pattern tokenizer. </summary>
    public readonly partial struct RegexFlags : IEquatable<RegexFlags>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RegexFlags"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RegexFlags(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CanonEQValue = "CANON_EQ";
        private const string CaseInsensitiveValue = "CASE_INSENSITIVE";
        private const string CommentsValue = "COMMENTS";
        private const string DotallValue = "DOTALL";
        private const string LiteralValue = "LITERAL";
        private const string MultilineValue = "MULTILINE";
        private const string UnicodeCaseValue = "UNICODE_CASE";
        private const string UnixLinesValue = "UNIX_LINES";

        /// <summary> CANON_EQ. </summary>
        public static RegexFlags CanonEQ { get; } = new RegexFlags(CanonEQValue);
        /// <summary> CASE_INSENSITIVE. </summary>
        public static RegexFlags CaseInsensitive { get; } = new RegexFlags(CaseInsensitiveValue);
        /// <summary> COMMENTS. </summary>
        public static RegexFlags Comments { get; } = new RegexFlags(CommentsValue);
        /// <summary> DOTALL. </summary>
        public static RegexFlags Dotall { get; } = new RegexFlags(DotallValue);
        /// <summary> LITERAL. </summary>
        public static RegexFlags Literal { get; } = new RegexFlags(LiteralValue);
        /// <summary> MULTILINE. </summary>
        public static RegexFlags Multiline { get; } = new RegexFlags(MultilineValue);
        /// <summary> UNICODE_CASE. </summary>
        public static RegexFlags UnicodeCase { get; } = new RegexFlags(UnicodeCaseValue);
        /// <summary> UNIX_LINES. </summary>
        public static RegexFlags UnixLines { get; } = new RegexFlags(UnixLinesValue);
        /// <summary> Determines if two <see cref="RegexFlags"/> values are the same. </summary>
        public static bool operator ==(RegexFlags left, RegexFlags right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RegexFlags"/> values are not the same. </summary>
        public static bool operator !=(RegexFlags left, RegexFlags right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RegexFlags"/>. </summary>
        public static implicit operator RegexFlags(string value) => new RegexFlags(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RegexFlags other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RegexFlags other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
