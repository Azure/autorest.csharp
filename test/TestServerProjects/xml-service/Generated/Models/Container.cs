// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> An Azure Storage container. </summary>
    public partial class Container
    {
        public string Name { get; set; }
        /// <summary> Properties of a container. </summary>
        public ContainerProperties Properties { get; set; } = new ContainerProperties();
        /// <summary> Dictionary of &lt;paths·xml-headers·get·responses·200·headers·custom_header·schema&gt;. </summary>
        public IDictionary<string, string> Metadata { get; set; }
    }
}
