// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtPagination
{
    /// <summary> A class representing the PageSizeInt64Model data model. </summary>
    public partial class PageSizeInt64ModelData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="PageSizeInt64ModelData"/>. </summary>
        public PageSizeInt64ModelData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PageSizeInt64ModelData"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal PageSizeInt64ModelData(string id, string name, string resourceType, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            Name = name;
            ResourceType = resourceType;
            _rawData = rawData;
        }

        /// <summary> Resource ID. </summary>
        public string Id { get; }
        /// <summary> Resource name. </summary>
        public string Name { get; }
        /// <summary> Resource type. </summary>
        public string ResourceType { get; }
    }
}
