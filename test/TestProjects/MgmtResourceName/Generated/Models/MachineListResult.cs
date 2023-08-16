// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using MgmtResourceName;

namespace MgmtResourceName.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    internal partial class MachineListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtResourceName.Models.MachineListResult
        ///
        /// </summary>
        internal MachineListResult()
        {
            Value = new ChangeTrackingList<MachineData>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtResourceName.Models.MachineListResult
        ///
        /// </summary>
        /// <param name="value"> Gets the list of storage accounts and their properties. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal MachineListResult(IReadOnlyList<MachineData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public IReadOnlyList<MachineData> Value { get; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
