// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> An Azure Storage container. </summary>
    public partial class Container
    {
        /// <summary> Initializes a new instance of Container. </summary>
        internal Container()
        {
        }

        /// <summary> Initializes a new instance of Container. </summary>
        /// <param name="name"> . </param>
        /// <param name="properties"> Properties of a container. </param>
        /// <param name="metadata"> Dictionary of &lt;string&gt;. </param>
        internal Container(string name, ContainerProperties properties, IDictionary<string, string> metadata)
        {
            Name = name;
            Properties = properties;
            Metadata = metadata;
        }

        public string Name { get; internal set; }
        /// <summary> Properties of a container. </summary>
        public ContainerProperties Properties { get; internal set; } = new ContainerProperties();
        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IDictionary<string, string> Metadata { get; internal set; }
    }
}
