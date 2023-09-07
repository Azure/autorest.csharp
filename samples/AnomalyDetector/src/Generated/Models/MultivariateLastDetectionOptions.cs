// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> Request of last detection. </summary>
    public partial class MultivariateLastDetectionOptions
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of MultivariateLastDetectionOptions. </summary>
        /// <param name="variables">
        /// This contains the inference data, including the name, timestamps(ISO 8601) and
        /// values of variables.
        /// </param>
        /// <param name="topContributorCount">
        /// An optional field, which is used to specify the number of top contributed
        /// variables for one anomalous timestamp in the response. The default number is
        /// 10.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="variables"/> is null. </exception>
        public MultivariateLastDetectionOptions(IEnumerable<VariableValues> variables, int topContributorCount)
        {
            Argument.AssertNotNull(variables, nameof(variables));

            Variables = variables.ToList();
            TopContributorCount = topContributorCount;
        }

        /// <summary> Initializes a new instance of MultivariateLastDetectionOptions. </summary>
        /// <param name="variables">
        /// This contains the inference data, including the name, timestamps(ISO 8601) and
        /// values of variables.
        /// </param>
        /// <param name="topContributorCount">
        /// An optional field, which is used to specify the number of top contributed
        /// variables for one anomalous timestamp in the response. The default number is
        /// 10.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MultivariateLastDetectionOptions(IList<VariableValues> variables, int topContributorCount, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Variables = variables;
            TopContributorCount = topContributorCount;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MultivariateLastDetectionOptions"/> for deserialization. </summary>
        internal MultivariateLastDetectionOptions()
        {
        }

        /// <summary>
        /// This contains the inference data, including the name, timestamps(ISO 8601) and
        /// values of variables.
        /// </summary>
        public IList<VariableValues> Variables { get; }
        /// <summary>
        /// An optional field, which is used to specify the number of top contributed
        /// variables for one anomalous timestamp in the response. The default number is
        /// 10.
        /// </summary>
        public int TopContributorCount { get; }
    }
}
