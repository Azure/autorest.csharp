// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class DocumentLinkedEntities
    {
        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; set; }
        /// <summary> Recognized well-known entities in the document. </summary>
        public ICollection<LinkedEntity> Entities { get; set; } = new List<LinkedEntity>();
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public DocumentStatistics? Statistics { get; set; }
    }
}
