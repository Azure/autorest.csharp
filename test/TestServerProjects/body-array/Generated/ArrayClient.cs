// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_array.Models;

namespace body_array
{
    /// <summary> The Array service client. </summary>
    public partial class ArrayClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ArrayRestClient RestClient { get; }

        /// <summary> Initializes a new instance of ArrayClient for mocking. </summary>
        protected ArrayClient()
        {
        }

        /// <summary> Initializes a new instance of ArrayClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal ArrayClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new ArrayRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get null array value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<int>>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetNull");
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

        /// <summary> Get null array value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<int>> GetNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetNull");
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

        /// <summary> Get invalid array [1, 2, 3. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<int>>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetInvalid");
            scope.Start();
            try
            {
                return await RestClient.GetInvalidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid array [1, 2, 3. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<int>> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetInvalid");
            scope.Start();
            try
            {
                return RestClient.GetInvalid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get empty array value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<int>>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetEmpty");
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

        /// <summary> Get empty array value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<int>> GetEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetEmpty");
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

        /// <summary> Set array value empty []. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutEmptyAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutEmpty");
            scope.Start();
            try
            {
                return await RestClient.PutEmptyAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value empty []. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutEmpty(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutEmpty");
            scope.Start();
            try
            {
                return RestClient.PutEmpty(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get boolean array value [true, false, false, true]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<bool>>> GetBooleanTfftAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetBooleanTfft");
            scope.Start();
            try
            {
                return await RestClient.GetBooleanTfftAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get boolean array value [true, false, false, true]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<bool>> GetBooleanTfft(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetBooleanTfft");
            scope.Start();
            try
            {
                return RestClient.GetBooleanTfft(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value empty [true, false, false, true]. </summary>
        /// <param name="arrayBody"> The ArrayOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutBooleanTfftAsync(IEnumerable<bool> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutBooleanTfft");
            scope.Start();
            try
            {
                return await RestClient.PutBooleanTfftAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value empty [true, false, false, true]. </summary>
        /// <param name="arrayBody"> The ArrayOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutBooleanTfft(IEnumerable<bool> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutBooleanTfft");
            scope.Start();
            try
            {
                return RestClient.PutBooleanTfft(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get boolean array value [true, null, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<bool>>> GetBooleanInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetBooleanInvalidNull");
            scope.Start();
            try
            {
                return await RestClient.GetBooleanInvalidNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get boolean array value [true, null, false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<bool>> GetBooleanInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetBooleanInvalidNull");
            scope.Start();
            try
            {
                return RestClient.GetBooleanInvalidNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get boolean array value [true, 'boolean', false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<bool>>> GetBooleanInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetBooleanInvalidString");
            scope.Start();
            try
            {
                return await RestClient.GetBooleanInvalidStringAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get boolean array value [true, 'boolean', false]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<bool>> GetBooleanInvalidString(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetBooleanInvalidString");
            scope.Start();
            try
            {
                return RestClient.GetBooleanInvalidString(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<int>>> GetIntegerValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetIntegerValid");
            scope.Start();
            try
            {
                return await RestClient.GetIntegerValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<int>> GetIntegerValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetIntegerValid");
            scope.Start();
            try
            {
                return RestClient.GetIntegerValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutIntegerValidAsync(IEnumerable<int> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutIntegerValid");
            scope.Start();
            try
            {
                return await RestClient.PutIntegerValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutIntegerValid(IEnumerable<int> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutIntegerValid");
            scope.Start();
            try
            {
                return RestClient.PutIntegerValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get integer array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<int>>> GetIntInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetIntInvalidNull");
            scope.Start();
            try
            {
                return await RestClient.GetIntInvalidNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get integer array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<int>> GetIntInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetIntInvalidNull");
            scope.Start();
            try
            {
                return RestClient.GetIntInvalidNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get integer array value [1, 'integer', 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<int>>> GetIntInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetIntInvalidString");
            scope.Start();
            try
            {
                return await RestClient.GetIntInvalidStringAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get integer array value [1, 'integer', 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<int>> GetIntInvalidString(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetIntInvalidString");
            scope.Start();
            try
            {
                return RestClient.GetIntInvalidString(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<long>>> GetLongValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetLongValid");
            scope.Start();
            try
            {
                return await RestClient.GetLongValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get integer array value [1, -1, 3, 300]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<long>> GetLongValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetLongValid");
            scope.Start();
            try
            {
                return RestClient.GetLongValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutLongValidAsync(IEnumerable<long> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutLongValid");
            scope.Start();
            try
            {
                return await RestClient.PutLongValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value empty [1, -1, 3, 300]. </summary>
        /// <param name="arrayBody"> The ArrayOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutLongValid(IEnumerable<long> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutLongValid");
            scope.Start();
            try
            {
                return RestClient.PutLongValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get long array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<long>>> GetLongInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetLongInvalidNull");
            scope.Start();
            try
            {
                return await RestClient.GetLongInvalidNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get long array value [1, null, 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<long>> GetLongInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetLongInvalidNull");
            scope.Start();
            try
            {
                return RestClient.GetLongInvalidNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get long array value [1, 'integer', 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<long>>> GetLongInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetLongInvalidString");
            scope.Start();
            try
            {
                return await RestClient.GetLongInvalidStringAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get long array value [1, 'integer', 0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<long>> GetLongInvalidString(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetLongInvalidString");
            scope.Start();
            try
            {
                return RestClient.GetLongInvalidString(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<float>>> GetFloatValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetFloatValid");
            scope.Start();
            try
            {
                return await RestClient.GetFloatValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<float>> GetFloatValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetFloatValid");
            scope.Start();
            try
            {
                return RestClient.GetFloatValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutFloatValidAsync(IEnumerable<float> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutFloatValid");
            scope.Start();
            try
            {
                return await RestClient.PutFloatValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutFloatValid(IEnumerable<float> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutFloatValid");
            scope.Start();
            try
            {
                return RestClient.PutFloatValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<float>>> GetFloatInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetFloatInvalidNull");
            scope.Start();
            try
            {
                return await RestClient.GetFloatInvalidNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<float>> GetFloatInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetFloatInvalidNull");
            scope.Start();
            try
            {
                return RestClient.GetFloatInvalidNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get boolean array value [1.0, 'number', 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<float>>> GetFloatInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetFloatInvalidString");
            scope.Start();
            try
            {
                return await RestClient.GetFloatInvalidStringAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get boolean array value [1.0, 'number', 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<float>> GetFloatInvalidString(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetFloatInvalidString");
            scope.Start();
            try
            {
                return RestClient.GetFloatInvalidString(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<double>>> GetDoubleValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDoubleValid");
            scope.Start();
            try
            {
                return await RestClient.GetDoubleValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get float array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<double>> GetDoubleValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDoubleValid");
            scope.Start();
            try
            {
                return RestClient.GetDoubleValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDoubleValidAsync(IEnumerable<double> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDoubleValid");
            scope.Start();
            try
            {
                return await RestClient.PutDoubleValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value [0, -0.01, 1.2e20]. </summary>
        /// <param name="arrayBody"> The ArrayOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDoubleValid(IEnumerable<double> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDoubleValid");
            scope.Start();
            try
            {
                return RestClient.PutDoubleValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<double>>> GetDoubleInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDoubleInvalidNull");
            scope.Start();
            try
            {
                return await RestClient.GetDoubleInvalidNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get float array value [0.0, null, -1.2e20]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<double>> GetDoubleInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDoubleInvalidNull");
            scope.Start();
            try
            {
                return RestClient.GetDoubleInvalidNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get boolean array value [1.0, 'number', 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<double>>> GetDoubleInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDoubleInvalidString");
            scope.Start();
            try
            {
                return await RestClient.GetDoubleInvalidStringAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get boolean array value [1.0, 'number', 0.0]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<double>> GetDoubleInvalidString(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDoubleInvalidString");
            scope.Start();
            try
            {
                return RestClient.GetDoubleInvalidString(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get string array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<string>>> GetStringValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetStringValid");
            scope.Start();
            try
            {
                return await RestClient.GetStringValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get string array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<string>> GetStringValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetStringValid");
            scope.Start();
            try
            {
                return RestClient.GetStringValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutStringValidAsync(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutStringValid");
            scope.Start();
            try
            {
                return await RestClient.PutStringValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutStringValid(IEnumerable<string> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutStringValid");
            scope.Start();
            try
            {
                return RestClient.PutStringValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get enum array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<FooEnum>>> GetEnumValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetEnumValid");
            scope.Start();
            try
            {
                return await RestClient.GetEnumValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get enum array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<FooEnum>> GetEnumValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetEnumValid");
            scope.Start();
            try
            {
                return RestClient.GetEnumValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfFooEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutEnumValidAsync(IEnumerable<FooEnum> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutEnumValid");
            scope.Start();
            try
            {
                return await RestClient.PutEnumValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfFooEnum to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutEnumValid(IEnumerable<FooEnum> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutEnumValid");
            scope.Start();
            try
            {
                return RestClient.PutEnumValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get enum array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<Enum0>>> GetStringEnumValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetStringEnumValid");
            scope.Start();
            try
            {
                return await RestClient.GetStringEnumValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get enum array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Enum0>> GetStringEnumValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetStringEnumValid");
            scope.Start();
            try
            {
                return RestClient.GetStringEnumValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfpathsBqqpc7ArrayPrimStringEnumFoo1Foo2Foo3PutRequestbodyContentApplicationJsonSchemaItems to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutStringEnumValidAsync(IEnumerable<Enum1> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutStringEnumValid");
            scope.Start();
            try
            {
                return await RestClient.PutStringEnumValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value ['foo1', 'foo2', 'foo3']. </summary>
        /// <param name="arrayBody"> The ArrayOfpathsBqqpc7ArrayPrimStringEnumFoo1Foo2Foo3PutRequestbodyContentApplicationJsonSchemaItems to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutStringEnumValid(IEnumerable<Enum1> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutStringEnumValid");
            scope.Start();
            try
            {
                return RestClient.PutStringEnumValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get string array value ['foo', null, 'foo2']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<string>>> GetStringWithNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetStringWithNull");
            scope.Start();
            try
            {
                return await RestClient.GetStringWithNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get string array value ['foo', null, 'foo2']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<string>> GetStringWithNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetStringWithNull");
            scope.Start();
            try
            {
                return RestClient.GetStringWithNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get string array value ['foo', 123, 'foo2']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<string>>> GetStringWithInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetStringWithInvalid");
            scope.Start();
            try
            {
                return await RestClient.GetStringWithInvalidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get string array value ['foo', 123, 'foo2']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<string>> GetStringWithInvalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetStringWithInvalid");
            scope.Start();
            try
            {
                return RestClient.GetStringWithInvalid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get uuid array value ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'd1399005-30f7-40d6-8da6-dd7c89ad34db', 'f42f6aa1-a5bc-4ddf-907e-5f915de43205']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<Guid>>> GetUuidValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetUuidValid");
            scope.Start();
            try
            {
                return await RestClient.GetUuidValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get uuid array value ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'd1399005-30f7-40d6-8da6-dd7c89ad34db', 'f42f6aa1-a5bc-4ddf-907e-5f915de43205']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Guid>> GetUuidValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetUuidValid");
            scope.Start();
            try
            {
                return RestClient.GetUuidValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value  ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'd1399005-30f7-40d6-8da6-dd7c89ad34db', 'f42f6aa1-a5bc-4ddf-907e-5f915de43205']. </summary>
        /// <param name="arrayBody"> The ArrayOfUuid to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutUuidValidAsync(IEnumerable<Guid> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutUuidValid");
            scope.Start();
            try
            {
                return await RestClient.PutUuidValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value  ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'd1399005-30f7-40d6-8da6-dd7c89ad34db', 'f42f6aa1-a5bc-4ddf-907e-5f915de43205']. </summary>
        /// <param name="arrayBody"> The ArrayOfUuid to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutUuidValid(IEnumerable<Guid> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutUuidValid");
            scope.Start();
            try
            {
                return RestClient.PutUuidValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get uuid array value ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'foo']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<Guid>>> GetUuidInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetUuidInvalidChars");
            scope.Start();
            try
            {
                return await RestClient.GetUuidInvalidCharsAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get uuid array value ['6dcc7237-45fe-45c4-8a6b-3a8a3f625652', 'foo']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Guid>> GetUuidInvalidChars(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetUuidInvalidChars");
            scope.Start();
            try
            {
                return RestClient.GetUuidInvalidChars(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get integer array value ['2000-12-01', '1980-01-02', '1492-10-12']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateValid");
            scope.Start();
            try
            {
                return await RestClient.GetDateValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get integer array value ['2000-12-01', '1980-01-02', '1492-10-12']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<DateTimeOffset>> GetDateValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateValid");
            scope.Start();
            try
            {
                return RestClient.GetDateValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value  ['2000-12-01', '1980-01-02', '1492-10-12']. </summary>
        /// <param name="arrayBody"> The ArrayOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDateValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDateValid");
            scope.Start();
            try
            {
                return await RestClient.PutDateValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value  ['2000-12-01', '1980-01-02', '1492-10-12']. </summary>
        /// <param name="arrayBody"> The ArrayOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDateValid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDateValid");
            scope.Start();
            try
            {
                return RestClient.PutDateValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date array value ['2012-01-01', null, '1776-07-04']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateInvalidNull");
            scope.Start();
            try
            {
                return await RestClient.GetDateInvalidNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date array value ['2012-01-01', null, '1776-07-04']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<DateTimeOffset>> GetDateInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateInvalidNull");
            scope.Start();
            try
            {
                return RestClient.GetDateInvalidNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date array value ['2011-03-22', 'date']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateInvalidChars");
            scope.Start();
            try
            {
                return await RestClient.GetDateInvalidCharsAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date array value ['2011-03-22', 'date']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<DateTimeOffset>> GetDateInvalidChars(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateInvalidChars");
            scope.Start();
            try
            {
                return RestClient.GetDateInvalidChars(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date-time array value ['2000-12-01t00:00:01z', '1980-01-02T00:11:35+01:00', '1492-10-12T10:15:01-08:00']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateTimeValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateTimeValid");
            scope.Start();
            try
            {
                return await RestClient.GetDateTimeValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date-time array value ['2000-12-01t00:00:01z', '1980-01-02T00:11:35+01:00', '1492-10-12T10:15:01-08:00']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<DateTimeOffset>> GetDateTimeValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateTimeValid");
            scope.Start();
            try
            {
                return RestClient.GetDateTimeValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value  ['2000-12-01t00:00:01z', '1980-01-02T00:11:35+01:00', '1492-10-12T10:15:01-08:00']. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDateTimeValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDateTimeValid");
            scope.Start();
            try
            {
                return await RestClient.PutDateTimeValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value  ['2000-12-01t00:00:01z', '1980-01-02T00:11:35+01:00', '1492-10-12T10:15:01-08:00']. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDateTimeValid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDateTimeValid");
            scope.Start();
            try
            {
                return RestClient.PutDateTimeValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date array value ['2000-12-01t00:00:01z', null]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateTimeInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateTimeInvalidNull");
            scope.Start();
            try
            {
                return await RestClient.GetDateTimeInvalidNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date array value ['2000-12-01t00:00:01z', null]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<DateTimeOffset>> GetDateTimeInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateTimeInvalidNull");
            scope.Start();
            try
            {
                return RestClient.GetDateTimeInvalidNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date array value ['2000-12-01t00:00:01z', 'date-time']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateTimeInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateTimeInvalidChars");
            scope.Start();
            try
            {
                return await RestClient.GetDateTimeInvalidCharsAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date array value ['2000-12-01t00:00:01z', 'date-time']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<DateTimeOffset>> GetDateTimeInvalidChars(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateTimeInvalidChars");
            scope.Start();
            try
            {
                return RestClient.GetDateTimeInvalidChars(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date-time array value ['Fri, 01 Dec 2000 00:00:01 GMT', 'Wed, 02 Jan 1980 00:11:35 GMT', 'Wed, 12 Oct 1492 10:15:01 GMT']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<DateTimeOffset>>> GetDateTimeRfc1123ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                return await RestClient.GetDateTimeRfc1123ValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get date-time array value ['Fri, 01 Dec 2000 00:00:01 GMT', 'Wed, 02 Jan 1980 00:11:35 GMT', 'Wed, 12 Oct 1492 10:15:01 GMT']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<DateTimeOffset>> GetDateTimeRfc1123Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                return RestClient.GetDateTimeRfc1123Valid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value  ['Fri, 01 Dec 2000 00:00:01 GMT', 'Wed, 02 Jan 1980 00:11:35 GMT', 'Wed, 12 Oct 1492 10:15:01 GMT']. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDateTimeRfc1123ValidAsync(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                return await RestClient.PutDateTimeRfc1123ValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value  ['Fri, 01 Dec 2000 00:00:01 GMT', 'Wed, 02 Jan 1980 00:11:35 GMT', 'Wed, 12 Oct 1492 10:15:01 GMT']. </summary>
        /// <param name="arrayBody"> The ArrayOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDateTimeRfc1123Valid(IEnumerable<DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDateTimeRfc1123Valid");
            scope.Start();
            try
            {
                return RestClient.PutDateTimeRfc1123Valid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get duration array value ['P123DT22H14M12.011S', 'P5DT1H0M0S']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<TimeSpan>>> GetDurationValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDurationValid");
            scope.Start();
            try
            {
                return await RestClient.GetDurationValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get duration array value ['P123DT22H14M12.011S', 'P5DT1H0M0S']. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<TimeSpan>> GetDurationValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDurationValid");
            scope.Start();
            try
            {
                return RestClient.GetDurationValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value  ['P123DT22H14M12.011S', 'P5DT1H0M0S']. </summary>
        /// <param name="arrayBody"> The ArrayOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDurationValidAsync(IEnumerable<TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDurationValid");
            scope.Start();
            try
            {
                return await RestClient.PutDurationValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Set array value  ['P123DT22H14M12.011S', 'P5DT1H0M0S']. </summary>
        /// <param name="arrayBody"> The ArrayOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDurationValid(IEnumerable<TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDurationValid");
            scope.Start();
            try
            {
                return RestClient.PutDurationValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get byte array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<byte[]>>> GetByteValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetByteValid");
            scope.Start();
            try
            {
                return await RestClient.GetByteValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get byte array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<byte[]>> GetByteValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetByteValid");
            scope.Start();
            try
            {
                return RestClient.GetByteValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put the array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The ArrayOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutByteValidAsync(IEnumerable<byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutByteValid");
            scope.Start();
            try
            {
                return await RestClient.PutByteValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put the array value [hex(FF FF FF FA), hex(01 02 03), hex (25, 29, 43)] with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The ArrayOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutByteValid(IEnumerable<byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutByteValid");
            scope.Start();
            try
            {
                return RestClient.PutByteValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get byte array value [hex(AB, AC, AD), null] with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<byte[]>>> GetByteInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetByteInvalidNull");
            scope.Start();
            try
            {
                return await RestClient.GetByteInvalidNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get byte array value [hex(AB, AC, AD), null] with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<byte[]>> GetByteInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetByteInvalidNull");
            scope.Start();
            try
            {
                return RestClient.GetByteInvalidNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get array value ['a string that gets encoded with base64url', 'test string' 'Lorem ipsum'] with the items base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<byte[]>>> GetBase64UrlAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetBase64Url");
            scope.Start();
            try
            {
                return await RestClient.GetBase64UrlAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get array value ['a string that gets encoded with base64url', 'test string' 'Lorem ipsum'] with the items base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<byte[]>> GetBase64Url(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetBase64Url");
            scope.Start();
            try
            {
                return RestClient.GetBase64Url(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get array of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<Product>>> GetComplexNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetComplexNull");
            scope.Start();
            try
            {
                return await RestClient.GetComplexNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get array of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Product>> GetComplexNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetComplexNull");
            scope.Start();
            try
            {
                return RestClient.GetComplexNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get empty array of complex type []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<Product>>> GetComplexEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetComplexEmpty");
            scope.Start();
            try
            {
                return await RestClient.GetComplexEmptyAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get empty array of complex type []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Product>> GetComplexEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetComplexEmpty");
            scope.Start();
            try
            {
                return RestClient.GetComplexEmpty(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get array of complex type with null item [{'integer': 1 'string': '2'}, null, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<Product>>> GetComplexItemNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetComplexItemNull");
            scope.Start();
            try
            {
                return await RestClient.GetComplexItemNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get array of complex type with null item [{'integer': 1 'string': '2'}, null, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Product>> GetComplexItemNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetComplexItemNull");
            scope.Start();
            try
            {
                return RestClient.GetComplexItemNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get array of complex type with empty item [{'integer': 1 'string': '2'}, {}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<Product>>> GetComplexItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetComplexItemEmpty");
            scope.Start();
            try
            {
                return await RestClient.GetComplexItemEmptyAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get array of complex type with empty item [{'integer': 1 'string': '2'}, {}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Product>> GetComplexItemEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetComplexItemEmpty");
            scope.Start();
            try
            {
                return RestClient.GetComplexItemEmpty(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get array of complex type with [{'integer': 1 'string': '2'}, {'integer': 3, 'string': '4'}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<Product>>> GetComplexValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetComplexValid");
            scope.Start();
            try
            {
                return await RestClient.GetComplexValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get array of complex type with [{'integer': 1 'string': '2'}, {'integer': 3, 'string': '4'}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Product>> GetComplexValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetComplexValid");
            scope.Start();
            try
            {
                return RestClient.GetComplexValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put an array of complex type with values [{'integer': 1 'string': '2'}, {'integer': 3, 'string': '4'}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="arrayBody"> The ArrayOfProduct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutComplexValidAsync(IEnumerable<Product> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutComplexValid");
            scope.Start();
            try
            {
                return await RestClient.PutComplexValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put an array of complex type with values [{'integer': 1 'string': '2'}, {'integer': 3, 'string': '4'}, {'integer': 5, 'string': '6'}]. </summary>
        /// <param name="arrayBody"> The ArrayOfProduct to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutComplexValid(IEnumerable<Product> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutComplexValid");
            scope.Start();
            try
            {
                return RestClient.PutComplexValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<IList<string>>>> GetArrayNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetArrayNull");
            scope.Start();
            try
            {
                return await RestClient.GetArrayNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a null array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<IList<string>>> GetArrayNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetArrayNull");
            scope.Start();
            try
            {
                return RestClient.GetArrayNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an empty array []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<IList<string>>>> GetArrayEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetArrayEmpty");
            scope.Start();
            try
            {
                return await RestClient.GetArrayEmptyAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an empty array []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<IList<string>>> GetArrayEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetArrayEmpty");
            scope.Start();
            try
            {
                return RestClient.GetArrayEmpty(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], null, ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<IList<string>>>> GetArrayItemNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetArrayItemNull");
            scope.Start();
            try
            {
                return await RestClient.GetArrayItemNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], null, ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<IList<string>>> GetArrayItemNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetArrayItemNull");
            scope.Start();
            try
            {
                return RestClient.GetArrayItemNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], [], ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<IList<string>>>> GetArrayItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetArrayItemEmpty");
            scope.Start();
            try
            {
                return await RestClient.GetArrayItemEmptyAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], [], ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<IList<string>>> GetArrayItemEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetArrayItemEmpty");
            scope.Start();
            try
            {
                return RestClient.GetArrayItemEmpty(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], ['4', '5', '6'], ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<IList<string>>>> GetArrayValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetArrayValid");
            scope.Start();
            try
            {
                return await RestClient.GetArrayValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of array of strings [['1', '2', '3'], ['4', '5', '6'], ['7', '8', '9']]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<IList<string>>> GetArrayValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetArrayValid");
            scope.Start();
            try
            {
                return RestClient.GetArrayValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put An array of array of strings [['1', '2', '3'], ['4', '5', '6'], ['7', '8', '9']]. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutArrayValidAsync(IEnumerable<IList<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutArrayValid");
            scope.Start();
            try
            {
                return await RestClient.PutArrayValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put An array of array of strings [['1', '2', '3'], ['4', '5', '6'], ['7', '8', '9']]. </summary>
        /// <param name="arrayBody"> The ArrayOfPutContentSchemaItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutArrayValid(IEnumerable<IList<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutArrayValid");
            scope.Start();
            try
            {
                return RestClient.PutArrayValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<IDictionary<string, string>>>> GetDictionaryNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDictionaryNull");
            scope.Start();
            try
            {
                return await RestClient.GetDictionaryNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<IDictionary<string, string>>> GetDictionaryNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDictionaryNull");
            scope.Start();
            try
            {
                return RestClient.GetDictionaryNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<IDictionary<string, string>>>> GetDictionaryEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDictionaryEmpty");
            scope.Start();
            try
            {
                return await RestClient.GetDictionaryEmptyAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value []. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<IDictionary<string, string>>> GetDictionaryEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDictionaryEmpty");
            scope.Start();
            try
            {
                return RestClient.GetDictionaryEmpty(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, null, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<IDictionary<string, string>>>> GetDictionaryItemNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDictionaryItemNull");
            scope.Start();
            try
            {
                return await RestClient.GetDictionaryItemNullAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, null, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<IDictionary<string, string>>> GetDictionaryItemNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDictionaryItemNull");
            scope.Start();
            try
            {
                return RestClient.GetDictionaryItemNull(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<IDictionary<string, string>>>> GetDictionaryItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDictionaryItemEmpty");
            scope.Start();
            try
            {
                return await RestClient.GetDictionaryItemEmptyAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<IDictionary<string, string>>> GetDictionaryItemEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDictionaryItemEmpty");
            scope.Start();
            try
            {
                return RestClient.GetDictionaryItemEmpty(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {'4': 'four', '5': 'five', '6': 'six'}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<IDictionary<string, string>>>> GetDictionaryValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDictionaryValid");
            scope.Start();
            try
            {
                return await RestClient.GetDictionaryValidAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {'4': 'four', '5': 'five', '6': 'six'}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<IDictionary<string, string>>> GetDictionaryValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.GetDictionaryValid");
            scope.Start();
            try
            {
                return RestClient.GetDictionaryValid(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {'4': 'four', '5': 'five', '6': 'six'}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="arrayBody"> The ArrayOfDictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDictionaryValidAsync(IEnumerable<IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDictionaryValid");
            scope.Start();
            try
            {
                return await RestClient.PutDictionaryValidAsync(arrayBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an array of Dictionaries of type &lt;string, string&gt; with value [{'1': 'one', '2': 'two', '3': 'three'}, {'4': 'four', '5': 'five', '6': 'six'}, {'7': 'seven', '8': 'eight', '9': 'nine'}]. </summary>
        /// <param name="arrayBody"> The ArrayOfDictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDictionaryValid(IEnumerable<IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ArrayClient.PutDictionaryValid");
            scope.Start();
            try
            {
                return RestClient.PutDictionaryValid(arrayBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
