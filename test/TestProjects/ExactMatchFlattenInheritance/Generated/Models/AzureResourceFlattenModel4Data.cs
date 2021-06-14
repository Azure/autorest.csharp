// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace ExactMatchFlattenInheritance
{
    /// <summary> A class representing the AzureResourceFlattenModel4 data model. </summary>
    public partial class AzureResourceFlattenModel4Data
    {
        /// <summary> Initializes a new instance of AzureResourceFlattenModel4Data. </summary>
        public AzureResourceFlattenModel4Data()
        {
        }

        /// <summary> Initializes a new instance of AzureResourceFlattenModel4Data. </summary>
        /// <param name="foo"> New property. </param>
        /// <param name="id"> . </param>
        /// <param name="name"> . </param>
        /// <param name="type"> . </param>
        internal AzureResourceFlattenModel4Data(int? foo, int? id, string name, string type)
        {
            Foo = foo;
            Id = id;
            Name = name;
            Type = type;
        }

        /// <summary> New property. </summary>
        public int? Foo { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
