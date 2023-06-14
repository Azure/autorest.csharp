// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace ApiVersionInCadl.Models
{
    /// <summary> Detection results for the given resultId. </summary>
    public partial class DetectionResult
    {
        /// <summary> Initializes a new instance of DetectionResult. </summary>
        /// <param name="resultId"> Result identifier, which is used to fetch the results of an inference call. </param>
        internal DetectionResult(Guid resultId)
        {
            ResultId = resultId;
        }

        /// <summary> Result identifier, which is used to fetch the results of an inference call. </summary>
        public Guid ResultId { get; }
    }
}
