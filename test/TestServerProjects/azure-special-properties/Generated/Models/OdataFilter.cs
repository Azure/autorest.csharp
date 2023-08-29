// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace azure_special_properties.Models
{
    /// <summary> The OdataFilter. </summary>
    internal partial class OdataFilter
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="OdataFilter"/>. </summary>
        internal OdataFilter()
        {
        }

        /// <summary> Initializes a new instance of <see cref="OdataFilter"/>. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal OdataFilter(int? id, string name, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            Name = name;
            _rawData = rawData;
        }

        /// <summary> Gets the id. </summary>
        public int? Id { get; }
        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
