// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using httpInfrastructure.Models;

namespace httpInfrastructure
{
    /// <summary> The MultipleResponses service client. </summary>
    public partial class MultipleResponsesClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal MultipleResponsesRestClient RestClient { get; }

        /// <summary> Initializes a new instance of MultipleResponsesClient for mocking. </summary>
        protected MultipleResponsesClient()
        {
        }

        /// <summary> Initializes a new instance of MultipleResponsesClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal MultipleResponsesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new MultipleResponsesRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200Model204NoModelDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError200Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200Model204NoModelDefaultError200ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200Model204NoModelDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError200Valid");
            scope.Start();
            try
            {
                return RestClient.Get200Model204NoModelDefaultError200Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200Model204NoModelDefaultError204ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError204Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200Model204NoModelDefaultError204ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200Model204NoModelDefaultError204Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError204Valid");
            scope.Start();
            try
            {
                return RestClient.Get200Model204NoModelDefaultError204Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 201 response with valid payload: {'statusCode': '201'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200Model204NoModelDefaultError201InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError201Invalid");
            scope.Start();
            try
            {
                return await RestClient.Get200Model204NoModelDefaultError201InvalidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 201 response with valid payload: {'statusCode': '201'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200Model204NoModelDefaultError201Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError201Invalid");
            scope.Start();
            try
            {
                return RestClient.Get200Model204NoModelDefaultError201Invalid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 202 response with no payload:. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200Model204NoModelDefaultError202NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError202None");
            scope.Start();
            try
            {
                return await RestClient.Get200Model204NoModelDefaultError202NoneAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 202 response with no payload:. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200Model204NoModelDefaultError202None(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError202None");
            scope.Start();
            try
            {
                return RestClient.Get200Model204NoModelDefaultError202None(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid error payload: {'status': 400, 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200Model204NoModelDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError400Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200Model204NoModelDefaultError400ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid error payload: {'status': 400, 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200Model204NoModelDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model204NoModelDefaultError400Valid");
            scope.Start();
            try
            {
                return RestClient.Get200Model204NoModelDefaultError400Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<object>> Get200Model201ModelDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError200Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200Model201ModelDefaultError200ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<object> Get200Model201ModelDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError200Valid");
            scope.Start();
            try
            {
                return RestClient.Get200Model201ModelDefaultError200Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 201 response with valid payload: {'statusCode': '201', 'textStatusCode': 'Created'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<object>> Get200Model201ModelDefaultError201ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError201Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200Model201ModelDefaultError201ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 201 response with valid payload: {'statusCode': '201', 'textStatusCode': 'Created'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<object> Get200Model201ModelDefaultError201Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError201Valid");
            scope.Start();
            try
            {
                return RestClient.Get200Model201ModelDefaultError201Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<object>> Get200Model201ModelDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError400Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200Model201ModelDefaultError400ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<object> Get200Model201ModelDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200Model201ModelDefaultError400Valid");
            scope.Start();
            try
            {
                return RestClient.Get200Model201ModelDefaultError400Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<object>> Get200ModelA201ModelC404ModelDDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError200Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200ModelA201ModelC404ModelDDefaultError200ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<object> Get200ModelA201ModelC404ModelDDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError200Valid");
            scope.Start();
            try
            {
                return RestClient.Get200ModelA201ModelC404ModelDDefaultError200Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with valid payload: {'httpCode': '201'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<object>> Get200ModelA201ModelC404ModelDDefaultError201ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError201Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200ModelA201ModelC404ModelDDefaultError201ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with valid payload: {'httpCode': '201'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<object> Get200ModelA201ModelC404ModelDDefaultError201Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError201Valid");
            scope.Start();
            try
            {
                return RestClient.Get200ModelA201ModelC404ModelDDefaultError201Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with valid payload: {'httpStatusCode': '404'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<object>> Get200ModelA201ModelC404ModelDDefaultError404ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError404Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200ModelA201ModelC404ModelDDefaultError404ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with valid payload: {'httpStatusCode': '404'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<object> Get200ModelA201ModelC404ModelDDefaultError404Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError404Valid");
            scope.Start();
            try
            {
                return RestClient.Get200ModelA201ModelC404ModelDDefaultError404Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<object>> Get200ModelA201ModelC404ModelDDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError400Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200ModelA201ModelC404ModelDDefaultError400ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<object> Get200ModelA201ModelC404ModelDDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA201ModelC404ModelDDefaultError400Valid");
            scope.Start();
            try
            {
                return RestClient.Get200ModelA201ModelC404ModelDDefaultError400Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 202 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get202None204NoneDefaultError202NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError202None");
            scope.Start();
            try
            {
                return await RestClient.Get202None204NoneDefaultError202NoneAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 202 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get202None204NoneDefaultError202None(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError202None");
            scope.Start();
            try
            {
                return RestClient.Get202None204NoneDefaultError202None(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get202None204NoneDefaultError204NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError204None");
            scope.Start();
            try
            {
                return await RestClient.Get202None204NoneDefaultError204NoneAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get202None204NoneDefaultError204None(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError204None");
            scope.Start();
            try
            {
                return RestClient.Get202None204NoneDefaultError204None(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get202None204NoneDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError400Valid");
            scope.Start();
            try
            {
                return await RestClient.Get202None204NoneDefaultError400ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid payload: {'code': '400', 'message': 'client error'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get202None204NoneDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultError400Valid");
            scope.Start();
            try
            {
                return RestClient.Get202None204NoneDefaultError400Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 202 response with an unexpected payload {'property': 'value'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get202None204NoneDefaultNone202InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone202Invalid");
            scope.Start();
            try
            {
                return await RestClient.Get202None204NoneDefaultNone202InvalidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 202 response with an unexpected payload {'property': 'value'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get202None204NoneDefaultNone202Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone202Invalid");
            scope.Start();
            try
            {
                return RestClient.Get202None204NoneDefaultNone202Invalid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get202None204NoneDefaultNone204NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone204None");
            scope.Start();
            try
            {
                return await RestClient.Get202None204NoneDefaultNone204NoneAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get202None204NoneDefaultNone204None(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone204None");
            scope.Start();
            try
            {
                return RestClient.Get202None204NoneDefaultNone204None(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get202None204NoneDefaultNone400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone400None");
            scope.Start();
            try
            {
                return await RestClient.Get202None204NoneDefaultNone400NoneAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get202None204NoneDefaultNone400None(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone400None");
            scope.Start();
            try
            {
                return RestClient.Get202None204NoneDefaultNone400None(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with an unexpected payload {'property': 'value'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> Get202None204NoneDefaultNone400InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone400Invalid");
            scope.Start();
            try
            {
                return await RestClient.Get202None204NoneDefaultNone400InvalidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with an unexpected payload {'property': 'value'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Get202None204NoneDefaultNone400Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get202None204NoneDefaultNone400Invalid");
            scope.Start();
            try
            {
                return RestClient.Get202None204NoneDefaultNone400Invalid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> GetDefaultModelA200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA200Valid");
            scope.Start();
            try
            {
                return await RestClient.GetDefaultModelA200ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with valid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> GetDefaultModelA200Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA200Valid");
            scope.Start();
            try
            {
                return RestClient.GetDefaultModelA200Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> GetDefaultModelA200NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA200None");
            scope.Start();
            try
            {
                return await RestClient.GetDefaultModelA200NoneAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> GetDefaultModelA200None(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA200None");
            scope.Start();
            try
            {
                return RestClient.GetDefaultModelA200None(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid payload: {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetDefaultModelA400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA400Valid");
            scope.Start();
            try
            {
                return await RestClient.GetDefaultModelA400ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid payload: {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetDefaultModelA400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA400Valid");
            scope.Start();
            try
            {
                return RestClient.GetDefaultModelA400Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetDefaultModelA400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA400None");
            scope.Start();
            try
            {
                return await RestClient.GetDefaultModelA400NoneAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetDefaultModelA400None(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultModelA400None");
            scope.Start();
            try
            {
                return RestClient.GetDefaultModelA400None(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with invalid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetDefaultNone200InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone200Invalid");
            scope.Start();
            try
            {
                return await RestClient.GetDefaultNone200InvalidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with invalid payload: {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetDefaultNone200Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone200Invalid");
            scope.Start();
            try
            {
                return RestClient.GetDefaultNone200Invalid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetDefaultNone200NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone200None");
            scope.Start();
            try
            {
                return await RestClient.GetDefaultNone200NoneAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetDefaultNone200None(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone200None");
            scope.Start();
            try
            {
                return RestClient.GetDefaultNone200None(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid payload: {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetDefaultNone400InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone400Invalid");
            scope.Start();
            try
            {
                return await RestClient.GetDefaultNone400InvalidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with valid payload: {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetDefaultNone400Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone400Invalid");
            scope.Start();
            try
            {
                return RestClient.GetDefaultNone400Invalid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetDefaultNone400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone400None");
            scope.Start();
            try
            {
                return await RestClient.GetDefaultNone400NoneAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetDefaultNone400None(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.GetDefaultNone400None");
            scope.Start();
            try
            {
                return RestClient.GetDefaultNone400None(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with no payload, when a payload is expected - client should return a null object of thde type for model A. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200ModelA200NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200None");
            scope.Start();
            try
            {
                return await RestClient.Get200ModelA200NoneAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with no payload, when a payload is expected - client should return a null object of thde type for model A. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200ModelA200None(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200None");
            scope.Start();
            try
            {
                return RestClient.Get200ModelA200None(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with payload {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200ModelA200ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200ModelA200ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with payload {'statusCode': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200ModelA200Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200Valid");
            scope.Start();
            try
            {
                return RestClient.Get200ModelA200Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with invalid payload {'statusCodeInvalid': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200ModelA200InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200Invalid");
            scope.Start();
            try
            {
                return await RestClient.Get200ModelA200InvalidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with invalid payload {'statusCodeInvalid': '200'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200ModelA200Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA200Invalid");
            scope.Start();
            try
            {
                return RestClient.Get200ModelA200Invalid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with no payload client should treat as an http error with no error model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200ModelA400NoneAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400None");
            scope.Start();
            try
            {
                return await RestClient.Get200ModelA400NoneAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 400 response with no payload client should treat as an http error with no error model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200ModelA400None(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400None");
            scope.Start();
            try
            {
                return RestClient.Get200ModelA400None(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with payload {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200ModelA400ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200ModelA400ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with payload {'statusCode': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200ModelA400Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400Valid");
            scope.Start();
            try
            {
                return RestClient.Get200ModelA400Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with invalid payload {'statusCodeInvalid': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200ModelA400InvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400Invalid");
            scope.Start();
            try
            {
                return await RestClient.Get200ModelA400InvalidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 200 response with invalid payload {'statusCodeInvalid': '400'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200ModelA400Invalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA400Invalid");
            scope.Start();
            try
            {
                return RestClient.Get200ModelA400Invalid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 202 response with payload {'statusCode': '202'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MyException>> Get200ModelA202ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA202Valid");
            scope.Start();
            try
            {
                return await RestClient.Get200ModelA202ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a 202 response with payload {'statusCode': '202'}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MyException> Get200ModelA202Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MultipleResponsesClient.Get200ModelA202Valid");
            scope.Start();
            try
            {
                return RestClient.Get200ModelA202Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
