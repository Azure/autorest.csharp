// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Filter to apply to the documents in the source path for training. </summary>
    public partial class TrainSourceFilter
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="TrainSourceFilter"/>. </summary>
        public TrainSourceFilter()
        {
        }

        /// <summary> Initializes a new instance of <see cref="TrainSourceFilter"/>. </summary>
        /// <param name="prefix"> A case-sensitive prefix string to filter documents in the source path for training. For example, when using a Azure storage blob Uri, use the prefix to restrict sub folders for training. </param>
        /// <param name="includeSubFolders"> A flag to indicate if sub folders within the set of prefix folders will also need to be included when searching for content to be preprocessed. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TrainSourceFilter(string prefix, bool? includeSubFolders, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Prefix = prefix;
            IncludeSubFolders = includeSubFolders;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> A case-sensitive prefix string to filter documents in the source path for training. For example, when using a Azure storage blob Uri, use the prefix to restrict sub folders for training. </summary>
        public string Prefix { get; set; }
        /// <summary> A flag to indicate if sub folders within the set of prefix folders will also need to be included when searching for content to be preprocessed. </summary>
        public bool? IncludeSubFolders { get; set; }
    }
}
