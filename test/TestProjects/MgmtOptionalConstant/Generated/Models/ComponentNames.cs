// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtOptionalConstant.Models
{
    /// <summary> The component name. Currently, the only allowable value is Microsoft-Windows-Shell-Setup. </summary>
    public readonly partial struct ComponentNames : IEquatable<ComponentNames>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ComponentNames"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ComponentNames(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftWindowsShellSetupValue = "Microsoft-Windows-Shell-Setup";

        /// <summary> Microsoft-Windows-Shell-Setup. </summary>
        public static ComponentNames MicrosoftWindowsShellSetup { get; } = new ComponentNames(MicrosoftWindowsShellSetupValue);
        /// <summary> Determines if two <see cref="ComponentNames"/> values are the same. </summary>
        public static bool operator ==(ComponentNames left, ComponentNames right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ComponentNames"/> values are not the same. </summary>
        public static bool operator !=(ComponentNames left, ComponentNames right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ComponentNames"/>. </summary>
        public static implicit operator ComponentNames(string value) => new ComponentNames(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ComponentNames other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ComponentNames other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
