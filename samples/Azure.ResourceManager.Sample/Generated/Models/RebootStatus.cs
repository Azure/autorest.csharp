// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> The reboot status of the machine after the patch operation. It will be in &quot;NotNeeded&quot; status if reboot is not needed after the patch operation. &quot;Required&quot; will be the status once the patch is applied and machine is required to reboot. &quot;Started&quot; will be the reboot status when the machine has started to reboot. &quot;Failed&quot; will be the status if the machine is failed to reboot. &quot;Completed&quot; will be the status once the machine is rebooted successfully. </summary>
    public readonly partial struct RebootStatus : IEquatable<RebootStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of RebootStatus. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RebootStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotNeededValue = "NotNeeded";
        private const string RequiredValue = "Required";
        private const string StartedValue = "Started";
        private const string FailedValue = "Failed";
        private const string CompletedValue = "Completed";

        /// <summary> NotNeeded. </summary>
        public static RebootStatus NotNeeded { get; } = new RebootStatus(NotNeededValue);
        /// <summary> Required. </summary>
        public static RebootStatus Required { get; } = new RebootStatus(RequiredValue);
        /// <summary> Started. </summary>
        public static RebootStatus Started { get; } = new RebootStatus(StartedValue);
        /// <summary> Failed. </summary>
        public static RebootStatus Failed { get; } = new RebootStatus(FailedValue);
        /// <summary> Completed. </summary>
        public static RebootStatus Completed { get; } = new RebootStatus(CompletedValue);
        /// <summary> Determines if two <see cref="RebootStatus"/> values are the same. </summary>
        public static bool operator ==(RebootStatus left, RebootStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RebootStatus"/> values are not the same. </summary>
        public static bool operator !=(RebootStatus left, RebootStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RebootStatus"/>. </summary>
        public static implicit operator RebootStatus(string value) => new RebootStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RebootStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RebootStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
