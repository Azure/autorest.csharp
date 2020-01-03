// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace xml_service.Models.V100
{
    public partial class Blob
    {
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public string Snapshot { get; set; }
        public BlobProperties Properties { get; set; } = new BlobProperties();
        public IDictionary<string, string>? Metadata { get; set; }
    }
}
