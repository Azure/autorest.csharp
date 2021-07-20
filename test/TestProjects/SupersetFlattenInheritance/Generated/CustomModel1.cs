// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace SupersetFlattenInheritance
{
    /// <summary> A Class representing a CustomModel1 along with the instance operations that can be performed on it. </summary>
    public class CustomModel1 : CustomModel1Operations
    {
        /// <summary> Initializes a new instance of the <see cref = "CustomModel1"/> class for mocking. </summary>
        internal CustomModel1()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "CustomModel1"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal CustomModel1(OperationsBase options, CustomModel1Data resource)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the CustomModel1Data. </summary>
        public CustomModel1Data Data { get; private set; }
    }
}
