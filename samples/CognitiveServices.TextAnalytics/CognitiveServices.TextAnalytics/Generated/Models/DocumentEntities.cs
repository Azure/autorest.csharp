// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The DocumentEntities. </summary>
    public partial class DocumentEntities
    {
        /// <summary> Initializes a new instance of DocumentEntities. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="entities"> Recognized entities in the document. </param>
        internal DocumentEntities(string id, IReadOnlyList<Entity> entities)
        {
            Id = id;
            Entities = entities;
        }

        /// <summary> Initializes a new instance of DocumentEntities. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="entities"> Recognized entities in the document. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        internal DocumentEntities(string id, IReadOnlyList<Entity> entities, DocumentStatistics statistics)
        {
            Id = id;
            Entities = entities;
            Statistics = statistics;
        }

        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; }
        /// <summary> Recognized entities in the document. </summary>
        public IReadOnlyList<Entity> Entities { get; } = new List<Entity>();
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public DocumentStatistics Statistics { get; }
    }
}
