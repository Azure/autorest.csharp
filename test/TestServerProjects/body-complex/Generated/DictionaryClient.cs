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
    /// <summary> The Dictionary service client. </summary>
    public partial class DictionaryClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal DictionaryRestClient RestClient { get; }

        /// <summary> Initializes a new instance of DictionaryClient for mocking. </summary>
        protected DictionaryClient()
        {
        }

        /// <summary> Initializes a new instance of DictionaryClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal DictionaryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new DictionaryRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get complex types with dictionary property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DictionaryWrapper>> GetValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetValid");
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

        /// <summary> Get complex types with dictionary property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DictionaryWrapper> GetValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetValid");
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

        /// <summary> Put complex types with dictionary property. </summary>
        /// <param name="complexBody"> Please put a dictionary with 5 key-value pairs: &quot;txt&quot;:&quot;notepad&quot;, &quot;bmp&quot;:&quot;mspaint&quot;, &quot;xls&quot;:&quot;excel&quot;, &quot;exe&quot;:&quot;&quot;, &quot;&quot;:null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public virtual async Task<Response> PutValidAsync(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutValid");
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

        /// <summary> Put complex types with dictionary property. </summary>
        /// <param name="complexBody"> Please put a dictionary with 5 key-value pairs: &quot;txt&quot;:&quot;notepad&quot;, &quot;bmp&quot;:&quot;mspaint&quot;, &quot;xls&quot;:&quot;excel&quot;, &quot;exe&quot;:&quot;&quot;, &quot;&quot;:null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public virtual Response PutValid(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutValid");
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

        /// <summary> Get complex types with dictionary property which is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DictionaryWrapper>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetEmpty");
            scope.Start();
            try
            {
                return await RestClient.GetEmptyAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with dictionary property which is empty. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DictionaryWrapper> GetEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetEmpty");
            scope.Start();
            try
            {
                return RestClient.GetEmpty(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with dictionary property which is empty. </summary>
        /// <param name="complexBody"> Please put an empty dictionary. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public virtual async Task<Response> PutEmptyAsync(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutEmpty");
            scope.Start();
            try
            {
                return await RestClient.PutEmptyAsync(complexBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put complex types with dictionary property which is empty. </summary>
        /// <param name="complexBody"> Please put an empty dictionary. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="complexBody"/> is null. </exception>
        public virtual Response PutEmpty(DictionaryWrapper complexBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutEmpty");
            scope.Start();
            try
            {
                return RestClient.PutEmpty(complexBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with dictionary property which is null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DictionaryWrapper>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetNull");
            scope.Start();
            try
            {
                return await RestClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with dictionary property which is null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DictionaryWrapper> GetNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetNull");
            scope.Start();
            try
            {
                return RestClient.GetNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with dictionary property while server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DictionaryWrapper>> GetNotProvidedAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetNotProvided");
            scope.Start();
            try
            {
                return await RestClient.GetNotProvidedAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get complex types with dictionary property while server doesn&apos;t provide a response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DictionaryWrapper> GetNotProvided(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetNotProvided");
            scope.Start();
            try
            {
                return RestClient.GetNotProvided(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
