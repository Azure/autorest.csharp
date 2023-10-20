// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtScopeResource.Models
{
    /// <summary> Deployment operation information. </summary>
    public partial class DeploymentOperation
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DeploymentOperation"/>. </summary>
        internal DeploymentOperation()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DeploymentOperation"/>. </summary>
        /// <param name="id"> Full deployment operation ID. </param>
        /// <param name="operationId"> Deployment operation ID. </param>
        /// <param name="properties"> Deployment properties. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DeploymentOperation(string id, string operationId, DeploymentOperationProperties properties, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            OperationId = operationId;
            Properties = properties;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Full deployment operation ID. </summary>
        public string Id { get; }
        /// <summary> Deployment operation ID. </summary>
        public string OperationId { get; }
        /// <summary> Deployment properties. </summary>
        public DeploymentOperationProperties Properties { get; }
    }
}
