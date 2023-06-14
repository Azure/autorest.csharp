// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The ExactMatchModel8. </summary>
    public partial class ExactMatchModel8
    {
        /// <summary> Initializes a new instance of ExactMatchModel8. </summary>
        public ExactMatchModel8()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel8. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="bar"></param>
        internal ExactMatchModel8(ResourceIdentifier id, string name, string bar)
        {
            Id = id;
            Name = name;
            Bar = bar;
        }

        /// <summary> Gets or sets the id. </summary>
        public ResourceIdentifier Id { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the bar. </summary>
        public string Bar { get; set; }
    }
}
