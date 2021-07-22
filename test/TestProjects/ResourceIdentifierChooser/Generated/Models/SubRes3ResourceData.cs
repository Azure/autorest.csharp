// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace ResourceIdentifierChooser
{
    /// <summary> A class representing the SubRes3Resource data model. </summary>
    public partial class SubRes3ResourceData : SubResource<ResourceGroupResourceIdentifier>
    {
        /// <summary> Initializes a new instance of SubRes3ResourceData. </summary>
        public SubRes3ResourceData()
        {
        }

        /// <summary> Initializes a new instance of SubRes3ResourceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="new"></param>
        internal SubRes3ResourceData(string id, string @new) : base(id)
        {
            New = @new;
        }

        public string New { get; set; }
    }
}
