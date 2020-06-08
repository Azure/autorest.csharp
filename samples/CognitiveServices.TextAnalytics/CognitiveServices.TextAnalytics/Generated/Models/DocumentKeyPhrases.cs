// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The DocumentKeyPhrases. </summary>
    public partial class DocumentKeyPhrases
    {
        /// <summary> Initializes a new instance of DocumentKeyPhrases. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="keyPhrases"> A list of representative words or phrases. The number of key phrases returned is proportional to the number of words in the input document. </param>
        internal DocumentKeyPhrases(string id, IEnumerable<string> keyPhrases)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (keyPhrases == null)
            {
                throw new ArgumentNullException(nameof(keyPhrases));
            }

            Id = id;
            KeyPhrases = keyPhrases.ToArray();
        }

        /// <summary> Initializes a new instance of DocumentKeyPhrases. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="keyPhrases"> A list of representative words or phrases. The number of key phrases returned is proportional to the number of words in the input document. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        internal DocumentKeyPhrases(string id, IReadOnlyList<string> keyPhrases, DocumentStatistics statistics)
        {
            Id = id;
            KeyPhrases = keyPhrases ?? new List<string>();
            Statistics = statistics;
        }

        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; }
        /// <summary> A list of representative words or phrases. The number of key phrases returned is proportional to the number of words in the input document. </summary>
        public IReadOnlyList<string> KeyPhrases { get; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public DocumentStatistics Statistics { get; }
    }
}
