// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Abstract base class for data change detection policies. </summary>
    public partial class DataChangeDetectionPolicy
    {
        /// <summary> Initializes a new instance of DataChangeDetectionPolicy. </summary>
        public DataChangeDetectionPolicy()
        {
            OdataType = null;
        }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string OdataType { get; internal set; }
    }
}
