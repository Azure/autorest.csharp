// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The property is for NFS share only. The default is NoRootSquash. </summary>
    public readonly partial struct RootSquashType : IEquatable<RootSquashType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RootSquashType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RootSquashType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoRootSquashValue = "NoRootSquash";
        private const string RootSquashValue = "RootSquash";
        private const string AllSquashValue = "AllSquash";

        /// <summary> NoRootSquash. </summary>
        public static RootSquashType NoRootSquash { get; } = new RootSquashType(NoRootSquashValue);
        /// <summary> RootSquash. </summary>
        public static RootSquashType RootSquash { get; } = new RootSquashType(RootSquashValue);
        /// <summary> AllSquash. </summary>
        public static RootSquashType AllSquash { get; } = new RootSquashType(AllSquashValue);
        /// <summary> Determines if two <see cref="RootSquashType"/> values are the same. </summary>
        public static bool operator ==(RootSquashType left, RootSquashType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RootSquashType"/> values are not the same. </summary>
        public static bool operator !=(RootSquashType left, RootSquashType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RootSquashType"/>. </summary>
        public static implicit operator RootSquashType(string value) => new RootSquashType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RootSquashType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RootSquashType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
