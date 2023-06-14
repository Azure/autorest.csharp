// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    /// <summary> The NetworkInterfaceIPConfigurations service client. </summary>
    public partial class NetworkInterfaceIPConfigurationsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal NetworkInterfaceIPConfigurationsRestClient RestClient { get; }

        /// <summary> Initializes a new instance of NetworkInterfaceIPConfigurationsClient for mocking. </summary>
        protected NetworkInterfaceIPConfigurationsClient()
        {
        }

        /// <summary> Initializes a new instance of NetworkInterfaceIPConfigurationsClient. </summary>
        /// <param name="subscriptionId"> The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public NetworkInterfaceIPConfigurationsClient(string subscriptionId, TokenCredential credential, Uri endpoint = null, AzureNetworkManagementInterfaceClientOptions options = null)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
            endpoint ??= new Uri("https://management.azure.com");

            options ??= new AzureNetworkManagementInterfaceClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "user_impersonation" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes));
            RestClient = new NetworkInterfaceIPConfigurationsRestClient(_clientDiagnostics, _pipeline, subscriptionId, endpoint, options.Version);
        }

        /// <summary> Initializes a new instance of NetworkInterfaceIPConfigurationsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="subscriptionId"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        internal NetworkInterfaceIPConfigurationsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null, string apiVersion = "2019-11-01")
        {
            RestClient = new NetworkInterfaceIPConfigurationsRestClient(clientDiagnostics, pipeline, subscriptionId, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Gets the specified network interface ip configuration. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the ip configuration name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NetworkInterfaceIPConfiguration>> GetAsync(string resourceGroupName, string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NetworkInterfaceIPConfigurationsClient.Get");
            scope.Start();
            try
            {
                return await RestClient.GetAsync(resourceGroupName, networkInterfaceName, ipConfigurationName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified network interface ip configuration. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the ip configuration name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NetworkInterfaceIPConfiguration> Get(string resourceGroupName, string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NetworkInterfaceIPConfigurationsClient.Get");
            scope.Start();
            try
            {
                return RestClient.Get(resourceGroupName, networkInterfaceName, ipConfigurationName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get all ip configurations in a network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="networkInterfaceName"/> is null. </exception>
        public virtual AsyncPageable<NetworkInterfaceIPConfiguration> ListAsync(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateListRequest(resourceGroupName, networkInterfaceName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateListNextPageRequest(nextLink, resourceGroupName, networkInterfaceName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, NetworkInterfaceIPConfiguration.DeserializeNetworkInterfaceIPConfiguration, _clientDiagnostics, _pipeline, "NetworkInterfaceIPConfigurationsClient.List", "value", "nextLink", cancellationToken);
        }

        /// <summary> Get all ip configurations in a network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="networkInterfaceName"/> is null. </exception>
        public virtual Pageable<NetworkInterfaceIPConfiguration> List(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateListRequest(resourceGroupName, networkInterfaceName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateListNextPageRequest(nextLink, resourceGroupName, networkInterfaceName);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, NetworkInterfaceIPConfiguration.DeserializeNetworkInterfaceIPConfiguration, _clientDiagnostics, _pipeline, "NetworkInterfaceIPConfigurationsClient.List", "value", "nextLink", cancellationToken);
        }
    }
}
