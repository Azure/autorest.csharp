// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace AppConfiguration.Models
{
    /// <summary> The Label. </summary>
    public partial class Label
    {
        /// <summary> Initializes a new instance of Label. </summary>
        internal Label()
        {
        }

        /// <summary> Initializes a new instance of Label. </summary>
        /// <param name="name"></param>
        internal Label(string name)
        {
            Name = name;
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
