// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace xml_service.Models.V100
{
    public partial class Blobs
    {
        public ICollection<BlobPrefix>? BlobPrefix { get; set; }
        public ICollection<Blob>? Blob { get; set; }
    }
}
