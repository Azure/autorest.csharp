// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using MgmtOperations.Models;

namespace MgmtOperations
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    internal partial class ResourceGroupExtensionClient : ArmResource
    {
        private ClientDiagnostics _availabilitySetClientDiagnostics;
        private AvailabilitySetsRestOperations _availabilitySetRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics AvailabilitySetClientDiagnostics => _availabilitySetClientDiagnostics ??= new ClientDiagnostics("MgmtOperations", AvailabilitySet.ResourceType.Namespace, DiagnosticOptions);
        private AvailabilitySetsRestOperations AvailabilitySetRestClient => _availabilitySetRestClient ??= new AvailabilitySetsRestOperations(AvailabilitySetClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(AvailabilitySet.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            Client.TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of AvailabilitySets in the AvailabilitySet. </summary>
        /// <returns> An object representing collection of AvailabilitySets and their operations over a AvailabilitySet. </returns>
        public virtual AvailabilitySetCollection GetAvailabilitySets()
        {
            return new AvailabilitySetCollection(Client, Id);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/patchAvailabilitySets
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AvailabilitySets_TestLROMethod
        /// <summary> Update an availability set. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation<TestAvailabilitySet>> TestLROMethodAvailabilitySetAsync(bool waitForCompletion, AvailabilitySetUpdate parameters, CancellationToken cancellationToken = default)
        {
            using var scope = AvailabilitySetClientDiagnostics.CreateScope("ResourceGroupExtensionClient.TestLROMethodAvailabilitySet");
            scope.Start();
            try
            {
                var response = await AvailabilitySetRestClient.TestLROMethodAsync(Id.SubscriptionId, Id.ResourceGroupName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtOperationsArmOperation<TestAvailabilitySet>(new TestAvailabilitySetSource(Client), AvailabilitySetClientDiagnostics, Pipeline, AvailabilitySetRestClient.CreateTestLROMethodRequest(Id.SubscriptionId, Id.ResourceGroupName, parameters).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/patchAvailabilitySets
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AvailabilitySets_TestLROMethod
        /// <summary> Update an availability set. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<TestAvailabilitySet> TestLROMethodAvailabilitySet(bool waitForCompletion, AvailabilitySetUpdate parameters, CancellationToken cancellationToken = default)
        {
            using var scope = AvailabilitySetClientDiagnostics.CreateScope("ResourceGroupExtensionClient.TestLROMethodAvailabilitySet");
            scope.Start();
            try
            {
                var response = AvailabilitySetRestClient.TestLROMethod(Id.SubscriptionId, Id.ResourceGroupName, parameters, cancellationToken);
                var operation = new MgmtOperationsArmOperation<TestAvailabilitySet>(new TestAvailabilitySetSource(Client), AvailabilitySetClientDiagnostics, Pipeline, AvailabilitySetRestClient.CreateTestLROMethodRequest(Id.SubscriptionId, Id.ResourceGroupName, parameters).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
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
