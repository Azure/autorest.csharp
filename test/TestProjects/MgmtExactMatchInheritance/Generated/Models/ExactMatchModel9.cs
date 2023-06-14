// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The ExactMatchModel9. </summary>
    public partial class ExactMatchModel9
    {
        /// <summary> Initializes a new instance of ExactMatchModel9. </summary>
        public ExactMatchModel9()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel9. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="exactMatchModel9Type"></param>
        internal ExactMatchModel9(int? id, string name, string exactMatchModel9Type)
        {
            Id = id;
            Name = name;
            ExactMatchModel9Type = exactMatchModel9Type;
        }

        /// <summary> Gets or sets the id. </summary>
        public int? Id { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the exact match model 9 type. </summary>
        public string ExactMatchModel9Type { get; set; }
    }
}
