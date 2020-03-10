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
using Azure.Storage.Management.Models;

namespace Azure.Storage.Management
{
    public partial class BlobServicesClient
    {
        private readonly ClientDiagnostics clientDiagnostics;
        private readonly HttpPipeline pipeline;
        internal BlobServicesRestClient RestClient { get; }
        /// <summary> Initializes a new instance of BlobServicesClient for mocking. </summary>
        protected BlobServicesClient()
        {
        }
        /// <summary> Initializes a new instance of BlobServicesClient. </summary>
        internal BlobServicesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string subscriptionId, string host = "https://management.azure.com", string ApiVersion = "2019-06-01")
        {
            RestClient = new BlobServicesRestClient(clientDiagnostics, pipeline, subscriptionId, host, ApiVersion);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Sets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BlobServiceProperties>> SetServicePropertiesAsync(string resourceGroupName, string accountName, BlobServiceProperties parameters, CancellationToken cancellationToken = default)
        {
            return await RestClient.SetServicePropertiesAsync(resourceGroupName, accountName, parameters, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Sets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="parameters"> The properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BlobServiceProperties> SetServiceProperties(string resourceGroupName, string accountName, BlobServiceProperties parameters, CancellationToken cancellationToken = default)
        {
            return RestClient.SetServiceProperties(resourceGroupName, accountName, parameters, cancellationToken);
        }
        /// <summary> Gets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BlobServiceProperties>> GetServicePropertiesAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            return await RestClient.GetServicePropertiesAsync(resourceGroupName, accountName, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Gets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BlobServiceProperties> GetServiceProperties(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            return RestClient.GetServiceProperties(resourceGroupName, accountName, cancellationToken);
        }
        /// <summary> List blob services of storage account. It returns a collection of one object named default. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<BlobServiceProperties> ListAsync(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            async Task<Page<BlobServiceProperties>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.ListAsync(resourceGroupName, accountName, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            async Task<Page<BlobServiceProperties>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.ListNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> List blob services of storage account. It returns a collection of one object named default. </summary>
        /// <param name="resourceGroupName"> The name of the resource group within the user&apos;s subscription. The name is case insensitive. </param>
        /// <param name="accountName"> The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<BlobServiceProperties> List(string resourceGroupName, string accountName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            Page<BlobServiceProperties> FirstPageFunc(int? pageSizeHint)
            {
                var response = RestClient.List(resourceGroupName, accountName, cancellationToken);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            Page<BlobServiceProperties> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.ListNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
