// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using OmitOperationGroups.Models;

namespace OmitOperationGroups
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ResourceGroupExtensions
    {
        #region Model2
        /// <summary> Gets an object representing a Model2Collection along with the instance operations that can be performed on it. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="Model2Collection" /> object. </returns>
        public static Model2Collection GetModel2s(this ResourceGroup resourceGroup)
        {
            return new Model2Collection(resourceGroup);
        }
        #endregion

        private static Model5SRestOperations GetModel5SRestOperations(ClientDiagnostics clientDiagnostics, TokenCredential credential, ArmClientOptions clientOptions, HttpPipeline pipeline, Uri endpoint = null)
        {
            return new Model5SRestOperations(clientDiagnostics, pipeline, clientOptions, endpoint);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model5s_List
        /// <summary> Lists the Model5s for this <see cref="ResourceGroup" />. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<Model5> GetModel5sAsync(this ResourceGroup resourceGroup, CancellationToken cancellationToken = default)
        {
            return resourceGroup.UseClientContext((baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                var restOperations = GetModel5SRestOperations(clientDiagnostics, credential, options, pipeline, baseUri);
                async Task<Page<Model5>> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.GetModel5s");
                    scope.Start();
                    try
                    {
                        var response = await restOperations.ListAsync(resourceGroup.Id.SubscriptionId, resourceGroup.Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
            }
            );
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model5s_List
        /// <summary> Lists the Model5s for this <see cref="ResourceGroup" />. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<Model5> GetModel5s(this ResourceGroup resourceGroup, CancellationToken cancellationToken = default)
        {
            return resourceGroup.UseClientContext((baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                var restOperations = GetModel5SRestOperations(clientDiagnostics, credential, options, pipeline, baseUri);
                Page<Model5> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.GetModel5s");
                    scope.Start();
                    try
                    {
                        var response = restOperations.List(resourceGroup.Id.SubscriptionId, resourceGroup.Id.ResourceGroupName, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
            }
            );
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model5s_CreateOrUpdate
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The String to use. </param>
        /// <param name="parameters"> The Model5 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> or <paramref name="parameters"/> is null. </exception>
        public static async Task<Response<Model5>> CreateOrUpdateModel5Async(this ResourceGroup resourceGroup, string model5SName, Model5 parameters, CancellationToken cancellationToken = default)
        {
            if (model5SName == null)
            {
                throw new ArgumentNullException(nameof(model5SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return await resourceGroup.UseClientContext(async (baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.CreateOrUpdateModel5");
                scope.Start();
                try
                {
                    var restOperations = GetModel5SRestOperations(clientDiagnostics, credential, options, pipeline, baseUri);
                    var response = await restOperations.CreateOrUpdateAsync(resourceGroup.Id.SubscriptionId, resourceGroup.Id.ResourceGroupName, model5SName, parameters, cancellationToken).ConfigureAwait(false);
                    return response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            ).ConfigureAwait(false);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model5s_CreateOrUpdate
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The String to use. </param>
        /// <param name="parameters"> The Model5 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> or <paramref name="parameters"/> is null. </exception>
        public static Response<Model5> CreateOrUpdateModel5(this ResourceGroup resourceGroup, string model5SName, Model5 parameters, CancellationToken cancellationToken = default)
        {
            if (model5SName == null)
            {
                throw new ArgumentNullException(nameof(model5SName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return resourceGroup.UseClientContext((baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.CreateOrUpdateModel5");
                scope.Start();
                try
                {
                    var restOperations = GetModel5SRestOperations(clientDiagnostics, credential, options, pipeline, baseUri);
                    var response = restOperations.CreateOrUpdate(resourceGroup.Id.SubscriptionId, resourceGroup.Id.ResourceGroupName, model5SName, parameters, cancellationToken);
                    return response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            );
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model5s_Get
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> is null. </exception>
        public static async Task<Response<Model5>> GetModel5Async(this ResourceGroup resourceGroup, string model5SName, CancellationToken cancellationToken = default)
        {
            if (model5SName == null)
            {
                throw new ArgumentNullException(nameof(model5SName));
            }

            return await resourceGroup.UseClientContext(async (baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.GetModel5");
                scope.Start();
                try
                {
                    var restOperations = GetModel5SRestOperations(clientDiagnostics, credential, options, pipeline, baseUri);
                    var response = await restOperations.GetAsync(resourceGroup.Id.SubscriptionId, resourceGroup.Id.ResourceGroupName, model5SName, cancellationToken).ConfigureAwait(false);
                    return response;
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            ).ConfigureAwait(false);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model5s/{model5sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: Model5s_Get
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="model5SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model5SName"/> is null. </exception>
        public static Response<Model5> GetModel5(this ResourceGroup resourceGroup, string model5SName, CancellationToken cancellationToken = default)
        {
            if (model5SName == null)
            {
                throw new ArgumentNullException(nameof(model5SName));
            }

            return resourceGroup.UseClientContext((baseUri, credential, options, pipeline) =>
            {
                var clientDiagnostics = new ClientDiagnostics(options);
                using var scope = clientDiagnostics.CreateScope("ResourceGroupExtensions.GetModel5");
                scope.Start();
                try
                {
                    var restOperations = GetModel5SRestOperations(clientDiagnostics, credential, options, pipeline, baseUri);
                    var response = restOperations.Get(resourceGroup.Id.SubscriptionId, resourceGroup.Id.ResourceGroupName, model5SName, cancellationToken);
                    return response;
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
