// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace ExactMatchFlattenInheritance
{
    /// <summary> A Class representing a AzureResourceFlattenModel1 along with the instance operations that can be performed on it. </summary>
    public class AzureResourceFlattenModel1 : AzureResourceFlattenModel1Operations
    {
        /// <summary> Initializes a new instance of the <see cref = "AzureResourceFlattenModel1"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal AzureResourceFlattenModel1(OperationsBase options, AzureResourceFlattenModel1Data resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the AzureResourceFlattenModel1Data. </summary>
        public AzureResourceFlattenModel1Data Data { get; private set; }
    }
}
