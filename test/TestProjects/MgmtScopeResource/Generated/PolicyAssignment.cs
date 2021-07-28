// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace MgmtScopeResource
{
    /// <summary> A Class representing a PolicyAssignment along with the instance operations that can be performed on it. </summary>
    public class PolicyAssignment : PolicyAssignmentOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "PolicyAssignment"/> class for mocking. </summary>
        protected PolicyAssignment() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "PolicyAssignment"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal PolicyAssignment(OperationsBase options, PolicyAssignmentData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the PolicyAssignmentData. </summary>
        public virtual PolicyAssignmentData Data { get; private set; }
    }
}
