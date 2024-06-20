// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtPartialResource.Models
{
    /// <summary> Specify what happens to the public IP address when the VM using it is deleted. </summary>
    public readonly partial struct DeleteOption : IEquatable<DeleteOption>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DeleteOption"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DeleteOption(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string DeleteValue = "Delete";
        private const string DetachValue = "Detach";

        /// <summary> Delete. </summary>
        public static DeleteOption Delete { get; } = new DeleteOption(DeleteValue);
        /// <summary> Detach. </summary>
        public static DeleteOption Detach { get; } = new DeleteOption(DetachValue);
        /// <summary> Determines if two <see cref="DeleteOption"/> values are the same. </summary>
        public static bool operator ==(DeleteOption left, DeleteOption right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DeleteOption"/> values are not the same. </summary>
        public static bool operator !=(DeleteOption left, DeleteOption right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DeleteOption"/>. </summary>
        public static implicit operator DeleteOption(string value) => new DeleteOption(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DeleteOption other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DeleteOption other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
