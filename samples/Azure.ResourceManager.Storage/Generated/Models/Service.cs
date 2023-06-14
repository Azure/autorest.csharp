// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The signed services accessible with the account SAS. Possible values include: Blob (b), Queue (q), Table (t), File (f). </summary>
    public readonly partial struct Service : IEquatable<Service>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Service"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Service(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string BValue = "b";
        private const string QValue = "q";
        private const string TValue = "t";
        private const string FValue = "f";

        /// <summary> b. </summary>
        public static Service B { get; } = new Service(BValue);
        /// <summary> q. </summary>
        public static Service Q { get; } = new Service(QValue);
        /// <summary> t. </summary>
        public static Service T { get; } = new Service(TValue);
        /// <summary> f. </summary>
        public static Service F { get; } = new Service(FValue);
        /// <summary> Determines if two <see cref="Service"/> values are the same. </summary>
        public static bool operator ==(Service left, Service right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Service"/> values are not the same. </summary>
        public static bool operator !=(Service left, Service right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Service"/>. </summary>
        public static implicit operator Service(string value) => new Service(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Service other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Service other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
