// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtPagination
{
    /// <summary> A class representing the PageSizeFloatModel data model. </summary>
    public partial class PageSizeFloatModelData
    {
        /// <summary> Initializes a new instance of PageSizeFloatModelData. </summary>
        public PageSizeFloatModelData()
        {
        }

        /// <summary> Initializes a new instance of PageSizeFloatModelData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        internal PageSizeFloatModelData(string id, string name, string resourceType)
        {
            Id = id;
            Name = name;
            ResourceType = resourceType;
        }

        /// <summary> Resource ID. </summary>
        public string Id { get; }
        /// <summary> Resource name. </summary>
        public string Name { get; }
        /// <summary> Resource type. </summary>
        public string ResourceType { get; }
    }
}
