// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics. </summary>
    public readonly partial struct Bypass : IEquatable<Bypass>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Bypass"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Bypass(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "None";
        private const string LoggingValue = "Logging";
        private const string MetricsValue = "Metrics";
        private const string AzureServicesValue = "AzureServices";

        /// <summary> None. </summary>
        public static Bypass None { get; } = new Bypass(NoneValue);
        /// <summary> Logging. </summary>
        public static Bypass Logging { get; } = new Bypass(LoggingValue);
        /// <summary> Metrics. </summary>
        public static Bypass Metrics { get; } = new Bypass(MetricsValue);
        /// <summary> AzureServices. </summary>
        public static Bypass AzureServices { get; } = new Bypass(AzureServicesValue);
        /// <summary> Determines if two <see cref="Bypass"/> values are the same. </summary>
        public static bool operator ==(Bypass left, Bypass right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Bypass"/> values are not the same. </summary>
        public static bool operator !=(Bypass left, Bypass right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Bypass"/>. </summary>
        public static implicit operator Bypass(string value) => new Bypass(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Bypass other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Bypass other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
