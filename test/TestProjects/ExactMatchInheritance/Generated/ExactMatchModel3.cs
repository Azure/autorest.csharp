// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace ExactMatchInheritance
{
    /// <summary> A Class representing a ExactMatchModel3 along with the instance operations that can be performed on it. </summary>
    public class ExactMatchModel3 : ExactMatchModel3Operations
    {
        /// <summary> Initializes a new instance of the <see cref = "ExactMatchModel3"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal ExactMatchModel3(OperationsBase options, ExactMatchModel3Data resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the ExactMatchModel3Data. </summary>
        public ExactMatchModel3Data Data { get; private set; }
    }
}
