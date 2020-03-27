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
using Azure.Network.Management.Interface.Models;

namespace Azure.Network.Management.Interface
{
    public partial class NetworkInterfaceIPConfigurationsClient
    {
        private readonly ClientDiagnostics clientDiagnostics;
        private readonly HttpPipeline pipeline;
        internal NetworkInterfaceIPConfigurationsRestClient RestClient { get; }
        /// <summary> Initializes a new instance of NetworkInterfaceIPConfigurationsClient for mocking. </summary>
        protected NetworkInterfaceIPConfigurationsClient()
        {
        }
        /// <summary> Initializes a new instance of NetworkInterfaceIPConfigurationsClient. </summary>
        internal NetworkInterfaceIPConfigurationsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, string host = "https://management.azure.com", string apiVersion = "2019-11-01")
        {
            RestClient = new NetworkInterfaceIPConfigurationsRestClient(clientDiagnostics, pipeline, subscriptionId, host, apiVersion);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }

        /// <summary> Gets the specified network interface ip configuration. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the ip configuration name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NetworkInterfaceIPConfiguration>> GetAsync(string resourceGroupName, string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken = default)
        {
            return await RestClient.GetAsync(resourceGroupName, networkInterfaceName, ipConfigurationName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the specified network interface ip configuration. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the ip configuration name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NetworkInterfaceIPConfiguration> Get(string resourceGroupName, string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken = default)
        {
            return RestClient.Get(resourceGroupName, networkInterfaceName, ipConfigurationName, cancellationToken);
        }

        /// <summary> Get all ip configurations in a network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<NetworkInterfaceIPConfiguration> ListAsync(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (networkInterfaceName == null)
            {
                throw new ArgumentNullException(nameof(networkInterfaceName));
            }

            async Task<Page<NetworkInterfaceIPConfiguration>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.ListAsync(resourceGroupName, networkInterfaceName, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<NetworkInterfaceIPConfiguration>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.ListNextPageAsync(nextLink, resourceGroupName, networkInterfaceName, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get all ip configurations in a network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<NetworkInterfaceIPConfiguration> List(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (networkInterfaceName == null)
            {
                throw new ArgumentNullException(nameof(networkInterfaceName));
            }

            Page<NetworkInterfaceIPConfiguration> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.List(resourceGroupName, networkInterfaceName, cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            Page<NetworkInterfaceIPConfiguration> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.ListNextPage(nextLink, resourceGroupName, networkInterfaceName, cancellationToken);
                return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
