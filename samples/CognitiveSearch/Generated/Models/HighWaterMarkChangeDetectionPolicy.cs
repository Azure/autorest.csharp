// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Defines a data change detection policy that captures changes based on the value of a high water mark column. </summary>
    public partial class HighWaterMarkChangeDetectionPolicy : DataChangeDetectionPolicy
    {
        /// <summary> Initializes a new instance of HighWaterMarkChangeDetectionPolicy. </summary>
        /// <param name="highWaterMarkColumnName"> The name of the high water mark column. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="highWaterMarkColumnName"/> is null. </exception>
        public HighWaterMarkChangeDetectionPolicy(string highWaterMarkColumnName)
        {
            Argument.AssertNotNull(highWaterMarkColumnName, nameof(highWaterMarkColumnName));

            HighWaterMarkColumnName = highWaterMarkColumnName;
            OdataType = "#Microsoft.Azure.Search.HighWaterMarkChangeDetectionPolicy";
        }

        /// <summary> Initializes a new instance of HighWaterMarkChangeDetectionPolicy. </summary>
        /// <param name="odataType"> Identifies the concrete type of the data change detection policy. </param>
        /// <param name="highWaterMarkColumnName"> The name of the high water mark column. </param>
        internal HighWaterMarkChangeDetectionPolicy(string odataType, string highWaterMarkColumnName) : base(odataType)
        {
            HighWaterMarkColumnName = highWaterMarkColumnName;
            OdataType = odataType ?? "#Microsoft.Azure.Search.HighWaterMarkChangeDetectionPolicy";
        }

        /// <summary> The name of the high water mark column. </summary>
        public string HighWaterMarkColumnName { get; set; }
    }
}
