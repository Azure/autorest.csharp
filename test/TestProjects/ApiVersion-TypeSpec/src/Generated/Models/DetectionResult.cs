// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ApiVersionInTsp.Models
{
    /// <summary> Detection results for the given resultId. </summary>
    public partial class DetectionResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of DetectionResult. </summary>
        /// <param name="resultId"> Result identifier, which is used to fetch the results of an inference call. </param>
        internal DetectionResult(Guid resultId)
        {
            ResultId = resultId;
        }

        /// <summary> Initializes a new instance of DetectionResult. </summary>
        /// <param name="resultId"> Result identifier, which is used to fetch the results of an inference call. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DetectionResult(Guid resultId, Dictionary<string, BinaryData> rawData)
        {
            ResultId = resultId;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="DetectionResult"/> for deserialization. </summary>
        internal DetectionResult()
        {
        }

        /// <summary> Result identifier, which is used to fetch the results of an inference call. </summary>
        public Guid ResultId { get; }
    }
}
