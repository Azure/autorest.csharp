// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.Resources.Sample
{
    /// <summary> A Class representing a DeploymentExtended along with the instance operations that can be performed on it. </summary>
    public class DeploymentExtended : DeploymentExtendedOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "DeploymentExtended"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal DeploymentExtended(OperationsBase options, DeploymentExtendedData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the DeploymentExtendedData. </summary>
        public DeploymentExtendedData Data { get; private set; }
    }
}
