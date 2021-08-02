// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtListMethods.Models
{
    /// <summary> Quota update parameters. </summary>
    public partial class QuotaUpdateParameters
    {
        /// <summary> Initializes a new instance of QuotaUpdateParameters. </summary>
        public QuotaUpdateParameters()
        {
            Value = new ChangeTrackingList<QuotaBaseProperties>();
        }

        /// <summary> The list for update quota. </summary>
        public IList<QuotaBaseProperties> Value { get; }
        /// <summary> Region of workspace quota to be updated. </summary>
        public string Location { get; set; }
    }
}
