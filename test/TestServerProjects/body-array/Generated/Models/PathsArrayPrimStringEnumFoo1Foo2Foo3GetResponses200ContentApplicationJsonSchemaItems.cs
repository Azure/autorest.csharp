// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace body_array.Models.V100
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
    public readonly partial struct PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems : IEquatable<PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems>
    {
        private readonly string? _value;

        /// <summary> Determines if two <see cref="PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems"/> values are the same. </summary>
        public PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Foo1Value = "foo1";
        private const string Foo2Value = "foo2";
        private const string Foo3Value = "foo3";

        /// <summary> foo1. </summary>
        public static PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems Foo1 { get; } = new PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems(Foo1Value);
        /// <summary> foo2. </summary>
        public static PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems Foo2 { get; } = new PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems(Foo2Value);
        /// <summary> foo3. </summary>
        public static PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems Foo3 { get; } = new PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems(Foo3Value);
        /// <summary> Determines if two <see cref="PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems"/> values are the same. </summary>
        public static bool operator ==(PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems left, PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems right) => left.Equals(right);
        /// <summary> Determines if two <see cref="PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems"/> values are not the same. </summary>
        public static bool operator !=(PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems left, PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems"/>. </summary>
        public static implicit operator PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems(string value) => new PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems other && Equals(other);
        /// <inheritdoc />
        public bool Equals(PathsArrayPrimStringEnumFoo1Foo2Foo3GetResponses200ContentApplicationJsonSchemaItems other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string? ToString() => _value;
    }
}
