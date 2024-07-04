// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// The component name. Currently, the only allowable value is Microsoft-Windows-Shell-Setup.
    /// Serialized Name: ComponentNames
    /// </summary>
    public readonly partial struct ComponentName : IEquatable<ComponentName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ComponentName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ComponentName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftWindowsShellSetupValue = "Microsoft-Windows-Shell-Setup";

        /// <summary>
        /// Microsoft-Windows-Shell-Setup
        /// Serialized Name: ComponentNames.Microsoft-Windows-Shell-Setup
        /// </summary>
        public static ComponentName MicrosoftWindowsShellSetup { get; } = new ComponentName(MicrosoftWindowsShellSetupValue);
        /// <summary> Determines if two <see cref="ComponentName"/> values are the same. </summary>
        public static bool operator ==(ComponentName left, ComponentName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ComponentName"/> values are not the same. </summary>
        public static bool operator !=(ComponentName left, ComponentName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ComponentName"/>. </summary>
        public static implicit operator ComponentName(string value) => new ComponentName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ComponentName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ComponentName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
