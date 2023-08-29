// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtScopeResource.Models
{
    /// <summary> Deployment What-If operation settings. </summary>
    internal partial class DeploymentWhatIfSettings
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="DeploymentWhatIfSettings"/>. </summary>
        public DeploymentWhatIfSettings()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DeploymentWhatIfSettings"/>. </summary>
        /// <param name="resultFormat"> The format of the What-If results. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DeploymentWhatIfSettings(WhatIfResultFormat? resultFormat, Dictionary<string, BinaryData> rawData)
        {
            ResultFormat = resultFormat;
            _rawData = rawData;
        }

        /// <summary> The format of the What-If results. </summary>
        public WhatIfResultFormat? ResultFormat { get; set; }
    }
}
