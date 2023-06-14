// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using required_optional.Models;

namespace required_optional
{
    /// <summary> The Explicit service client. </summary>
    public partial class ExplicitClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ExplicitRestClient RestClient { get; }

        /// <summary> Initializes a new instance of ExplicitClient for mocking. </summary>
        protected ExplicitClient()
        {
        }

        /// <summary> Initializes a new instance of ExplicitClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal ExplicitClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new ExplicitRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Test explicitly optional body parameter. </summary>
        /// <param name="bodyParameter"> The Stream to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutOptionalBinaryBodyAsync(Stream bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PutOptionalBinaryBody");
            scope.Start();
            try
            {
                return await RestClient.PutOptionalBinaryBodyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional body parameter. </summary>
        /// <param name="bodyParameter"> The Stream to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutOptionalBinaryBody(Stream bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PutOptionalBinaryBody");
            scope.Start();
            try
            {
                return RestClient.PutOptionalBinaryBody(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required body parameter. </summary>
        /// <param name="bodyParameter"> The Stream to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutRequiredBinaryBodyAsync(Stream bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PutRequiredBinaryBody");
            scope.Start();
            try
            {
                return await RestClient.PutRequiredBinaryBodyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required body parameter. </summary>
        /// <param name="bodyParameter"> The Stream to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutRequiredBinaryBody(Stream bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PutRequiredBinaryBody");
            scope.Start();
            try
            {
                return RestClient.PutRequiredBinaryBody(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required integer. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredIntegerParameterAsync(int bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredIntegerParameter");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredIntegerParameterAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required integer. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequiredIntegerParameter(int bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredIntegerParameter");
            scope.Start();
            try
            {
                return RestClient.PostRequiredIntegerParameter(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional integer. Please put null. </summary>
        /// <param name="bodyParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalIntegerParameterAsync(int? bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalIntegerParameter");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalIntegerParameterAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional integer. Please put null. </summary>
        /// <param name="bodyParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptionalIntegerParameter(int? bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalIntegerParameter");
            scope.Start();
            try
            {
                return RestClient.PostOptionalIntegerParameter(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required integer. Please put a valid int-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The IntWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredIntegerPropertyAsync(IntWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredIntegerProperty");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredIntegerPropertyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required integer. Please put a valid int-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The IntWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequiredIntegerProperty(IntWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredIntegerProperty");
            scope.Start();
            try
            {
                return RestClient.PostRequiredIntegerProperty(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional integer. Please put a valid int-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The IntOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalIntegerPropertyAsync(IntOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalIntegerProperty");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalIntegerPropertyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional integer. Please put a valid int-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The IntOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptionalIntegerProperty(IntOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalIntegerProperty");
            scope.Start();
            try
            {
                return RestClient.PostOptionalIntegerProperty(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required integer. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredIntegerHeaderAsync(int headerParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredIntegerHeader");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredIntegerHeaderAsync(headerParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required integer. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequiredIntegerHeader(int headerParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredIntegerHeader");
            scope.Start();
            try
            {
                return RestClient.PostRequiredIntegerHeader(headerParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional integer. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="headerParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalIntegerHeaderAsync(int? headerParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalIntegerHeader");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalIntegerHeaderAsync(headerParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional integer. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="headerParameter"> The Int32 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptionalIntegerHeader(int? headerParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalIntegerHeader");
            scope.Start();
            try
            {
                return RestClient.PostOptionalIntegerHeader(headerParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required string. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredStringParameterAsync(string bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredStringParameter");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredStringParameterAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required string. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequiredStringParameter(string bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredStringParameter");
            scope.Start();
            try
            {
                return RestClient.PostRequiredStringParameter(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional string. Please put null. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalStringParameterAsync(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalStringParameter");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalStringParameterAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional string. Please put null. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptionalStringParameter(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalStringParameter");
            scope.Start();
            try
            {
                return RestClient.PostOptionalStringParameter(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required string. Please put a valid string-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The StringWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredStringPropertyAsync(StringWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredStringProperty");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredStringPropertyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required string. Please put a valid string-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The StringWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequiredStringProperty(StringWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredStringProperty");
            scope.Start();
            try
            {
                return RestClient.PostRequiredStringProperty(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional integer. Please put a valid string-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The StringOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalStringPropertyAsync(StringOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalStringProperty");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalStringPropertyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional integer. Please put a valid string-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The StringOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptionalStringProperty(StringOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalStringProperty");
            scope.Start();
            try
            {
                return RestClient.PostOptionalStringProperty(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required string. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredStringHeaderAsync(string headerParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredStringHeader");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredStringHeaderAsync(headerParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required string. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequiredStringHeader(string headerParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredStringHeader");
            scope.Start();
            try
            {
                return RestClient.PostRequiredStringHeader(headerParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional string. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalStringHeaderAsync(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalStringHeader");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalStringHeaderAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional string. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="bodyParameter"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptionalStringHeader(string bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalStringHeader");
            scope.Start();
            try
            {
                return RestClient.PostOptionalStringHeader(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required complex object. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The Product to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredClassParameterAsync(Product bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredClassParameter");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredClassParameterAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required complex object. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The Product to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequiredClassParameter(Product bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredClassParameter");
            scope.Start();
            try
            {
                return RestClient.PostRequiredClassParameter(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional complex object. Please put null. </summary>
        /// <param name="bodyParameter"> The Product to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalClassParameterAsync(Product bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalClassParameter");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalClassParameterAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional complex object. Please put null. </summary>
        /// <param name="bodyParameter"> The Product to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptionalClassParameter(Product bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalClassParameter");
            scope.Start();
            try
            {
                return RestClient.PostOptionalClassParameter(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required complex object. Please put a valid class-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ClassWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredClassPropertyAsync(ClassWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredClassProperty");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredClassPropertyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required complex object. Please put a valid class-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ClassWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequiredClassProperty(ClassWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredClassProperty");
            scope.Start();
            try
            {
                return RestClient.PostRequiredClassProperty(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional complex object. Please put a valid class-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The ClassOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalClassPropertyAsync(ClassOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalClassProperty");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalClassPropertyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional complex object. Please put a valid class-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The ClassOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptionalClassProperty(ClassOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalClassProperty");
            scope.Start();
            try
            {
                return RestClient.PostOptionalClassProperty(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required array. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ArrayOfPostContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredArrayParameterAsync(IEnumerable<string> bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredArrayParameter");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredArrayParameterAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required array. Please put null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ArrayOfPostContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequiredArrayParameter(IEnumerable<string> bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredArrayParameter");
            scope.Start();
            try
            {
                return RestClient.PostRequiredArrayParameter(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional array. Please put null. </summary>
        /// <param name="bodyParameter"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalArrayParameterAsync(IEnumerable<string> bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalArrayParameter");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalArrayParameterAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional array. Please put null. </summary>
        /// <param name="bodyParameter"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptionalArrayParameter(IEnumerable<string> bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalArrayParameter");
            scope.Start();
            try
            {
                return RestClient.PostOptionalArrayParameter(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required array. Please put a valid array-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ArrayWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredArrayPropertyAsync(ArrayWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredArrayProperty");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredArrayPropertyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required array. Please put a valid array-wrapper with 'value' = null and the client library should throw before the request is sent. </summary>
        /// <param name="bodyParameter"> The ArrayWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequiredArrayProperty(ArrayWrapper bodyParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredArrayProperty");
            scope.Start();
            try
            {
                return RestClient.PostRequiredArrayProperty(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional array. Please put a valid array-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The ArrayOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalArrayPropertyAsync(ArrayOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalArrayProperty");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalArrayPropertyAsync(bodyParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional array. Please put a valid array-wrapper with 'value' = null. </summary>
        /// <param name="bodyParameter"> The ArrayOptionalWrapper to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptionalArrayProperty(ArrayOptionalWrapper bodyParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalArrayProperty");
            scope.Start();
            try
            {
                return RestClient.PostOptionalArrayProperty(bodyParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required array. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The ArrayOfPost0ItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostRequiredArrayHeaderAsync(IEnumerable<string> headerParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredArrayHeader");
            scope.Start();
            try
            {
                return await RestClient.PostRequiredArrayHeaderAsync(headerParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly required array. Please put a header 'headerParameter' =&gt; null and the client library should throw before the request is sent. </summary>
        /// <param name="headerParameter"> The ArrayOfPost0ItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostRequiredArrayHeader(IEnumerable<string> headerParameter, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostRequiredArrayHeader");
            scope.Start();
            try
            {
                return RestClient.PostRequiredArrayHeader(headerParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional integer. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="headerParameter"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PostOptionalArrayHeaderAsync(IEnumerable<string> headerParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalArrayHeader");
            scope.Start();
            try
            {
                return await RestClient.PostOptionalArrayHeaderAsync(headerParameter, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Test explicitly optional integer. Please put a header 'headerParameter' =&gt; null. </summary>
        /// <param name="headerParameter"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PostOptionalArrayHeader(IEnumerable<string> headerParameter = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExplicitClient.PostOptionalArrayHeader");
            scope.Start();
            try
            {
                return RestClient.PostOptionalArrayHeader(headerParameter, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
