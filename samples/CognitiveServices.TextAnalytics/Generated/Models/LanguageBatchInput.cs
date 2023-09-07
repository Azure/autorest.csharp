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
    /// <summary> The LanguageBatchInput. </summary>
    public partial class LanguageBatchInput
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="LanguageBatchInput"/>. </summary>
        /// <param name="documents"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="documents"/> is null. </exception>
        public LanguageBatchInput(IEnumerable<LanguageInput> documents)
        {
            Argument.AssertNotNull(documents, nameof(documents));

            Documents = documents.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="LanguageBatchInput"/>. </summary>
        /// <param name="documents"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal LanguageBatchInput(IList<LanguageInput> documents, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Documents = documents;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="LanguageBatchInput"/> for deserialization. </summary>
        internal LanguageBatchInput()
        {
        }

        /// <summary> Gets the documents. </summary>
        public IList<LanguageInput> Documents { get; }
    }
}
