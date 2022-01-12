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
using Azure.ResourceManager.Resources;
using MgmtOperations.Models;

namespace MgmtOperations
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ResourceGroupExtensions
    {
        #region AvailabilitySet
        /// <summary> Gets an object representing a AvailabilitySetCollection along with the instance operations that can be performed on it. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="AvailabilitySetCollection" /> object. </returns>
        public static AvailabilitySetCollection GetAvailabilitySets(this ResourceGroup resourceGroup)
        {
            return new AvailabilitySetCollection(resourceGroup);
        }
        #endregion

        private static AvailabilitySetsRestOperations GetAvailabilitySetsRestOperations(ClientDiagnostics clientDiagnostics, TokenCredential credential, ArmClientOptions clientOptions, HttpPipeline pipeline, Uri endpoint = null)
        {
            return new AvailabilitySetsRestOperations(clientDiagnostics, pipeline, clientOptions, endpoint);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AvailabilitySets_TestLROMethod
        /// <summary> Update an availability set. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public static async Task<TestLROMethodAvailabilitySetOperation> TestLROMethodAvailabilitySetAsync(this ResourceGroup resourceGroup, AvailabilitySetUpdate parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return await resourceGroup.UseClientContext(async (baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.TestLROMethodAvailabilitySet");
                scope.Start();
                try
                {
                    var restOperations = GetAvailabilitySetsRestOperations(clientDiagnostics, credential, options, pipeline, baseUri);
                    var response = await restOperations.TestLROMethodAsync(resourceGroup.Id.SubscriptionId, resourceGroup.Id.ResourceGroupName, parameters, cancellationToken).ConfigureAwait(false);
                    var operation = new TestLROMethodAvailabilitySetOperation(clientDiagnostics, pipeline, restOperations.CreateTestLROMethodRequest(resourceGroup.Id.SubscriptionId, resourceGroup.Id.ResourceGroupName, parameters).Request, response);
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
            ).ConfigureAwait(false);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: AvailabilitySets_TestLROMethod
        /// <summary> Update an availability set. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="parameters"> Parameters supplied to the Update Availability Set operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public static TestLROMethodAvailabilitySetOperation TestLROMethodAvailabilitySet(this ResourceGroup resourceGroup, AvailabilitySetUpdate parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return resourceGroup.UseClientContext((baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.TestLROMethodAvailabilitySet");
                scope.Start();
                try
                {
                    var restOperations = GetAvailabilitySetsRestOperations(clientDiagnostics, credential, options, pipeline, baseUri);
                    var response = restOperations.TestLROMethod(resourceGroup.Id.SubscriptionId, resourceGroup.Id.ResourceGroupName, parameters, cancellationToken);
                    var operation = new TestLROMethodAvailabilitySetOperation(clientDiagnostics, pipeline, restOperations.CreateTestLROMethodRequest(resourceGroup.Id.SubscriptionId, resourceGroup.Id.ResourceGroupName, parameters).Request, response);
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
            );
        }
    }
}
