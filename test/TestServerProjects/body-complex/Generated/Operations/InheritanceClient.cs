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
    public partial class InheritanceClient
    {
        private InheritanceRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of InheritanceClient. </summary>
        internal InheritanceClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new InheritanceRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get complex types that extend others. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Siamese>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get complex types that extend others. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Siamese> GetValid(CancellationToken cancellationToken = default)
        {
            return restClient.GetValid(cancellationToken);
        }
        /// <summary> Put complex types that extend others. </summary>
        /// <param name="complexBody"> Please put a siamese with id=2, name=&quot;Siameee&quot;, color=green, breed=persion, which hates 2 dogs, the 1st one named &quot;Potato&quot; with id=1 and food=&quot;tomato&quot;, and the 2nd one named &quot;Tomato&quot; with id=-1 and food=&quot;french fries&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutValidAsync(Siamese complexBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutValidAsync(complexBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put complex types that extend others. </summary>
        /// <param name="complexBody"> Please put a siamese with id=2, name=&quot;Siameee&quot;, color=green, breed=persion, which hates 2 dogs, the 1st one named &quot;Potato&quot; with id=1 and food=&quot;tomato&quot;, and the 2nd one named &quot;Tomato&quot; with id=-1 and food=&quot;french fries&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutValid(Siamese complexBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutValid(complexBody, cancellationToken);
        }
    }
}
