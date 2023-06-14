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
        /// Gets a specific foo with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="skip"> Optional. Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FooResource>> GetAsync(string filter = null, int? top = null, string orderby = null, ETag? ifMatch = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Get");
            scope.Start();
            try
            {
                var response = await _fooRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, orderby, ifMatch, skip, cancellationToken).ConfigureAwait(false);
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
        /// Gets a specific foo with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="skip"> Optional. Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FooResource> Get(string filter = null, int? top = null, string orderby = null, ETag? ifMatch = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Get");
            scope.Start();
            try
            {
                var response = _fooRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, orderby, ifMatch, skip, cancellationToken);
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
        /// Update foo.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The foo parameters supplied to the Update operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<FooResource>> UpdateAsync(FooPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Update");
            scope.Start();
            try
            {
                var response = await _fooRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new FooResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update foo.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> The foo parameters supplied to the Update operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<FooResource> Update(FooPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Update");
            scope.Start();
            try
            {
                var response = _fooRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, cancellationToken);
                return Response.FromValue(new FooResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reconnect an existing foo with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}/reconnect</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Reconnect</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FooResource>> ReconnectAsync(FooReconnectTestOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new FooReconnectTestOptions();

            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Reconnect");
            scope.Start();
            try
            {
                var response = await _fooRestClient.ReconnectAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, options.Data, options.Filter, options.Top, options.Orderby, options.IfMatch, options.CountryOrRegions, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new FooResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reconnect an existing foo with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/foos/{fooName}/reconnect</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Foos_Reconnect</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FooResource> Reconnect(FooReconnectTestOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new FooReconnectTestOptions();

            using var scope = _fooClientDiagnostics.CreateScope("FooResource.Reconnect");
            scope.Start();
            try
            {
                var response = _fooRestClient.Reconnect(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, options.Data, options.Filter, options.Top, options.Orderby, options.IfMatch, options.CountryOrRegions, cancellationToken);
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
