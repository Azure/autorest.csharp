// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;

namespace MgmtPropertyBag.Models
{
    /// <summary> The FooCollectionGetAllOptions. </summary>
    public partial class FooCollectionGetAllOptions
    {
        /// <summary> Initializes a new instance of FooCollectionGetAllOptions. </summary>
        public FooCollectionGetAllOptions()
        {
        }

        /// <summary> The filter to apply on the operation. </summary>
        public string Filter { get; set; }
        /// <summary> The Integer to use. </summary>
        public int? Top { get; set; } = 10;

        /// <summary> The String to use. </summary>
        public string Orderby { get; set; }
        /// <summary> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </summary>
        public ETag? IfMatch { get; set; }
        /// <summary> Optional. Specified maximum number of containers that can be included in the list. </summary>
        public string Maxpagesize { get; set; }
        /// <summary> Optional. Number of records to skip. </summary>
        public int? Skip { get; set; }
    }
}
