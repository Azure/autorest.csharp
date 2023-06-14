// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtPropertyBag.Models
{
    /// <summary> The BarCollectionExistsOptions. </summary>
    public partial class BarCollectionExistsOptions
    {
        /// <summary> Initializes a new instance of BarCollectionExistsOptions. </summary>
        /// <param name="barName"> The bar name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="barName"/> is null. </exception>
        public BarCollectionExistsOptions(string barName)
        {
            Argument.AssertNotNull(barName, nameof(barName));

            BarName = barName;
            Items = new ChangeTrackingList<string>();
        }

        /// <summary> The bar name. </summary>
        public string BarName { get; }
        /// <summary> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </summary>
        public string IfMatch { get; set; }
        /// <summary> The filter to apply on the operation. </summary>
        public string Filter { get; set; }
        /// <summary> The Integer to use. </summary>
        public int? Top { get; set; }
        /// <summary> Optional. Number of records to skip. </summary>
        public int? Skip { get; set; }
        /// <summary> The items to query on the bar resource. </summary>
        public IList<string> Items { get; }
    }
}
