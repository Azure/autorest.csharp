// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Tables.Models;

namespace Azure.Storage.Tables
{
    internal partial class ServiceRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _url;
        private readonly Enum0 _version;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of ServiceRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="url"> The URL of the service account or table that is the targe of the desired operation. </param>
        /// <param name="version"> Specifies the version of the operation to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="url"/> is null. </exception>
        public ServiceRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url, Enum0 version)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _url = url ?? throw new ArgumentNullException(nameof(url));
            _version = version;
        }

        internal HttpMessage CreateSetPropertiesRequest(Enum4 restype, Enum5 comp, StorageServiceProperties storageServiceProperties, int? timeout)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/", false);
            uri.AppendQuery("restype", restype.ToString(), true);
            uri.AppendQuery("comp", comp.ToString(), true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("Accept", "application/xml");
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(storageServiceProperties, "StorageServiceProperties");
            request.Content = content;
            return message;
        }

        /// <summary> Sets properties for a storage account's Table service endpoint, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="restype"> Required query string to set the storage service properties. </param>
        /// <param name="comp"> Required query string to set the storage service properties. </param>
        /// <param name="storageServiceProperties"> The StorageService properties. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="storageServiceProperties"/> is null. </exception>
        public async Task<ResponseWithHeaders<ServiceSetPropertiesHeaders>> SetPropertiesAsync(Enum4 restype, Enum5 comp, StorageServiceProperties storageServiceProperties, int? timeout = null, CancellationToken cancellationToken = default)
        {
            if (storageServiceProperties == null)
            {
                throw new ArgumentNullException(nameof(storageServiceProperties));
            }

            using var message = CreateSetPropertiesRequest(restype, comp, storageServiceProperties, timeout);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new ServiceSetPropertiesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Sets properties for a storage account's Table service endpoint, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="restype"> Required query string to set the storage service properties. </param>
        /// <param name="comp"> Required query string to set the storage service properties. </param>
        /// <param name="storageServiceProperties"> The StorageService properties. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="storageServiceProperties"/> is null. </exception>
        public ResponseWithHeaders<ServiceSetPropertiesHeaders> SetProperties(Enum4 restype, Enum5 comp, StorageServiceProperties storageServiceProperties, int? timeout = null, CancellationToken cancellationToken = default)
        {
            if (storageServiceProperties == null)
            {
                throw new ArgumentNullException(nameof(storageServiceProperties));
            }

            using var message = CreateSetPropertiesRequest(restype, comp, storageServiceProperties, timeout);
            _pipeline.Send(message, cancellationToken);
            var headers = new ServiceSetPropertiesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 202:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetPropertiesRequest(Enum4 restype, Enum5 comp, int? timeout)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/", false);
            uri.AppendQuery("restype", restype.ToString(), true);
            uri.AppendQuery("comp", comp.ToString(), true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> gets the properties of a storage account's Table service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="restype"> Required query string to set the storage service properties. </param>
        /// <param name="comp"> Required query string to set the storage service properties. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<StorageServiceProperties, ServiceGetPropertiesHeaders>> GetPropertiesAsync(Enum4 restype, Enum5 comp, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetPropertiesRequest(restype, comp, timeout);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new ServiceGetPropertiesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        StorageServiceProperties value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("StorageServiceProperties") is XElement storageServicePropertiesElement)
                        {
                            value = StorageServiceProperties.DeserializeStorageServiceProperties(storageServicePropertiesElement);
                        }
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> gets the properties of a storage account's Table service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="restype"> Required query string to set the storage service properties. </param>
        /// <param name="comp"> Required query string to set the storage service properties. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<StorageServiceProperties, ServiceGetPropertiesHeaders> GetProperties(Enum4 restype, Enum5 comp, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetPropertiesRequest(restype, comp, timeout);
            _pipeline.Send(message, cancellationToken);
            var headers = new ServiceGetPropertiesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        StorageServiceProperties value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("StorageServiceProperties") is XElement storageServicePropertiesElement)
                        {
                            value = StorageServiceProperties.DeserializeStorageServiceProperties(storageServicePropertiesElement);
                        }
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetStatisticsRequest(Enum4 restype, Enum6 comp, int? timeout)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/", false);
            uri.AppendQuery("restype", restype.ToString(), true);
            uri.AppendQuery("comp", comp.ToString(), true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version.ToString());
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Retrieves statistics related to replication for the Table service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account. </summary>
        /// <param name="restype"> Required query string to get storage service stats. </param>
        /// <param name="comp"> Required query string to get storage service stats. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<StorageServiceStats, ServiceGetStatisticsHeaders>> GetStatisticsAsync(Enum4 restype, Enum6 comp, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetStatisticsRequest(restype, comp, timeout);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new ServiceGetStatisticsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        StorageServiceStats value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("StorageServiceStats") is XElement storageServiceStatsElement)
                        {
                            value = StorageServiceStats.DeserializeStorageServiceStats(storageServiceStatsElement);
                        }
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Retrieves statistics related to replication for the Table service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account. </summary>
        /// <param name="restype"> Required query string to get storage service stats. </param>
        /// <param name="comp"> Required query string to get storage service stats. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<StorageServiceStats, ServiceGetStatisticsHeaders> GetStatistics(Enum4 restype, Enum6 comp, int? timeout = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetStatisticsRequest(restype, comp, timeout);
            _pipeline.Send(message, cancellationToken);
            var headers = new ServiceGetStatisticsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        StorageServiceStats value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("StorageServiceStats") is XElement storageServiceStatsElement)
                        {
                            value = StorageServiceStats.DeserializeStorageServiceStats(storageServiceStatsElement);
                        }
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
