// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;
using Azure.ResourceManager.Models;

namespace ExactMatchFlattenInheritance
{
    /// <summary> A class representing the AzureResourceFlattenModel5 data model. </summary>
    public partial class AzureResourceFlattenModel5Data : Resource
    {
        /// <summary> Initializes a new instance of AzureResourceFlattenModel5Data. </summary>
        public AzureResourceFlattenModel5Data()
        {
        }

        /// <summary> Initializes a new instance of AzureResourceFlattenModel5Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="foo"> New property. </param>
        internal AzureResourceFlattenModel5Data(ResourceIdentifier id, string name, ResourceType type, int? foo) : base(id, name, type)
        {
            Foo = foo;
        }

        /// <summary> New property. </summary>
        public int? Foo { get; set; }
    }
}
