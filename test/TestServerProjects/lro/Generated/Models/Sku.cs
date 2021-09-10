// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
        /// <param name="name"> The Name. </param>
        /// <param name="id"> The Id. </param>
        internal Sku(string name, string id)
        {
            Name = name;
            Id = id;
        }

        /// <summary> The Name. </summary>
        public string Name { get; set; }
        /// <summary> The Id. </summary>
        public string Id { get; set; }
    }
}
