// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary>
    /// Base type for data change detection policies.
    /// Please note <see cref="DataChangeDetectionPolicy"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="HighWaterMarkChangeDetectionPolicy"/> and <see cref="SqlIntegratedChangeTrackingPolicy"/>.
    /// </summary>
    public partial class DataChangeDetectionPolicy
    {
        /// <summary> Initializes a new instance of DataChangeDetectionPolicy. </summary>
        public DataChangeDetectionPolicy()
        {
        }

        /// <summary> Initializes a new instance of DataChangeDetectionPolicy. </summary>
        /// <param name="odataType"> Identifies the concrete type of the data change detection policy. </param>
        internal DataChangeDetectionPolicy(string odataType)
        {
            OdataType = odataType;
        }

        /// <summary> Identifies the concrete type of the data change detection policy. </summary>
        internal string OdataType { get; set; }
    }
}
