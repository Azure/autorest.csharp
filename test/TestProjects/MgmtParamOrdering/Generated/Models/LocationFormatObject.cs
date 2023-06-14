// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace MgmtParamOrdering.Models
{
    /// <summary> The LocationFormatObject. </summary>
    internal partial class LocationFormatObject
    {
        /// <summary> Initializes a new instance of LocationFormatObject. </summary>
        internal LocationFormatObject()
        {
        }

        /// <summary> This location should be a string. </summary>
        public string StringLocation { get; }
        /// <summary> This location should be an AzureLocation. </summary>
        public AzureLocation? ObjectLocation { get; }
    }
}
