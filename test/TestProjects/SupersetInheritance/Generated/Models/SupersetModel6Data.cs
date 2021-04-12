// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace SupersetInheritance
{
    /// <summary> A class representing the SupersetModel6 data model. </summary>
    public partial class SupersetModel6Data : SupersetModel7
    {
        /// <summary> Initializes a new instance of SupersetModel6Data. </summary>
        public SupersetModel6Data()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel6Data. </summary>
        /// <param name="type"> . </param>
        /// <param name="id"> . </param>
        /// <param name="name"> . </param>
        internal SupersetModel6Data(string type, string id, string name) : base(type)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
