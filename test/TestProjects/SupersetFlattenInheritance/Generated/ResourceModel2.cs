// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace SupersetFlattenInheritance
{
    /// <summary> A Class representing a ResourceModel2 along with the instance operations that can be performed on it. </summary>
    public class ResourceModel2 : ResourceModel2Operations
    {
        /// <summary> Initializes a new instance of the <see cref = "ResourceModel2"/> class for mocking. </summary>
        protected ResourceModel2() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ResourceModel2"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal ResourceModel2(ResourceOperations options, ResourceModel2Data resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the ResourceModel2Data. </summary>
        public virtual ResourceModel2Data Data { get; private set; }
    }
}
