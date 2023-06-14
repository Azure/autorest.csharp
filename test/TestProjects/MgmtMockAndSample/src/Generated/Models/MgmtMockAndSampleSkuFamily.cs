// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> SKU family name. </summary>
    public readonly partial struct MgmtMockAndSampleSkuFamily : IEquatable<MgmtMockAndSampleSkuFamily>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MgmtMockAndSampleSkuFamily"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MgmtMockAndSampleSkuFamily(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AValue = "A";

        /// <summary> A. </summary>
        public static MgmtMockAndSampleSkuFamily A { get; } = new MgmtMockAndSampleSkuFamily(AValue);
        /// <summary> Determines if two <see cref="MgmtMockAndSampleSkuFamily"/> values are the same. </summary>
        public static bool operator ==(MgmtMockAndSampleSkuFamily left, MgmtMockAndSampleSkuFamily right) => left.Equals(right);
        /// <summary> Determines if two <see cref="MgmtMockAndSampleSkuFamily"/> values are not the same. </summary>
        public static bool operator !=(MgmtMockAndSampleSkuFamily left, MgmtMockAndSampleSkuFamily right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="MgmtMockAndSampleSkuFamily"/>. </summary>
        public static implicit operator MgmtMockAndSampleSkuFamily(string value) => new MgmtMockAndSampleSkuFamily(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is MgmtMockAndSampleSkuFamily other && Equals(other);
        /// <inheritdoc />
        public bool Equals(MgmtMockAndSampleSkuFamily other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
