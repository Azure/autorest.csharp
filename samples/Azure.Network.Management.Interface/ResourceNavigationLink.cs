// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    [CodeGenModel("ResourceNavigationLink")]
    public partial class ResourceNavigationLink : SubResource
    {
        [CodeGenMember("id")]
        public string ResourceNavigationLinkId { get; internal set; }
    }
}
