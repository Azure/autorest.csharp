// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using ResourceRename.Models;

namespace ResourceRename
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ResourceGroupExtensions
    {
        #region SshPublicKey
        private static SshPublicKeysRestOperations GetSshPublicKeysRestOperations(ClientDiagnostics clientDiagnostics, TokenCredential credential, ArmClientOptions clientOptions, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null)
        {
            return new SshPublicKeysRestOperations(clientDiagnostics, pipeline, subscriptionId, endpoint);
        }

        /// <summary> Creates a new SSH public key resource. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="path"> Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys. </param>
        /// <param name="keyData"> SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format. &lt;br&gt;&lt;br&gt; For creating ssh keys, see [Create SSH keys on Linux and Mac for Linux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public static async Task<Response<SshPublicKeyInfo>> CreateSshPublicKeyAsync(this ResourceGroup resourceGroup, string sshPublicKeyName, string path = null, string keyData = null, CancellationToken cancellationToken = default)
        {
            if (sshPublicKeyName == null)
            {
                throw new ArgumentNullException(nameof(sshPublicKeyName));
            }

            return await resourceGroup.UseClientContext(async (baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                var restOperations = GetSshPublicKeysRestOperations(clientDiagnostics, credential, options, pipeline, resourceGroup.Id.SubscriptionId, baseUri);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.CreateSshPublicKey");
                scope.Start();
                try
                {
                    var response = await restOperations.CreateAsync(resourceGroup.Id.Name, sshPublicKeyName, path, keyData, cancellationToken).ConfigureAwait(false);
                    return response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            ).ConfigureAwait(false);
        }

        /// <summary> Creates a new SSH public key resource. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="path"> Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys. </param>
        /// <param name="keyData"> SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format. &lt;br&gt;&lt;br&gt; For creating ssh keys, see [Create SSH keys on Linux and Mac for Linux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public static Response<SshPublicKeyInfo> CreateSshPublicKey(this ResourceGroup resourceGroup, string sshPublicKeyName, string path = null, string keyData = null, CancellationToken cancellationToken = default)
        {
            if (sshPublicKeyName == null)
            {
                throw new ArgumentNullException(nameof(sshPublicKeyName));
            }

            return resourceGroup.UseClientContext((baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                var restOperations = GetSshPublicKeysRestOperations(clientDiagnostics, credential, options, pipeline, resourceGroup.Id.SubscriptionId, baseUri);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.CreateSshPublicKey");
                scope.Start();
                try
                {
                    var response = restOperations.Create(resourceGroup.Id.Name, sshPublicKeyName, path, keyData, cancellationToken);
                    return response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            );
        }

        /// <summary> Delete an SSH public key. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public static async Task<Response> DeleteSshPublicKeyAsync(this ResourceGroup resourceGroup, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            if (sshPublicKeyName == null)
            {
                throw new ArgumentNullException(nameof(sshPublicKeyName));
            }

            return await resourceGroup.UseClientContext(async (baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                var restOperations = GetSshPublicKeysRestOperations(clientDiagnostics, credential, options, pipeline, resourceGroup.Id.SubscriptionId, baseUri);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.DeleteSshPublicKey");
                scope.Start();
                try
                {
                    var response = await restOperations.DeleteAsync(resourceGroup.Id.Name, sshPublicKeyName, cancellationToken).ConfigureAwait(false);
                    return response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            ).ConfigureAwait(false);
        }

        /// <summary> Delete an SSH public key. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public static Response DeleteSshPublicKey(this ResourceGroup resourceGroup, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            if (sshPublicKeyName == null)
            {
                throw new ArgumentNullException(nameof(sshPublicKeyName));
            }

            return resourceGroup.UseClientContext((baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                var restOperations = GetSshPublicKeysRestOperations(clientDiagnostics, credential, options, pipeline, resourceGroup.Id.SubscriptionId, baseUri);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.DeleteSshPublicKey");
                scope.Start();
                try
                {
                    var response = restOperations.Delete(resourceGroup.Id.Name, sshPublicKeyName, cancellationToken);
                    return response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            );
        }

        /// <summary> Retrieves information about an SSH public key. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public static async Task<Response<SshPublicKeyInfo>> GetSshPublicKeyAsync(this ResourceGroup resourceGroup, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            if (sshPublicKeyName == null)
            {
                throw new ArgumentNullException(nameof(sshPublicKeyName));
            }

            return await resourceGroup.UseClientContext(async (baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                var restOperations = GetSshPublicKeysRestOperations(clientDiagnostics, credential, options, pipeline, resourceGroup.Id.SubscriptionId, baseUri);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.GetSshPublicKey");
                scope.Start();
                try
                {
                    var response = await restOperations.GetAsync(resourceGroup.Id.Name, sshPublicKeyName, cancellationToken).ConfigureAwait(false);
                    return response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            ).ConfigureAwait(false);
        }

        /// <summary> Retrieves information about an SSH public key. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="sshPublicKeyName"> The name of the SSH public key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sshPublicKeyName"/> is null. </exception>
        public static Response<SshPublicKeyInfo> GetSshPublicKey(this ResourceGroup resourceGroup, string sshPublicKeyName, CancellationToken cancellationToken = default)
        {
            if (sshPublicKeyName == null)
            {
                throw new ArgumentNullException(nameof(sshPublicKeyName));
            }

            return resourceGroup.UseClientContext((baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                var restOperations = GetSshPublicKeysRestOperations(clientDiagnostics, credential, options, pipeline, resourceGroup.Id.SubscriptionId, baseUri);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.GetSshPublicKey");
                scope.Start();
                try
                {
                    var response = restOperations.Get(resourceGroup.Id.Name, sshPublicKeyName, cancellationToken);
                    return response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            );
        }

        #endregion
    }
}
