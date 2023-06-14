// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtScopeResource.Models
{
    /// <summary> The onboarding status for the resource. Note that, a higher level scope, e.g., resource group or subscription, is considered onboarded if at least one resource under it is onboarded. </summary>
    public readonly partial struct OnboardingStatus : IEquatable<OnboardingStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="OnboardingStatus"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OnboardingStatus(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string OnboardedValue = "onboarded";
        private const string NotOnboardedValue = "notOnboarded";
        private const string UnknownValue = "unknown";

        /// <summary> onboarded. </summary>
        public static OnboardingStatus Onboarded { get; } = new OnboardingStatus(OnboardedValue);
        /// <summary> notOnboarded. </summary>
        public static OnboardingStatus NotOnboarded { get; } = new OnboardingStatus(NotOnboardedValue);
        /// <summary> unknown. </summary>
        public static OnboardingStatus Unknown { get; } = new OnboardingStatus(UnknownValue);
        /// <summary> Determines if two <see cref="OnboardingStatus"/> values are the same. </summary>
        public static bool operator ==(OnboardingStatus left, OnboardingStatus right) => left.Equals(right);
        /// <summary> Determines if two <see cref="OnboardingStatus"/> values are not the same. </summary>
        public static bool operator !=(OnboardingStatus left, OnboardingStatus right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="OnboardingStatus"/>. </summary>
        public static implicit operator OnboardingStatus(string value) => new OnboardingStatus(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OnboardingStatus other && Equals(other);
        /// <inheritdoc />
        public bool Equals(OnboardingStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
