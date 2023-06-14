// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Storage.Tables
{
    /// <summary> The Enum2. </summary>
    public readonly partial struct ResponseFormat : IEquatable<ResponseFormat>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ResponseFormat"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ResponseFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ApplicationJsonOdataNometadataValue = "application/json;odata=nometadata";
        private const string ApplicationJsonOdataMinimalmetadataValue = "application/json;odata=minimalmetadata";
        private const string ApplicationJsonOdataFullmetadataValue = "application/json;odata=fullmetadata";

        /// <summary> application/json;odata=nometadata. </summary>
        public static ResponseFormat ApplicationJsonOdataNometadata { get; } = new ResponseFormat(ApplicationJsonOdataNometadataValue);
        /// <summary> application/json;odata=minimalmetadata. </summary>
        public static ResponseFormat ApplicationJsonOdataMinimalmetadata { get; } = new ResponseFormat(ApplicationJsonOdataMinimalmetadataValue);
        /// <summary> application/json;odata=fullmetadata. </summary>
        public static ResponseFormat ApplicationJsonOdataFullmetadata { get; } = new ResponseFormat(ApplicationJsonOdataFullmetadataValue);
        /// <summary> Determines if two <see cref="ResponseFormat"/> values are the same. </summary>
        public static bool operator ==(ResponseFormat left, ResponseFormat right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ResponseFormat"/> values are not the same. </summary>
        public static bool operator !=(ResponseFormat left, ResponseFormat right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ResponseFormat"/>. </summary>
        public static implicit operator ResponseFormat(string value) => new ResponseFormat(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ResponseFormat other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ResponseFormat other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
