// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_complex.Models;

namespace body_complex
{
    /// <summary> The Polymorphicrecursive service client. </summary>
    public partial class PolymorphicrecursiveClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal PolymorphicrecursiveRestClient RestClient { get; }

        /// <summary> Initializes a new instance of PolymorphicrecursiveClient for mocking. </summary>
        protected PolymorphicrecursiveClient()
        {
        }

        /// <summary> Initializes a new instance of PolymorphicrecursiveClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal PolymorphicrecursiveClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new PolymorphicrecursiveRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get complex types that are polymorphic and have recursive references. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Fish>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphicrecursiveClient.GetValid");
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

        /// <summary> Get complex types that are polymorphic and have recursive references. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Fish> GetValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphicrecursiveClient.GetValid");
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

        /// <summary> Put complex types that are polymorphic and have recursive references. </summary>
        /// <param name="complexBody">
        /// Please put a salmon that looks like this:
        /// {
        ///     &quot;fishtype&quot;: &quot;salmon&quot;,
        ///     &quot;species&quot;: &quot;king&quot;,
        ///     &quot;length&quot;: 1,
        ///     &quot;age&quot;: 1,
        ///     &quot;location&quot;: &quot;alaska&quot;,
        ///     &quot;iswild&quot;: true,
        ///     &quot;siblings&quot;: [
        ///         {
        ///             &quot;fishtype&quot;: &quot;shark&quot;,
        ///             &quot;species&quot;: &quot;predator&quot;,
        ///             &quot;length&quot;: 20,
        ///             &quot;age&quot;: 6,
        ///             &quot;siblings&quot;: [
        ///                 {
        ///                     &quot;fishtype&quot;: &quot;salmon&quot;,
        ///                     &quot;species&quot;: &quot;coho&quot;,
        ///                     &quot;length&quot;: 2,
        ///                     &quot;age&quot;: 2,
        ///                     &quot;location&quot;: &quot;atlantic&quot;,
        ///                     &quot;iswild&quot;: true,
        ///                     &quot;siblings&quot;: [
        ///                         {
        ///                             &quot;fishtype&quot;: &quot;shark&quot;,
        ///                             &quot;species&quot;: &quot;predator&quot;,
        ///                             &quot;length&quot;: 20,
        ///                             &quot;age&quot;: 6
        ///                         },
        ///                         {
        ///                             &quot;fishtype&quot;: &quot;sawshark&quot;,
        ///                             &quot;species&quot;: &quot;dangerous&quot;,
        ///                             &quot;length&quot;: 10,
        ///                             &quot;age&quot;: 105
        ///                         }
        ///                     ]
        ///                 },
        ///                 {
        ///                     &quot;fishtype&quot;: &quot;sawshark&quot;,
        ///                     &quot;species&quot;: &quot;dangerous&quot;,
        ///                     &quot;length&quot;: 10,
        ///                     &quot;age&quot;: 105
        ///                 }
        ///             ]
        ///         },
        ///         {
        ///             &quot;fishtype&quot;: &quot;sawshark&quot;,
        ///             &quot;species&quot;: &quot;dangerous&quot;,
        ///             &quot;length&quot;: 10,
        ///             &quot;age&quot;: 105
        ///         }
        ///     ]
        /// }
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public virtual async Task<Response> PutValidAsync(Fish complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphicrecursiveClient.PutValid");
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

        /// <summary> Put complex types that are polymorphic and have recursive references. </summary>
        /// <param name="complexBody">
        /// Please put a salmon that looks like this:
        /// {
        ///     &quot;fishtype&quot;: &quot;salmon&quot;,
        ///     &quot;species&quot;: &quot;king&quot;,
        ///     &quot;length&quot;: 1,
        ///     &quot;age&quot;: 1,
        ///     &quot;location&quot;: &quot;alaska&quot;,
        ///     &quot;iswild&quot;: true,
        ///     &quot;siblings&quot;: [
        ///         {
        ///             &quot;fishtype&quot;: &quot;shark&quot;,
        ///             &quot;species&quot;: &quot;predator&quot;,
        ///             &quot;length&quot;: 20,
        ///             &quot;age&quot;: 6,
        ///             &quot;siblings&quot;: [
        ///                 {
        ///                     &quot;fishtype&quot;: &quot;salmon&quot;,
        ///                     &quot;species&quot;: &quot;coho&quot;,
        ///                     &quot;length&quot;: 2,
        ///                     &quot;age&quot;: 2,
        ///                     &quot;location&quot;: &quot;atlantic&quot;,
        ///                     &quot;iswild&quot;: true,
        ///                     &quot;siblings&quot;: [
        ///                         {
        ///                             &quot;fishtype&quot;: &quot;shark&quot;,
        ///                             &quot;species&quot;: &quot;predator&quot;,
        ///                             &quot;length&quot;: 20,
        ///                             &quot;age&quot;: 6
        ///                         },
        ///                         {
        ///                             &quot;fishtype&quot;: &quot;sawshark&quot;,
        ///                             &quot;species&quot;: &quot;dangerous&quot;,
        ///                             &quot;length&quot;: 10,
        ///                             &quot;age&quot;: 105
        ///                         }
        ///                     ]
        ///                 },
        ///                 {
        ///                     &quot;fishtype&quot;: &quot;sawshark&quot;,
        ///                     &quot;species&quot;: &quot;dangerous&quot;,
        ///                     &quot;length&quot;: 10,
        ///                     &quot;age&quot;: 105
        ///                 }
        ///             ]
        ///         },
        ///         {
        ///             &quot;fishtype&quot;: &quot;sawshark&quot;,
        ///             &quot;species&quot;: &quot;dangerous&quot;,
        ///             &quot;length&quot;: 10,
        ///             &quot;age&quot;: 105
        ///         }
        ///     ]
        /// }
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public virtual Response PutValid(Fish complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PolymorphicrecursiveClient.PutValid");
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
