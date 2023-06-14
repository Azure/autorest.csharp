// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> An enumeration of blobs. </summary>
    public partial class ListBlobsResponse
    {
        /// <summary> Initializes a new instance of ListBlobsResponse. </summary>
        /// <param name="containerName"></param>
        /// <param name="prefix"></param>
        /// <param name="marker"></param>
        /// <param name="maxResults"></param>
        /// <param name="delimiter"></param>
        /// <param name="blobs"></param>
        /// <param name="nextMarker"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/>, <paramref name="prefix"/>, <paramref name="marker"/>, <paramref name="delimiter"/>, <paramref name="blobs"/> or <paramref name="nextMarker"/> is null. </exception>
        internal ListBlobsResponse(string containerName, string prefix, string marker, int maxResults, string delimiter, Blobs blobs, string nextMarker)
        {
            Argument.AssertNotNull(containerName, nameof(containerName));
            Argument.AssertNotNull(prefix, nameof(prefix));
            Argument.AssertNotNull(marker, nameof(marker));
            Argument.AssertNotNull(delimiter, nameof(delimiter));
            Argument.AssertNotNull(blobs, nameof(blobs));
            Argument.AssertNotNull(nextMarker, nameof(nextMarker));

            ContainerName = containerName;
            Prefix = prefix;
            Marker = marker;
            MaxResults = maxResults;
            Delimiter = delimiter;
            Blobs = blobs;
            NextMarker = nextMarker;
        }

        /// <summary> Initializes a new instance of ListBlobsResponse. </summary>
        /// <param name="serviceEndpoint"></param>
        /// <param name="containerName"></param>
        /// <param name="prefix"></param>
        /// <param name="marker"></param>
        /// <param name="maxResults"></param>
        /// <param name="delimiter"></param>
        /// <param name="blobs"></param>
        /// <param name="nextMarker"></param>
        internal ListBlobsResponse(string serviceEndpoint, string containerName, string prefix, string marker, int maxResults, string delimiter, Blobs blobs, string nextMarker)
        {
            ServiceEndpoint = serviceEndpoint;
            ContainerName = containerName;
            Prefix = prefix;
            Marker = marker;
            MaxResults = maxResults;
            Delimiter = delimiter;
            Blobs = blobs;
            NextMarker = nextMarker;
        }

        /// <summary> Gets the service endpoint. </summary>
        public string ServiceEndpoint { get; }
        /// <summary> Gets the container name. </summary>
        public string ContainerName { get; }
        /// <summary> Gets the prefix. </summary>
        public string Prefix { get; }
        /// <summary> Gets the marker. </summary>
        public string Marker { get; }
        /// <summary> Gets the max results. </summary>
        public int MaxResults { get; }
        /// <summary> Gets the delimiter. </summary>
        public string Delimiter { get; }
        /// <summary> Gets the blobs. </summary>
        public Blobs Blobs { get; }
        /// <summary> Gets the next marker. </summary>
        public string NextMarker { get; }
    }
}
