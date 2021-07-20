// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace ExactMatchInheritance
{
    /// <summary> A Class representing a ExactMatchModel5 along with the instance operations that can be performed on it. </summary>
    public class ExactMatchModel5 : ExactMatchModel5Operations
    {
        /// <summary> Initializes a new instance of the <see cref = "ExactMatchModel5"/> class for mocking. </summary>
        internal ExactMatchModel5() : base()
        {
        }
        /// <summary> Initializes a new instance of the <see cref = "ExactMatchModel5"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal ExactMatchModel5(OperationsBase options, ExactMatchModel5Data resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the ExactMatchModel5Data. </summary>
        public ExactMatchModel5Data Data { get; private set; }
    }
}
