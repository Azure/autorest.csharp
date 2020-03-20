// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> Blob range. </summary>
    public partial class BlobRestoreRange
    {
        /// <summary> Initializes a new instance of BlobRestoreRange. </summary>
        public BlobRestoreRange()
        {
        }

        /// <summary> Initializes a new instance of BlobRestoreRange. </summary>
        /// <param name="startRange"> Blob start range. Empty means account start. </param>
        /// <param name="endRange"> Blob end range. Empty means account end. </param>
        internal BlobRestoreRange(string startRange, string endRange)
        {
            StartRange = startRange;
            EndRange = endRange;
        }

        /// <summary> Blob start range. Empty means account start. </summary>
        public string StartRange { get; set; }
        /// <summary> Blob end range. Empty means account end. </summary>
        public string EndRange { get; set; }
    }
}
