// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.Storage.Tables.Models;

namespace Azure.Storage.Tables
{
    /// <summary> The Service service client. </summary>
    public partial class ServiceClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ServiceRestClient RestClient { get; }

        /// <summary> Initializes a new instance of ServiceClient for mocking. </summary>
        protected ServiceClient()
        {
        }

        /// <summary> Initializes a new instance of ServiceClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="url"> The URL of the service account or table that is the targe of the desired operation. </param>
        /// <param name="version"> Specifies the version of the operation to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="url"/> is null. </exception>
        internal ServiceClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url, Enum0 version)
        {
            RestClient = new ServiceRestClient(clientDiagnostics, pipeline, url, version);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Sets properties for a storage account's Table service endpoint, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="restype"> Required query string to set the storage service properties. </param>
        /// <param name="comp"> Required query string to set the storage service properties. </param>
        /// <param name="storageServiceProperties"> The StorageService properties. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SetPropertiesAsync(Enum4 restype, Enum5 comp, StorageServiceProperties storageServiceProperties, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.SetProperties");
            scope.Start();
            try
            {
                return (await RestClient.SetPropertiesAsync(restype, comp, storageServiceProperties, timeout, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sets properties for a storage account's Table service endpoint, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="restype"> Required query string to set the storage service properties. </param>
        /// <param name="comp"> Required query string to set the storage service properties. </param>
        /// <param name="storageServiceProperties"> The StorageService properties. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SetProperties(Enum4 restype, Enum5 comp, StorageServiceProperties storageServiceProperties, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.SetProperties");
            scope.Start();
            try
            {
                return RestClient.SetProperties(restype, comp, storageServiceProperties, timeout, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> gets the properties of a storage account's Table service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="restype"> Required query string to set the storage service properties. </param>
        /// <param name="comp"> Required query string to set the storage service properties. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<StorageServiceProperties>> GetPropertiesAsync(Enum4 restype, Enum5 comp, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetProperties");
            scope.Start();
            try
            {
                return await RestClient.GetPropertiesAsync(restype, comp, timeout, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> gets the properties of a storage account's Table service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="restype"> Required query string to set the storage service properties. </param>
        /// <param name="comp"> Required query string to set the storage service properties. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<StorageServiceProperties> GetProperties(Enum4 restype, Enum5 comp, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetProperties");
            scope.Start();
            try
            {
                return RestClient.GetProperties(restype, comp, timeout, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves statistics related to replication for the Table service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account. </summary>
        /// <param name="restype"> Required query string to get storage service stats. </param>
        /// <param name="comp"> Required query string to get storage service stats. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<StorageServiceStats>> GetStatisticsAsync(Enum4 restype, Enum6 comp, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetStatistics");
            scope.Start();
            try
            {
                return await RestClient.GetStatisticsAsync(restype, comp, timeout, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves statistics related to replication for the Table service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account. </summary>
        /// <param name="restype"> Required query string to get storage service stats. </param>
        /// <param name="comp"> Required query string to get storage service stats. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<StorageServiceStats> GetStatistics(Enum4 restype, Enum6 comp, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ServiceClient.GetStatistics");
            scope.Start();
            try
            {
                return RestClient.GetStatistics(restype, comp, timeout, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
