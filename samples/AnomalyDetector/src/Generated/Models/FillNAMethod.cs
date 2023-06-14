// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace AnomalyDetector.Models
{
    /// <summary> An optional field, indicating how missing values will be filled. One of Previous, Subsequent, Linear, Zero, Fixed. </summary>
    public readonly partial struct FillNAMethod : IEquatable<FillNAMethod>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FillNAMethod"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public FillNAMethod(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PreviousValue = "Previous";
        private const string SubsequentValue = "Subsequent";
        private const string LinearValue = "Linear";
        private const string ZeroValue = "Zero";
        private const string FixedValue = "Fixed";

        /// <summary> Previous. </summary>
        public static FillNAMethod Previous { get; } = new FillNAMethod(PreviousValue);
        /// <summary> Subsequent. </summary>
        public static FillNAMethod Subsequent { get; } = new FillNAMethod(SubsequentValue);
        /// <summary> Linear. </summary>
        public static FillNAMethod Linear { get; } = new FillNAMethod(LinearValue);
        /// <summary> Zero. </summary>
        public static FillNAMethod Zero { get; } = new FillNAMethod(ZeroValue);
        /// <summary> Fixed. </summary>
        public static FillNAMethod Fixed { get; } = new FillNAMethod(FixedValue);
        /// <summary> Determines if two <see cref="FillNAMethod"/> values are the same. </summary>
        public static bool operator ==(FillNAMethod left, FillNAMethod right) => left.Equals(right);
        /// <summary> Determines if two <see cref="FillNAMethod"/> values are not the same. </summary>
        public static bool operator !=(FillNAMethod left, FillNAMethod right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="FillNAMethod"/>. </summary>
        public static implicit operator FillNAMethod(string value) => new FillNAMethod(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FillNAMethod other && Equals(other);
        /// <inheritdoc />
        public bool Equals(FillNAMethod other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
