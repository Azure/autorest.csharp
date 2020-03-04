// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using httpInfrastructure.Models;

namespace httpInfrastructure
{
    public partial class MultipleResponsesClient
    {
        private MultipleResponsesRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of MultipleResponsesClient. </summary>
        internal MultipleResponsesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new MultipleResponsesRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model204NoModelDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200Model204NoModelDefaultError200ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200Model204NoModelDefaultError200Valid(cancellationToken);
        }
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model204NoModelDefaultError204ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200Model204NoModelDefaultError204ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError204Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200Model204NoModelDefaultError204Valid(cancellationToken);
        }
        /// <summary> Send a 201 response with valid payload: {&apos;statusCode&apos;: &apos;201&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model204NoModelDefaultError201InvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200Model204NoModelDefaultError201InvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 201 response with valid payload: {&apos;statusCode&apos;: &apos;201&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError201Invalid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200Model204NoModelDefaultError201Invalid(cancellationToken);
        }
        /// <summary> Send a 202 response with no payload:. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model204NoModelDefaultError202NoneAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200Model204NoModelDefaultError202NoneAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 202 response with no payload:. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError202None(CancellationToken cancellationToken = default)
        {
            return restClient.Get200Model204NoModelDefaultError202None(cancellationToken);
        }
        /// <summary> Send a 400 response with valid error payload: {&apos;status&apos;: 400, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model204NoModelDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200Model204NoModelDefaultError400ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 400 response with valid error payload: {&apos;status&apos;: 400, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model204NoModelDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200Model204NoModelDefaultError400Valid(cancellationToken);
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model201ModelDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200Model201ModelDefaultError200ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model201ModelDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200Model201ModelDefaultError200Valid(cancellationToken);
        }
        /// <summary> Send a 201 response with valid payload: {&apos;statusCode&apos;: &apos;201&apos;, &apos;textStatusCode&apos;: &apos;Created&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model201ModelDefaultError201ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200Model201ModelDefaultError201ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 201 response with valid payload: {&apos;statusCode&apos;: &apos;201&apos;, &apos;textStatusCode&apos;: &apos;Created&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model201ModelDefaultError201Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200Model201ModelDefaultError201Valid(cancellationToken);
        }
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200Model201ModelDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200Model201ModelDefaultError400ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200Model201ModelDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200Model201ModelDefaultError400Valid(cancellationToken);
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA201ModelC404ModelDDefaultError200ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200ModelA201ModelC404ModelDDefaultError200ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA201ModelC404ModelDDefaultError200Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200ModelA201ModelC404ModelDDefaultError200Valid(cancellationToken);
        }
        /// <summary> Send a 200 response with valid payload: {&apos;httpCode&apos;: &apos;201&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA201ModelC404ModelDDefaultError201ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200ModelA201ModelC404ModelDDefaultError201ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with valid payload: {&apos;httpCode&apos;: &apos;201&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA201ModelC404ModelDDefaultError201Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200ModelA201ModelC404ModelDDefaultError201Valid(cancellationToken);
        }
        /// <summary> Send a 200 response with valid payload: {&apos;httpStatusCode&apos;: &apos;404&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA201ModelC404ModelDDefaultError404ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200ModelA201ModelC404ModelDDefaultError404ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with valid payload: {&apos;httpStatusCode&apos;: &apos;404&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA201ModelC404ModelDDefaultError404Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200ModelA201ModelC404ModelDDefaultError404Valid(cancellationToken);
        }
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA201ModelC404ModelDDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200ModelA201ModelC404ModelDDefaultError400ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA201ModelC404ModelDDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200ModelA201ModelC404ModelDDefaultError400Valid(cancellationToken);
        }
        /// <summary> Send a 202 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultError202NoneAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get202None204NoneDefaultError202NoneAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 202 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultError202None(CancellationToken cancellationToken = default)
        {
            return restClient.Get202None204NoneDefaultError202None(cancellationToken);
        }
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultError204NoneAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get202None204NoneDefaultError204NoneAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultError204None(CancellationToken cancellationToken = default)
        {
            return restClient.Get202None204NoneDefaultError204None(cancellationToken);
        }
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultError400ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get202None204NoneDefaultError400ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 400 response with valid payload: {&apos;code&apos;: &apos;400&apos;, &apos;message&apos;: &apos;client error&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultError400Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get202None204NoneDefaultError400Valid(cancellationToken);
        }
        /// <summary> Send a 202 response with an unexpected payload {&apos;property&apos;: &apos;value&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultNone202InvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get202None204NoneDefaultNone202InvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 202 response with an unexpected payload {&apos;property&apos;: &apos;value&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone202Invalid(CancellationToken cancellationToken = default)
        {
            return restClient.Get202None204NoneDefaultNone202Invalid(cancellationToken);
        }
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultNone204NoneAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get202None204NoneDefaultNone204NoneAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 204 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone204None(CancellationToken cancellationToken = default)
        {
            return restClient.Get202None204NoneDefaultNone204None(cancellationToken);
        }
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultNone400NoneAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get202None204NoneDefaultNone400NoneAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone400None(CancellationToken cancellationToken = default)
        {
            return restClient.Get202None204NoneDefaultNone400None(cancellationToken);
        }
        /// <summary> Send a 400 response with an unexpected payload {&apos;property&apos;: &apos;value&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> Get202None204NoneDefaultNone400InvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get202None204NoneDefaultNone400InvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 400 response with an unexpected payload {&apos;property&apos;: &apos;value&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Get202None204NoneDefaultNone400Invalid(CancellationToken cancellationToken = default)
        {
            return restClient.Get202None204NoneDefaultNone400Invalid(cancellationToken);
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> GetDefaultModelA200ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDefaultModelA200ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with valid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> GetDefaultModelA200Valid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDefaultModelA200Valid(cancellationToken);
        }
        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> GetDefaultModelA200NoneAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDefaultModelA200NoneAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> GetDefaultModelA200None(CancellationToken cancellationToken = default)
        {
            return restClient.GetDefaultModelA200None(cancellationToken);
        }
        /// <summary> Send a 400 response with valid payload: {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultModelA400ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDefaultModelA400ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 400 response with valid payload: {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultModelA400Valid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDefaultModelA400Valid(cancellationToken);
        }
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultModelA400NoneAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDefaultModelA400NoneAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultModelA400None(CancellationToken cancellationToken = default)
        {
            return restClient.GetDefaultModelA400None(cancellationToken);
        }
        /// <summary> Send a 200 response with invalid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultNone200InvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDefaultNone200InvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with invalid payload: {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone200Invalid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDefaultNone200Invalid(cancellationToken);
        }
        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultNone200NoneAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDefaultNone200NoneAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone200None(CancellationToken cancellationToken = default)
        {
            return restClient.GetDefaultNone200None(cancellationToken);
        }
        /// <summary> Send a 400 response with valid payload: {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultNone400InvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDefaultNone400InvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 400 response with valid payload: {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone400Invalid(CancellationToken cancellationToken = default)
        {
            return restClient.GetDefaultNone400Invalid(cancellationToken);
        }
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetDefaultNone400NoneAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDefaultNone400NoneAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 400 response with no payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetDefaultNone400None(CancellationToken cancellationToken = default)
        {
            return restClient.GetDefaultNone400None(cancellationToken);
        }
        /// <summary> Send a 200 response with no payload, when a payload is expected - client should return a null object of thde type for model A. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA200NoneAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200ModelA200NoneAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with no payload, when a payload is expected - client should return a null object of thde type for model A. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA200None(CancellationToken cancellationToken = default)
        {
            return restClient.Get200ModelA200None(cancellationToken);
        }
        /// <summary> Send a 200 response with payload {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA200ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200ModelA200ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with payload {&apos;statusCode&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA200Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200ModelA200Valid(cancellationToken);
        }
        /// <summary> Send a 200 response with invalid payload {&apos;statusCodeInvalid&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA200InvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200ModelA200InvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with invalid payload {&apos;statusCodeInvalid&apos;: &apos;200&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA200Invalid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200ModelA200Invalid(cancellationToken);
        }
        /// <summary> Send a 400 response with no payload client should treat as an http error with no error model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA400NoneAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200ModelA400NoneAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 400 response with no payload client should treat as an http error with no error model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA400None(CancellationToken cancellationToken = default)
        {
            return restClient.Get200ModelA400None(cancellationToken);
        }
        /// <summary> Send a 200 response with payload {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA400ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200ModelA400ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with payload {&apos;statusCode&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA400Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200ModelA400Valid(cancellationToken);
        }
        /// <summary> Send a 200 response with invalid payload {&apos;statusCodeInvalid&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA400InvalidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200ModelA400InvalidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 200 response with invalid payload {&apos;statusCodeInvalid&apos;: &apos;400&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA400Invalid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200ModelA400Invalid(cancellationToken);
        }
        /// <summary> Send a 202 response with payload {&apos;statusCode&apos;: &apos;202&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<MyException>> Get200ModelA202ValidAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.Get200ModelA202ValidAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Send a 202 response with payload {&apos;statusCode&apos;: &apos;202&apos;}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<MyException> Get200ModelA202Valid(CancellationToken cancellationToken = default)
        {
            return restClient.Get200ModelA202Valid(cancellationToken);
        }
    }
}
