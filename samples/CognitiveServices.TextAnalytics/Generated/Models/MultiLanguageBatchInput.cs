// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> Contains a set of input documents to be analyzed by the service. </summary>
    public partial class MultiLanguageBatchInput
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::CognitiveServices.TextAnalytics.Models.MultiLanguageBatchInput
        ///
        /// </summary>
        /// <param name="documents"> The set of documents to process as part of this batch. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="documents"/> is null. </exception>
        public MultiLanguageBatchInput(IEnumerable<MultiLanguageInput> documents)
        {
            Argument.AssertNotNull(documents, nameof(documents));

            Documents = documents.ToList();
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveServices.TextAnalytics.Models.MultiLanguageBatchInput
        ///
        /// </summary>
        /// <param name="documents"> The set of documents to process as part of this batch. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal MultiLanguageBatchInput(IList<MultiLanguageInput> documents, Dictionary<string, BinaryData> rawData)
        {
            Documents = documents;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="MultiLanguageBatchInput"/> for deserialization. </summary>
        internal MultiLanguageBatchInput()
        {
        }

        /// <summary> The set of documents to process as part of this batch. </summary>
        public IList<MultiLanguageInput> Documents { get; }
    }
}
