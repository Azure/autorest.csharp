// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AppConfiguration.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class KeyValue
    {
        public string? Key { get; set; }
        public string? Label { get; set; }
        public string? ContentType { get; set; }
        public string? Value { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-DATETIME. </summary>
        public DateTimeOffset? LastModified { get; set; }
        /// <summary> Dictionary of &lt;paths·keys·get·parameters·0·schema&gt;. </summary>
        public IDictionary<string, string>? Tags { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BOOLEAN. </summary>
        public bool? Locked { get; set; }
        public string? Etag { get; set; }
    }
}
