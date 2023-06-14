// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Blob range. </summary>
    public partial class BlobRestoreRange
    {
        /// <summary> Initializes a new instance of BlobRestoreRange. </summary>
        /// <param name="startRange"> Blob start range. This is inclusive. Empty means account start. </param>
        /// <param name="endRange"> Blob end range. This is exclusive. Empty means account end. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="startRange"/> or <paramref name="endRange"/> is null. </exception>
        public BlobRestoreRange(string startRange, string endRange)
        {
            Argument.AssertNotNull(startRange, nameof(startRange));
            Argument.AssertNotNull(endRange, nameof(endRange));

            StartRange = startRange;
            EndRange = endRange;
        }

        /// <summary> Blob start range. This is inclusive. Empty means account start. </summary>
        public string StartRange { get; set; }
        /// <summary> Blob end range. This is exclusive. Empty means account end. </summary>
        public string EndRange { get; set; }
    }
}
