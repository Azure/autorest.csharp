// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using CognitiveServices.TextAnalytics;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> Contains a set of input documents to be analyzed by the service. </summary>
    public partial class MultiLanguageBatchInput
    {
        /// <summary> Initializes a new instance of <see cref="MultiLanguageBatchInput"/>. </summary>
        /// <param name="documents"> The set of documents to process as part of this batch. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="documents"/> is null. </exception>
        public MultiLanguageBatchInput(IEnumerable<MultiLanguageInput> documents)
        {
            Argument.AssertNotNull(documents, nameof(documents));

            Documents = documents.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="MultiLanguageBatchInput"/>. </summary>
        /// <param name="documents"> The set of documents to process as part of this batch. </param>
        internal MultiLanguageBatchInput(IList<MultiLanguageInput> documents)
        {
            Documents = documents;
        }

        /// <summary> The set of documents to process as part of this batch. </summary>
        public IList<MultiLanguageInput> Documents { get; }
    }
}
