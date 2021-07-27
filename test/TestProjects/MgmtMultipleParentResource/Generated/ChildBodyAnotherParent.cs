// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace MgmtMultipleParentResource
{
    /// <summary> A Class representing a ChildBodyAnotherParent along with the instance operations that can be performed on it. </summary>
    public class ChildBodyAnotherParent : ChildBodyAnotherParentOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "ChildBodyAnotherParent"/> class for mocking. </summary>
        protected ChildBodyAnotherParent() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ChildBodyAnotherParent"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal ChildBodyAnotherParent(OperationsBase options, ChildBodyData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the ChildBodyData. </summary>
        public virtual ChildBodyData Data { get; private set; }
    }
}
