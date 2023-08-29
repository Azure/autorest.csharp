// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtPagination
{
    /// <summary> A class representing the PageSizeStringModel data model. </summary>
    public partial class PageSizeStringModelData
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="PageSizeStringModelData"/>. </summary>
        public PageSizeStringModelData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PageSizeStringModelData"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal PageSizeStringModelData(string id, string name, string resourceType, Dictionary<string, BinaryData> rawData)
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
