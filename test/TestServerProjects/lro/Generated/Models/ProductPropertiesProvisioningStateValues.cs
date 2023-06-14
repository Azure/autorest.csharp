// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace lro.Models
{
    /// <summary> The ProductPropertiesProvisioningStateValues. </summary>
    public readonly partial struct ProductPropertiesProvisioningStateValues : IEquatable<ProductPropertiesProvisioningStateValues>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ProductPropertiesProvisioningStateValues"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ProductPropertiesProvisioningStateValues(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";
        private const string CanceledValue = "canceled";
        private const string AcceptedValue = "Accepted";
        private const string CreatingValue = "Creating";
        private const string CreatedValue = "Created";
        private const string UpdatingValue = "Updating";
        private const string UpdatedValue = "Updated";
        private const string DeletingValue = "Deleting";
        private const string DeletedValue = "Deleted";
        private const string OKValue = "OK";

        /// <summary> Succeeded. </summary>
        public static ProductPropertiesProvisioningStateValues Succeeded { get; } = new ProductPropertiesProvisioningStateValues(SucceededValue);
        /// <summary> Failed. </summary>
        public static ProductPropertiesProvisioningStateValues Failed { get; } = new ProductPropertiesProvisioningStateValues(FailedValue);
        /// <summary> canceled. </summary>
        public static ProductPropertiesProvisioningStateValues Canceled { get; } = new ProductPropertiesProvisioningStateValues(CanceledValue);
        /// <summary> Accepted. </summary>
        public static ProductPropertiesProvisioningStateValues Accepted { get; } = new ProductPropertiesProvisioningStateValues(AcceptedValue);
        /// <summary> Creating. </summary>
        public static ProductPropertiesProvisioningStateValues Creating { get; } = new ProductPropertiesProvisioningStateValues(CreatingValue);
        /// <summary> Created. </summary>
        public static ProductPropertiesProvisioningStateValues Created { get; } = new ProductPropertiesProvisioningStateValues(CreatedValue);
        /// <summary> Updating. </summary>
        public static ProductPropertiesProvisioningStateValues Updating { get; } = new ProductPropertiesProvisioningStateValues(UpdatingValue);
        /// <summary> Updated. </summary>
        public static ProductPropertiesProvisioningStateValues Updated { get; } = new ProductPropertiesProvisioningStateValues(UpdatedValue);
        /// <summary> Deleting. </summary>
        public static ProductPropertiesProvisioningStateValues Deleting { get; } = new ProductPropertiesProvisioningStateValues(DeletingValue);
        /// <summary> Deleted. </summary>
        public static ProductPropertiesProvisioningStateValues Deleted { get; } = new ProductPropertiesProvisioningStateValues(DeletedValue);
        /// <summary> OK. </summary>
        public static ProductPropertiesProvisioningStateValues OK { get; } = new ProductPropertiesProvisioningStateValues(OKValue);
        /// <summary> Determines if two <see cref="ProductPropertiesProvisioningStateValues"/> values are the same. </summary>
        public static bool operator ==(ProductPropertiesProvisioningStateValues left, ProductPropertiesProvisioningStateValues right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ProductPropertiesProvisioningStateValues"/> values are not the same. </summary>
        public static bool operator !=(ProductPropertiesProvisioningStateValues left, ProductPropertiesProvisioningStateValues right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ProductPropertiesProvisioningStateValues"/>. </summary>
        public static implicit operator ProductPropertiesProvisioningStateValues(string value) => new ProductPropertiesProvisioningStateValues(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ProductPropertiesProvisioningStateValues other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ProductPropertiesProvisioningStateValues other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
