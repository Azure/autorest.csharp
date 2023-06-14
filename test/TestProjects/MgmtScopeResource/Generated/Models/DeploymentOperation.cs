// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtScopeResource.Models
{
    /// <summary> Deployment operation information. </summary>
    public partial class DeploymentOperation
    {
        /// <summary> Initializes a new instance of DeploymentOperation. </summary>
        internal DeploymentOperation()
        {
        }

        /// <summary> Initializes a new instance of DeploymentOperation. </summary>
        /// <param name="id"> Full deployment operation ID. </param>
        /// <param name="operationId"> Deployment operation ID. </param>
        /// <param name="properties"> Deployment properties. </param>
        internal DeploymentOperation(string id, string operationId, DeploymentOperationProperties properties)
        {
            Id = id;
            OperationId = operationId;
            Properties = properties;
        }

        /// <summary> Full deployment operation ID. </summary>
        public string Id { get; }
        /// <summary> Deployment operation ID. </summary>
        public string OperationId { get; }
        /// <summary> Deployment properties. </summary>
        public DeploymentOperationProperties Properties { get; }
    }
}
