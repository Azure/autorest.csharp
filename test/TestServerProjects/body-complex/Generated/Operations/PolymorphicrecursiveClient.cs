// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_complex.Models;

namespace body_complex
{
    public partial class PolymorphicrecursiveClient
    {
        internal PolymorphicrecursiveRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PolymorphicrecursiveClient. </summary>
        internal PolymorphicrecursiveClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new PolymorphicrecursiveRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get complex types that are polymorphic and have recursive references. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Fish>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types that are polymorphic and have recursive references. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Fish> GetValid(CancellationToken cancellationToken = default)
        {
            return RestClient.GetValid(cancellationToken);
        }
        /// <summary> Put complex types that are polymorphic and have recursive references. </summary>
        /// <param name="complexBody">
        /// Please put a salmon that looks like this:
        /// {
        ///         &apos;fishtype&apos;:&apos;Salmon&apos;,
        ///         &apos;location&apos;:&apos;alaska&apos;,
        ///         &apos;iswild&apos;:true,
        ///         &apos;species&apos;:&apos;king&apos;,
        ///         &apos;length&apos;:1.0,
        ///         &apos;siblings&apos;:[
        ///           {
        ///             &apos;fishtype&apos;:&apos;Shark&apos;,
        ///             &apos;age&apos;:6,
        ///             &apos;birthday&apos;: &apos;2012-01-05T01:00:00Z&apos;,
        ///             &apos;length&apos;:20.0,
        ///             &apos;species&apos;:&apos;predator&apos;,
        ///           },
        ///           {
        ///             &apos;fishtype&apos;:&apos;Sawshark&apos;,
        ///             &apos;age&apos;:105,
        ///             &apos;birthday&apos;: &apos;1900-01-05T01:00:00Z&apos;,
        ///             &apos;length&apos;:10.0,
        ///             &apos;picture&apos;: new Buffer([255, 255, 255, 255, 254]).toString(&apos;base64&apos;),
        ///             &apos;species&apos;:&apos;dangerous&apos;,
        ///           },
        ///           {
        ///             &apos;fishtype&apos;: &apos;goblin&apos;,
        ///             &apos;age&apos;: 1,
        ///             &apos;birthday&apos;: &apos;2015-08-08T00:00:00Z&apos;,
        ///             &apos;length&apos;: 30.0,
        ///             &apos;species&apos;: &apos;scary&apos;,
        ///             &apos;jawsize&apos;: 5
        ///           }
        ///         ]
        ///       };.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutValidAsync(Fish complexBody, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutValidAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types that are polymorphic and have recursive references. </summary>
        /// <param name="complexBody">
        /// Please put a salmon that looks like this:
        /// {
        ///         &apos;fishtype&apos;:&apos;Salmon&apos;,
        ///         &apos;location&apos;:&apos;alaska&apos;,
        ///         &apos;iswild&apos;:true,
        ///         &apos;species&apos;:&apos;king&apos;,
        ///         &apos;length&apos;:1.0,
        ///         &apos;siblings&apos;:[
        ///           {
        ///             &apos;fishtype&apos;:&apos;Shark&apos;,
        ///             &apos;age&apos;:6,
        ///             &apos;birthday&apos;: &apos;2012-01-05T01:00:00Z&apos;,
        ///             &apos;length&apos;:20.0,
        ///             &apos;species&apos;:&apos;predator&apos;,
        ///           },
        ///           {
        ///             &apos;fishtype&apos;:&apos;Sawshark&apos;,
        ///             &apos;age&apos;:105,
        ///             &apos;birthday&apos;: &apos;1900-01-05T01:00:00Z&apos;,
        ///             &apos;length&apos;:10.0,
        ///             &apos;picture&apos;: new Buffer([255, 255, 255, 255, 254]).toString(&apos;base64&apos;),
        ///             &apos;species&apos;:&apos;dangerous&apos;,
        ///           },
        ///           {
        ///             &apos;fishtype&apos;: &apos;goblin&apos;,
        ///             &apos;age&apos;: 1,
        ///             &apos;birthday&apos;: &apos;2015-08-08T00:00:00Z&apos;,
        ///             &apos;length&apos;: 30.0,
        ///             &apos;species&apos;: &apos;scary&apos;,
        ///             &apos;jawsize&apos;: 5
        ///           }
        ///         ]
        ///       };.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutValid(Fish complexBody, CancellationToken cancellationToken = default)
        {
            return RestClient.PutValid(complexBody, cancellationToken);
        }
    }
}
