// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace MgmtMultipleParentResource
{
    /// <summary> A Class representing a AnotherParent along with the instance operations that can be performed on it. </summary>
    public class AnotherParent : AnotherParentOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "AnotherParent"/> class for mocking. </summary>
        protected AnotherParent() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "AnotherParent"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal AnotherParent(OperationsBase options, AnotherParentData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the AnotherParentData. </summary>
        public virtual AnotherParentData Data { get; private set; }
    }
}
