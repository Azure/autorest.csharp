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
        /// <param name="id"> The Id. </param>
        /// <param name="name"> The Name. </param>
        /// <param name="type"> The Type. </param>
        internal AzureResourceFlattenModel4Data(int? foo, int? id, string name, string type)
        {
            Foo = foo;
            Id = id;
            Name = name;
            Type = type;
        }

        /// <summary> New property. </summary>
        public int? Foo { get; set; }
        /// <summary> The Id. </summary>
        public int? Id { get; set; }
        /// <summary> The Name. </summary>
        public string Name { get; set; }
        /// <summary> The Type. </summary>
        public string Type { get; set; }
    }
}
