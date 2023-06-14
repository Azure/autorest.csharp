// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The reason for the restriction. As of now this can be "QuotaId" or "NotAvailableForSubscription". Quota Id is set when the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The "NotAvailableForSubscription" is related to capacity at DC. </summary>
    public readonly partial struct ReasonCode : IEquatable<ReasonCode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ReasonCode"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ReasonCode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string QuotaIdValue = "QuotaId";
        private const string NotAvailableForSubscriptionValue = "NotAvailableForSubscription";

        /// <summary> QuotaId. </summary>
        public static ReasonCode QuotaId { get; } = new ReasonCode(QuotaIdValue);
        /// <summary> NotAvailableForSubscription. </summary>
        public static ReasonCode NotAvailableForSubscription { get; } = new ReasonCode(NotAvailableForSubscriptionValue);
        /// <summary> Determines if two <see cref="ReasonCode"/> values are the same. </summary>
        public static bool operator ==(ReasonCode left, ReasonCode right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ReasonCode"/> values are not the same. </summary>
        public static bool operator !=(ReasonCode left, ReasonCode right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ReasonCode"/>. </summary>
        public static implicit operator ReasonCode(string value) => new ReasonCode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ReasonCode other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ReasonCode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
