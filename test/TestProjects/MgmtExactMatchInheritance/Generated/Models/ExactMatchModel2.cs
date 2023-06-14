// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The ExactMatchModel2. </summary>
    public partial class ExactMatchModel2 : ExactMatchModel7
    {
        /// <summary> Initializes a new instance of ExactMatchModel2. </summary>
        public ExactMatchModel2()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel2. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="exactMatchModel7Type"></param>
        /// <param name="new"></param>
        internal ExactMatchModel2(string id, string name, string exactMatchModel7Type, string @new) : base(id, name, exactMatchModel7Type)
        {
            New = @new;
        }

        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
