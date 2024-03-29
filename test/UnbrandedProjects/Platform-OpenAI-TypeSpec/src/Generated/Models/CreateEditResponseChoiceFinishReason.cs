// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Models
{
    /// <summary> Enum for finish_reason in CreateEditResponseChoice. </summary>
    public readonly partial struct CreateEditResponseChoiceFinishReason : IEquatable<CreateEditResponseChoiceFinishReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateEditResponseChoiceFinishReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateEditResponseChoiceFinishReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StopValue = "stop";
        private const string LengthValue = "length";

        /// <summary> stop. </summary>
        public static CreateEditResponseChoiceFinishReason Stop { get; } = new CreateEditResponseChoiceFinishReason(StopValue);
        /// <summary> length. </summary>
        public static CreateEditResponseChoiceFinishReason Length { get; } = new CreateEditResponseChoiceFinishReason(LengthValue);
        /// <summary> Determines if two <see cref="CreateEditResponseChoiceFinishReason"/> values are the same. </summary>
        public static bool operator ==(CreateEditResponseChoiceFinishReason left, CreateEditResponseChoiceFinishReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateEditResponseChoiceFinishReason"/> values are not the same. </summary>
        public static bool operator !=(CreateEditResponseChoiceFinishReason left, CreateEditResponseChoiceFinishReason right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateEditResponseChoiceFinishReason"/>. </summary>
        public static implicit operator CreateEditResponseChoiceFinishReason(string value) => new CreateEditResponseChoiceFinishReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateEditResponseChoiceFinishReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateEditResponseChoiceFinishReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
