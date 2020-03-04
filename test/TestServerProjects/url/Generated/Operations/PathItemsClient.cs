// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace url
{
    public partial class PathItemsClient
    {
        private PathItemsRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PathItemsClient. </summary>
        internal PathItemsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string globalStringPath, string globalStringQuery, string host = "http://localhost:3000")
        {
            restClient = new PathItemsRestClient(clientDiagnostics, pipeline, globalStringPath, globalStringQuery, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetAllWithValuesAsync(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            return await restClient.GetAllWithValuesAsync(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetAllWithValues(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            return restClient.GetAllWithValues(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery, cancellationToken);
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetGlobalQueryNullAsync(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            return await restClient.GetGlobalQueryNullAsync(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetGlobalQueryNull(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            return restClient.GetGlobalQueryNull(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery, cancellationToken);
        }
        /// <summary> send globalStringPath=globalStringPath, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetGlobalAndLocalQueryNullAsync(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            return await restClient.GetGlobalAndLocalQueryNullAsync(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> send globalStringPath=globalStringPath, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetGlobalAndLocalQueryNull(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            return restClient.GetGlobalAndLocalQueryNull(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery, cancellationToken);
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=null, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetLocalPathItemQueryNullAsync(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            return await restClient.GetLocalPathItemQueryNullAsync(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=null, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetLocalPathItemQueryNull(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            return restClient.GetLocalPathItemQueryNull(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery, cancellationToken);
        }
    }
}
