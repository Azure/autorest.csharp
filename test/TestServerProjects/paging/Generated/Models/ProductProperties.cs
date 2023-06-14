// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <param name="id"></param>
        /// <param name="name"></param>
        internal ProductProperties(int? id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary> Gets the id. </summary>
        public int? Id { get; }
        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
