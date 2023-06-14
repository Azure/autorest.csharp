// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtConstants.Models
{
    /// <summary> The OptionalMachineExpand. </summary>
    public readonly partial struct OptionalMachineExpand : IEquatable<OptionalMachineExpand>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="OptionalMachineExpand"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OptionalMachineExpand(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InstanceViewValue = "instanceView";

        /// <summary> instanceView. </summary>
        public static OptionalMachineExpand InstanceView { get; } = new OptionalMachineExpand(InstanceViewValue);
        /// <summary> Determines if two <see cref="OptionalMachineExpand"/> values are the same. </summary>
        public static bool operator ==(OptionalMachineExpand left, OptionalMachineExpand right) => left.Equals(right);
        /// <summary> Determines if two <see cref="OptionalMachineExpand"/> values are not the same. </summary>
        public static bool operator !=(OptionalMachineExpand left, OptionalMachineExpand right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="OptionalMachineExpand"/>. </summary>
        public static implicit operator OptionalMachineExpand(string value) => new OptionalMachineExpand(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OptionalMachineExpand other && Equals(other);
        /// <inheritdoc />
        public bool Equals(OptionalMachineExpand other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
