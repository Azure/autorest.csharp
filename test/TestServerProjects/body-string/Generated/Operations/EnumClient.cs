// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_string.Models;

namespace body_string
{
    public partial class EnumClient
    {
        private EnumRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of EnumClient. </summary>
        internal EnumClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new EnumRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Colors>> GetNotExpandableAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNotExpandableAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Colors> GetNotExpandable(CancellationToken cancellationToken = default)
        {
            return restClient.GetNotExpandable(cancellationToken);
        }
        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="stringBody"> The Colors to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutNotExpandableAsync(Colors stringBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutNotExpandableAsync(stringBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="stringBody"> The Colors to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNotExpandable(Colors stringBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutNotExpandable(stringBody, cancellationToken);
        }
        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Colors>> GetReferencedAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetReferencedAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get enum value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Colors> GetReferenced(CancellationToken cancellationToken = default)
        {
            return restClient.GetReferenced(cancellationToken);
        }
        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="enumStringBody"> The Colors to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutReferencedAsync(Colors enumStringBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutReferencedAsync(enumStringBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Sends value &apos;red color&apos; from enumeration of &apos;red color&apos;, &apos;green-color&apos;, &apos;blue_color&apos;. </summary>
        /// <param name="enumStringBody"> The Colors to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutReferenced(Colors enumStringBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutReferenced(enumStringBody, cancellationToken);
        }
        /// <summary> Get value &apos;green-color&apos; from the constant. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<RefColorConstant>> GetReferencedConstantAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetReferencedConstantAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get value &apos;green-color&apos; from the constant. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RefColorConstant> GetReferencedConstant(CancellationToken cancellationToken = default)
        {
            return restClient.GetReferencedConstant(cancellationToken);
        }
        /// <summary> Sends value &apos;green-color&apos; from a constant. </summary>
        /// <param name="enumStringBody"> The RefColorConstant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutReferencedConstantAsync(RefColorConstant enumStringBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutReferencedConstantAsync(enumStringBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Sends value &apos;green-color&apos; from a constant. </summary>
        /// <param name="enumStringBody"> The RefColorConstant to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutReferencedConstant(RefColorConstant enumStringBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutReferencedConstant(enumStringBody, cancellationToken);
        }
    }
}
