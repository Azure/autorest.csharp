// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace ExactMatchFlattenInheritance
{
    /// <summary> A Class representing a CustomModel3 along with the instance operations that can be performed on it. </summary>
    public class CustomModel3 : CustomModel3Operations
    {
        /// <summary> Initializes a new instance of the <see cref = "CustomModel3"/> class for mocking. </summary>
        internal CustomModel3() : base()
        {
        }
        /// <summary> Initializes a new instance of the <see cref = "CustomModel3"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal CustomModel3(OperationsBase options, CustomModel3Data resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the CustomModel3Data. </summary>
        public CustomModel3Data Data { get; private set; }
    }
}
