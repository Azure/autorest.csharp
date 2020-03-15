// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace body_complex.Models
{
    /// <summary> The Pet. </summary>
    public partial class Pet
    {
        /// <summary> Initializes a new instance of Pet. </summary>
        internal Pet()
        {
        }
        /// <summary> Initializes a new instance of Pet. </summary>
        internal Pet(int? id, string name)
        {
            Id = id;
            Name = name;
        }
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
