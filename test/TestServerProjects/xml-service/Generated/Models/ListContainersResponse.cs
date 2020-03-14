// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> An enumeration of containers. </summary>
    public partial class ListContainersResponse
    {
        public string ServiceEndpoint { get; internal set; }
        public string Prefix { get; internal set; }
        public string Marker { get; internal set; }
        public int MaxResults { get; internal set; }
        public IList<Container> Containers { get; internal set; }
        public string NextMarker { get; internal set; }
    }
}
