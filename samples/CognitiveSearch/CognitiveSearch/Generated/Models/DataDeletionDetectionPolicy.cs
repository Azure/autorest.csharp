// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Abstract base class for data deletion detection policies. </summary>
    public partial class DataDeletionDetectionPolicy
    {
        /// <summary> Initializes a new instance of DataDeletionDetectionPolicy. </summary>
        public DataDeletionDetectionPolicy()
        {
            OdataType = null;
        }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string OdataType { get; internal set; }
    }
}
