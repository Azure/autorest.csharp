// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> This is a required field, it specifies the format for the inventory files. </summary>
    public readonly partial struct Format : IEquatable<Format>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Format"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Format(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CsvValue = "Csv";
        private const string ParquetValue = "Parquet";

        /// <summary> Csv. </summary>
        public static Format Csv { get; } = new Format(CsvValue);
        /// <summary> Parquet. </summary>
        public static Format Parquet { get; } = new Format(ParquetValue);
        /// <summary> Determines if two <see cref="Format"/> values are the same. </summary>
        public static bool operator ==(Format left, Format right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Format"/> values are not the same. </summary>
        public static bool operator !=(Format left, Format right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Format"/>. </summary>
        public static implicit operator Format(string value) => new Format(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Format other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Format other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
