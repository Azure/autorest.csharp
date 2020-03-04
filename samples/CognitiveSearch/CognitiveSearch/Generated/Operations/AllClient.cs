// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using CognitiveSearch.Models;

namespace CognitiveSearch
{
    public partial class AllClient
    {
        private AllRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of AllClient. </summary>
        internal AllClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string searchServiceName, string searchDnsSuffix = "search.windows.net", string ApiVersion = "2019-05-06")
        {
            restClient = new AllRestClient(clientDiagnostics, pipeline, searchServiceName, searchDnsSuffix, ApiVersion);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Gets service level statistics for a search service. </summary>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ServiceStatistics>> GetServiceStatisticsAsync(Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return await restClient.GetServiceStatisticsAsync(clientRequestId, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Gets service level statistics for a search service. </summary>
        /// <param name="clientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ServiceStatistics> GetServiceStatistics(Guid? clientRequestId, CancellationToken cancellationToken = default)
        {
            return restClient.GetServiceStatistics(clientRequestId, cancellationToken);
        }
    }
}
