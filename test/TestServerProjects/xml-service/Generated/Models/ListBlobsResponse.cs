// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace xml_service.Models.V100
{
    /// <summary> An enumeration of blobs. </summary>
    public partial class ListBlobsResponse
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string ServiceEndpoint { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string ContainerName { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string Prefix { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string Marker { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-INTEGER. </summary>
        public int MaxResults { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string Delimiter { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
        public Blobs Blobs { get; set; } = new Blobs();
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string NextMarker { get; set; }
    }
}
