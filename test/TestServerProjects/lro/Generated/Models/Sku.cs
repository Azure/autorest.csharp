// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace lro.Models
{
    /// <summary> The Sku. </summary>
    public partial class Sku
    {
        /// <summary> Initializes a new instance of Sku. </summary>
        public Sku()
        {
        }

        /// <summary> Initializes a new instance of Sku. </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        internal Sku(string name, string id)
        {
            Name = name;
            Id = id;
        }

        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the id. </summary>
        public string Id { get; set; }
    }
}
