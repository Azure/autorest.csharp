// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtCollectionParent.Models
{
    /// <summary> Stage name. </summary>
    public readonly partial struct StageName : IEquatable<StageName>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StageName"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StageName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PlacedValue = "Placed";
        private const string InReviewValue = "InReview";
        private const string ConfirmedValue = "Confirmed";
        private const string ReadyToShipValue = "ReadyToShip";
        private const string ShippedValue = "Shipped";
        private const string DeliveredValue = "Delivered";
        private const string InUseValue = "InUse";
        private const string ReturnInitiatedValue = "ReturnInitiated";
        private const string ReturnPickedUpValue = "ReturnPickedUp";
        private const string ReturnedToMicrosoftValue = "ReturnedToMicrosoft";
        private const string ReturnCompletedValue = "ReturnCompleted";
        private const string CancelledValue = "Cancelled";

        /// <summary> Currently in draft mode and can still be cancelled. </summary>
        public static StageName Placed { get; } = new StageName(PlacedValue);
        /// <summary> Order is currently in draft mode and can still be cancelled. </summary>
        public static StageName InReview { get; } = new StageName(InReviewValue);
        /// <summary> Order is confirmed. </summary>
        public static StageName Confirmed { get; } = new StageName(ConfirmedValue);
        /// <summary> Order is ready to ship. </summary>
        public static StageName ReadyToShip { get; } = new StageName(ReadyToShipValue);
        /// <summary> Order is in transit to customer. </summary>
        public static StageName Shipped { get; } = new StageName(ShippedValue);
        /// <summary> Order is delivered to customer. </summary>
        public static StageName Delivered { get; } = new StageName(DeliveredValue);
        /// <summary> Order is in use at customer site. </summary>
        public static StageName InUse { get; } = new StageName(InUseValue);
        /// <summary> Return has been initiated by customer. </summary>
        public static StageName ReturnInitiated { get; } = new StageName(ReturnInitiatedValue);
        /// <summary> Order is in transit from customer to microsoft. </summary>
        public static StageName ReturnPickedUp { get; } = new StageName(ReturnPickedUpValue);
        /// <summary> Order has been received back to microsoft. </summary>
        public static StageName ReturnedToMicrosoft { get; } = new StageName(ReturnedToMicrosoftValue);
        /// <summary> Return has now completed. </summary>
        public static StageName ReturnCompleted { get; } = new StageName(ReturnCompletedValue);
        /// <summary> Order has been cancelled. </summary>
        public static StageName Cancelled { get; } = new StageName(CancelledValue);
        /// <summary> Determines if two <see cref="StageName"/> values are the same. </summary>
        public static bool operator ==(StageName left, StageName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="StageName"/> values are not the same. </summary>
        public static bool operator !=(StageName left, StageName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="StageName"/>. </summary>
        public static implicit operator StageName(string value) => new StageName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StageName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StageName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
