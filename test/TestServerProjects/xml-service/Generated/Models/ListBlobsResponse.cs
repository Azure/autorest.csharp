// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace xml_service.Models
{
    /// <summary> An enumeration of blobs. </summary>
    public partial class ListBlobsResponse
    {
        /// <summary> Initializes a new instance of ListBlobsResponse. </summary>
        /// <param name="containerName"> The ContainerName. </param>
        /// <param name="prefix"> The Prefix. </param>
        /// <param name="marker"> The Marker. </param>
        /// <param name="maxResults"> The MaxResults. </param>
        /// <param name="delimiter"> The Delimiter. </param>
        /// <param name="blobs"> The Blobs. </param>
        /// <param name="nextMarker"> The NextMarker. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/>, <paramref name="prefix"/>, <paramref name="marker"/>, <paramref name="delimiter"/>, <paramref name="blobs"/>, or <paramref name="nextMarker"/> is null. </exception>
        internal ListBlobsResponse(string containerName, string prefix, string marker, int maxResults, string delimiter, Blobs blobs, string nextMarker)
        {
            if (containerName == null)
            {
                throw new ArgumentNullException(nameof(containerName));
            }
            if (prefix == null)
            {
                throw new ArgumentNullException(nameof(prefix));
            }
            if (marker == null)
            {
                throw new ArgumentNullException(nameof(marker));
            }
            if (delimiter == null)
            {
                throw new ArgumentNullException(nameof(delimiter));
            }
            if (blobs == null)
            {
                throw new ArgumentNullException(nameof(blobs));
            }
            if (nextMarker == null)
            {
                throw new ArgumentNullException(nameof(nextMarker));
            }

            ContainerName = containerName;
            Prefix = prefix;
            Marker = marker;
            MaxResults = maxResults;
            Delimiter = delimiter;
            Blobs = blobs;
            NextMarker = nextMarker;
        }

        /// <summary> Initializes a new instance of ListBlobsResponse. </summary>
        /// <param name="serviceEndpoint"> The ServiceEndpoint. </param>
        /// <param name="containerName"> The ContainerName. </param>
        /// <param name="prefix"> The Prefix. </param>
        /// <param name="marker"> The Marker. </param>
        /// <param name="maxResults"> The MaxResults. </param>
        /// <param name="delimiter"> The Delimiter. </param>
        /// <param name="blobs"> The Blobs. </param>
        /// <param name="nextMarker"> The NextMarker. </param>
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

        /// <summary> The ServiceEndpoint. </summary>
        public string ServiceEndpoint { get; }
        /// <summary> The ContainerName. </summary>
        public string ContainerName { get; }
        /// <summary> The Prefix. </summary>
        public string Prefix { get; }
        /// <summary> The Marker. </summary>
        public string Marker { get; }
        /// <summary> The MaxResults. </summary>
        public int MaxResults { get; }
        /// <summary> The Delimiter. </summary>
        public string Delimiter { get; }
        /// <summary> The Blobs. </summary>
        public Blobs Blobs { get; }
        /// <summary> The NextMarker. </summary>
        public string NextMarker { get; }
    }
}
