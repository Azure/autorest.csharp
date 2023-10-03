// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Models
{
    /// <summary> Enum for model in CreateEditRequest. </summary>
    public readonly partial struct CreateEditRequestModel : IEquatable<CreateEditRequestModel>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateEditRequestModel"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateEditRequestModel(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string TextDavinciEdit001Value = "text-davinci-edit-001";
        private const string CodeDavinciEdit001Value = "code-davinci-edit-001";

        /// <summary> text-davinci-edit-001. </summary>
        public static CreateEditRequestModel TextDavinciEdit001 { get; } = new CreateEditRequestModel(TextDavinciEdit001Value);
        /// <summary> code-davinci-edit-001. </summary>
        public static CreateEditRequestModel CodeDavinciEdit001 { get; } = new CreateEditRequestModel(CodeDavinciEdit001Value);
        /// <summary> Determines if two <see cref="CreateEditRequestModel"/> values are the same. </summary>
        public static bool operator ==(CreateEditRequestModel left, CreateEditRequestModel right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateEditRequestModel"/> values are not the same. </summary>
        public static bool operator !=(CreateEditRequestModel left, CreateEditRequestModel right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateEditRequestModel"/>. </summary>
        public static implicit operator CreateEditRequestModel(string value) => new CreateEditRequestModel(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateEditRequestModel other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateEditRequestModel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
