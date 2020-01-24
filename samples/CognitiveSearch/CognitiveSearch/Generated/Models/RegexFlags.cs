// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace CognitiveSearch.Models
{
    /// <summary> Defines flags that can be combined to control how regular expressions are used in the pattern analyzer and pattern tokenizer. </summary>
    public readonly partial struct RegexFlags : IEquatable<RegexFlags>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="RegexFlags"/> values are the same. </summary>
        public RegexFlags(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CANONEQValue = "CANON_EQ";
        private const string CASEINSENSITIVEValue = "CASE_INSENSITIVE";
        private const string COMMENTSValue = "COMMENTS";
        private const string DOTALLValue = "DOTALL";
        private const string LITERALValue = "LITERAL";
        private const string MULTILINEValue = "MULTILINE";
        private const string UNICODECASEValue = "UNICODE_CASE";
        private const string UNIXLINESValue = "UNIX_LINES";

        /// <summary> The value &apos;undefined&apos;. </summary>
        public static RegexFlags CANONEQ { get; } = new RegexFlags(CANONEQValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static RegexFlags CASEINSENSITIVE { get; } = new RegexFlags(CASEINSENSITIVEValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static RegexFlags COMMENTS { get; } = new RegexFlags(COMMENTSValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static RegexFlags DOTALL { get; } = new RegexFlags(DOTALLValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static RegexFlags LITERAL { get; } = new RegexFlags(LITERALValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static RegexFlags MULTILINE { get; } = new RegexFlags(MULTILINEValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static RegexFlags UNICODECASE { get; } = new RegexFlags(UNICODECASEValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static RegexFlags UNIXLINES { get; } = new RegexFlags(UNIXLINESValue);
        /// <summary> Determines if two <see cref="RegexFlags"/> values are the same. </summary>
        public static bool operator ==(RegexFlags left, RegexFlags right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RegexFlags"/> values are not the same. </summary>
        public static bool operator !=(RegexFlags left, RegexFlags right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RegexFlags"/>. </summary>
        public static implicit operator RegexFlags(string value) => new RegexFlags(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is RegexFlags other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RegexFlags other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
