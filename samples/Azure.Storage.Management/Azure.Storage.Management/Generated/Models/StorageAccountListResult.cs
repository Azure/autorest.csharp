// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Storage.Management.Models
{
    /// <summary> The response from the List Storage Accounts operation. </summary>
    public partial class StorageAccountListResult
    {
        /// <summary> Gets the list of storage accounts and their properties. </summary>
        public ICollection<StorageAccount> Value { get; internal set; }
        /// <summary> Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size. </summary>
        public string NextLink { get; internal set; }
    }
}
