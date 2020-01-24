// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> The operation to perform on a document in an indexing batch. </summary>
    public enum IndexActionType
    {
        /// <summary> The value &apos;undefined&apos;. </summary>
        Upload,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Merge,
        /// <summary> The value &apos;undefined&apos;. </summary>
        MergeOrUpload,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Delete
    }
}
