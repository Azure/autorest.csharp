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
using MgmtKeyvault.Models;

namespace MgmtKeyvault
{
    /// <summary> A class to add extension methods to MgmtKeyvault. </summary>
    public static partial class MgmtKeyvaultExtensions
    {
        private static SubscriptionResourceExtensionClient GetExtensionClient(SubscriptionResource subscriptionResource)
        {
            return subscriptionResource.GetCachedClient((client) =>
            {
                return new SubscriptionResourceExtensionClient(client, subscriptionResource.Id);
            }
            );
        }

        /// <summary> Gets a collection of DeletedVaultResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DeletedVaultResources and their operations over a DeletedVaultResource. </returns>
        public static DeletedVaultCollection GetDeletedVaults(this SubscriptionResource subscriptionResource)
        {
            return GetExtensionClient(subscriptionResource).GetDeletedVaults();
        }

        /// <summary>
        /// Gets the deleted Azure key vault.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}
        /// Operation Id: Vaults_GetDeleted
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the deleted vault. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="vaultName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DeletedVaultResource>> GetDeletedVaultAsync(this SubscriptionResource subscriptionResource, string location, string vaultName, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetDeletedVaults().GetAsync(location, vaultName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the deleted Azure key vault.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}
        /// Operation Id: Vaults_GetDeleted
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the deleted vault. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="vaultName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DeletedVaultResource> GetDeletedVault(this SubscriptionResource subscriptionResource, string location, string vaultName, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetDeletedVaults().Get(location, vaultName, cancellationToken);
        }

        /// <summary> Gets a collection of DeletedManagedHsmResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DeletedManagedHsmResources and their operations over a DeletedManagedHsmResource. </returns>
        public static DeletedManagedHsmCollection GetDeletedManagedHsms(this SubscriptionResource subscriptionResource)
        {
            return GetExtensionClient(subscriptionResource).GetDeletedManagedHsms();
        }

