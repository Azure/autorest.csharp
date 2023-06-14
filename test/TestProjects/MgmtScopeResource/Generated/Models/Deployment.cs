// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    /// <summary> Deployment operation parameters. </summary>
    public partial class Deployment
    {
        /// <summary> Initializes a new instance of Deployment. </summary>
        /// <param name="properties"> The deployment properties. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public Deployment(DeploymentProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> The location to store the deployment data. </summary>
        public string Location { get; set; }
        /// <summary> The deployment properties. </summary>
        public DeploymentProperties Properties { get; }
        /// <summary> Deployment tags. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
