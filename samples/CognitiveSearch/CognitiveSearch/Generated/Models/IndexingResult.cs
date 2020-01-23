// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Status of an indexing operation for a single document. </summary>
    public partial class IndexingResult
    {
        /// <summary> The key of a document that was in the indexing request. </summary>
        public string? Key { get; internal set; }
        /// <summary> The error message explaining why the indexing operation failed for the document identified by the key; null if indexing succeeded. </summary>
        public string? ErrorMessage { get; internal set; }
        /// <summary> A value indicating whether the indexing operation succeeded for the document identified by the key. </summary>
        public bool? Succeeded { get; internal set; }
        /// <summary> The status code of the indexing operation. Possible values include: 200 for a successful update or delete, 201 for successful document creation, 400 for a malformed input document, 404 for document not found, 409 for a version conflict, 422 when the index is temporarily unavailable, or 503 for when the service is too busy. </summary>
        public int? StatusCode { get; internal set; }
    }
}
