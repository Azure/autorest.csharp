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
    /// <summary> The DocumentKeyPhrases. </summary>
    public partial class DocumentKeyPhrases
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::CognitiveServices.TextAnalytics.Models.DocumentKeyPhrases
        ///
        /// </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="keyPhrases"> A list of representative words or phrases. The number of key phrases returned is proportional to the number of words in the input document. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="keyPhrases"/> or <paramref name="warnings"/> is null. </exception>
        internal DocumentKeyPhrases(string id, IEnumerable<string> keyPhrases, IEnumerable<TextAnalyticsWarning> warnings)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(keyPhrases, nameof(keyPhrases));
            Argument.AssertNotNull(warnings, nameof(warnings));

            Id = id;
            KeyPhrases = keyPhrases.ToList();
            Warnings = warnings.ToList();
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveServices.TextAnalytics.Models.DocumentKeyPhrases
        ///
        /// </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="keyPhrases"> A list of representative words or phrases. The number of key phrases returned is proportional to the number of words in the input document. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DocumentKeyPhrases(string id, IReadOnlyList<string> keyPhrases, IReadOnlyList<TextAnalyticsWarning> warnings, DocumentStatistics statistics, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            KeyPhrases = keyPhrases;
            Warnings = warnings;
            Statistics = statistics;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="DocumentKeyPhrases"/> for deserialization. </summary>
        internal DocumentKeyPhrases()
        {
        }

        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; }
        /// <summary> A list of representative words or phrases. The number of key phrases returned is proportional to the number of words in the input document. </summary>
        public IReadOnlyList<string> KeyPhrases { get; }
        /// <summary> Warnings encountered while processing document. </summary>
        public IReadOnlyList<TextAnalyticsWarning> Warnings { get; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public DocumentStatistics Statistics { get; }
    }
}
