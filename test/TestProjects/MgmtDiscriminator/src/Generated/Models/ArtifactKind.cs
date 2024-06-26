// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> Specifies the kind of blueprint artifact. </summary>
    internal readonly partial struct ArtifactKind : IEquatable<ArtifactKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ArtifactKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ArtifactKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TemplateValue = "template";
        private const string RoleAssignmentValue = "roleAssignment";
        private const string PolicyAssignmentValue = "policyAssignment";

        /// <summary> template. </summary>
        public static ArtifactKind Template { get; } = new ArtifactKind(TemplateValue);
        /// <summary> roleAssignment. </summary>
        public static ArtifactKind RoleAssignment { get; } = new ArtifactKind(RoleAssignmentValue);
        /// <summary> policyAssignment. </summary>
        public static ArtifactKind PolicyAssignment { get; } = new ArtifactKind(PolicyAssignmentValue);
        /// <summary> Determines if two <see cref="ArtifactKind"/> values are the same. </summary>
        public static bool operator ==(ArtifactKind left, ArtifactKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ArtifactKind"/> values are not the same. </summary>
        public static bool operator !=(ArtifactKind left, ArtifactKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ArtifactKind"/>. </summary>
        public static implicit operator ArtifactKind(string value) => new ArtifactKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ArtifactKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ArtifactKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
