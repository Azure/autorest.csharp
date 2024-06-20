// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The name of the action for the delivery rule. </summary>
    internal readonly partial struct DeliveryRuleActionType : IEquatable<DeliveryRuleActionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleActionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DeliveryRuleActionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CacheExpirationValue = "CacheExpiration";
        private const string CacheKeyQueryStringValue = "CacheKeyQueryString";
        private const string ModifyRequestHeaderValue = "ModifyRequestHeader";
        private const string ModifyResponseHeaderValue = "ModifyResponseHeader";
        private const string UrlRedirectValue = "UrlRedirect";
        private const string UrlRewriteValue = "UrlRewrite";
        private const string UrlSigningValue = "UrlSigning";
        private const string OriginGroupOverrideValue = "OriginGroupOverride";
        private const string RouteConfigurationOverrideValue = "RouteConfigurationOverride";

        /// <summary> CacheExpiration. </summary>
        public static DeliveryRuleActionType CacheExpiration { get; } = new DeliveryRuleActionType(CacheExpirationValue);
        /// <summary> CacheKeyQueryString. </summary>
        public static DeliveryRuleActionType CacheKeyQueryString { get; } = new DeliveryRuleActionType(CacheKeyQueryStringValue);
        /// <summary> ModifyRequestHeader. </summary>
        public static DeliveryRuleActionType ModifyRequestHeader { get; } = new DeliveryRuleActionType(ModifyRequestHeaderValue);
        /// <summary> ModifyResponseHeader. </summary>
        public static DeliveryRuleActionType ModifyResponseHeader { get; } = new DeliveryRuleActionType(ModifyResponseHeaderValue);
        /// <summary> UrlRedirect. </summary>
        public static DeliveryRuleActionType UrlRedirect { get; } = new DeliveryRuleActionType(UrlRedirectValue);
        /// <summary> UrlRewrite. </summary>
        public static DeliveryRuleActionType UrlRewrite { get; } = new DeliveryRuleActionType(UrlRewriteValue);
        /// <summary> UrlSigning. </summary>
        public static DeliveryRuleActionType UrlSigning { get; } = new DeliveryRuleActionType(UrlSigningValue);
        /// <summary> OriginGroupOverride. </summary>
        public static DeliveryRuleActionType OriginGroupOverride { get; } = new DeliveryRuleActionType(OriginGroupOverrideValue);
        /// <summary> RouteConfigurationOverride. </summary>
        public static DeliveryRuleActionType RouteConfigurationOverride { get; } = new DeliveryRuleActionType(RouteConfigurationOverrideValue);
        /// <summary> Determines if two <see cref="DeliveryRuleActionType"/> values are the same. </summary>
        public static bool operator ==(DeliveryRuleActionType left, DeliveryRuleActionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DeliveryRuleActionType"/> values are not the same. </summary>
        public static bool operator !=(DeliveryRuleActionType left, DeliveryRuleActionType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DeliveryRuleActionType"/>. </summary>
        public static implicit operator DeliveryRuleActionType(string value) => new DeliveryRuleActionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DeliveryRuleActionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DeliveryRuleActionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value);
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
