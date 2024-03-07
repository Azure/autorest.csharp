// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.AI.FormRecognizer;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Response to the list custom models operation. </summary>
    public partial class Models
    {
        /// <summary> Initializes a new instance of <see cref="Models"/>. </summary>
        internal Models()
        {
            ModelList = new ChangeTrackingList<ModelInfo>();
        }

        /// <summary> Initializes a new instance of <see cref="Models"/>. </summary>
        /// <param name="summary"> Summary of all trained custom models. </param>
        /// <param name="modelList"> Collection of trained custom models. </param>
        /// <param name="nextLink"> Link to the next page of custom models. </param>
        internal Models(ModelsSummary summary, IReadOnlyList<ModelInfo> modelList, string nextLink)
        {
            Summary = summary;
            ModelList = modelList;
            NextLink = nextLink;
        }

        /// <summary> Summary of all trained custom models. </summary>
        public ModelsSummary Summary { get; }
        /// <summary> Collection of trained custom models. </summary>
        public IReadOnlyList<ModelInfo> ModelList { get; }
        /// <summary> Link to the next page of custom models. </summary>
        public string NextLink { get; }
    }
}
