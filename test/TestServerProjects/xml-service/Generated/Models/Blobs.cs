// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> The Blobs. </summary>
    public partial class Blobs
    {
        /// <summary> Initializes a new instance of Blobs. </summary>
        internal Blobs()
        {
            BlobPrefix = new ChangeTrackingList<BlobPrefix>();
            Blob = new ChangeTrackingList<Blob>();
        }

        /// <summary> Initializes a new instance of Blobs. </summary>
        /// <param name="blobPrefix"></param>
        /// <param name="blob"></param>
        internal Blobs(IReadOnlyList<BlobPrefix> blobPrefix, IReadOnlyList<Blob> blob)
        {
            BlobPrefix = blobPrefix;
            Blob = blob;
        }

        /// <summary> Gets the blob prefix. </summary>
        public IReadOnlyList<BlobPrefix> BlobPrefix { get; }
        /// <summary> Gets the blob. </summary>
        public IReadOnlyList<Blob> Blob { get; }
    }
}
