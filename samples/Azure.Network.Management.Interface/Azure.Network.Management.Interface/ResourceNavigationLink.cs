// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    [CodeGenSchema("ResourceNavigationLink")]
    public partial class ResourceNavigationLink : SubResource
    {
        [CodeGenSchemaMember("id")]
        public string ResourceNavigationLinkId { get; internal set; }
    }
}
