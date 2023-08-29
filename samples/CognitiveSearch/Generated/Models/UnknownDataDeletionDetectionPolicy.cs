// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> The UnknownDataDeletionDetectionPolicy. </summary>
    internal partial class UnknownDataDeletionDetectionPolicy : DataDeletionDetectionPolicy
    {
        /// <summary> Initializes a new instance of <see cref="UnknownDataDeletionDetectionPolicy"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the data deletion detection policy. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownDataDeletionDetectionPolicy(string odataType, Dictionary<string, BinaryData> rawData) : base(odataType, rawData)
        {
            OdataType = odataType ?? "Unknown";
        }

        /// <summary> Initializes a new instance of <see cref="UnknownDataDeletionDetectionPolicy"/> for deserialization. </summary>
        internal UnknownDataDeletionDetectionPolicy()
        {
        }
    }
}
