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
using Azure.Management.Storage.Models;

namespace Azure.Management.Storage
{
    /// <summary> The Usages service client. </summary>
    public partial class UsagesClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal UsagesRestClient RestClient { get; }
        /// <summary> Initializes a new instance of UsagesClient for mocking. </summary>
        protected UsagesClient()
        {
        }

        /// <summary> Initializes a new instance of UsagesClient. </summary>
        public UsagesClient(string subscriptionId, TokenCredential tokenCredential, StorageManagementClientOptions options = null)
        {
            options = new StorageManagementClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = ManagementPipelineBuilder.Build(tokenCredential, options);
            RestClient = new UsagesRestClient(_clientDiagnostics, _pipeline, subscriptionId);
        }

        /// <summary> Gets the current usage count and the limit for the resources of the location under the subscription. </summary>
        /// <param name="location"> The location of the Azure Storage resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<Usage> ListByLocationAsync(string location, CancellationToken cancellationToken = default)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            async Task<Page<Usage>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.ListByLocationAsync(location, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            async Task<Page<Usage>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.ListByLocationNextPageAsync(nextLink, location, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the current usage count and the limit for the resources of the location under the subscription. </summary>
        /// <param name="location"> The location of the Azure Storage resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<Usage> ListByLocation(string location, CancellationToken cancellationToken = default)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            Page<Usage> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.ListByLocation(location, cancellationToken);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            Page<Usage> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.ListByLocationNextPage(nextLink, location, cancellationToken);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
