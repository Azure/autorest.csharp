// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace xml_service.Models.V100
{
    public partial class Logging
    {
        public string Version { get; set; }
        public bool Delete { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public RetentionPolicy RetentionPolicy { get; set; } = new RetentionPolicy();
    }
}
