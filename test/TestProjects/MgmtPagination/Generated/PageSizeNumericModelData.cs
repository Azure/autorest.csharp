// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtPagination
{
    /// <summary> A class representing the PageSizeNumericModel data model. </summary>
    public partial class PageSizeNumericModelData
    {
        /// <summary> Initializes a new instance of PageSizeNumericModelData. </summary>
        public PageSizeNumericModelData()
        {
        }

        /// <summary> Initializes a new instance of PageSizeNumericModelData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        internal PageSizeNumericModelData(string id, string name, string resourceType)
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
