// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace MgmtListMethods
{
    /// <summary> A Class representing a TheExtension along with the instance operations that can be performed on it. </summary>
    public class TheExtension : TheExtensionOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "TheExtension"/> class for mocking. </summary>
        protected TheExtension() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "TheExtension"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal TheExtension(ResourceOperations options, TheExtensionData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the TheExtensionData. </summary>
        public virtual TheExtensionData Data { get; private set; }
    }
}
