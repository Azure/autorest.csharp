// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A Class representing a Image along with the instance operations that can be performed on it. </summary>
    public class Image : ImageOperations
    {
        /// <summary> Initializes a new instance of the <see cref="Image"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal Image(ResourceOperationsBase options, ImageData resource) : base(options, resource.Id)
        {
        }

        /// <summary> Gets or sets the resource data. </summary>
        public Image Data { get; private set; }
    }
}
