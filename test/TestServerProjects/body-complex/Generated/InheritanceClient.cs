// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_complex.Models;

namespace body_complex
{
    /// <summary> The Inheritance service client. </summary>
    public partial class InheritanceClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal InheritanceRestClient RestClient { get; }

        /// <summary> Initializes a new instance of InheritanceClient for mocking. </summary>
        protected InheritanceClient()
        {
        }

        /// <summary> Initializes a new instance of InheritanceClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal InheritanceClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new InheritanceRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get complex types that extend others. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Siamese>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("InheritanceClient.GetValid");
            scope.Start();
            try
            {
                return await RestClient.GetValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types that extend others. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Siamese> GetValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("InheritanceClient.GetValid");
            scope.Start();
            try
            {
                return RestClient.GetValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types that extend others. </summary>
        /// <param name="complexBody"> Please put a siamese with id=2, name="Siameee", color=green, breed=persion, which hates 2 dogs, the 1st one named "Potato" with id=1 and food="tomato", and the 2nd one named "Tomato" with id=-1 and food="french fries". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutValidAsync(Siamese complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("InheritanceClient.PutValid");
            scope.Start();
            try
            {
                return await RestClient.PutValidAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types that extend others. </summary>
        /// <param name="complexBody"> Please put a siamese with id=2, name="Siameee", color=green, breed=persion, which hates 2 dogs, the 1st one named "Potato" with id=1 and food="tomato", and the 2nd one named "Tomato" with id=-1 and food="french fries". </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutValid(Siamese complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("InheritanceClient.PutValid");
            scope.Start();
            try
            {
                return RestClient.PutValid(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
