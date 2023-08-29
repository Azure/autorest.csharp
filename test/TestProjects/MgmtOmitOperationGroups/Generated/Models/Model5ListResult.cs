// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtOmitOperationGroups.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class Model5ListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Model5ListResult"/>. </summary>
        internal Model5ListResult()
        {
            Value = new ChangeTrackingList<Model5>();
        }

        /// <summary> Initializes a new instance of <see cref="Model5ListResult"/>. </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Model5ListResult(IReadOnlyList<Model5> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<Model5> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
