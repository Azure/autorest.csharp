// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The SubResource.
    /// Serialized Name: SubResource
    /// </summary>
    public partial class SubResource
    {
        /// <summary> Initializes a new instance of SubResource. </summary>
        public SubResource()
        {
        }

        /// <summary> Initializes a new instance of SubResource. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </param>
        internal SubResource(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </summary>
        public string Id { get; set; }
    }
}
