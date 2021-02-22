// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace TenantOnly
{
    /// <summary> The category of the agreement signed by a customer. </summary>
    public readonly partial struct Category : IEquatable<Category>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="Category"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Category(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftCustomerAgreementValue = "MicrosoftCustomerAgreement";
        private const string AffiliatePurchaseTermsValue = "AffiliatePurchaseTerms";
        private const string OtherValue = "Other";

        /// <summary> MicrosoftCustomerAgreement. </summary>
        public static Category MicrosoftCustomerAgreement { get; } = new Category(MicrosoftCustomerAgreementValue);
        /// <summary> AffiliatePurchaseTerms. </summary>
        public static Category AffiliatePurchaseTerms { get; } = new Category(AffiliatePurchaseTermsValue);
        /// <summary> Other. </summary>
        public static Category Other { get; } = new Category(OtherValue);
        /// <summary> Determines if two <see cref="Category"/> values are the same. </summary>
        public static bool operator ==(Category left, Category right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Category"/> values are not the same. </summary>
        public static bool operator !=(Category left, Category right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Category"/>. </summary>
        public static implicit operator Category(string value) => new Category(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Category other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Category other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
