// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace MgmtPropertyBag.Models
{
    /// <summary> A class representing the query and header parameters in CreateOrUpdate method. </summary>
    public partial class BarCreateOrUpdateOptions
    {
        /// <summary> Initializes a new instance of BarCreateOrUpdateOptions. </summary>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of &quot;*&quot; can be used for If-Match to unconditionally apply the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ifMatch"/> is null. </exception>
        public BarCreateOrUpdateOptions(string ifMatch)
        {
            Argument.AssertNotNull(ifMatch, nameof(ifMatch));

            IfMatch = ifMatch;
        }

        /// <summary> The entity state (Etag) version. A value of &quot;*&quot; can be used for If-Match to unconditionally apply the operation. </summary>
        public string IfMatch { get; }
        /// <summary> The filter to apply on the operation. </summary>
        public string Filter { get; set; }
        /// <summary> Gets or sets the top. </summary>
        public int? Top { get; set; }
    }
}
