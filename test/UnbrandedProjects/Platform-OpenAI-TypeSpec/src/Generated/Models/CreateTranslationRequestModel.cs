// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace OpenAI.Models
{
    /// <summary> Enum for model in CreateTranslationRequest. </summary>
    public readonly partial struct CreateTranslationRequestModel : IEquatable<CreateTranslationRequestModel>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CreateTranslationRequestModel"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CreateTranslationRequestModel(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Whisper1Value = "whisper-1";

        /// <summary> whisper-1. </summary>
        public static CreateTranslationRequestModel Whisper1 { get; } = new CreateTranslationRequestModel(Whisper1Value);
        /// <summary> Determines if two <see cref="CreateTranslationRequestModel"/> values are the same. </summary>
        public static bool operator ==(CreateTranslationRequestModel left, CreateTranslationRequestModel right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CreateTranslationRequestModel"/> values are not the same. </summary>
        public static bool operator !=(CreateTranslationRequestModel left, CreateTranslationRequestModel right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CreateTranslationRequestModel"/>. </summary>
        public static implicit operator CreateTranslationRequestModel(string value) => new CreateTranslationRequestModel(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CreateTranslationRequestModel other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CreateTranslationRequestModel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
