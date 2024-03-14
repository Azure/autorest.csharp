// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using MgmtScopeResource;

namespace MgmtScopeResource.Models
{
    /// <summary> Deployment operation parameters. </summary>
    public partial class Deployment
    {
        /// <summary> Initializes a new instance of <see cref="Deployment"/>. </summary>
        /// <param name="properties"> The deployment properties. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public Deployment(DeploymentProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="Deployment"/>. </summary>
        /// <param name="location"> The location to store the deployment data. </param>
        /// <param name="properties"> The deployment properties. </param>
        /// <param name="tags"> Deployment tags. </param>
        internal Deployment(string location, DeploymentProperties properties, IDictionary<string, string> tags)
        {
            Location = location;
            Properties = properties;
            Tags = tags;
        }

        /// <summary> The location to store the deployment data. </summary>
        public string Location { get; set; }
        /// <summary> The deployment properties. </summary>
        public DeploymentProperties Properties { get; }
        /// <summary> Deployment tags. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
