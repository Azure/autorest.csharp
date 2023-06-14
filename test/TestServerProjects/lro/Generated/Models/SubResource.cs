// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace lro.Models
{
    /// <summary> The SubResource. </summary>
    public partial class SubResource
    {
        /// <summary> Initializes a new instance of SubResource. </summary>
        public SubResource()
        {
        }

        /// <summary> Initializes a new instance of SubResource. </summary>
        /// <param name="id"> Sub Resource Id. </param>
        internal SubResource(string id)
        {
            Id = id;
        }

        /// <summary> Sub Resource Id. </summary>
        public string Id { get; }
    }
}
