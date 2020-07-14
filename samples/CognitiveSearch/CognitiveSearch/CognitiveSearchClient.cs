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
    public class CognitiveSearchCredential
    {
        internal string ApiKey { get; private set; }
        public CognitiveSearchCredential(string apiKey) { ApiKey = apiKey; }
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

    public class CognitiveSearchClientOptions : ClientOptions
    {
        public enum ServiceVersion { V2019_05_06 = 1 }
        internal const ServiceVersion LatestVersion = ServiceVersion.V2019_05_06;
        public ServiceVersion Version { get; }
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

    public class CognitiveSearchClient
    {
        public virtual string ServiceName { get; }
        internal HttpPipeline Pipeline { get; }
        internal ClientDiagnostics ClientDiagnostics { get; }
        internal CognitiveSearchClientOptions.ServiceVersion Version { get; }
        private ServiceClient AllOperations { get; }
        private IndexesClient IndexesOperations { get; }

        public CognitiveSearchClient(string serviceName, CognitiveSearchCredential credential) : this(serviceName, credential, null) { }
        public CognitiveSearchClient(string serviceName, CognitiveSearchCredential credential, CognitiveSearchClientOptions options)
        {
            ServiceName = serviceName;
            options ??= new CognitiveSearchClientOptions();
            Pipeline = options.Build(credential);
            ClientDiagnostics = new ClientDiagnostics(options);
            Version = options.Version;
            AllOperations = new ServiceClient(ClientDiagnostics, Pipeline, ServiceName, apiVersion: Version.ToVersionString());
            IndexesOperations = new IndexesClient(ClientDiagnostics, Pipeline, ServiceName, apiVersion: Version.ToVersionString());
        }
        public IndexClient GetIndexClient(string indexName) => new IndexClient(this, indexName);
    }

    public class IndexClient
    {
        internal CognitiveSearchClient SearchClient { get; }
        public string IndexName { get; }
        private DocumentsClient Operations { get; }

        internal IndexClient(CognitiveSearchClient searchClient, string name)
        {
            SearchClient = searchClient;
            IndexName = name;
            Operations = new DocumentsClient(SearchClient.ClientDiagnostics, SearchClient.Pipeline, SearchClient.ServiceName, IndexName, apiVersion: SearchClient.Version.ToVersionString());
        }

        public virtual async Task<Response<SearchDocumentsResult>> SearchAsync(string searchText, string filter = null, CancellationToken cancellationToken = default) =>
            await Operations.SearchGetAsync(
                searchText: searchText,
                new SearchOptions()
                {
                    Filter = filter
                },
                new RequestOptions(),
                cancellationToken: cancellationToken);
    }
}
