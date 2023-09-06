// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> An enumeration of containers. </summary>
    public partial class ListContainersResponse
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ListContainersResponse"/>. </summary>
        /// <param name="serviceEndpoint"></param>
        /// <param name="prefix"></param>
        /// <param name="maxResults"></param>
        /// <param name="nextMarker"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceEndpoint"/>, <paramref name="prefix"/> or <paramref name="nextMarker"/> is null. </exception>
        internal ListContainersResponse(string serviceEndpoint, string prefix, int maxResults, string nextMarker)
        {
            Argument.AssertNotNull(serviceEndpoint, nameof(serviceEndpoint));
            Argument.AssertNotNull(prefix, nameof(prefix));
            Argument.AssertNotNull(nextMarker, nameof(nextMarker));

            ServiceEndpoint = serviceEndpoint;
            Prefix = prefix;
            MaxResults = maxResults;
            Containers = new ChangeTrackingList<Container>();
            NextMarker = nextMarker;
        }

        /// <summary> Initializes a new instance of <see cref="ListContainersResponse"/>. </summary>
        /// <param name="serviceEndpoint"></param>
        /// <param name="prefix"></param>
        /// <param name="marker"></param>
        /// <param name="maxResults"></param>
        /// <param name="containers"></param>
        /// <param name="nextMarker"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ListContainersResponse(string serviceEndpoint, string prefix, string marker, int maxResults, IReadOnlyList<Container> containers, string nextMarker, Dictionary<string, BinaryData> rawData)
        {
            ServiceEndpoint = serviceEndpoint;
            Prefix = prefix;
            Marker = marker;
            MaxResults = maxResults;
            Containers = containers;
            NextMarker = nextMarker;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ListContainersResponse"/> for deserialization. </summary>
        internal ListContainersResponse()
        {
        }

        /// <summary> Gets the service endpoint. </summary>
        public string ServiceEndpoint { get; }
        /// <summary> Gets the prefix. </summary>
        public string Prefix { get; }
        /// <summary> Gets the marker. </summary>
        public string Marker { get; }
        /// <summary> Gets the max results. </summary>
        public int MaxResults { get; }
        /// <summary> Gets the containers. </summary>
        public IReadOnlyList<Container> Containers { get; }
        /// <summary> Gets the next marker. </summary>
        public string NextMarker { get; }
    }
}
