// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Models
{
    /// <summary> The List disk encryption set operation response. </summary>
    internal partial class DiskEncryptionSetList
    {
        /// <summary> Initializes a new instance of DiskEncryptionSetList. </summary>
        /// <param name="value"> A list of disk encryption sets. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal DiskEncryptionSetList(IEnumerable<DiskEncryptionSetData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of DiskEncryptionSetList. </summary>
        /// <param name="value"> A list of disk encryption sets. </param>
        /// <param name="nextLink"> The uri to fetch the next page of disk encryption sets. Call ListNext() with this to fetch the next page of disk encryption sets. </param>
        internal DiskEncryptionSetList(IReadOnlyList<DiskEncryptionSetData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> A list of disk encryption sets. </summary>
        public IReadOnlyList<DiskEncryptionSetData> Value { get; }
        /// <summary> The uri to fetch the next page of disk encryption sets. Call ListNext() with this to fetch the next page of disk encryption sets. </summary>
        public string NextLink { get; }
    }
}
