// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> List of keys. </summary>
    internal partial class VaultListKeysResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="VaultListKeysResult"/>. </summary>
        internal VaultListKeysResult()
        {
            Value = new ChangeTrackingList<VaultKey>();
        }

        /// <summary> Initializes a new instance of <see cref="VaultListKeysResult"/>. </summary>
        /// <param name="value"> The list of vaults. </param>
        /// <param name="nextLink"> The URL to get the next set of vaults. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VaultListKeysResult(IReadOnlyList<VaultKey> value, string nextLink, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The list of vaults. </summary>
        public IReadOnlyList<VaultKey> Value { get; }
        /// <summary> The URL to get the next set of vaults. </summary>
        public string NextLink { get; }
    }
}
