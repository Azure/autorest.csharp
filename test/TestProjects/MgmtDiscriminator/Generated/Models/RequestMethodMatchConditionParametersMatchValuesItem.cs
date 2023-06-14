// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace MgmtDiscriminator.Models
{
    /// <summary> The RequestMethodMatchConditionParametersMatchValuesItem. </summary>
    public readonly partial struct RequestMethodMatchConditionParametersMatchValuesItem : IEquatable<RequestMethodMatchConditionParametersMatchValuesItem>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RequestMethodMatchConditionParametersMatchValuesItem"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RequestMethodMatchConditionParametersMatchValuesItem(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string GETValue = "GET";
        private const string HeadValue = "HEAD";
        private const string PostValue = "POST";
        private const string PUTValue = "PUT";
        private const string DeleteValue = "DELETE";
        private const string OptionsValue = "OPTIONS";
        private const string TraceValue = "TRACE";

        /// <summary> GET. </summary>
        public static RequestMethodMatchConditionParametersMatchValuesItem GET { get; } = new RequestMethodMatchConditionParametersMatchValuesItem(GETValue);
        /// <summary> HEAD. </summary>
        public static RequestMethodMatchConditionParametersMatchValuesItem Head { get; } = new RequestMethodMatchConditionParametersMatchValuesItem(HeadValue);
        /// <summary> POST. </summary>
        public static RequestMethodMatchConditionParametersMatchValuesItem Post { get; } = new RequestMethodMatchConditionParametersMatchValuesItem(PostValue);
        /// <summary> PUT. </summary>
        public static RequestMethodMatchConditionParametersMatchValuesItem PUT { get; } = new RequestMethodMatchConditionParametersMatchValuesItem(PUTValue);
        /// <summary> DELETE. </summary>
        public static RequestMethodMatchConditionParametersMatchValuesItem Delete { get; } = new RequestMethodMatchConditionParametersMatchValuesItem(DeleteValue);
        /// <summary> OPTIONS. </summary>
        public static RequestMethodMatchConditionParametersMatchValuesItem Options { get; } = new RequestMethodMatchConditionParametersMatchValuesItem(OptionsValue);
        /// <summary> TRACE. </summary>
        public static RequestMethodMatchConditionParametersMatchValuesItem Trace { get; } = new RequestMethodMatchConditionParametersMatchValuesItem(TraceValue);
        /// <summary> Determines if two <see cref="RequestMethodMatchConditionParametersMatchValuesItem"/> values are the same. </summary>
        public static bool operator ==(RequestMethodMatchConditionParametersMatchValuesItem left, RequestMethodMatchConditionParametersMatchValuesItem right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RequestMethodMatchConditionParametersMatchValuesItem"/> values are not the same. </summary>
        public static bool operator !=(RequestMethodMatchConditionParametersMatchValuesItem left, RequestMethodMatchConditionParametersMatchValuesItem right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RequestMethodMatchConditionParametersMatchValuesItem"/>. </summary>
        public static implicit operator RequestMethodMatchConditionParametersMatchValuesItem(string value) => new RequestMethodMatchConditionParametersMatchValuesItem(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RequestMethodMatchConditionParametersMatchValuesItem other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RequestMethodMatchConditionParametersMatchValuesItem other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