        /// <summary>
        /// Gets the specified deleted managed HSM.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}
        /// Operation Id: ManagedHsms_GetDeleted
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the deleted managed HSM. </param>
        /// <param name="name"> The name of the deleted managed HSM. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DeletedManagedHsmResource>> GetDeletedManagedHsmAsync(this SubscriptionResource subscriptionResource, string location, string name, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetDeletedManagedHsms().GetAsync(location, name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified deleted managed HSM.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}
        /// Operation Id: ManagedHsms_GetDeleted
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the deleted managed HSM. </param>
        /// <param name="name"> The name of the deleted managed HSM. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> or <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> or <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DeletedManagedHsmResource> GetDeletedManagedHsm(this SubscriptionResource subscriptionResource, string location, string name, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetDeletedManagedHsms().Get(location, name, cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the vaults associated with the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/vaults
        /// Operation Id: Vaults_ListBySubscription
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VaultResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VaultResource> GetVaultsAsync(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetVaultsAsync(top, cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the vaults associated with the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/vaults
        /// Operation Id: Vaults_ListBySubscription
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VaultResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VaultResource> GetVaults(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetVaults(top, cancellationToken);
        }

        /// <summary>
        /// Gets information about the deleted vaults in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults
        /// Operation Id: Vaults_ListDeleted
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeletedVaultResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<DeletedVaultResource> GetDeletedVaultsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetDeletedVaultsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets information about the deleted vaults in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults
        /// Operation Id: Vaults_ListDeleted
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedVaultResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<DeletedVaultResource> GetDeletedVaults(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetDeletedVaults(cancellationToken);
        }

        /// <summary>
        /// Checks that the vault name is valid and is not already in use.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/checkNameAvailability
        /// Operation Id: Vaults_CheckNameAvailability
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="content"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static async Task<Response<CheckNameAvailabilityResult>> CheckNameAvailabilityVaultAsync(this SubscriptionResource subscriptionResource, VaultCheckNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return await GetExtensionClient(subscriptionResource).CheckNameAvailabilityVaultAsync(content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks that the vault name is valid and is not already in use.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/checkNameAvailability
        /// Operation Id: Vaults_CheckNameAvailability
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="content"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static Response<CheckNameAvailabilityResult> CheckNameAvailabilityVault(this SubscriptionResource subscriptionResource, VaultCheckNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return GetExtensionClient(subscriptionResource).CheckNameAvailabilityVault(content, cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the managed HSM Pools associated with the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/managedHSMs
        /// Operation Id: ManagedHsms_ListBySubscription
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ManagedHsmResource> GetManagedHsmsAsync(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetManagedHsmsAsync(top, cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the managed HSM Pools associated with the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/managedHSMs
        /// Operation Id: ManagedHsms_ListBySubscription
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ManagedHsmResource> GetManagedHsms(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetManagedHsms(top, cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the deleted managed HSMs associated with the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedManagedHSMs
        /// Operation Id: ManagedHsms_ListDeleted
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeletedManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<DeletedManagedHsmResource> GetDeletedManagedHsmsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetDeletedManagedHsmsAsync(cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the deleted managed HSMs associated with the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedManagedHSMs
        /// Operation Id: ManagedHsms_ListDeleted
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<DeletedManagedHsmResource> GetDeletedManagedHsms(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetDeletedManagedHsms(cancellationToken);
        }

        private static ResourceGroupResourceExtensionClient GetExtensionClient(ResourceGroupResource resourceGroupResource)
        {
            return resourceGroupResource.GetCachedClient((client) =>
            {
                return new ResourceGroupResourceExtensionClient(client, resourceGroupResource.Id);
            }
            );
        }

        /// <summary> Gets a collection of VaultResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of VaultResources and their operations over a VaultResource. </returns>
        public static VaultCollection GetVaults(this ResourceGroupResource resourceGroupResource)
        {
            return GetExtensionClient(resourceGroupResource).GetVaults();
        }

        /// <summary>
        /// Gets the specified Azure key vault.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}
        /// Operation Id: Vaults_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<VaultResource>> GetVaultAsync(this ResourceGroupResource resourceGroupResource, string vaultName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetVaults().GetAsync(vaultName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified Azure key vault.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}
        /// Operation Id: Vaults_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<VaultResource> GetVault(this ResourceGroupResource resourceGroupResource, string vaultName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetVaults().Get(vaultName, cancellationToken);
        }

        /// <summary> Gets a collection of ManagedHsmResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ManagedHsmResources and their operations over a ManagedHsmResource. </returns>
        public static ManagedHsmCollection GetManagedHsms(this ResourceGroupResource resourceGroupResource)
        {
            return GetExtensionClient(resourceGroupResource).GetManagedHsms();
        }

        /// <summary>
        /// Gets the specified managed HSM Pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// Operation Id: ManagedHsms_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ManagedHsmResource>> GetManagedHsmAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetManagedHsms().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified managed HSM Pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}
        /// Operation Id: ManagedHsms_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ManagedHsmResource> GetManagedHsm(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetManagedHsms().Get(name, cancellationToken);
        }

        #region VaultResource
        /// <summary>
        /// Gets an object representing a <see cref="VaultResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VaultResource.CreateResourceIdentifier" /> to create a <see cref="VaultResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VaultResource" /> object. </returns>
        public static VaultResource GetVaultResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VaultResource.ValidateResourceId(id);
                return new VaultResource(client, id);
            }
            );
        }
        #endregion

        #region DeletedVaultResource
        /// <summary>
        /// Gets an object representing a <see cref="DeletedVaultResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DeletedVaultResource.CreateResourceIdentifier" /> to create a <see cref="DeletedVaultResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DeletedVaultResource" /> object. </returns>
        public static DeletedVaultResource GetDeletedVaultResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                DeletedVaultResource.ValidateResourceId(id);
                return new DeletedVaultResource(client, id);
            }
            );
        }
        #endregion

        #region PrivateEndpointConnectionResource
        /// <summary>
        /// Gets an object representing a <see cref="PrivateEndpointConnectionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PrivateEndpointConnectionResource.CreateResourceIdentifier" /> to create a <see cref="PrivateEndpointConnectionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PrivateEndpointConnectionResource" /> object. </returns>
        public static PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                PrivateEndpointConnectionResource.ValidateResourceId(id);
                return new PrivateEndpointConnectionResource(client, id);
            }
            );
        }
        #endregion

        #region ManagedHsmResource
        /// <summary>
        /// Gets an object representing a <see cref="ManagedHsmResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ManagedHsmResource.CreateResourceIdentifier" /> to create a <see cref="ManagedHsmResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ManagedHsmResource" /> object. </returns>
        public static ManagedHsmResource GetManagedHsmResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ManagedHsmResource.ValidateResourceId(id);
                return new ManagedHsmResource(client, id);
            }
            );
        }
        #endregion

        #region DeletedManagedHsmResource
        /// <summary>
        /// Gets an object representing a <see cref="DeletedManagedHsmResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DeletedManagedHsmResource.CreateResourceIdentifier" /> to create a <see cref="DeletedManagedHsmResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DeletedManagedHsmResource" /> object. </returns>
        public static DeletedManagedHsmResource GetDeletedManagedHsmResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                DeletedManagedHsmResource.ValidateResourceId(id);
                return new DeletedManagedHsmResource(client, id);
            }
            );
        }
        #endregion

        #region MhsmPrivateEndpointConnectionResource
        /// <summary>
        /// Gets an object representing a <see cref="MhsmPrivateEndpointConnectionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier" /> to create a <see cref="MhsmPrivateEndpointConnectionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MhsmPrivateEndpointConnectionResource" /> object. </returns>
        public static MhsmPrivateEndpointConnectionResource GetMhsmPrivateEndpointConnectionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                MhsmPrivateEndpointConnectionResource.ValidateResourceId(id);
                return new MhsmPrivateEndpointConnectionResource(client, id);
            }
            );
        }
        #endregion
    }
}
