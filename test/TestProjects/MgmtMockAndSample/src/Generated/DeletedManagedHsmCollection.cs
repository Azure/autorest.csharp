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
    /// A class representing a collection of <see cref="DeletedManagedHsmResource" /> and their operations.
    /// Each <see cref="DeletedManagedHsmResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />.
    /// To get a <see cref="DeletedManagedHsmCollection" /> instance call the GetDeletedManagedHsms method from an instance of <see cref="SubscriptionResource" />.
    /// </summary>
    public partial class DeletedManagedHsmCollection : ArmCollection
    {
        private readonly ClientDiagnostics _deletedManagedHsmManagedHsmsClientDiagnostics;
        private readonly ManagedHsmsRestOperations _deletedManagedHsmManagedHsmsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DeletedManagedHsmCollection"/> class for mocking. </summary>
        protected DeletedManagedHsmCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DeletedManagedHsmCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DeletedManagedHsmCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deletedManagedHsmManagedHsmsClientDiagnostics = new ClientDiagnostics("MgmtMockAndSample", DeletedManagedHsmResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DeletedManagedHsmResource.ResourceType, out string deletedManagedHsmManagedHsmsApiVersion);
            _deletedManagedHsmManagedHsmsRestClient = new ManagedHsmsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, deletedManagedHsmManagedHsmsApiVersion);
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
        /// Gets the specified deleted managed HSM.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted managed HSM. </param>
        /// <param name="name"> The name of the deleted managed HSM. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<DeletedManagedHsmResource>> GetAsync(AzureLocation location, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _deletedManagedHsmManagedHsmsClientDiagnostics.CreateScope("DeletedManagedHsmCollection.Get");
            scope.Start();
            try
            {
                var response = await _deletedManagedHsmManagedHsmsRestClient.GetDeletedAsync(Id.SubscriptionId, location, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedManagedHsmResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified deleted managed HSM.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted managed HSM. </param>
        /// <param name="name"> The name of the deleted managed HSM. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<DeletedManagedHsmResource> Get(AzureLocation location, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _deletedManagedHsmManagedHsmsClientDiagnostics.CreateScope("DeletedManagedHsmCollection.Get");
            scope.Start();
            try
            {
                var response = _deletedManagedHsmManagedHsmsRestClient.GetDeleted(Id.SubscriptionId, location, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedManagedHsmResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted managed HSM. </param>
        /// <param name="name"> The name of the deleted managed HSM. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(AzureLocation location, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _deletedManagedHsmManagedHsmsClientDiagnostics.CreateScope("DeletedManagedHsmCollection.Exists");
            scope.Start();
            try
            {
                var response = await _deletedManagedHsmManagedHsmsRestClient.GetDeletedAsync(Id.SubscriptionId, location, name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The location of the deleted managed HSM. </param>
        /// <param name="name"> The name of the deleted managed HSM. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(AzureLocation location, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _deletedManagedHsmManagedHsmsClientDiagnostics.CreateScope("DeletedManagedHsmCollection.Exists");
            scope.Start();
            try
            {
                var response = _deletedManagedHsmManagedHsmsRestClient.GetDeleted(Id.SubscriptionId, location, name, cancellationToken: cancellationToken);
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
