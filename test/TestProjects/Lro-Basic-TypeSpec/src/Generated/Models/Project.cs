// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace LroBasicTypeSpec.Models
{
    /// <summary> The Project. </summary>
    public partial class Project
    {
        /// <summary> Initializes a new instance of Project. </summary>
        public Project()
        {
        }

        /// <summary> Initializes a new instance of Project. </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="name"></param>
        internal Project(string id, string description, string name)
        {
            Id = id;
            Description = description;
            Name = name;
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
        /// <summary> Gets or sets the description. </summary>
        public string Description { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
    }
}
