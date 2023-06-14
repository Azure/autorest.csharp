// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtMockAndSample
{
    /// <summary>
    /// A class representing a collection of <see cref="DeletedVaultResource" /> and their operations.
    /// Each <see cref="DeletedVaultResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />.
    /// To get a <see cref="DeletedVaultCollection" /> instance call the GetDeletedVaults method from an instance of <see cref="SubscriptionResource" />.
    /// </summary>
    public partial class DeletedVaultCollection : ArmCollection
    {
        private readonly ClientDiagnostics _deletedVaultVaultsClientDiagnostics;
        private readonly VaultsRestOperations _deletedVaultVaultsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DeletedVaultCollection"/> class for mocking. </summary>
        protected DeletedVaultCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DeletedVaultCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DeletedVaultCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deletedVaultVaultsClientDiagnostics = new ClientDiagnostics("MgmtMockAndSample", DeletedVaultResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DeletedVaultResource.ResourceType, out string deletedVaultVaultsApiVersion);
            _deletedVaultVaultsRestClient = new VaultsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, deletedVaultVaultsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SubscriptionResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SubscriptionResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the deleted Azure key vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted vault. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public virtual async Task<Response<DeletedVaultResource>> GetAsync(AzureLocation location, string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));

            using var scope = _deletedVaultVaultsClientDiagnostics.CreateScope("DeletedVaultCollection.Get");
            scope.Start();
            try
            {
                var response = await _deletedVaultVaultsRestClient.GetDeletedAsync(Id.SubscriptionId, location, vaultName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedVaultResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the deleted Azure key vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted vault. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public virtual Response<DeletedVaultResource> Get(AzureLocation location, string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));

            using var scope = _deletedVaultVaultsClientDiagnostics.CreateScope("DeletedVaultCollection.Get");
            scope.Start();
            try
            {
                var response = _deletedVaultVaultsRestClient.GetDeleted(Id.SubscriptionId, location, vaultName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedVaultResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted vault. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(AzureLocation location, string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));

            using var scope = _deletedVaultVaultsClientDiagnostics.CreateScope("DeletedVaultCollection.Exists");
            scope.Start();
            try
            {
                var response = await _deletedVaultVaultsRestClient.GetDeletedAsync(Id.SubscriptionId, location, vaultName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted vault. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        public virtual Response<bool> Exists(AzureLocation location, string vaultName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));

            using var scope = _deletedVaultVaultsClientDiagnostics.CreateScope("DeletedVaultCollection.Exists");
            scope.Start();
            try
            {
                var response = _deletedVaultVaultsRestClient.GetDeleted(Id.SubscriptionId, location, vaultName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
