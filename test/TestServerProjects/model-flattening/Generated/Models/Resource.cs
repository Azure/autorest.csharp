// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace model_flattening.Models
{
    /// <summary> The Resource. </summary>
    public partial class Resource
    {
        /// <summary> Initializes a new instance of Resource. </summary>
        public Resource()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of Resource. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="type"> Resource Type. </param>
        /// <param name="tags"> Dictionary of &lt;string&gt;. </param>
        /// <param name="location"> Resource Location. </param>
        /// <param name="name"> Resource Name. </param>
        internal Resource(string id, string type, IDictionary<string, string> tags, string location, string name)
        {
            Id = id;
            Type = type;
            Tags = tags;
            Location = location;
            Name = name;
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
