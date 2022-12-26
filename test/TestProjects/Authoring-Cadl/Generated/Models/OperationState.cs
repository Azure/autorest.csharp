// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Language.Authoring.Models
{
    public readonly partial struct OperationState : IEquatable<OperationState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="OperationState"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OperationState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InProgressValue = "InProgress";
        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";
        private const string CanceledValue = "Canceled";

        /// <summary> InProgress. </summary>
        public static OperationState InProgress { get; } = new OperationState(InProgressValue);
        /// <summary> Succeeded. </summary>
        public static OperationState Succeeded { get; } = new OperationState(SucceededValue);
        /// <summary> Failed. </summary>
        public static OperationState Failed { get; } = new OperationState(FailedValue);
        /// <summary> Canceled. </summary>
        public static OperationState Canceled { get; } = new OperationState(CanceledValue);
        /// <summary> Determines if two <see cref="OperationState"/> values are the same. </summary>
        public static bool operator ==(OperationState left, OperationState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="OperationState"/> values are not the same. </summary>
        public static bool operator !=(OperationState left, OperationState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="OperationState"/>. </summary>
        public static implicit operator OperationState(string value) => new OperationState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OperationState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(OperationState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
