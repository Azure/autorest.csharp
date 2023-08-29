// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Custom model copy result. </summary>
    public partial class CopyResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.AI.FormRecognizer.Models.CopyResult
        ///
        /// </summary>
        /// <param name="modelId"> Identifier of the target model. </param>
        internal CopyResult(Guid modelId)
        {
            ModelId = modelId;
            Errors = new ChangeTrackingList<ErrorInformation>();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.AI.FormRecognizer.Models.CopyResult
        ///
        /// </summary>
        /// <param name="modelId"> Identifier of the target model. </param>
        /// <param name="errors"> Errors returned during the copy operation. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal CopyResult(Guid modelId, IReadOnlyList<ErrorInformation> errors, Dictionary<string, BinaryData> rawData)
        {
            ModelId = modelId;
            Errors = errors;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="CopyResult"/> for deserialization. </summary>
        internal CopyResult()
        {
        }

        /// <summary> Identifier of the target model. </summary>
        public Guid ModelId { get; }
        /// <summary> Errors returned during the copy operation. </summary>
        public IReadOnlyList<ErrorInformation> Errors { get; }
    }
}
