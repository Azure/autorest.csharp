// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace AppConfiguration.Models
{
    /// <summary> The Key. </summary>
    public partial class Key
    {
        /// <summary> Initializes a new instance of Key. </summary>
        internal Key()
        {
        }

        /// <summary> Initializes a new instance of Key. </summary>
        /// <param name="name"></param>
        internal Key(string name)
        {
            Name = name;
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
