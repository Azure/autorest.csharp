// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> The UnknownDataChangeDetectionPolicy. </summary>
    internal partial class UnknownDataChangeDetectionPolicy : DataChangeDetectionPolicy
    {
        /// <summary> Initializes a new instance of <see cref="UnknownDataChangeDetectionPolicy"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the data change detection policy. </param>
        internal UnknownDataChangeDetectionPolicy(string odataType) : base(odataType)
        {
            OdataType = odataType ?? "Unknown";
        }
    }
}
