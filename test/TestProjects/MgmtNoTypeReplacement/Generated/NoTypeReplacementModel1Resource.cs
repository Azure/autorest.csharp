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

namespace MgmtNoTypeReplacement
{
    /// <summary>
    /// A Class representing a NoTypeReplacementModel1 along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="NoTypeReplacementModel1Resource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetNoTypeReplacementModel1Resource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetNoTypeReplacementModel1 method.
    /// </summary>
    public partial class NoTypeReplacementModel1Resource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="NoTypeReplacementModel1Resource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="noTypeReplacementModel1SName"> The noTypeReplacementModel1SName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string noTypeReplacementModel1SName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1SName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _noTypeReplacementModel1ClientDiagnostics;
        private readonly NoTypeReplacementModel1SRestOperations _noTypeReplacementModel1RestClient;
        private readonly NoTypeReplacementModel1Data _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/noTypeReplacementModel1s";

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel1Resource"/> class for mocking. </summary>
        protected NoTypeReplacementModel1Resource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel1Resource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal NoTypeReplacementModel1Resource(ArmClient client, NoTypeReplacementModel1Data data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="NoTypeReplacementModel1Resource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal NoTypeReplacementModel1Resource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _noTypeReplacementModel1ClientDiagnostics = new ClientDiagnostics("MgmtNoTypeReplacement", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string noTypeReplacementModel1ApiVersion);
            _noTypeReplacementModel1RestClient = new NoTypeReplacementModel1SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, noTypeReplacementModel1ApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual NoTypeReplacementModel1Data Data
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NoTypeReplacementModel1Resource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Resource.Get");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NoTypeReplacementModel1Resource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Resource.Get");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NoTypeReplacementModel1Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The <see cref="NoTypeReplacementModel1Data"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NoTypeReplacementModel1Resource>> UpdateAsync(WaitUntil waitUntil, NoTypeReplacementModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Resource.Update");
            scope.Start();
            try
            {
                var response = await _noTypeReplacementModel1RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtNoTypeReplacementArmOperation<NoTypeReplacementModel1Resource>(Response.FromValue(new NoTypeReplacementModel1Resource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/noTypeReplacementModel1s/{noTypeReplacementModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NoTypeReplacementModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The <see cref="NoTypeReplacementModel1Data"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NoTypeReplacementModel1Resource> Update(WaitUntil waitUntil, NoTypeReplacementModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _noTypeReplacementModel1ClientDiagnostics.CreateScope("NoTypeReplacementModel1Resource.Update");
            scope.Start();
            try
            {
                var response = _noTypeReplacementModel1RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken);
                var operation = new MgmtNoTypeReplacementArmOperation<NoTypeReplacementModel1Resource>(Response.FromValue(new NoTypeReplacementModel1Resource(Client, response), response.GetRawResponse()));
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
