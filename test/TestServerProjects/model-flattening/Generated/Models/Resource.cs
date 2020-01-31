// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace model_flattening.Models
{
    /// <summary> The Resource. </summary>
    public partial class Resource
    {
        /// <summary> Resource Id. </summary>
        public string Id { get; internal set; }
        /// <summary> Resource Type. </summary>
        public string Type { get; internal set; }
        /// <summary> Dictionary of &lt;components·schemas·resource·properties·tags·additionalproperties&gt;. </summary>
        public IDictionary<string, string> Tags { get; set; }
        /// <summary> Resource Location. </summary>
        public string Location { get; set; }
        /// <summary> Resource Name. </summary>
        public string Name { get; internal set; }
    }
}
