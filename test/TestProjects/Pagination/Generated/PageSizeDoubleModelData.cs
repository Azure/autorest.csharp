// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Pagination
{
    /// <summary> A class representing the PageSizeDoubleModel data model. </summary>
    public partial class PageSizeDoubleModelData : SubResource
    {
        /// <summary> Initializes a new instance of PageSizeDoubleModelData. </summary>
        public PageSizeDoubleModelData()
        {
        }

        /// <summary> Initializes a new instance of PageSizeDoubleModelData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        internal PageSizeDoubleModelData(string id, string name, string type) : base(id)
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
