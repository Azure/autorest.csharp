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

namespace MgmtScopeResource
{
    /// <summary>
    /// A Class representing a VMInsightsOnboardingStatus along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="VMInsightsOnboardingStatusResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetVMInsightsOnboardingStatusResource method.
    /// Otherwise you can get one from its parent resource <see cref="ArmResource" /> using the GetVMInsightsOnboardingStatus method.
    /// </summary>
    public partial class VMInsightsOnboardingStatusResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="VMInsightsOnboardingStatusResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string resourceUri)
        {
            var resourceId = $"{resourceUri}/providers/Microsoft.Insights/vmInsightsOnboardingStatuses/default";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _vmInsightsOnboardingStatusVMInsightsClientDiagnostics;
        private readonly VMInsightsRestOperations _vmInsightsOnboardingStatusVMInsightsRestClient;
        private readonly VMInsightsOnboardingStatusData _data;

        /// <summary> Initializes a new instance of the <see cref="VMInsightsOnboardingStatusResource"/> class for mocking. </summary>
        protected VMInsightsOnboardingStatusResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "VMInsightsOnboardingStatusResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal VMInsightsOnboardingStatusResource(ArmClient client, VMInsightsOnboardingStatusData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="VMInsightsOnboardingStatusResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VMInsightsOnboardingStatusResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _vmInsightsOnboardingStatusVMInsightsClientDiagnostics = new ClientDiagnostics("MgmtScopeResource", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string vmInsightsOnboardingStatusVMInsightsApiVersion);
            _vmInsightsOnboardingStatusVMInsightsRestClient = new VMInsightsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, vmInsightsOnboardingStatusVMInsightsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Insights/vmInsightsOnboardingStatuses";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual VMInsightsOnboardingStatusData Data
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
        /// Retrieves the VM Insights onboarding status for the specified resource or resource scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceUri}/providers/Microsoft.Insights/vmInsightsOnboardingStatuses/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VMInsights_GetOnboardingStatus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<VMInsightsOnboardingStatusResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _vmInsightsOnboardingStatusVMInsightsClientDiagnostics.CreateScope("VMInsightsOnboardingStatusResource.Get");
            scope.Start();
            try
            {
                var response = await _vmInsightsOnboardingStatusVMInsightsRestClient.GetOnboardingStatusAsync(Id.Parent, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VMInsightsOnboardingStatusResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the VM Insights onboarding status for the specified resource or resource scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{resourceUri}/providers/Microsoft.Insights/vmInsightsOnboardingStatuses/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VMInsights_GetOnboardingStatus</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<VMInsightsOnboardingStatusResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _vmInsightsOnboardingStatusVMInsightsClientDiagnostics.CreateScope("VMInsightsOnboardingStatusResource.Get");
            scope.Start();
            try
            {
                var response = _vmInsightsOnboardingStatusVMInsightsRestClient.GetOnboardingStatus(Id.Parent, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VMInsightsOnboardingStatusResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
