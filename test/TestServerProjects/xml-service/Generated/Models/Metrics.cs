// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace xml_service.Models.V100
{
    public partial class Metrics
    {
        public string? Version { get; set; }
        public bool Enabled { get; set; }
        public bool? IncludeAPIs { get; set; }
        public RetentionPolicy? RetentionPolicy { get; set; }
    }
}
