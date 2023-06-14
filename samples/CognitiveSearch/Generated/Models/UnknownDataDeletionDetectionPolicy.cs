// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> The UnknownDataDeletionDetectionPolicy. </summary>
    internal partial class UnknownDataDeletionDetectionPolicy : DataDeletionDetectionPolicy
    {
        /// <summary> Initializes a new instance of UnknownDataDeletionDetectionPolicy. </summary>
        /// <param name="odataType"> Identifies the concrete type of the data deletion detection policy. </param>
        internal UnknownDataDeletionDetectionPolicy(string odataType) : base(odataType)
        {
            OdataType = odataType ?? "Unknown";
        }
    }
}
