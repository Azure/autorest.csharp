// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The dictionary-wrapper. </summary>
    public partial class DictionaryWrapper
    {
        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IDictionary<string, string> DefaultProgram { get; set; }
    }
}
