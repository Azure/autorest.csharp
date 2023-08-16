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
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.AI.FormRecognizer.Models.TrainSourceFilter
        ///
        /// </summary>
        public TrainSourceFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.AI.FormRecognizer.Models.TrainSourceFilter
        ///
        /// </summary>
        /// <param name="prefix"> A case-sensitive prefix string to filter documents in the source path for training. For example, when using a Azure storage blob Uri, use the prefix to restrict sub folders for training. </param>
        /// <param name="includeSubFolders"> A flag to indicate if sub folders within the set of prefix folders will also need to be included when searching for content to be preprocessed. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal TrainSourceFilter(string prefix, bool? includeSubFolders, Dictionary<string, BinaryData> rawData)
        {
            Prefix = prefix;
            IncludeSubFolders = includeSubFolders;
            _rawData = rawData;
        }

        /// <summary> A case-sensitive prefix string to filter documents in the source path for training. For example, when using a Azure storage blob Uri, use the prefix to restrict sub folders for training. </summary>
        public string Prefix { get; set; }
        /// <summary> A flag to indicate if sub folders within the set of prefix folders will also need to be included when searching for content to be preprocessed. </summary>
        public bool? IncludeSubFolders { get; set; }
    }
}
