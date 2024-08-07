// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace CustomizationsInTsp.Models
{
    /// <summary> Extensible enum to customize operator. </summary>
    public readonly partial struct ExtensibleEnumWithOperator : IEquatable<ExtensibleEnumWithOperator>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ExtensibleEnumWithOperator"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ExtensibleEnumWithOperator(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MondayValue = "Monday";
        private const string TuesdayValue = "Tuesday";

        /// <summary> Monday. </summary>
        public static ExtensibleEnumWithOperator Monday { get; } = new ExtensibleEnumWithOperator(MondayValue);
        /// <summary> Tuesday. </summary>
        public static ExtensibleEnumWithOperator Tuesday { get; } = new ExtensibleEnumWithOperator(TuesdayValue);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ExtensibleEnumWithOperator other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ExtensibleEnumWithOperator other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
