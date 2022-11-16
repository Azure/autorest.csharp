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
using MgmtPropertyBag.Models;

namespace MgmtPropertyBag
{
    /// <summary>
    /// A Class representing a Foo along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="FooResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetFooResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetFoo method.
    /// </summary>
    public partial class FooResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="FooResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fooName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _fooClientDiagnostics;
        private readonly FoosRestOperations _fooRestClient;
        private readonly FooData _data;

        /// <summary> Initializes a new instance of the <see cref="FooResource"/> class for mocking. </summary>
        protected FooResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "FooResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal FooResource(ArmClient client, FooData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="FooResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal FooResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fooClientDiagnostics = new ClientDiagnostics("MgmtPropertyBag", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string fooApiVersion);
            _fooRestClient = new FoosRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fooApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Fake/foos";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual FooData Data
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
        /// Gets a specific foo with three optional query parameters.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}
        /// Operation Id: Foos_Get
        /// </summary>
        /// <param name="options"> A property bag which contains all the query and header parameters of this method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FooResource>> GetAsync(FooGetOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new FooGetOptions();

            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Get");
            scope.Start();
            try
            {
                var response = await _fooRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, options.Filter, options.Top, options.Orderby, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FooResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a specific foo with three optional query parameters.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}
        /// Operation Id: Foos_Get
        /// </summary>
        /// <param name="options"> A property bag which contains all the query and header parameters of this method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FooResource> Get(FooGetOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new FooGetOptions();

            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Get");
            scope.Start();
            try
            {
                var response = _fooRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, options.Filter, options.Top, options.Orderby, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FooResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create foo with three optional query parameters.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}
        /// Operation Id: Foos_Create
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The foo parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="options"> A property bag which contains all the query and header parameters of this method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FooResource>> UpdateAsync(WaitUntil waitUntil, FooData data, FooCreateOrUpdateOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            options ??= new FooCreateOrUpdateOptions();

            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Update");
            scope.Start();
            try
            {
                var response = await _fooRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, options.Filter, options.Top, options.Orderby, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtPropertyBagArmOperation<FooResource>(Response.FromValue(new FooResource(Client, response), response.GetRawResponse()));
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
        /// Create foo with three optional query parameters.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}
        /// Operation Id: Foos_Create
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The foo parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="options"> A property bag which contains all the query and header parameters of this method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FooResource> Update(WaitUntil waitUntil, FooData data, FooCreateOrUpdateOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            options ??= new FooCreateOrUpdateOptions();

            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Update");
            scope.Start();
            try
            {
                var response = _fooRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, options.Filter, options.Top, options.Orderby, cancellationToken);
                var operation = new MgmtPropertyBagArmOperation<FooResource>(Response.FromValue(new FooResource(Client, response), response.GetRawResponse()));
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

        /// <summary>
        /// Reconnect an existing foo with three optional query parameters.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}/reconnect
        /// Operation Id: Foos_Reconnect
        /// </summary>
        /// <param name="options"> A property bag which contains all the query and header parameters of this method. </param>
        /// <param name="data"> The parameters supplied to the Reconnect operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FooResource>> ReconnectAsync(FooReconnectTestOptions options, FooData data = null, CancellationToken cancellationToken = default)
        {
            options ??= new FooReconnectTestOptions();

            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Reconnect");
            scope.Start();
            try
            {
                var response = await _fooRestClient.ReconnectAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, options.Filter, options.Top, options.Orderby, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new FooResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reconnect an existing foo with three optional query parameters.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}/reconnect
        /// Operation Id: Foos_Reconnect
        /// </summary>
        /// <param name="options"> A property bag which contains all the query and header parameters of this method. </param>
        /// <param name="data"> The parameters supplied to the Reconnect operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FooResource> Reconnect(FooReconnectTestOptions options, FooData data = null, CancellationToken cancellationToken = default)
        {
            options ??= new FooReconnectTestOptions();

            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Reconnect");
            scope.Start();
            try
            {
                var response = _fooRestClient.Reconnect(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, options.Filter, options.Top, options.Orderby, cancellationToken);
                return Response.FromValue(new FooResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
