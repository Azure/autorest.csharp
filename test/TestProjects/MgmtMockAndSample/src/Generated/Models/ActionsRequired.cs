// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtMockAndSample.Models
{
    /// <summary> A message indicating if changes on the service provider require any updates on the consumer. </summary>
    public readonly partial struct ActionsRequired : IEquatable<ActionsRequired>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ActionsRequired"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ActionsRequired(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "None";

        /// <summary> None. </summary>
        public static ActionsRequired None { get; } = new ActionsRequired(NoneValue);
        /// <summary> Determines if two <see cref="ActionsRequired"/> values are the same. </summary>
        public static bool operator ==(ActionsRequired left, ActionsRequired right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ActionsRequired"/> values are not the same. </summary>
        public static bool operator !=(ActionsRequired left, ActionsRequired right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ActionsRequired"/>. </summary>
        public static implicit operator ActionsRequired(string value) => new ActionsRequired(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ActionsRequired other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ActionsRequired other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
