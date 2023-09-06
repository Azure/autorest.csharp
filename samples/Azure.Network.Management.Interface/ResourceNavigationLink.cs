// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    [CodeGenModel("ResourceNavigationLink")]
    public partial class ResourceNavigationLink : SubResource
    {
        /// <summary>
        /// Gets the identifier of the resource navigation link.
        /// </summary>
        [CodeGenMember("id")]
        public string ResourceNavigationLinkId { get; internal set; }
    }
}
