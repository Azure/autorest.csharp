// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The DocumentLinkedEntities. </summary>
    public partial class DocumentLinkedEntities
    {
        /// <summary> Initializes a new instance of DocumentLinkedEntities. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="entities"> Recognized well-known entities in the document. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="entities"/> or <paramref name="warnings"/> is null. </exception>
        internal DocumentLinkedEntities(string id, IEnumerable<LinkedEntity> entities, IEnumerable<TextAnalyticsWarning> warnings)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(entities, nameof(entities));
            Argument.AssertNotNull(warnings, nameof(warnings));

            Id = id;
            Entities = entities.ToList();
            Warnings = warnings.ToList();
        }

        /// <summary> Initializes a new instance of DocumentLinkedEntities. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="entities"> Recognized well-known entities in the document. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        internal DocumentLinkedEntities(string id, IReadOnlyList<LinkedEntity> entities, IReadOnlyList<TextAnalyticsWarning> warnings, DocumentStatistics statistics)
        {
            Id = id;
            Entities = entities;
            Warnings = warnings;
            Statistics = statistics;
        }

        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; }
        /// <summary> Recognized well-known entities in the document. </summary>
        public IReadOnlyList<LinkedEntity> Entities { get; }
        /// <summary> Warnings encountered while processing document. </summary>
        public IReadOnlyList<TextAnalyticsWarning> Warnings { get; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public DocumentStatistics Statistics { get; }
    }
}
