// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using CognitiveSearch;
using CognitiveSearch.Models;

#pragma warning disable SA1402, SA1649
namespace Azure.CognitiveSearch
{
    /// <summary>
    /// Credential for cognitive search.
    /// </summary>
    public class CognitiveSearchCredential
    {
        internal string ApiKey { get; private set; }
        /// <summary>
        /// Instantiates a new instance of <see cref="CognitiveSearchCredential"/>.
        /// </summary>
        /// <param name="apiKey"></param>
        public CognitiveSearchCredential(string apiKey) { ApiKey = apiKey; }

        /// <summary>
        /// Refreshes the credential.
        /// </summary>
        /// <param name="apiKey">The api key to use.</param>
        public void Refresh(string apiKey) { ApiKey = apiKey; }
    }

    internal class CognitiveSearchCredentialPolicy : HttpPipelineSynchronousPolicy
    {
        public CognitiveSearchCredential Credential { get; private set; }
        public CognitiveSearchCredentialPolicy(CognitiveSearchCredential credential) { Credential = credential; }
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);
            message.Request.Headers.SetValue("api-key", Credential.ApiKey);
        }
    }

    /// <summary>
    /// Client options for <see cref="CognitiveSearchClient"/>.
    /// </summary>
    public class CognitiveSearchClientOptions : ClientOptions
    {
        /// <summary>
        /// Service versions.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// 2019-05-06
            /// </summary>
            V2019_05_06 = 1
        }

        internal const ServiceVersion LatestVersion = ServiceVersion.V2019_05_06;
        /// <summary>
        /// Gets the Version.
        /// </summary>
        public ServiceVersion Version { get; }
        /// <summary>
        /// Instantiates a new instance of <see cref="CognitiveSearchClientOptions"/>.
        /// </summary>
        /// <param name="version">The version to use.</param>
        /// <exception cref="ArgumentException"></exception>
        public CognitiveSearchClientOptions(ServiceVersion version = LatestVersion) =>
            Version = version == ServiceVersion.V2019_05_06 ?
                version :
                throw new ArgumentException($"Invalid value for {nameof(CognitiveSearchClientOptions)}.{nameof(ServiceVersion)}", "version");
        internal HttpPipeline Build(CognitiveSearchCredential credential) =>
            HttpPipelineBuilder.Build(this, new[] { new CognitiveSearchCredentialPolicy(credential) }, Array.Empty<HttpPipelinePolicy>(), null);
    }

    internal static class CognitiveSearchExtensions
    {
        public static string ToVersionString(this CognitiveSearchClientOptions.ServiceVersion version) => "2019-05-06";
    }

    /// <summary>
    /// Client for Azure Cognitive Search.
    /// </summary>
    public class CognitiveSearchClient
    {
        /// <summary>
        /// Gets the ServiceName.
        /// </summary>
        public virtual string ServiceName { get; }
        internal HttpPipeline Pipeline { get; }
        internal ClientDiagnostics ClientDiagnostics { get; }
        internal CognitiveSearchClientOptions.ServiceVersion Version { get; }
        private CognitiveServicesClient AllOperations { get; }
        private IndexesClient IndexesOperations { get; }

        /// <summary>
        /// Instantiates a new instance of <see cref="CognitiveSearchClient"/> for mocking.
        /// </summary>
        protected CognitiveSearchClient() { }

        /// <summary>
        /// Instantiates a new instance of <see cref="CognitiveSearchClient"/>.
        /// </summary>
        /// <param name="serviceName">The service name to use.</param>
        /// <param name="credential">The crednetial to use.</param>
        public CognitiveSearchClient(string serviceName, CognitiveSearchCredential credential) : this(serviceName, credential, null) { }
        /// <summary>
        /// Instantiates a new instance of <see cref="CognitiveSearchClient"/>.
        /// </summary>
        /// <param name="serviceName">The service name to use.</param>
        /// <param name="credential">The credential to use.</param>
        /// <param name="options">The options to use.</param>
        public CognitiveSearchClient(string serviceName, CognitiveSearchCredential credential, CognitiveSearchClientOptions options)
        {
            ServiceName = serviceName;
            options ??= new CognitiveSearchClientOptions();
            Pipeline = options.Build(credential);
            ClientDiagnostics = new ClientDiagnostics(options);
            Version = options.Version;
            AllOperations = new CognitiveServicesClient(ClientDiagnostics, Pipeline, ServiceName, apiVersion: Version.ToVersionString());
            IndexesOperations = new IndexesClient(ClientDiagnostics, Pipeline, ServiceName, apiVersion: Version.ToVersionString());
        }

        /// <summary>
        /// Gets the <see cref="IndexClient"/> for the given index name.
        /// </summary>
        /// <param name="indexName">The indexName to use.</param>
        /// <returns></returns>
        public IndexClient GetIndexClient(string indexName) => new IndexClient(this, indexName);
    }

    /// <summary>
    /// Client for Azure Cognitive Search Indexes.
    /// </summary>
    public class IndexClient
    {
        internal CognitiveSearchClient SearchClient { get; }
        /// <summary>
        /// Gets the IndexName.
        /// </summary>
        public string IndexName { get; }
        private DocumentsClient Operations { get; }

        /// <summary>
        /// Instantiates a new instance of <see cref="IndexClient"/> for mocking.
        /// </summary>
        protected IndexClient() { }

        internal IndexClient(CognitiveSearchClient searchClient, string name)
        {
            SearchClient = searchClient;
            IndexName = name;
            Operations = new DocumentsClient(SearchClient.ClientDiagnostics, SearchClient.Pipeline, SearchClient.ServiceName, IndexName, apiVersion: SearchClient.Version.ToVersionString());
        }

        /// <summary>
        /// Searches the index.
        /// </summary>
        /// <param name="searchText">The searchText to use.</param>
        /// <param name="filter">The filter to use.</param>
        /// <param name="cancellationToken">The cancellationToken to use.</param>
        public virtual async Task<Response<SearchDocumentsResult>> SearchAsync(string searchText, string filter = null, CancellationToken cancellationToken = default) =>
            await Operations.SearchGetAsync(
                searchText: searchText,
                new SearchOptions()
                {
                    Filter = filter
                },
                new global::CognitiveSearch.Models.RequestOptions(),
                cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Searches the index.
        /// </summary>
        /// <param name="searchText">The searchText to use.</param>
        /// <param name="filter">The filter to use.</param>
        /// <param name="cancellationToken">The cancellationToken to use.</param>
        public virtual Response<SearchDocumentsResult> Search(string searchText, string filter = null, CancellationToken cancellationToken = default) =>
             Operations.SearchGet(
                searchText: searchText,
                new SearchOptions()
                {
                    Filter = filter
                },
                new global::CognitiveSearch.Models.RequestOptions(),
                cancellationToken: cancellationToken);
    }
}
