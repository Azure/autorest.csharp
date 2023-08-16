// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> The Blobs. </summary>
    public partial class Blobs
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::xml_service.Models.Blobs
        ///
        /// </summary>
        internal Blobs()
        {
            BlobPrefix = new ChangeTrackingList<BlobPrefix>();
            Blob = new ChangeTrackingList<Blob>();
        }

        /// <summary>
        /// Initializes a new instance of global::xml_service.Models.Blobs
        ///
        /// </summary>
        /// <param name="blobPrefix"></param>
        /// <param name="blob"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Blobs(IReadOnlyList<BlobPrefix> blobPrefix, IReadOnlyList<Blob> blob, Dictionary<string, BinaryData> rawData)
        {
            BlobPrefix = blobPrefix;
            Blob = blob;
            _rawData = rawData;
        }

        /// <summary> Gets the blob prefix. </summary>
        public IReadOnlyList<BlobPrefix> BlobPrefix { get; }
        /// <summary> Gets the blob. </summary>
        public IReadOnlyList<Blob> Blob { get; }
    }
}
