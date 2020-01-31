// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> The Blobs. </summary>
    public partial class Blobs
    {
        public ICollection<BlobPrefix> BlobPrefix { get; set; }
        public ICollection<Blob> Blob { get; set; }
    }
}
