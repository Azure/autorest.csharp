// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> An error response from the service. </summary>
    public partial class CloudErrorBody
    {
        /// <summary> An identifier for the error. Codes are invariant and are intended to be consumed programmatically. </summary>
        public string Code { get; set; }
        /// <summary> A message describing the error, intended to be suitable for display in a user interface. </summary>
        public string Message { get; set; }
        /// <summary> The target of the particular error. For example, the name of the property in error. </summary>
        public string Target { get; set; }
        /// <summary> A list of additional details about the error. </summary>
        public IList<CloudErrorBody> Details { get; set; }
    }
}
