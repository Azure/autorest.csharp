// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtScopeResource.Models
{
    /// <summary> A value indicating compliance status of the machine for the assigned guest configuration. </summary>
    public readonly partial struct ComplianceStatus : IEquatable<ComplianceStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ComplianceStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ComplianceStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CompliantValue = "Compliant";
        private const string NonCompliantValue = "NonCompliant";
        private const string PendingValue = "Pending";

        /// <summary> Compliant. </summary>
        public static ComplianceStatus Compliant { get; } = new ComplianceStatus(CompliantValue);
        /// <summary> NonCompliant. </summary>
        public static ComplianceStatus NonCompliant { get; } = new ComplianceStatus(NonCompliantValue);
        /// <summary> Pending. </summary>
        public static ComplianceStatus Pending { get; } = new ComplianceStatus(PendingValue);
        /// <summary> Determines if two <see cref="ComplianceStatus"/> values are the same. </summary>
        public static bool operator ==(ComplianceStatus left, ComplianceStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ComplianceStatus"/> values are not the same. </summary>
        public static bool operator !=(ComplianceStatus left, ComplianceStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ComplianceStatus"/>. </summary>
        public static implicit operator ComplianceStatus(string value) => new ComplianceStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ComplianceStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ComplianceStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
