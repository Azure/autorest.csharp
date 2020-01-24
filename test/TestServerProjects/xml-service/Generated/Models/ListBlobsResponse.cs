// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace xml_service.Models
{
    /// <summary> An enumeration of blobs. </summary>
    public partial class ListBlobsResponse
    {
        public string ServiceEndpoint { get; set; }
        public string ContainerName { get; set; }
        public string Prefix { get; set; }
        public string Marker { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-INTEGER. </summary>
        public int MaxResults { get; set; }
        public string Delimiter { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
        public Blobs Blobs { get; set; } = new Blobs();
        public string NextMarker { get; set; }
    }
}
