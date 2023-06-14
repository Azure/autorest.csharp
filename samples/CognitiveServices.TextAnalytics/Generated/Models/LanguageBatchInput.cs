// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The LanguageBatchInput. </summary>
    public partial class LanguageBatchInput
    {
        /// <summary> Initializes a new instance of LanguageBatchInput. </summary>
        /// <param name="documents"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="documents"/> is null. </exception>
        public LanguageBatchInput(IEnumerable<LanguageInput> documents)
        {
            Argument.AssertNotNull(documents, nameof(documents));

            Documents = documents.ToList();
        }

        /// <summary> Gets the documents. </summary>
        public IList<LanguageInput> Documents { get; }
    }
}
