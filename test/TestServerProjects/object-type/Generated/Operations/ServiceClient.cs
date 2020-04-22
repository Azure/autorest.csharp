// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace object_type
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
        internal ServiceClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new ServiceRestClient(clientDiagnostics, pipeline, host);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Basic get that returns an object. Returns object { &apos;message&apos;: &apos;An object was successfully returned&apos; }. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<object>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Basic get that returns an object. Returns object { &apos;message&apos;: &apos;An object was successfully returned&apos; }. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<object> Get(CancellationToken cancellationToken = default)
        {
            return RestClient.Get(cancellationToken);
        }

        /// <summary> Basic put that puts an object. Pass in {&apos;foo&apos;: &apos;bar&apos;} to get a 200 and anything else to get an object error. </summary>
        /// <param name="putObject"> Pass in {&apos;foo&apos;: &apos;bar&apos;} for a 200, anything else for an object error. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutAsync(object putObject, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutAsync(putObject, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Basic put that puts an object. Pass in {&apos;foo&apos;: &apos;bar&apos;} to get a 200 and anything else to get an object error. </summary>
        /// <param name="putObject"> Pass in {&apos;foo&apos;: &apos;bar&apos;} for a 200, anything else for an object error. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Put(object putObject, CancellationToken cancellationToken = default)
        {
            return RestClient.Put(putObject, cancellationToken);
        }
    }
}
