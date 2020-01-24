// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class KeyPhraseResult
    {
        /// <summary> Response by document. </summary>
        public ICollection<DocumentKeyPhrases> Documents { get; set; } = new List<DocumentKeyPhrases>();
        /// <summary> Errors by document id. </summary>
        public ICollection<DocumentError> Errors { get; set; } = new List<DocumentError>();
        /// <summary> if showStats=true was specified in the request this field will contain information about the request payload. </summary>
        public RequestStatistics Statistics { get; set; }
        /// <summary> This field indicates which model is used for scoring. </summary>
        public string ModelVersion { get; set; }
    }
}
