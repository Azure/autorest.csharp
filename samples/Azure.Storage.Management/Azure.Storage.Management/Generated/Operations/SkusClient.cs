// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Management.Models;

namespace Azure.Storage.Management
{
    public partial class SkusClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal SkusRestClient RestClient { get; }
        /// <summary> Initializes a new instance of SkusClient for mocking. </summary>
        protected SkusClient()
        {
        }
        /// <summary> Initializes a new instance of SkusClient. </summary>
        internal SkusClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, string host = "https://management.azure.com", string apiVersion = "2019-06-01")
        {
            RestClient = new SkusRestClient(_clientDiagnostics, _pipeline, subscriptionId, host, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Lists the available SKUs supported by Microsoft.Storage for given subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<SkuInformation> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SkuInformation>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.ListAsync(cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            async Task<Page<SkuInformation>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists the available SKUs supported by Microsoft.Storage for given subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<SkuInformation> List(CancellationToken cancellationToken = default)
        {
            Page<SkuInformation> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.List(cancellationToken);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            Page<SkuInformation> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.ListNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
