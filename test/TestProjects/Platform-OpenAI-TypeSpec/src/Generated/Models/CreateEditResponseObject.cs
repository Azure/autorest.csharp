// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Models
{
    /// <summary> The CreateEditResponse_object. </summary>
    public readonly partial struct CreateEditResponseObject : IEquatable<CreateEditResponseObject>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateEditResponseObject"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateEditResponseObject(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EditValue = "edit";

        /// <summary> edit. </summary>
        public static CreateEditResponseObject Edit { get; } = new CreateEditResponseObject(EditValue);
        /// <summary> Determines if two <see cref="CreateEditResponseObject"/> values are the same. </summary>
        public static bool operator ==(CreateEditResponseObject left, CreateEditResponseObject right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateEditResponseObject"/> values are not the same. </summary>
        public static bool operator !=(CreateEditResponseObject left, CreateEditResponseObject right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateEditResponseObject"/>. </summary>
        public static implicit operator CreateEditResponseObject(string value) => new CreateEditResponseObject(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateEditResponseObject other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateEditResponseObject other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
