// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ModelShapes.Models
{
    /// <summary> The ReadonlyModel. </summary>
    public partial class ReadonlyModel
    {
        /// <summary> Initializes a new instance of ReadonlyModel. </summary>
        internal ReadonlyModel()
        {
        }

        /// <summary> Initializes a new instance of ReadonlyModel. </summary>
        /// <param name="name"></param>
        internal ReadonlyModel(string name)
        {
            Name = name;
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
