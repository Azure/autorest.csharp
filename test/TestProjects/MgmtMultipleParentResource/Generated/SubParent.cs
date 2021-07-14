// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;
using MgmtMultipleParentResource.Models;

namespace MgmtMultipleParentResource
{
    /// <summary> A Class representing a SubParent along with the instance operations that can be performed on it. </summary>
    public class SubParent : SubParentOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "SubParent"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal SubParent(OperationsBase options, SubParentData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the SubParentData. </summary>
        public SubParentData Data { get; private set; }
    }
}
