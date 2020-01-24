// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class DocumentLanguage
    {
        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; set; }
        /// <summary> A list of extracted languages. </summary>
        public ICollection<DetectedLanguage> DetectedLanguages { get; set; } = new System.Collections.Generic.List<CognitiveServices.TextAnalytics.Models.DetectedLanguage>();
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public DocumentStatistics Statistics { get; set; }
    }
}
