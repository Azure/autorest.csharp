// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Custom model copy result. </summary>
    public partial class CopyResult
    {
        /// <summary> Initializes a new instance of CopyResult. </summary>
        /// <param name="modelId"> Identifier of the target model. </param>
        internal CopyResult(Guid modelId)
        {
            ModelId = modelId;
            Errors = new ChangeTrackingList<ErrorInformation>();
        }

        /// <summary> Initializes a new instance of CopyResult. </summary>
        /// <param name="modelId"> Identifier of the target model. </param>
        /// <param name="errors"> Errors returned during the copy operation. </param>
        internal CopyResult(Guid modelId, IReadOnlyList<ErrorInformation> errors)
        {
            ModelId = modelId;
            Errors = errors;
        }

        /// <summary> Identifier of the target model. </summary>
        public Guid ModelId { get; }
        /// <summary> Errors returned during the copy operation. </summary>
        public IReadOnlyList<ErrorInformation> Errors { get; }
    }
}
