// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace required_optional.Models
{
    /// <summary> The Product. </summary>
    public partial class Product
    {
        /// <summary> Initializes a new instance of Product. </summary>
        /// <param name="id"></param>
        public Product(int id)
        {
            Id = id;
        }

        /// <summary> Gets the id. </summary>
        public int Id { get; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
    }
}
