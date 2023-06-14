// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The ExactMatchModel3. </summary>
    public partial class ExactMatchModel3 : ExactMatchModel8
    {
        /// <summary> Initializes a new instance of ExactMatchModel3. </summary>
        public ExactMatchModel3()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel3. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="bar"></param>
        /// <param name="new"></param>
        internal ExactMatchModel3(ResourceIdentifier id, string name, string bar, string @new) : base(id, name, bar)
        {
            New = @new;
        }

        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
