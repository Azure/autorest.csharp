// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using constants.Models;

namespace constants
{
    /// <summary> The Contants service client. </summary>
    public partial class ContantsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ContantsRestClient RestClient { get; }

        /// <summary> Initializes a new instance of ContantsClient for mocking. </summary>
        protected ContantsClient()
        {
        }

        /// <summary> Initializes a new instance of ContantsClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="headerConstant"> Constant header property on the client that is a required parameter for operation 'constants_putClientConstants'. </param>
        /// <param name="queryConstant"> Constant query property on the client that is a required parameter for operation 'constants_putClientConstants'. </param>
        /// <param name="pathConstant"> Constant path property on the client that is a required parameter for operation 'constants_putClientConstants'. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="pathConstant"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pathConstant"/> is an empty string, and was expected to be non-empty. </exception>
        internal ContantsClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null, bool headerConstant = true, int queryConstant = 100, string pathConstant = "path")
        {
            RestClient = new ContantsRestClient(clientDiagnostics, pipeline, endpoint, headerConstant, queryConstant, pathConstant);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutNoModelAsStringNoRequiredTwoValueNoDefaultAsync(NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringNoRequiredTwoValueNoDefault");
            scope.Start();
            try
            {
                return await RestClient.PutNoModelAsStringNoRequiredTwoValueNoDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutNoModelAsStringNoRequiredTwoValueNoDefault(NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringNoRequiredTwoValueNoDefault");
            scope.Start();
            try
            {
                return RestClient.PutNoModelAsStringNoRequiredTwoValueNoDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringNoRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutNoModelAsStringNoRequiredTwoValueDefaultAsync(NoModelAsStringNoRequiredTwoValueDefaultOpEnum? input = NoModelAsStringNoRequiredTwoValueDefaultOpEnum.Value1, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringNoRequiredTwoValueDefault");
            scope.Start();
            try
            {
                return await RestClient.PutNoModelAsStringNoRequiredTwoValueDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringNoRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutNoModelAsStringNoRequiredTwoValueDefault(NoModelAsStringNoRequiredTwoValueDefaultOpEnum? input = NoModelAsStringNoRequiredTwoValueDefaultOpEnum.Value1, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringNoRequiredTwoValueDefault");
            scope.Start();
            try
            {
                return RestClient.PutNoModelAsStringNoRequiredTwoValueDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutNoModelAsStringNoRequiredOneValueNoDefaultAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringNoRequiredOneValueNoDefault");
            scope.Start();
            try
            {
                return await RestClient.PutNoModelAsStringNoRequiredOneValueNoDefaultAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutNoModelAsStringNoRequiredOneValueNoDefault(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringNoRequiredOneValueNoDefault");
            scope.Start();
            try
            {
                return RestClient.PutNoModelAsStringNoRequiredOneValueNoDefault(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutNoModelAsStringNoRequiredOneValueDefaultAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringNoRequiredOneValueDefault");
            scope.Start();
            try
            {
                return await RestClient.PutNoModelAsStringNoRequiredOneValueDefaultAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutNoModelAsStringNoRequiredOneValueDefault(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringNoRequiredOneValueDefault");
            scope.Start();
            try
            {
                return RestClient.PutNoModelAsStringNoRequiredOneValueDefault(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutNoModelAsStringRequiredTwoValueNoDefaultAsync(NoModelAsStringRequiredTwoValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringRequiredTwoValueNoDefault");
            scope.Start();
            try
            {
                return await RestClient.PutNoModelAsStringRequiredTwoValueNoDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutNoModelAsStringRequiredTwoValueNoDefault(NoModelAsStringRequiredTwoValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringRequiredTwoValueNoDefault");
            scope.Start();
            try
            {
                return RestClient.PutNoModelAsStringRequiredTwoValueNoDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutNoModelAsStringRequiredTwoValueDefaultAsync(NoModelAsStringRequiredTwoValueDefaultOpEnum input = NoModelAsStringRequiredTwoValueDefaultOpEnum.Value1, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringRequiredTwoValueDefault");
            scope.Start();
            try
            {
                return await RestClient.PutNoModelAsStringRequiredTwoValueDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The NoModelAsStringRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutNoModelAsStringRequiredTwoValueDefault(NoModelAsStringRequiredTwoValueDefaultOpEnum input = NoModelAsStringRequiredTwoValueDefaultOpEnum.Value1, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringRequiredTwoValueDefault");
            scope.Start();
            try
            {
                return RestClient.PutNoModelAsStringRequiredTwoValueDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutNoModelAsStringRequiredOneValueNoDefaultAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringRequiredOneValueNoDefault");
            scope.Start();
            try
            {
                return await RestClient.PutNoModelAsStringRequiredOneValueNoDefaultAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutNoModelAsStringRequiredOneValueNoDefault(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringRequiredOneValueNoDefault");
            scope.Start();
            try
            {
                return RestClient.PutNoModelAsStringRequiredOneValueNoDefault(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutNoModelAsStringRequiredOneValueDefaultAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringRequiredOneValueDefault");
            scope.Start();
            try
            {
                return await RestClient.PutNoModelAsStringRequiredOneValueDefaultAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutNoModelAsStringRequiredOneValueDefault(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutNoModelAsStringRequiredOneValueDefault");
            scope.Start();
            try
            {
                return RestClient.PutNoModelAsStringRequiredOneValueDefault(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutModelAsStringNoRequiredTwoValueNoDefaultAsync(ModelAsStringNoRequiredTwoValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringNoRequiredTwoValueNoDefault");
            scope.Start();
            try
            {
                return await RestClient.PutModelAsStringNoRequiredTwoValueNoDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutModelAsStringNoRequiredTwoValueNoDefault(ModelAsStringNoRequiredTwoValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringNoRequiredTwoValueNoDefault");
            scope.Start();
            try
            {
                return RestClient.PutModelAsStringNoRequiredTwoValueNoDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutModelAsStringNoRequiredTwoValueDefaultAsync(ModelAsStringNoRequiredTwoValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringNoRequiredTwoValueDefault");
            scope.Start();
            try
            {
                return await RestClient.PutModelAsStringNoRequiredTwoValueDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutModelAsStringNoRequiredTwoValueDefault(ModelAsStringNoRequiredTwoValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringNoRequiredTwoValueDefault");
            scope.Start();
            try
            {
                return RestClient.PutModelAsStringNoRequiredTwoValueDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredOneValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutModelAsStringNoRequiredOneValueNoDefaultAsync(ModelAsStringNoRequiredOneValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringNoRequiredOneValueNoDefault");
            scope.Start();
            try
            {
                return await RestClient.PutModelAsStringNoRequiredOneValueNoDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredOneValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutModelAsStringNoRequiredOneValueNoDefault(ModelAsStringNoRequiredOneValueNoDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringNoRequiredOneValueNoDefault");
            scope.Start();
            try
            {
                return RestClient.PutModelAsStringNoRequiredOneValueNoDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredOneValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutModelAsStringNoRequiredOneValueDefaultAsync(ModelAsStringNoRequiredOneValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringNoRequiredOneValueDefault");
            scope.Start();
            try
            {
                return await RestClient.PutModelAsStringNoRequiredOneValueDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringNoRequiredOneValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutModelAsStringNoRequiredOneValueDefault(ModelAsStringNoRequiredOneValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringNoRequiredOneValueDefault");
            scope.Start();
            try
            {
                return RestClient.PutModelAsStringNoRequiredOneValueDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutModelAsStringRequiredTwoValueNoDefaultAsync(ModelAsStringRequiredTwoValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringRequiredTwoValueNoDefault");
            scope.Start();
            try
            {
                return await RestClient.PutModelAsStringRequiredTwoValueNoDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredTwoValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutModelAsStringRequiredTwoValueNoDefault(ModelAsStringRequiredTwoValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringRequiredTwoValueNoDefault");
            scope.Start();
            try
            {
                return RestClient.PutModelAsStringRequiredTwoValueNoDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutModelAsStringRequiredTwoValueDefaultAsync(ModelAsStringRequiredTwoValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringRequiredTwoValueDefault");
            scope.Start();
            try
            {
                return await RestClient.PutModelAsStringRequiredTwoValueDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredTwoValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutModelAsStringRequiredTwoValueDefault(ModelAsStringRequiredTwoValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringRequiredTwoValueDefault");
            scope.Start();
            try
            {
                return RestClient.PutModelAsStringRequiredTwoValueDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredOneValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutModelAsStringRequiredOneValueNoDefaultAsync(ModelAsStringRequiredOneValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringRequiredOneValueNoDefault");
            scope.Start();
            try
            {
                return await RestClient.PutModelAsStringRequiredOneValueNoDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredOneValueNoDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutModelAsStringRequiredOneValueNoDefault(ModelAsStringRequiredOneValueNoDefaultOpEnum input, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringRequiredOneValueNoDefault");
            scope.Start();
            try
            {
                return RestClient.PutModelAsStringRequiredOneValueNoDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredOneValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutModelAsStringRequiredOneValueDefaultAsync(ModelAsStringRequiredOneValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringRequiredOneValueDefault");
            scope.Start();
            try
            {
                return await RestClient.PutModelAsStringRequiredOneValueDefaultAsync(input, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts constants to the testserver. </summary>
        /// <param name="input"> The ModelAsStringRequiredOneValueDefaultOpEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutModelAsStringRequiredOneValueDefault(ModelAsStringRequiredOneValueDefaultOpEnum? input = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutModelAsStringRequiredOneValueDefault");
            scope.Start();
            try
            {
                return RestClient.PutModelAsStringRequiredOneValueDefault(input, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Pass constants from the client to this function. Will pass in constant path, query, and header parameters. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutClientConstantsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutClientConstants");
            scope.Start();
            try
            {
                return await RestClient.PutClientConstantsAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Pass constants from the client to this function. Will pass in constant path, query, and header parameters. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutClientConstants(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContantsClient.PutClientConstants");
            scope.Start();
            try
            {
                return RestClient.PutClientConstants(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
