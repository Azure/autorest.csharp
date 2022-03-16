// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Resources;

namespace ResourceRename
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ResourceGroupExtensions
    {
        private static ResourceGroupExtensionClient GetExtensionClient(ResourceGroup resourceGroup)
        {
            return resourceGroup.GetCachedClient((client) =>
            {
                return new ResourceGroupExtensionClient(client, resourceGroup.Id);
            }
            );
        }

        /// <summary> Gets a collection of SshPublicKeyInfoResources in the SshPublicKeyInfoResource. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SshPublicKeyInfoResources and their operations over a SshPublicKeyInfoResource. </returns>
        public static SshPublicKeyInfoCollection GetSshPublicKeyInfos(this ResourceGroup resourceGroup)
        {
            return GetExtensionClient(resourceGroup).GetSshPublicKeyInfos();
        }

        /// <summary>
        /// Retrieves information about an SSH public key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public static async Task<Response<SshPublicKeyInfoResource>> GetSshPublicKeyInfoAsync(this ResourceGroup resourceGroup, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            return await resourceGroup.GetSshPublicKeyInfos().GetAsync(sshPublicKeyName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about an SSH public key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}
        /// Operation Id: SshPublicKeys_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public static Response<SshPublicKeyInfoResource> GetSshPublicKeyInfo(this ResourceGroup resourceGroup, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            return resourceGroup.GetSshPublicKeyInfos().Get(sshPublicKeyName, cancellationToken);
        }
    }
}
