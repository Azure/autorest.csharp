// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace xml_service.Models.V100
{
    public partial class StorageServiceProperties
    {
        public Logging? Logging { get; set; }
        public Metrics? HourMetrics { get; set; }
        public Metrics? MinuteMetrics { get; set; }
        public ICollection<CorsRule>? Cors { get; set; }
        public string? DefaultServiceVersion { get; set; }
        public RetentionPolicy? DeleteRetentionPolicy { get; set; }
    }
}
