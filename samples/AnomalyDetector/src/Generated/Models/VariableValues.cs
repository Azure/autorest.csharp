// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> Variable values. </summary>
    public partial class VariableValues
    {
        /// <summary> Initializes a new instance of VariableValues. </summary>
        /// <param name="variable"> Variable name of last detection request. </param>
        /// <param name="timestamps"> Timestamps of last detection request. </param>
        /// <param name="values"> Values of variables. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="variable"/>, <paramref name="timestamps"/> or <paramref name="values"/> is null. </exception>
        public VariableValues(string variable, IEnumerable<string> timestamps, IEnumerable<float> values)
        {
            Argument.AssertNotNull(variable, nameof(variable));
            Argument.AssertNotNull(timestamps, nameof(timestamps));
            Argument.AssertNotNull(values, nameof(values));

            Variable = variable;
            Timestamps = timestamps.ToList();
            Values = values.ToList();
        }

        /// <summary> Initializes a new instance of VariableValues. </summary>
        /// <param name="variable"> Variable name of last detection request. </param>
        /// <param name="timestamps"> Timestamps of last detection request. </param>
        /// <param name="values"> Values of variables. </param>
        internal VariableValues(string variable, IList<string> timestamps, IList<float> values)
        {
            Variable = variable;
            Timestamps = timestamps;
            Values = values;
        }

        /// <summary> Variable name of last detection request. </summary>
        public string Variable { get; }
        /// <summary> Timestamps of last detection request. </summary>
        public IList<string> Timestamps { get; }
        /// <summary> Values of variables. </summary>
        public IList<float> Values { get; }
    }
}
