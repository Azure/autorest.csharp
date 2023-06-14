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
    /// <summary> The NetworkInterfaces service client. </summary>
    public partial class NetworkInterfacesClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal NetworkInterfacesRestClient RestClient { get; }

        /// <summary> Initializes a new instance of NetworkInterfacesClient for mocking. </summary>
        protected NetworkInterfacesClient()
        {
        }

        /// <summary> Initializes a new instance of NetworkInterfacesClient. </summary>
        /// <param name="subscriptionId"> The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public NetworkInterfacesClient(string subscriptionId, TokenCredential credential, Uri endpoint = null, AzureNetworkManagementInterfaceClientOptions options = null)
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
            RestClient = new NetworkInterfacesRestClient(_clientDiagnostics, _pipeline, subscriptionId, endpoint, options.Version);
        }

        /// <summary> Initializes a new instance of NetworkInterfacesClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="subscriptionId"> The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="subscriptionId"/> or <paramref name="apiVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        internal NetworkInterfacesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, Uri endpoint = null, string apiVersion = "2019-11-01")
        {
            RestClient = new NetworkInterfacesRestClient(clientDiagnostics, pipeline, subscriptionId, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Gets information about the specified network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NetworkInterface>> GetAsync(string resourceGroupName, string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.Get");
            scope.Start();
            try
            {
                return await RestClient.GetAsync(resourceGroupName, networkInterfaceName, expand, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets information about the specified network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NetworkInterface> Get(string resourceGroupName, string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.Get");
            scope.Start();
            try
            {
                return RestClient.Get(resourceGroupName, networkInterfaceName, expand, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates a network interface tags. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="parameters"> Parameters supplied to update network interface tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NetworkInterface>> UpdateTagsAsync(string resourceGroupName, string networkInterfaceName, TagsObject parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.UpdateTags");
            scope.Start();
            try
            {
                return await RestClient.UpdateTagsAsync(resourceGroupName, networkInterfaceName, parameters, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates a network interface tags. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="parameters"> Parameters supplied to update network interface tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NetworkInterface> UpdateTags(string resourceGroupName, string networkInterfaceName, TagsObject parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.UpdateTags");
            scope.Start();
            try
            {
                return RestClient.UpdateTags(resourceGroupName, networkInterfaceName, parameters, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets all network interfaces in a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<NetworkInterface> ListAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateListAllRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateListAllNextPageRequest(nextLink);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, NetworkInterface.DeserializeNetworkInterface, _clientDiagnostics, _pipeline, "NetworkInterfacesClient.ListAll", "value", "nextLink", cancellationToken);
        }

        /// <summary> Gets all network interfaces in a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<NetworkInterface> ListAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateListAllRequest();
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateListAllNextPageRequest(nextLink);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, NetworkInterface.DeserializeNetworkInterface, _clientDiagnostics, _pipeline, "NetworkInterfacesClient.ListAll", "value", "nextLink", cancellationToken);
        }

        /// <summary> Gets all network interfaces in a resource group. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public virtual AsyncPageable<NetworkInterface> ListAsync(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateListRequest(resourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateListNextPageRequest(nextLink, resourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, NetworkInterface.DeserializeNetworkInterface, _clientDiagnostics, _pipeline, "NetworkInterfacesClient.List", "value", "nextLink", cancellationToken);
        }

        /// <summary> Gets all network interfaces in a resource group. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> is null. </exception>
        public virtual Pageable<NetworkInterface> List(string resourceGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => RestClient.CreateListRequest(resourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => RestClient.CreateListNextPageRequest(nextLink, resourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, NetworkInterface.DeserializeNetworkInterface, _clientDiagnostics, _pipeline, "NetworkInterfacesClient.List", "value", "nextLink", cancellationToken);
        }

        /// <summary> Deletes the specified network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="networkInterfaceName"/> is null. </exception>
        public virtual async Task<NetworkInterfacesDeleteOperation> StartDeleteAsync(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (networkInterfaceName == null)
            {
                throw new ArgumentNullException(nameof(networkInterfaceName));
            }

            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.StartDelete");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.DeleteAsync(resourceGroupName, networkInterfaceName, cancellationToken).ConfigureAwait(false);
                return new NetworkInterfacesDeleteOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteRequest(resourceGroupName, networkInterfaceName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes the specified network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="networkInterfaceName"/> is null. </exception>
        public virtual NetworkInterfacesDeleteOperation StartDelete(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (networkInterfaceName == null)
            {
                throw new ArgumentNullException(nameof(networkInterfaceName));
            }

            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.StartDelete");
            scope.Start();
            try
            {
                var originalResponse = RestClient.Delete(resourceGroupName, networkInterfaceName, cancellationToken);
                return new NetworkInterfacesDeleteOperation(_clientDiagnostics, _pipeline, RestClient.CreateDeleteRequest(resourceGroupName, networkInterfaceName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="parameters"> Parameters supplied to the create or update network interface operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="networkInterfaceName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<NetworkInterfacesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string networkInterfaceName, NetworkInterface parameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (networkInterfaceName == null)
            {
                throw new ArgumentNullException(nameof(networkInterfaceName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.CreateOrUpdateAsync(resourceGroupName, networkInterfaceName, parameters, cancellationToken).ConfigureAwait(false);
                return new NetworkInterfacesCreateOrUpdateOperation(_clientDiagnostics, _pipeline, RestClient.CreateCreateOrUpdateRequest(resourceGroupName, networkInterfaceName, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="parameters"> Parameters supplied to the create or update network interface operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/>, <paramref name="networkInterfaceName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual NetworkInterfacesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string networkInterfaceName, NetworkInterface parameters, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (networkInterfaceName == null)
            {
                throw new ArgumentNullException(nameof(networkInterfaceName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = RestClient.CreateOrUpdate(resourceGroupName, networkInterfaceName, parameters, cancellationToken);
                return new NetworkInterfacesCreateOrUpdateOperation(_clientDiagnostics, _pipeline, RestClient.CreateCreateOrUpdateRequest(resourceGroupName, networkInterfaceName, parameters).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets all route tables applied to a network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="networkInterfaceName"/> is null. </exception>
        public virtual async Task<NetworkInterfacesGetEffectiveRouteTableOperation> StartGetEffectiveRouteTableAsync(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (networkInterfaceName == null)
            {
                throw new ArgumentNullException(nameof(networkInterfaceName));
            }

            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.StartGetEffectiveRouteTable");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.GetEffectiveRouteTableAsync(resourceGroupName, networkInterfaceName, cancellationToken).ConfigureAwait(false);
                return new NetworkInterfacesGetEffectiveRouteTableOperation(_clientDiagnostics, _pipeline, RestClient.CreateGetEffectiveRouteTableRequest(resourceGroupName, networkInterfaceName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets all route tables applied to a network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="networkInterfaceName"/> is null. </exception>
        public virtual NetworkInterfacesGetEffectiveRouteTableOperation StartGetEffectiveRouteTable(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (networkInterfaceName == null)
            {
                throw new ArgumentNullException(nameof(networkInterfaceName));
            }

            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.StartGetEffectiveRouteTable");
            scope.Start();
            try
            {
                var originalResponse = RestClient.GetEffectiveRouteTable(resourceGroupName, networkInterfaceName, cancellationToken);
                return new NetworkInterfacesGetEffectiveRouteTableOperation(_clientDiagnostics, _pipeline, RestClient.CreateGetEffectiveRouteTableRequest(resourceGroupName, networkInterfaceName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets all network security groups applied to a network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="networkInterfaceName"/> is null. </exception>
        public virtual async Task<NetworkInterfacesListEffectiveNetworkSecurityGroupsOperation> StartListEffectiveNetworkSecurityGroupsAsync(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (networkInterfaceName == null)
            {
                throw new ArgumentNullException(nameof(networkInterfaceName));
            }

            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.StartListEffectiveNetworkSecurityGroups");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.ListEffectiveNetworkSecurityGroupsAsync(resourceGroupName, networkInterfaceName, cancellationToken).ConfigureAwait(false);
                return new NetworkInterfacesListEffectiveNetworkSecurityGroupsOperation(_clientDiagnostics, _pipeline, RestClient.CreateListEffectiveNetworkSecurityGroupsRequest(resourceGroupName, networkInterfaceName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets all network security groups applied to a network interface. </summary>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupName"/> or <paramref name="networkInterfaceName"/> is null. </exception>
        public virtual NetworkInterfacesListEffectiveNetworkSecurityGroupsOperation StartListEffectiveNetworkSecurityGroups(string resourceGroupName, string networkInterfaceName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (networkInterfaceName == null)
            {
                throw new ArgumentNullException(nameof(networkInterfaceName));
            }

            using var scope = _clientDiagnostics.CreateScope("NetworkInterfacesClient.StartListEffectiveNetworkSecurityGroups");
            scope.Start();
            try
            {
                var originalResponse = RestClient.ListEffectiveNetworkSecurityGroups(resourceGroupName, networkInterfaceName, cancellationToken);
                return new NetworkInterfacesListEffectiveNetworkSecurityGroupsOperation(_clientDiagnostics, _pipeline, RestClient.CreateListEffectiveNetworkSecurityGroupsRequest(resourceGroupName, networkInterfaceName).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
