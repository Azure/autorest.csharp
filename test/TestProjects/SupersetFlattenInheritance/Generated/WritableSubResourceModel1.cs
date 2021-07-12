// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace SupersetFlattenInheritance
{
    /// <summary> A Class representing a WritableSubResourceModel1 along with the instance operations that can be performed on it. </summary>
    public class WritableSubResourceModel1 : WritableSubResourceModel1Operations
    {
        /// <summary> Initializes a new instance of the <see cref = "WritableSubResourceModel1"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal WritableSubResourceModel1(ResourceOperationsBase options, WritableSubResourceModel1Data resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the WritableSubResourceModel1Data. </summary>
        public WritableSubResourceModel1Data Data { get; private set; }
    }
}
