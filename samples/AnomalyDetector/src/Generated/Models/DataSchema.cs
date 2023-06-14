// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace AnomalyDetector.Models
{
    /// <summary> Data schema of input data source: OneTable or MultiTable. The default DataSchema is OneTable. </summary>
    public readonly partial struct DataSchema : IEquatable<DataSchema>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DataSchema"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DataSchema(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string OneTableValue = "OneTable";
        private const string MultiTableValue = "MultiTable";

        /// <summary> OneTable means that your input data are all in one CSV file, which contains one 'timestamp' column and several variable columns. The default DataSchema is OneTable. </summary>
        public static DataSchema OneTable { get; } = new DataSchema(OneTableValue);
        /// <summary> MultiTable means that your input data are separated in multiple CSV files, in each file containing one 'timestamp' column and one 'variable' column, and the CSV file name should indicate the name of the variable. The default DataSchema is OneTable. </summary>
        public static DataSchema MultiTable { get; } = new DataSchema(MultiTableValue);
        /// <summary> Determines if two <see cref="DataSchema"/> values are the same. </summary>
        public static bool operator ==(DataSchema left, DataSchema right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DataSchema"/> values are not the same. </summary>
        public static bool operator !=(DataSchema left, DataSchema right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DataSchema"/>. </summary>
        public static implicit operator DataSchema(string value) => new DataSchema(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DataSchema other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DataSchema other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
