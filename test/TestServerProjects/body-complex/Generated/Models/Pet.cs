// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The Pet. </summary>
    public partial class Pet
    {
        /// <summary> Initializes a new instance of Pet. </summary>
        public Pet()
        {
        }

        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        internal Pet(int? id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary> Gets or sets the id. </summary>
        public int? Id { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
    }
}
