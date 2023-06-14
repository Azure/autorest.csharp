// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtPagination
{
    /// <summary> A class representing the PageSizeInt64Model data model. </summary>
    public partial class PageSizeInt64ModelData
    {
        /// <summary> Initializes a new instance of PageSizeInt64ModelData. </summary>
        public PageSizeInt64ModelData()
        {
        }

        /// <summary> Initializes a new instance of PageSizeInt64ModelData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        internal PageSizeInt64ModelData(string id, string name, string resourceType)
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
