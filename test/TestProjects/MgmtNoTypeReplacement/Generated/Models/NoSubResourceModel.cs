// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtNoTypeReplacement.Models
{
    /// <summary> The NoSubResourceModel. </summary>
    internal partial class NoSubResourceModel
    {
        /// <summary> Initializes a new instance of NoSubResourceModel. </summary>
        public NoSubResourceModel()
        {
        }

        /// <summary> Initializes a new instance of NoSubResourceModel. </summary>
        /// <param name="id"></param>
        internal NoSubResourceModel(string id)
        {
            Id = id;
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
    }
}
