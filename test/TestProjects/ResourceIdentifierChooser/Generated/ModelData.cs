// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace ResourceIdentifierChooser
{
    /// <summary> A Class representing a ModelData along with the instance operations that can be performed on it. </summary>
    public class ModelData : ModelDataOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "ModelData"/> class for mocking. </summary>
        internal ModelData() : base()
        {
        }
        /// <summary> Initializes a new instance of the <see cref = "ModelData"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal ModelData(OperationsBase options, ModelDataData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the ModelDataData. </summary>
        public ModelDataData Data { get; private set; }
    }
}
