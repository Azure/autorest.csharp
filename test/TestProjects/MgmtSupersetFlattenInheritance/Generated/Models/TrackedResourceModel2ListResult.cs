// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class TrackedResourceModel2ListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="TrackedResourceModel2ListResult"/>. </summary>
        internal TrackedResourceModel2ListResult()
        {
            Value = new ChangeTrackingList<TrackedResourceModel2>();
        }

        /// <summary> Initializes a new instance of <see cref="TrackedResourceModel2ListResult"/>. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TrackedResourceModel2ListResult(IReadOnlyList<TrackedResourceModel2> value, string nextLink, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<TrackedResourceModel2> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
