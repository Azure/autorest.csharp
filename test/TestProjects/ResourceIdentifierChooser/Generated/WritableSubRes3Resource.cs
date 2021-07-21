// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace ResourceIdentifierChooser
{
    /// <summary> A Class representing a WritableSubRes3Resource along with the instance operations that can be performed on it. </summary>
    public class WritableSubRes3Resource : WritableSubRes3ResourceOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "WritableSubRes3Resource"/> class for mocking. </summary>
        protected WritableSubRes3Resource() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "WritableSubRes3Resource"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal WritableSubRes3Resource(OperationsBase options, WritableSubRes3ResourceData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the WritableSubRes3ResourceData. </summary>
        public virtual WritableSubRes3ResourceData Data { get; private set; }
    }
}
