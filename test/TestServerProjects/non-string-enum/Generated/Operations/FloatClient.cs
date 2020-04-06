// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using non_string_enum.Models;

namespace non_string_enum
{
    public partial class FloatClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal FloatRestClient RestClient { get; }
        /// <summary> Initializes a new instance of FloatClient for mocking. </summary>
        protected FloatClient()
        {
        }
        /// <summary> Initializes a new instance of FloatClient. </summary>
        internal FloatClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new FloatRestClient(clientDiagnostics, pipeline, host);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Put a float enum. </summary>
        /// <param name="input"> Input float enum. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<string>> PutAsync(FloatEnum? input = null, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutAsync(input, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put a float enum. </summary>
        /// <param name="input"> Input float enum. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<string> Put(FloatEnum? input = null, CancellationToken cancellationToken = default)
        {
            return RestClient.Put(input, cancellationToken);
        }

        /// <summary> Get a float enum. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FloatEnum>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get a float enum. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FloatEnum> Get(CancellationToken cancellationToken = default)
        {
            return RestClient.Get(cancellationToken);
        }
    }
}
