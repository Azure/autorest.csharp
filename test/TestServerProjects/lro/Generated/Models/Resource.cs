// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace lro.Models
{
    /// <summary> The Resource. </summary>
    public partial class Resource
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Resource"/>. </summary>
        public Resource()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="Resource"/>. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="type"> Resource Type. </param>
        /// <param name="tags"> Dictionary of &lt;string&gt;. </param>
        /// <param name="location"> Resource Location. </param>
        /// <param name="name"> Resource Name. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Resource(string id, string type, IDictionary<string, string> tags, string location, string name, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            Type = type;
            Tags = tags;
            Location = location;
            Name = name;
            _rawData = rawData;
        }

        /// <summary> Resource Id. </summary>
        public string Id { get; }
        /// <summary> Resource Type. </summary>
        public string Type { get; }
        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IDictionary<string, string> Tags { get; }
        /// <summary> Resource Location. </summary>
        public string Location { get; set; }
        /// <summary> Resource Name. </summary>
        public string Name { get; }
    }
}
