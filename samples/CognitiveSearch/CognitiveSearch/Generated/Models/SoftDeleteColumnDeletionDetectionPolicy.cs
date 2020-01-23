// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Defines a data deletion detection policy that implements a soft-deletion strategy. It determines whether an item should be deleted based on the value of a designated &apos;soft delete&apos; column. </summary>
    public partial class SoftDeleteColumnDeletionDetectionPolicy : DataDeletionDetectionPolicy
    {
        /// <summary> Initializes a new instance of SoftDeleteColumnDeletionDetectionPolicy. </summary>
        public SoftDeleteColumnDeletionDetectionPolicy()
        {
            OdataType = "#Microsoft.Azure.Search.SoftDeleteColumnDeletionDetectionPolicy";
        }
        /// <summary> The name of the column to use for soft-deletion detection. </summary>
        public string? SoftDeleteColumnName { get; set; }
        /// <summary> The marker value that identifies an item as deleted. </summary>
        public string? SoftDeleteMarkerValue { get; set; }
    }
}
