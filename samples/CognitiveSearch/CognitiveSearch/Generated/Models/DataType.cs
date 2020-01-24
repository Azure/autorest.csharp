// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace CognitiveSearch.Models
{
    /// <summary> Defines the data type of a field in a search index. </summary>
    public readonly partial struct DataType : IEquatable<DataType>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="DataType"/> values are the same. </summary>
        public DataType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EdmStringValue = "Edm.String";
        private const string EdmInt32Value = "Edm.Int32";
        private const string EdmInt64Value = "Edm.Int64";
        private const string EdmDoubleValue = "Edm.Double";
        private const string EdmBooleanValue = "Edm.Boolean";
        private const string EdmDateTimeOffsetValue = "Edm.DateTimeOffset";
        private const string EdmGeographyPointValue = "Edm.GeographyPoint";
        private const string EdmComplexTypeValue = "Edm.ComplexType";

        /// <summary> The value &apos;undefined&apos;. </summary>
        public static DataType EdmString { get; } = new DataType(EdmStringValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static DataType EdmInt32 { get; } = new DataType(EdmInt32Value);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static DataType EdmInt64 { get; } = new DataType(EdmInt64Value);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static DataType EdmDouble { get; } = new DataType(EdmDoubleValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static DataType EdmBoolean { get; } = new DataType(EdmBooleanValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static DataType EdmDateTimeOffset { get; } = new DataType(EdmDateTimeOffsetValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static DataType EdmGeographyPoint { get; } = new DataType(EdmGeographyPointValue);
        /// <summary> The value &apos;undefined&apos;. </summary>
        public static DataType EdmComplexType { get; } = new DataType(EdmComplexTypeValue);
        /// <summary> Determines if two <see cref="DataType"/> values are the same. </summary>
        public static bool operator ==(DataType left, DataType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DataType"/> values are not the same. </summary>
        public static bool operator !=(DataType left, DataType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DataType"/>. </summary>
        public static implicit operator DataType(string value) => new DataType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is DataType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DataType other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
