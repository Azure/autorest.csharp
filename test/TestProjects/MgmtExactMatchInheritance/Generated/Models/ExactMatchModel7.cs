// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The ExactMatchModel7. </summary>
    public partial class ExactMatchModel7
    {
        /// <summary> Initializes a new instance of ExactMatchModel7. </summary>
        public ExactMatchModel7()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel7. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="exactMatchModel7Type"></param>
        internal ExactMatchModel7(string id, string name, string exactMatchModel7Type)
        {
            ID = id;
            Name = name;
            ExactMatchModel7Type = exactMatchModel7Type;
        }

        /// <summary> Gets or sets the id. </summary>
        public string ID { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the exact match model 7 type. </summary>
        public string ExactMatchModel7Type { get; set; }
    }
}
