// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtPropertyBag
{
    /// <summary>
    /// A Class representing a Bar along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="BarResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetBarResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetBar method.
    /// </summary>
    public partial class BarResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="BarResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string barName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _barClientDiagnostics;
        private readonly BarsRestOperations _barRestClient;
        private readonly BarData _data;

        /// <summary> Initializes a new instance of the <see cref="BarResource"/> class for mocking. </summary>
        protected BarResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "BarResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal BarResource(ArmClient client, BarData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="BarResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BarResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _barClientDiagnostics = new ClientDiagnostics("MgmtPropertyBag", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string barApiVersion);
            _barRestClient = new BarsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, barApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Fake/bars";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual BarData Data
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
        /// Gets a specific bar with one required header parameter and four optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="skip"> Optional. Number of records to skip. </param>
        /// <param name="items"> The items to query on the bar resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BarResource>> GetAsync(string ifMatch = null, string filter = null, int? top = null, int? skip = null, IEnumerable<string> items = null, CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("BarResource.Get");
            scope.Start();
            try
            {
                var response = await _barRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ifMatch, filter, top, skip, items, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BarResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a specific bar with one required header parameter and four optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="skip"> Optional. Number of records to skip. </param>
        /// <param name="items"> The items to query on the bar resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BarResource> Get(string ifMatch = null, string filter = null, int? top = null, int? skip = null, IEnumerable<string> items = null, CancellationToken cancellationToken = default)
        {
            using var scope = _barClientDiagnostics.CreateScope("BarResource.Get");
            scope.Start();
            try
            {
                var response = _barRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ifMatch, filter, top, skip, items, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BarResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create a bar with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The bar parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<BarResource>> UpdateAsync(WaitUntil waitUntil, BarData data, string filter = null, int? top = null, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _barClientDiagnostics.CreateScope("BarResource.Update");
            scope.Start();
            try
            {
                var response = await _barRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, filter, top, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtPropertyBagArmOperation<BarResource>(Response.FromValue(new BarResource(Client, response), response.GetRawResponse()));
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
        /// Create a bar with five optional query parameters.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Bars_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The bar parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="ifMatch"> The entity state (Etag) version. A value of "*" can be used for If-Match to unconditionally apply the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<BarResource> Update(WaitUntil waitUntil, BarData data, string filter = null, int? top = null, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _barClientDiagnostics.CreateScope("BarResource.Update");
            scope.Start();
            try
            {
                var response = _barRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, filter, top, ifMatch, cancellationToken);
                var operation = new MgmtPropertyBagArmOperation<BarResource>(Response.FromValue(new BarResource(Client, response), response.GetRawResponse()));
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
