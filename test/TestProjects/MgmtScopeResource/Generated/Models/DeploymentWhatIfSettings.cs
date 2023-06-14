// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtScopeResource.Models
{
    /// <summary> Deployment What-If operation settings. </summary>
    internal partial class DeploymentWhatIfSettings
    {
        /// <summary> Initializes a new instance of DeploymentWhatIfSettings. </summary>
        public DeploymentWhatIfSettings()
        {
        }

        /// <summary> The format of the What-If results. </summary>
        public WhatIfResultFormat? ResultFormat { get; set; }
    }
}
