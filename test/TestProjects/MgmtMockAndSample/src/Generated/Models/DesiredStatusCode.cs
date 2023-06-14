// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace MgmtMockAndSample.Models
{
    /// <summary> The desired status code. </summary>
    public readonly partial struct DesiredStatusCode : IEquatable<DesiredStatusCode>
    {
        private readonly int _value;

        /// <summary> Initializes a new instance of <see cref="DesiredStatusCode"/>. </summary>
        public DesiredStatusCode(int value)
        {
            _value = value;
        }

        private const int TwoHundredValue = 200;
        private const int TwoHundredOneValue = 201;
        private const int TwoHundredTwoValue = 202;
        private const int FourHundredValue = 400;
        private const int FourHundredFourValue = 404;

        /// <summary> 200. </summary>
        public static DesiredStatusCode TwoHundred { get; } = new DesiredStatusCode(TwoHundredValue);
        /// <summary> 201. </summary>
        public static DesiredStatusCode TwoHundredOne { get; } = new DesiredStatusCode(TwoHundredOneValue);
        /// <summary> 202. </summary>
        public static DesiredStatusCode TwoHundredTwo { get; } = new DesiredStatusCode(TwoHundredTwoValue);
        /// <summary> 400. </summary>
        public static DesiredStatusCode FourHundred { get; } = new DesiredStatusCode(FourHundredValue);
        /// <summary> 404. </summary>
        public static DesiredStatusCode FourHundredFour { get; } = new DesiredStatusCode(FourHundredFourValue);

        internal int ToSerialInt32() => _value;

        /// <summary> Determines if two <see cref="DesiredStatusCode"/> values are the same. </summary>
        public static bool operator ==(DesiredStatusCode left, DesiredStatusCode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DesiredStatusCode"/> values are not the same. </summary>
        public static bool operator !=(DesiredStatusCode left, DesiredStatusCode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DesiredStatusCode"/>. </summary>
        public static implicit operator DesiredStatusCode(int value) => new DesiredStatusCode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DesiredStatusCode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DesiredStatusCode other) => Equals(_value, other._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();
        /// <inheritdoc />
        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
