// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The LanguageBatchInput. </summary>
    public partial class LanguageBatchInput
    {
        /// <summary> Initializes a new instance of LanguageBatchInput. </summary>
        /// <param name="documents"> . </param>
        public LanguageBatchInput(IEnumerable<LanguageInput> documents)
        {
            if (documents == null)
            {
                throw new ArgumentNullException(nameof(documents));
            }

            Documents = documents.ToList();
        }

        /// <summary> Initializes a new instance of LanguageBatchInput. </summary>
        /// <param name="documents"> . </param>
        internal LanguageBatchInput(IList<LanguageInput> documents)
        {
            Documents = documents;
        }

        public IList<LanguageInput> Documents { get; }
    }
}
