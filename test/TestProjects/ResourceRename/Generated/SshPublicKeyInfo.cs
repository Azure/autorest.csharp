// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace ResourceRename
{
    /// <summary> A Class representing a SshPublicKeyInfo along with the instance operations that can be performed on it. </summary>
    public class SshPublicKeyInfo : SshPublicKeyInfoOperations
    {
        /// <summary> Initializes a new instance of the <see cref="SshPublicKeyInfo"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal SshPublicKeyInfo(ResourceOperationsBase options, SshPublicKeyInfoData resource)
        {
        }

        /// <summary> Gets or sets the resource data. </summary>
        public SshPublicKeyInfo Data { get; private set; }
    }
}
