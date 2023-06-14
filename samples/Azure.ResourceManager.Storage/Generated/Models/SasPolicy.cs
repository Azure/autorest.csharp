// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> SasPolicy assigned to the storage account. </summary>
    public partial class SasPolicy
    {
        /// <summary> Initializes a new instance of SasPolicy. </summary>
        /// <param name="sasExpirationPeriod"> The SAS expiration period, DD.HH:MM:SS. </param>
        /// <param name="expirationAction"> The SAS expiration action. Can only be Log. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sasExpirationPeriod"/> is null. </exception>
        public SasPolicy(string sasExpirationPeriod, ExpirationAction expirationAction)
        {
            Argument.AssertNotNull(sasExpirationPeriod, nameof(sasExpirationPeriod));

            SasExpirationPeriod = sasExpirationPeriod;
            ExpirationAction = expirationAction;
        }

        /// <summary> The SAS expiration period, DD.HH:MM:SS. </summary>
        public string SasExpirationPeriod { get; set; }
        /// <summary> The SAS expiration action. Can only be Log. </summary>
        public ExpirationAction ExpirationAction { get; set; }
    }
}
