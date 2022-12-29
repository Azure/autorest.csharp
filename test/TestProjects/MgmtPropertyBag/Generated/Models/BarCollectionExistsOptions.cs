// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace MgmtPropertyBag.Models
{
    /// <summary> The BarCollectionExistsOptions. </summary>
    public partial class BarCollectionExistsOptions
    {
        /// <summary> Initializes a new instance of BarCollectionExistsOptions. </summary>
        /// <param name="barName"> The bar name. </param>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of &quot;*&quot; can be used for If-Match to unconditionally apply the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="barName"/> or <paramref name="ifMatch"/> is null. </exception>
        public BarCollectionExistsOptions(string barName, string ifMatch)
        {
            Argument.AssertNotNull(barName, nameof(barName));
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));

            BarName = barName;
            IfMatch = ifMatch;
        }

        /// <summary> The bar name. </summary>
        public string BarName { get; }
        /// <summary> The entity state (Etag) version. A value of &quot;*&quot; can be used for If-Match to unconditionally apply the operation. </summary>
        public string IfMatch { get; }
        /// <summary> The filter to apply on the operation. </summary>
        public string Filter { get; set; }
        /// <summary> Gets or sets the top. </summary>
        public int? Top { get; set; }
    }
}
