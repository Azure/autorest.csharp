// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> The Resource model definition. </summary>
    public partial class PirResource
    {
        /// <summary> Initializes a new instance of PirResource. </summary>
        internal PirResource()
        {
        }

        /// <summary> Initializes a new instance of PirResource. </summary>
        /// <param name="name"> Resource name. </param>
        /// <param name="location"> Resource location. </param>
        internal PirResource(string name, string location)
        {
            Name = name;
            Location = location;
        }

        /// <summary> Resource name. </summary>
        public string Name { get; }
        /// <summary> Resource location. </summary>
        public string Location { get; }
    }
}
