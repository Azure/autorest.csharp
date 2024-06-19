// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtListMethods.Models
{
    /// <summary> Status of update workspace quota. </summary>
    public readonly partial struct Status : IEquatable<Status>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="Status"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Status(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UndefinedValue = "Undefined";
        private const string SuccessValue = "Success";
        private const string FailureValue = "Failure";
        private const string InvalidQuotaBelowClusterMinimumValue = "InvalidQuotaBelowClusterMinimum";
        private const string InvalidQuotaExceedsSubscriptionLimitValue = "InvalidQuotaExceedsSubscriptionLimit";
        private const string InvalidVmFamilyNameValue = "InvalidVMFamilyName";
        private const string OperationNotSupportedForSkuValue = "OperationNotSupportedForSku";
        private const string OperationNotEnabledForRegionValue = "OperationNotEnabledForRegion";

        /// <summary> Undefined. </summary>
        public static Status Undefined { get; } = new Status(UndefinedValue);
        /// <summary> Success. </summary>
        public static Status Success { get; } = new Status(SuccessValue);
        /// <summary> Failure. </summary>
        public static Status Failure { get; } = new Status(FailureValue);
        /// <summary> InvalidQuotaBelowClusterMinimum. </summary>
        public static Status InvalidQuotaBelowClusterMinimum { get; } = new Status(InvalidQuotaBelowClusterMinimumValue);
        /// <summary> InvalidQuotaExceedsSubscriptionLimit. </summary>
        public static Status InvalidQuotaExceedsSubscriptionLimit { get; } = new Status(InvalidQuotaExceedsSubscriptionLimitValue);
        /// <summary> InvalidVMFamilyName. </summary>
        public static Status InvalidVmFamilyName { get; } = new Status(InvalidVmFamilyNameValue);
        /// <summary> OperationNotSupportedForSku. </summary>
        public static Status OperationNotSupportedForSku { get; } = new Status(OperationNotSupportedForSkuValue);
        /// <summary> OperationNotEnabledForRegion. </summary>
        public static Status OperationNotEnabledForRegion { get; } = new Status(OperationNotEnabledForRegionValue);
        /// <summary> Determines if two <see cref="Status"/> values are the same. </summary>
        public static bool operator ==(Status left, Status right) => left.Equals(right);
        /// <summary> Determines if two <see cref="Status"/> values are not the same. </summary>
        public static bool operator !=(Status left, Status right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="Status"/>. </summary>
        public static implicit operator Status(string value) => new Status(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Status other && Equals(other);
        /// <inheritdoc />
        public bool Equals(Status other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
