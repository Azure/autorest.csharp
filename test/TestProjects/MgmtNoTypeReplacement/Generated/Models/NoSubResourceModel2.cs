// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtNoTypeReplacement.Models
{
    /// <summary> The NoSubResourceModel2. </summary>
    internal partial class NoSubResourceModel2
    {
        /// <summary> Initializes a new instance of NoSubResourceModel2. </summary>
        public NoSubResourceModel2()
        {
        }

        /// <summary> Initializes a new instance of NoSubResourceModel2. </summary>
        /// <param name="id"></param>
        internal NoSubResourceModel2(string id)
        {
            Id = id;
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
    }
}
