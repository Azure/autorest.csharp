// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Defines a data change detection policy that captures changes based on the value of a high water mark column. </summary>
    public partial class HighWaterMarkChangeDetectionPolicy : DataChangeDetectionPolicy
    {
        /// <summary> Initializes a new instance of HighWaterMarkChangeDetectionPolicy. </summary>
        public HighWaterMarkChangeDetectionPolicy()
        {
            OdataType = "#Microsoft.Azure.Search.HighWaterMarkChangeDetectionPolicy";
        }
        /// <summary> The name of the high water mark column. </summary>
        public string HighWaterMarkColumnName { get; set; }
    }
}
