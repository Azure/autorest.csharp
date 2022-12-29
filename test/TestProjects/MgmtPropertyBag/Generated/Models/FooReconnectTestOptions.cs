// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using MgmtPropertyBag;

namespace MgmtPropertyBag.Models
{
    /// <summary> The FooReconnectTestOptions. </summary>
    public partial class FooReconnectTestOptions
    {
        /// <summary> Initializes a new instance of FooReconnectTestOptions. </summary>
        public FooReconnectTestOptions()
        {
        }

        /// <summary> The filter to apply on the operation. </summary>
        public string Filter { get; set; }
        /// <summary> Gets or sets the top. </summary>
        public int? Top { get; set; }
        /// <summary> Gets or sets the orderby. </summary>
        public string Orderby { get; set; }
        /// <summary> The parameters supplied to the Reconnect operation. </summary>
        public FooData Data { get; set; }
    }
}
