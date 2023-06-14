// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Defines a data deletion detection policy that implements a soft-deletion strategy. It determines whether an item should be deleted based on the value of a designated 'soft delete' column. </summary>
    public partial class SoftDeleteColumnDeletionDetectionPolicy : DataDeletionDetectionPolicy
    {
        /// <summary> Initializes a new instance of SoftDeleteColumnDeletionDetectionPolicy. </summary>
        public SoftDeleteColumnDeletionDetectionPolicy()
        {
            OdataType = "#Microsoft.Azure.Search.SoftDeleteColumnDeletionDetectionPolicy";
        }

        /// <summary> Initializes a new instance of SoftDeleteColumnDeletionDetectionPolicy. </summary>
        /// <param name="odataType"> Identifies the concrete type of the data deletion detection policy. </param>
        /// <param name="softDeleteColumnName"> The name of the column to use for soft-deletion detection. </param>
        /// <param name="softDeleteMarkerValue"> The marker value that identifies an item as deleted. </param>
        internal SoftDeleteColumnDeletionDetectionPolicy(string odataType, string softDeleteColumnName, string softDeleteMarkerValue) : base(odataType)
        {
            SoftDeleteColumnName = softDeleteColumnName;
            SoftDeleteMarkerValue = softDeleteMarkerValue;
            OdataType = odataType ?? "#Microsoft.Azure.Search.SoftDeleteColumnDeletionDetectionPolicy";
        }

        /// <summary> The name of the column to use for soft-deletion detection. </summary>
        public string SoftDeleteColumnName { get; set; }
        /// <summary> The marker value that identifies an item as deleted. </summary>
        public string SoftDeleteMarkerValue { get; set; }
    }
}
