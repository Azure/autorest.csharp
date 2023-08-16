// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary>
    /// Base type for data deletion detection policies.
    /// Please note <see cref="DataDeletionDetectionPolicy"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="SoftDeleteColumnDeletionDetectionPolicy"/>.
    /// </summary>
    public partial class DataDeletionDetectionPolicy
    {
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.DataDeletionDetectionPolicy
        ///
        /// </summary>
        public DataDeletionDetectionPolicy()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.DataDeletionDetectionPolicy
        ///
        /// </summary>
        /// <param name="odataType"> Identifies the concrete type of the data deletion detection policy. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DataDeletionDetectionPolicy(string odataType, Dictionary<string, BinaryData> rawData)
        {
            OdataType = odataType;
            _rawData = rawData;
        }

        /// <summary> Identifies the concrete type of the data deletion detection policy. </summary>
        internal string OdataType { get; set; }
    }
}
