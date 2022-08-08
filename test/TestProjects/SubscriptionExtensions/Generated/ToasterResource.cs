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
using Azure.ResourceManager.Resources;

namespace SubscriptionExtensions
{
    /// <summary>
    /// A Class representing a Toaster along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ToasterResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetToasterResource method.
    /// Otherwise you can get one from its parent resource <see cref="SubscriptionResource" /> using the GetToaster method.
    /// </summary>
    public partial class ToasterResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ToasterResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string toasterName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _toasterClientDiagnostics;
        private readonly ToastersRestOperations _toasterRestClient;
        private readonly ToasterData _data;

        /// <summary> Initializes a new instance of the <see cref="ToasterResource"/> class for mocking. </summary>
        protected ToasterResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ToasterResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ToasterResource(ArmClient client, ToasterData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ToasterResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ToasterResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _toasterClientDiagnostics = new ClientDiagnostics("SubscriptionExtensions", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string toasterApiVersion);
            _toasterRestClient = new ToastersRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, toasterApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/toasters";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ToasterData Data
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// Operation Id: Toasters_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ToasterResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _toasterClientDiagnostics.CreateScope("ToasterResource.Get");
            scope.Start();
            try
            {
                var response = await _toasterRestClient.GetAsync(Id.SubscriptionId, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ToasterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// Operation Id: Toasters_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ToasterResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _toasterClientDiagnostics.CreateScope("ToasterResource.Get");
            scope.Start();
            try
            {
                var response = _toasterRestClient.Get(Id.SubscriptionId, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ToasterResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// Operation Id: Toasters_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ToasterResource>> UpdateAsync(WaitUntil waitUntil, ToasterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _toasterClientDiagnostics.CreateScope("ToasterResource.Update");
            scope.Start();
            try
            {
                var response = await _toasterRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new SubscriptionExtensionsArmOperation<ToasterResource>(Response.FromValue(new ToasterResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update an availability set.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/toasters/{toasterName}
        /// Operation Id: Toasters_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ToasterResource> Update(WaitUntil waitUntil, ToasterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _toasterClientDiagnostics.CreateScope("ToasterResource.Update");
            scope.Start();
            try
            {
                var response = _toasterRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, data, cancellationToken);
                var operation = new SubscriptionExtensionsArmOperation<ToasterResource>(Response.FromValue(new ToasterResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
