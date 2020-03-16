// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The EntitiesResult. </summary>
    public partial class EntitiesResult
    {
        /// <summary> Initializes a new instance of EntitiesResult. </summary>
        internal EntitiesResult()
        {
        }
        /// <summary> Initializes a new instance of EntitiesResult. </summary>
        /// <param name="documents"> Response by document. </param>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        internal EntitiesResult(IList<DocumentEntities> documents, IList<DocumentError> errors, RequestStatistics statistics, string modelVersion)
        {
            Documents = documents;
            Errors = errors;
            Statistics = statistics;
            ModelVersion = modelVersion;
        }
        /// <summary> Response by document. </summary>
        public IList<DocumentEntities> Documents { get; set; } = new List<DocumentEntities>();
        /// <summary> Errors by document id. </summary>
        public IList<DocumentError> Errors { get; set; } = new List<DocumentError>();
        /// <summary> if showStats=true was specified in the request this field will contain information about the request payload. </summary>
        public RequestStatistics Statistics { get; set; }
        /// <summary> This field indicates which model is used for scoring. </summary>
        public string ModelVersion { get; set; }
    }
}
