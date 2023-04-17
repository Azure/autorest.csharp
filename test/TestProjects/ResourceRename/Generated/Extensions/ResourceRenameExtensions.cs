// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace ResourceRename
{
    /// <summary> A class to add extension methods to ResourceRename. </summary>
    public static partial class ResourceRenameExtensions
    {
        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new ResourceGroupResourceExtensionClient(client, resource.Id);
            });
        }

        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new ResourceGroupResourceExtensionClient(client, scope);
            });
        }
        #region SshPublicKeyInfoResource
        /// <summary>
        /// Gets an object representing a <see cref="SshPublicKeyInfoResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SshPublicKeyInfoResource.CreateResourceIdentifier" /> to create a <see cref="SshPublicKeyInfoResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SshPublicKeyInfoResource" /> object. </returns>
        public static SshPublicKeyInfoResource GetSshPublicKeyInfoResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                SshPublicKeyInfoResource.ValidateResourceId(id);
                return new SshPublicKeyInfoResource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of SshPublicKeyInfoResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SshPublicKeyInfoResources and their operations over a SshPublicKeyInfoResource. </returns>
        public static SshPublicKeyInfoCollection GetSshPublicKeyInfos(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetSshPublicKeyInfos();
        }

        /// <summary>
        /// Retrieves information about an SSH public key.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SshPublicKeys_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<SshPublicKeyInfoResource>> GetSshPublicKeyInfoAsync(this ResourceGroupResource resourceGroupResource, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetSshPublicKeyInfos().GetAsync(sshPublicKeyName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information about an SSH public key.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{sshPublicKeyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SshPublicKeys_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="sshPublicKeyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<SshPublicKeyInfoResource> GetSshPublicKeyInfo(this ResourceGroupResource resourceGroupResource, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetSshPublicKeyInfos().Get(sshPublicKeyName, cancellationToken);
        }
    }
}
