// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> An enumeration of blobs. </summary>
    public partial class ListBlobsResponse
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ListBlobsResponse"/>. </summary>
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

        /// <summary> Initializes a new instance of <see cref="ListBlobsResponse"/>. </summary>
        /// <param name="serviceEndpoint"></param>
        /// <param name="containerName"></param>
        /// <param name="prefix"></param>
        /// <param name="marker"></param>
        /// <param name="maxResults"></param>
        /// <param name="delimiter"></param>
        /// <param name="blobs"></param>
        /// <param name="nextMarker"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ListBlobsResponse(string serviceEndpoint, string containerName, string prefix, string marker, int maxResults, string delimiter, Blobs blobs, string nextMarker, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ServiceEndpoint = serviceEndpoint;
            ContainerName = containerName;
            Prefix = prefix;
            Marker = marker;
            MaxResults = maxResults;
            Delimiter = delimiter;
            Blobs = blobs;
            NextMarker = nextMarker;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ListBlobsResponse"/> for deserialization. </summary>
        internal ListBlobsResponse()
        {
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
