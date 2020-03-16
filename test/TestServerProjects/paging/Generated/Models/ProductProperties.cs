// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace paging.Models
{
    /// <summary> The ProductProperties. </summary>
    public partial class ProductProperties
    {
        /// <summary> Initializes a new instance of ProductProperties. </summary>
        internal ProductProperties()
        {
        }
        /// <summary> Initializes a new instance of ProductProperties. </summary>
        /// <param name="id"> . </param>
        /// <param name="name"> . </param>
        internal ProductProperties(int? id, string name)
        {
            Id = id;
            Name = name;
        }
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
