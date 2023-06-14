// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The List SAS credentials operation response. </summary>
    public partial class ListAccountSasResponse
    {
        /// <summary> Initializes a new instance of ListAccountSasResponse. </summary>
        internal ListAccountSasResponse()
        {
        }

        /// <summary> Initializes a new instance of ListAccountSasResponse. </summary>
        /// <param name="accountSasToken"> List SAS credentials of storage account. </param>
        internal ListAccountSasResponse(string accountSasToken)
        {
            AccountSasToken = accountSasToken;
        }

        /// <summary> List SAS credentials of storage account. </summary>
        public string AccountSasToken { get; }
    }
}
