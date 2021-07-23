// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace Pagination.Models
{
    /// <summary> A class representing the PageSizeInt64Model data model. </summary>
    public partial class PageSizeInt64ModelData : SubResource<ResourceGroupResourceIdentifier>
    {
        /// <summary> Initializes a new instance of PageSizeInt64ModelData. </summary>
        public PageSizeInt64ModelData()
        {
        }

        /// <summary> Initializes a new instance of PageSizeInt64ModelData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        internal PageSizeInt64ModelData(string id, string name, string type) : base(id)
        {
            Name = name;
            Type = type;
        }

        /// <summary> Resource name. </summary>
        public string Name { get; }
        /// <summary> Resource type. </summary>
        public string Type { get; }
    }
}
