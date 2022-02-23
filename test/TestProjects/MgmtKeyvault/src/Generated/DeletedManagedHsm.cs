// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace MgmtKeyvault
{
    /// <summary> A Class representing a DeletedManagedHsm along with the instance operations that can be performed on it. </summary>
    public partial class DeletedManagedHsm : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DeletedManagedHsm"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string name)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _deletedManagedHsmManagedHsmsClientDiagnostics;
        private readonly ManagedHsmsRestOperations _deletedManagedHsmManagedHsmsRestClient;
        private readonly DeletedManagedHsmData _data;

        /// <summary> Initializes a new instance of the <see cref="DeletedManagedHsm"/> class for mocking. </summary>
        protected DeletedManagedHsm()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "DeletedManagedHsm"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DeletedManagedHsm(ArmClient client, DeletedManagedHsmData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DeletedManagedHsm"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DeletedManagedHsm(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deletedManagedHsmManagedHsmsClientDiagnostics = new ClientDiagnostics("MgmtKeyvault", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string deletedManagedHsmManagedHsmsApiVersion);
            _deletedManagedHsmManagedHsmsRestClient = new ManagedHsmsRestOperations(_deletedManagedHsmManagedHsmsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, deletedManagedHsmManagedHsmsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.KeyVault/locations/deletedManagedHSMs";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DeletedManagedHsmData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the specified deleted managed HSM.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}
        /// Operation Id: ManagedHsms_GetDeleted
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeletedManagedHsm>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _deletedManagedHsmManagedHsmsClientDiagnostics.CreateScope("DeletedManagedHsm.Get");
            scope.Start();
            try
            {
                var response = await _deletedManagedHsmManagedHsmsRestClient.GetDeletedAsync(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _deletedManagedHsmManagedHsmsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DeletedManagedHsm(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified deleted managed HSM.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}
        /// Operation Id: ManagedHsms_GetDeleted
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeletedManagedHsm> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _deletedManagedHsmManagedHsmsClientDiagnostics.CreateScope("DeletedManagedHsm.Get");
            scope.Start();
            try
            {
                var response = _deletedManagedHsmManagedHsmsRestClient.GetDeleted(Id.SubscriptionId, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _deletedManagedHsmManagedHsmsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedManagedHsm(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Permanently deletes the specified managed HSM.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}/purge
        /// Operation Id: ManagedHsms_PurgeDeleted
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> PurgeDeletedAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _deletedManagedHsmManagedHsmsClientDiagnostics.CreateScope("DeletedManagedHsm.PurgeDeleted");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(Id.SubscriptionId, "Id.SubscriptionId");
                Argument.AssertNotNullOrEmpty(Id.Parent.Name, "Id.Parent.Name");
                Argument.AssertNotNullOrEmpty(Id.Name, "Id.Name");
                using var message = _deletedManagedHsmManagedHsmsRestClient.CreatePurgeDeletedRequest(Id.SubscriptionId, Id.Parent.Name, Id.Name);
                return await ArmOperationHelpers.ProcessMessageAsync(Pipeline, message, _deletedManagedHsmManagedHsmsClientDiagnostics, waitForCompletion, "DeletedManagedHsm.PurgeDeleted", OperationFinalStateVia.Location, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Permanently deletes the specified managed HSM.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}/purge
        /// Operation Id: ManagedHsms_PurgeDeleted
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation PurgeDeleted(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _deletedManagedHsmManagedHsmsClientDiagnostics.CreateScope("DeletedManagedHsm.PurgeDeleted");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(Id.SubscriptionId, "Id.SubscriptionId");
                Argument.AssertNotNullOrEmpty(Id.Parent.Name, "Id.Parent.Name");
                Argument.AssertNotNullOrEmpty(Id.Name, "Id.Name");
                using var message = _deletedManagedHsmManagedHsmsRestClient.CreatePurgeDeletedRequest(Id.SubscriptionId, Id.Parent.Name, Id.Name);
                return ArmOperationHelpers.ProcessMessage(Pipeline, message, _deletedManagedHsmManagedHsmsClientDiagnostics, waitForCompletion, "DeletedManagedHsm.PurgeDeleted", OperationFinalStateVia.Location, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
