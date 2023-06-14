// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Uri or local path to source data. </summary>
    public partial class SourcePath
    {
        /// <summary> Initializes a new instance of SourcePath. </summary>
        public SourcePath()
        {
        }

        /// <summary> File source path. </summary>
        public string Source { get; set; }
    }
}
