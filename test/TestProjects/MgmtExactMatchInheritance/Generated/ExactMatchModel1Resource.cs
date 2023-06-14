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

namespace MgmtExactMatchInheritance
{
    /// <summary>
    /// A Class representing an ExactMatchModel1 along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="ExactMatchModel1Resource" />
    /// from an instance of <see cref="ArmClient" /> using the GetExactMatchModel1Resource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetExactMatchModel1 method.
    /// </summary>
    public partial class ExactMatchModel1Resource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ExactMatchModel1Resource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string exactMatchModel1SName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1SName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _exactMatchModel1ClientDiagnostics;
        private readonly ExactMatchModel1SRestOperations _exactMatchModel1RestClient;
        private readonly ExactMatchModel1Data _data;

        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel1Resource"/> class for mocking. </summary>
        protected ExactMatchModel1Resource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ExactMatchModel1Resource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ExactMatchModel1Resource(ArmClient client, ExactMatchModel1Data data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel1Resource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ExactMatchModel1Resource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _exactMatchModel1ClientDiagnostics = new ClientDiagnostics("MgmtExactMatchInheritance", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string exactMatchModel1ApiVersion);
            _exactMatchModel1RestClient = new ExactMatchModel1SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, exactMatchModel1ApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/exactMatchModel1s";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ExactMatchModel1Data Data
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ExactMatchModel1Resource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Resource.Get");
            scope.Start();
            try
            {
                var response = await _exactMatchModel1RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExactMatchModel1Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel1s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ExactMatchModel1Resource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Resource.Get");
            scope.Start();
            try
            {
                var response = _exactMatchModel1RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExactMatchModel1Resource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ExactMatchModel1Resource>> UpdateAsync(WaitUntil waitUntil, ExactMatchModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Resource.Update");
            scope.Start();
            try
            {
                var response = await _exactMatchModel1RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtExactMatchInheritanceArmOperation<ExactMatchModel1Resource>(Response.FromValue(new ExactMatchModel1Resource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/exactMatchModel1s/{exactMatchModel1sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ExactMatchModel1s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ExactMatchModel1Resource> Update(WaitUntil waitUntil, ExactMatchModel1Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _exactMatchModel1ClientDiagnostics.CreateScope("ExactMatchModel1Resource.Update");
            scope.Start();
            try
            {
                var response = _exactMatchModel1RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, data, cancellationToken);
                var operation = new MgmtExactMatchInheritanceArmOperation<ExactMatchModel1Resource>(Response.FromValue(new ExactMatchModel1Resource(Client, response), response.GetRawResponse()));
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
