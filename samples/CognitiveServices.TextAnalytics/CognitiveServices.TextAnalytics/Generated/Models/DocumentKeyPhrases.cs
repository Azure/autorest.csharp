// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The DocumentKeyPhrases. </summary>
    public partial class DocumentKeyPhrases
    {
        /// <summary> Initializes a new instance of DocumentKeyPhrases. </summary>
        internal DocumentKeyPhrases()
        {
        }

        /// <summary> Initializes a new instance of DocumentKeyPhrases. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="keyPhrases"> A list of representative words or phrases. The number of key phrases returned is proportional to the number of words in the input document. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        internal DocumentKeyPhrases(string id, IList<string> keyPhrases, DocumentStatistics statistics)
        {
            Id = id;
            KeyPhrases = keyPhrases;
            Statistics = statistics;
        }

        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; internal set; }
        /// <summary> A list of representative words or phrases. The number of key phrases returned is proportional to the number of words in the input document. </summary>
        public IList<string> KeyPhrases { get; internal set; } = new List<string>();
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public DocumentStatistics Statistics { get; internal set; }
    }
}
