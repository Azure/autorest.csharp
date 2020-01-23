// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace CognitiveSearch.Models
{
    /// <summary> Provides parameter values to a freshness scoring function. </summary>
    public partial class FreshnessScoringParameters
    {
        /// <summary> The expiration period after which boosting will stop for a particular document. </summary>
        public TimeSpan BoostingDuration { get; set; }
    }
}
