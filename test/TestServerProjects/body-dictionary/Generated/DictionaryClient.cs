// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using body_dictionary.Models;

namespace body_dictionary
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

        /// <summary> Get null dictionary value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, int>>> GetNullAsync(CancellationToken cancellationToken = default)
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

        /// <summary> Get null dictionary value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, int>> GetNull(CancellationToken cancellationToken = default)
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

        /// <summary> Get empty dictionary value {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, int>>> GetEmptyAsync(CancellationToken cancellationToken = default)
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

        /// <summary> Get empty dictionary value {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, int>> GetEmpty(CancellationToken cancellationToken = default)
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

        /// <summary> Set dictionary value empty {}. </summary>
        /// <param name="arrayBody"> The DictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutEmptyAsync(IDictionary<string, string> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutEmpty");
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

        /// <summary> Set dictionary value empty {}. </summary>
        /// <param name="arrayBody"> The DictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutEmpty(IDictionary<string, string> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutEmpty");
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

        /// <summary> Get Dictionary with null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, string>>> GetNullValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetNullValue");
            scope.Start();
            try
            {
                return await RestClient.GetNullValueAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get Dictionary with null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, string>> GetNullValue(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetNullValue");
            scope.Start();
            try
            {
                return RestClient.GetNullValue(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get Dictionary with null key. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, string>>> GetNullKeyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetNullKey");
            scope.Start();
            try
            {
                return await RestClient.GetNullKeyAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get Dictionary with null key. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, string>> GetNullKey(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetNullKey");
            scope.Start();
            try
            {
                return RestClient.GetNullKey(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get Dictionary with key as empty string. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, string>>> GetEmptyStringKeyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetEmptyStringKey");
            scope.Start();
            try
            {
                return await RestClient.GetEmptyStringKeyAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get Dictionary with key as empty string. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, string>> GetEmptyStringKey(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetEmptyStringKey");
            scope.Start();
            try
            {
                return RestClient.GetEmptyStringKey(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid Dictionary value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, string>>> GetInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetInvalid");
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

        /// <summary> Get invalid Dictionary value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, string>> GetInvalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetInvalid");
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

        /// <summary> Get boolean dictionary value {"0": true, "1": false, "2": false, "3": true }. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, bool>>> GetBooleanTfftAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetBooleanTfft");
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

        /// <summary> Get boolean dictionary value {"0": true, "1": false, "2": false, "3": true }. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, bool>> GetBooleanTfft(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetBooleanTfft");
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

        /// <summary> Set dictionary value empty {"0": true, "1": false, "2": false, "3": true }. </summary>
        /// <param name="arrayBody"> The DictionaryOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutBooleanTfftAsync(IDictionary<string, bool> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutBooleanTfft");
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

        /// <summary> Set dictionary value empty {"0": true, "1": false, "2": false, "3": true }. </summary>
        /// <param name="arrayBody"> The DictionaryOfBoolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutBooleanTfft(IDictionary<string, bool> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutBooleanTfft");
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

        /// <summary> Get boolean dictionary value {"0": true, "1": null, "2": false }. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, bool>>> GetBooleanInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetBooleanInvalidNull");
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

        /// <summary> Get boolean dictionary value {"0": true, "1": null, "2": false }. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, bool>> GetBooleanInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetBooleanInvalidNull");
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

        /// <summary> Get boolean dictionary value '{"0": true, "1": "boolean", "2": false}'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, bool>>> GetBooleanInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetBooleanInvalidString");
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

        /// <summary> Get boolean dictionary value '{"0": true, "1": "boolean", "2": false}'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, bool>> GetBooleanInvalidString(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetBooleanInvalidString");
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

        /// <summary> Get integer dictionary value {"0": 1, "1": -1, "2": 3, "3": 300}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, int>>> GetIntegerValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetIntegerValid");
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

        /// <summary> Get integer dictionary value {"0": 1, "1": -1, "2": 3, "3": 300}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, int>> GetIntegerValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetIntegerValid");
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

        /// <summary> Set dictionary value empty {"0": 1, "1": -1, "2": 3, "3": 300}. </summary>
        /// <param name="arrayBody"> The DictionaryOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutIntegerValidAsync(IDictionary<string, int> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutIntegerValid");
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

        /// <summary> Set dictionary value empty {"0": 1, "1": -1, "2": 3, "3": 300}. </summary>
        /// <param name="arrayBody"> The DictionaryOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutIntegerValid(IDictionary<string, int> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutIntegerValid");
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

        /// <summary> Get integer dictionary value {"0": 1, "1": null, "2": 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, int>>> GetIntInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetIntInvalidNull");
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

        /// <summary> Get integer dictionary value {"0": 1, "1": null, "2": 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, int>> GetIntInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetIntInvalidNull");
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

        /// <summary> Get integer dictionary value {"0": 1, "1": "integer", "2": 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, int>>> GetIntInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetIntInvalidString");
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

        /// <summary> Get integer dictionary value {"0": 1, "1": "integer", "2": 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, int>> GetIntInvalidString(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetIntInvalidString");
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

        /// <summary> Get integer dictionary value {"0": 1, "1": -1, "2": 3, "3": 300}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, long>>> GetLongValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetLongValid");
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

        /// <summary> Get integer dictionary value {"0": 1, "1": -1, "2": 3, "3": 300}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, long>> GetLongValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetLongValid");
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

        /// <summary> Set dictionary value empty {"0": 1, "1": -1, "2": 3, "3": 300}. </summary>
        /// <param name="arrayBody"> The DictionaryOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutLongValidAsync(IDictionary<string, long> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutLongValid");
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

        /// <summary> Set dictionary value empty {"0": 1, "1": -1, "2": 3, "3": 300}. </summary>
        /// <param name="arrayBody"> The DictionaryOfInteger to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutLongValid(IDictionary<string, long> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutLongValid");
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

        /// <summary> Get long dictionary value {"0": 1, "1": null, "2": 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, long>>> GetLongInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetLongInvalidNull");
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

        /// <summary> Get long dictionary value {"0": 1, "1": null, "2": 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, long>> GetLongInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetLongInvalidNull");
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

        /// <summary> Get long dictionary value {"0": 1, "1": "integer", "2": 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, long>>> GetLongInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetLongInvalidString");
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

        /// <summary> Get long dictionary value {"0": 1, "1": "integer", "2": 0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, long>> GetLongInvalidString(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetLongInvalidString");
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

        /// <summary> Get float dictionary value {"0": 0, "1": -0.01, "2": 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, float>>> GetFloatValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetFloatValid");
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

        /// <summary> Get float dictionary value {"0": 0, "1": -0.01, "2": 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, float>> GetFloatValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetFloatValid");
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

        /// <summary> Set dictionary value {"0": 0, "1": -0.01, "2": 1.2e20}. </summary>
        /// <param name="arrayBody"> The DictionaryOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutFloatValidAsync(IDictionary<string, float> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutFloatValid");
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

        /// <summary> Set dictionary value {"0": 0, "1": -0.01, "2": 1.2e20}. </summary>
        /// <param name="arrayBody"> The DictionaryOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutFloatValid(IDictionary<string, float> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutFloatValid");
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

        /// <summary> Get float dictionary value {"0": 0.0, "1": null, "2": 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, float>>> GetFloatInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetFloatInvalidNull");
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

        /// <summary> Get float dictionary value {"0": 0.0, "1": null, "2": 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, float>> GetFloatInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetFloatInvalidNull");
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

        /// <summary> Get boolean dictionary value {"0": 1.0, "1": "number", "2": 0.0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, float>>> GetFloatInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetFloatInvalidString");
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

        /// <summary> Get boolean dictionary value {"0": 1.0, "1": "number", "2": 0.0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, float>> GetFloatInvalidString(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetFloatInvalidString");
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

        /// <summary> Get float dictionary value {"0": 0, "1": -0.01, "2": 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, double>>> GetDoubleValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDoubleValid");
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

        /// <summary> Get float dictionary value {"0": 0, "1": -0.01, "2": 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, double>> GetDoubleValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDoubleValid");
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

        /// <summary> Set dictionary value {"0": 0, "1": -0.01, "2": 1.2e20}. </summary>
        /// <param name="arrayBody"> The DictionaryOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDoubleValidAsync(IDictionary<string, double> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDoubleValid");
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

        /// <summary> Set dictionary value {"0": 0, "1": -0.01, "2": 1.2e20}. </summary>
        /// <param name="arrayBody"> The DictionaryOfNumber to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDoubleValid(IDictionary<string, double> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDoubleValid");
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

        /// <summary> Get float dictionary value {"0": 0.0, "1": null, "2": 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, double>>> GetDoubleInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDoubleInvalidNull");
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

        /// <summary> Get float dictionary value {"0": 0.0, "1": null, "2": 1.2e20}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, double>> GetDoubleInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDoubleInvalidNull");
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

        /// <summary> Get boolean dictionary value {"0": 1.0, "1": "number", "2": 0.0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, double>>> GetDoubleInvalidStringAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDoubleInvalidString");
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

        /// <summary> Get boolean dictionary value {"0": 1.0, "1": "number", "2": 0.0}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, double>> GetDoubleInvalidString(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDoubleInvalidString");
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

        /// <summary> Get string dictionary value {"0": "foo1", "1": "foo2", "2": "foo3"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, string>>> GetStringValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetStringValid");
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

        /// <summary> Get string dictionary value {"0": "foo1", "1": "foo2", "2": "foo3"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, string>> GetStringValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetStringValid");
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

        /// <summary> Set dictionary value {"0": "foo1", "1": "foo2", "2": "foo3"}. </summary>
        /// <param name="arrayBody"> The DictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutStringValidAsync(IDictionary<string, string> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutStringValid");
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

        /// <summary> Set dictionary value {"0": "foo1", "1": "foo2", "2": "foo3"}. </summary>
        /// <param name="arrayBody"> The DictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutStringValid(IDictionary<string, string> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutStringValid");
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

        /// <summary> Get string dictionary value {"0": "foo", "1": null, "2": "foo2"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, string>>> GetStringWithNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetStringWithNull");
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

        /// <summary> Get string dictionary value {"0": "foo", "1": null, "2": "foo2"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, string>> GetStringWithNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetStringWithNull");
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

        /// <summary> Get string dictionary value {"0": "foo", "1": 123, "2": "foo2"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, string>>> GetStringWithInvalidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetStringWithInvalid");
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

        /// <summary> Get string dictionary value {"0": "foo", "1": 123, "2": "foo2"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, string>> GetStringWithInvalid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetStringWithInvalid");
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

        /// <summary> Get integer dictionary value {"0": "2000-12-01", "1": "1980-01-02", "2": "1492-10-12"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, DateTimeOffset>>> GetDateValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateValid");
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

        /// <summary> Get integer dictionary value {"0": "2000-12-01", "1": "1980-01-02", "2": "1492-10-12"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, DateTimeOffset>> GetDateValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateValid");
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

        /// <summary> Set dictionary value  {"0": "2000-12-01", "1": "1980-01-02", "2": "1492-10-12"}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDateValidAsync(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDateValid");
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

        /// <summary> Set dictionary value  {"0": "2000-12-01", "1": "1980-01-02", "2": "1492-10-12"}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDate to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDateValid(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDateValid");
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

        /// <summary> Get date dictionary value {"0": "2012-01-01", "1": null, "2": "1776-07-04"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, DateTimeOffset>>> GetDateInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateInvalidNull");
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

        /// <summary> Get date dictionary value {"0": "2012-01-01", "1": null, "2": "1776-07-04"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, DateTimeOffset>> GetDateInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateInvalidNull");
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

        /// <summary> Get date dictionary value {"0": "2011-03-22", "1": "date"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, DateTimeOffset>>> GetDateInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateInvalidChars");
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

        /// <summary> Get date dictionary value {"0": "2011-03-22", "1": "date"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, DateTimeOffset>> GetDateInvalidChars(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateInvalidChars");
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

        /// <summary> Get date-time dictionary value {"0": "2000-12-01t00:00:01z", "1": "1980-01-02T00:11:35+01:00", "2": "1492-10-12T10:15:01-08:00"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, DateTimeOffset>>> GetDateTimeValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateTimeValid");
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

        /// <summary> Get date-time dictionary value {"0": "2000-12-01t00:00:01z", "1": "1980-01-02T00:11:35+01:00", "2": "1492-10-12T10:15:01-08:00"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, DateTimeOffset>> GetDateTimeValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateTimeValid");
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

        /// <summary> Set dictionary value  {"0": "2000-12-01t00:00:01z", "1": "1980-01-02T00:11:35+01:00", "2": "1492-10-12T10:15:01-08:00"}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDateTimeValidAsync(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDateTimeValid");
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

        /// <summary> Set dictionary value  {"0": "2000-12-01t00:00:01z", "1": "1980-01-02T00:11:35+01:00", "2": "1492-10-12T10:15:01-08:00"}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDateTimeValid(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDateTimeValid");
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

        /// <summary> Get date dictionary value {"0": "2000-12-01t00:00:01z", "1": null}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, DateTimeOffset>>> GetDateTimeInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateTimeInvalidNull");
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

        /// <summary> Get date dictionary value {"0": "2000-12-01t00:00:01z", "1": null}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, DateTimeOffset>> GetDateTimeInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateTimeInvalidNull");
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

        /// <summary> Get date dictionary value {"0": "2000-12-01t00:00:01z", "1": "date-time"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, DateTimeOffset>>> GetDateTimeInvalidCharsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateTimeInvalidChars");
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

        /// <summary> Get date dictionary value {"0": "2000-12-01t00:00:01z", "1": "date-time"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, DateTimeOffset>> GetDateTimeInvalidChars(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateTimeInvalidChars");
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

        /// <summary> Get date-time-rfc1123 dictionary value {"0": "Fri, 01 Dec 2000 00:00:01 GMT", "1": "Wed, 02 Jan 1980 00:11:35 GMT", "2": "Wed, 12 Oct 1492 10:15:01 GMT"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, DateTimeOffset>>> GetDateTimeRfc1123ValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateTimeRfc1123Valid");
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

        /// <summary> Get date-time-rfc1123 dictionary value {"0": "Fri, 01 Dec 2000 00:00:01 GMT", "1": "Wed, 02 Jan 1980 00:11:35 GMT", "2": "Wed, 12 Oct 1492 10:15:01 GMT"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, DateTimeOffset>> GetDateTimeRfc1123Valid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDateTimeRfc1123Valid");
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

        /// <summary> Set dictionary value empty {"0": "Fri, 01 Dec 2000 00:00:01 GMT", "1": "Wed, 02 Jan 1980 00:11:35 GMT", "2": "Wed, 12 Oct 1492 10:15:01 GMT"}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDateTimeRfc1123ValidAsync(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDateTimeRfc1123Valid");
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

        /// <summary> Set dictionary value empty {"0": "Fri, 01 Dec 2000 00:00:01 GMT", "1": "Wed, 02 Jan 1980 00:11:35 GMT", "2": "Wed, 12 Oct 1492 10:15:01 GMT"}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDateTime to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDateTimeRfc1123Valid(IDictionary<string, DateTimeOffset> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDateTimeRfc1123Valid");
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

        /// <summary> Get duration dictionary value {"0": "P123DT22H14M12.011S", "1": "P5DT1H0M0S"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, TimeSpan>>> GetDurationValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDurationValid");
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

        /// <summary> Get duration dictionary value {"0": "P123DT22H14M12.011S", "1": "P5DT1H0M0S"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, TimeSpan>> GetDurationValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDurationValid");
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

        /// <summary> Set dictionary value  {"0": "P123DT22H14M12.011S", "1": "P5DT1H0M0S"}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDurationValidAsync(IDictionary<string, TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDurationValid");
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

        /// <summary> Set dictionary value  {"0": "P123DT22H14M12.011S", "1": "P5DT1H0M0S"}. </summary>
        /// <param name="arrayBody"> The DictionaryOfDuration to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDurationValid(IDictionary<string, TimeSpan> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDurationValid");
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

        /// <summary> Get byte dictionary value {"0": hex(FF FF FF FA), "1": hex(01 02 03), "2": hex (25, 29, 43)} with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, byte[]>>> GetByteValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetByteValid");
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

        /// <summary> Get byte dictionary value {"0": hex(FF FF FF FA), "1": hex(01 02 03), "2": hex (25, 29, 43)} with each item encoded in base64. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, byte[]>> GetByteValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetByteValid");
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

        /// <summary> Put the dictionary value {"0": hex(FF FF FF FA), "1": hex(01 02 03), "2": hex (25, 29, 43)} with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The DictionaryOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutByteValidAsync(IDictionary<string, byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutByteValid");
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

        /// <summary> Put the dictionary value {"0": hex(FF FF FF FA), "1": hex(01 02 03), "2": hex (25, 29, 43)} with each elementencoded in base 64. </summary>
        /// <param name="arrayBody"> The DictionaryOfByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutByteValid(IDictionary<string, byte[]> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutByteValid");
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

        /// <summary> Get byte dictionary value {"0": hex(FF FF FF FA), "1": null} with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, byte[]>>> GetByteInvalidNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetByteInvalidNull");
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

        /// <summary> Get byte dictionary value {"0": hex(FF FF FF FA), "1": null} with the first item base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, byte[]>> GetByteInvalidNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetByteInvalidNull");
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

        /// <summary> Get base64url dictionary value {"0": "a string that gets encoded with base64url", "1": "test string", "2": "Lorem ipsum"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, byte[]>>> GetBase64UrlAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetBase64Url");
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

        /// <summary> Get base64url dictionary value {"0": "a string that gets encoded with base64url", "1": "test string", "2": "Lorem ipsum"}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, byte[]>> GetBase64Url(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetBase64Url");
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

        /// <summary> Get dictionary of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, Widget>>> GetComplexNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetComplexNull");
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

        /// <summary> Get dictionary of complex type null value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, Widget>> GetComplexNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetComplexNull");
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

        /// <summary> Get empty dictionary of complex type {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, Widget>>> GetComplexEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetComplexEmpty");
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

        /// <summary> Get empty dictionary of complex type {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, Widget>> GetComplexEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetComplexEmpty");
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

        /// <summary> Get dictionary of complex type with null item {"0": {"integer": 1, "string": "2"}, "1": null, "2": {"integer": 5, "string": "6"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, Widget>>> GetComplexItemNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetComplexItemNull");
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

        /// <summary> Get dictionary of complex type with null item {"0": {"integer": 1, "string": "2"}, "1": null, "2": {"integer": 5, "string": "6"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, Widget>> GetComplexItemNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetComplexItemNull");
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

        /// <summary> Get dictionary of complex type with empty item {"0": {"integer": 1, "string": "2"}, "1:" {}, "2": {"integer": 5, "string": "6"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, Widget>>> GetComplexItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetComplexItemEmpty");
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

        /// <summary> Get dictionary of complex type with empty item {"0": {"integer": 1, "string": "2"}, "1:" {}, "2": {"integer": 5, "string": "6"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, Widget>> GetComplexItemEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetComplexItemEmpty");
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

        /// <summary> Get dictionary of complex type with {"0": {"integer": 1, "string": "2"}, "1": {"integer": 3, "string": "4"}, "2": {"integer": 5, "string": "6"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, Widget>>> GetComplexValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetComplexValid");
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

        /// <summary> Get dictionary of complex type with {"0": {"integer": 1, "string": "2"}, "1": {"integer": 3, "string": "4"}, "2": {"integer": 5, "string": "6"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, Widget>> GetComplexValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetComplexValid");
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

        /// <summary> Put an dictionary of complex type with values {"0": {"integer": 1, "string": "2"}, "1": {"integer": 3, "string": "4"}, "2": {"integer": 5, "string": "6"}}. </summary>
        /// <param name="arrayBody"> The DictionaryOfWidget to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutComplexValidAsync(IDictionary<string, Widget> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutComplexValid");
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

        /// <summary> Put an dictionary of complex type with values {"0": {"integer": 1, "string": "2"}, "1": {"integer": 3, "string": "4"}, "2": {"integer": 5, "string": "6"}}. </summary>
        /// <param name="arrayBody"> The DictionaryOfWidget to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutComplexValid(IDictionary<string, Widget> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutComplexValid");
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
        public virtual async Task<Response<IReadOnlyDictionary<string, IList<string>>>> GetArrayNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetArrayNull");
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
        public virtual Response<IReadOnlyDictionary<string, IList<string>>> GetArrayNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetArrayNull");
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

        /// <summary> Get an empty dictionary {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, IList<string>>>> GetArrayEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetArrayEmpty");
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

        /// <summary> Get an empty dictionary {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, IList<string>>> GetArrayEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetArrayEmpty");
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

        /// <summary> Get an dictionary of array of strings {"0": ["1", "2", "3"], "1": null, "2": ["7", "8", "9"]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, IList<string>>>> GetArrayItemNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetArrayItemNull");
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

        /// <summary> Get an dictionary of array of strings {"0": ["1", "2", "3"], "1": null, "2": ["7", "8", "9"]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, IList<string>>> GetArrayItemNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetArrayItemNull");
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

        /// <summary> Get an array of array of strings [{"0": ["1", "2", "3"], "1": [], "2": ["7", "8", "9"]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, IList<string>>>> GetArrayItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetArrayItemEmpty");
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

        /// <summary> Get an array of array of strings [{"0": ["1", "2", "3"], "1": [], "2": ["7", "8", "9"]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, IList<string>>> GetArrayItemEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetArrayItemEmpty");
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

        /// <summary> Get an array of array of strings {"0": ["1", "2", "3"], "1": ["4", "5", "6"], "2": ["7", "8", "9"]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, IList<string>>>> GetArrayValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetArrayValid");
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

        /// <summary> Get an array of array of strings {"0": ["1", "2", "3"], "1": ["4", "5", "6"], "2": ["7", "8", "9"]}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, IList<string>>> GetArrayValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetArrayValid");
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

        /// <summary> Put An array of array of strings {"0": ["1", "2", "3"], "1": ["4", "5", "6"], "2": ["7", "8", "9"]}. </summary>
        /// <param name="arrayBody"> The DictionaryOfpaths1Dxz488DictionaryArrayValidPutRequestbodyContentApplicationJsonSchemaAdditionalproperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutArrayValidAsync(IDictionary<string, IList<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutArrayValid");
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

        /// <summary> Put An array of array of strings {"0": ["1", "2", "3"], "1": ["4", "5", "6"], "2": ["7", "8", "9"]}. </summary>
        /// <param name="arrayBody"> The DictionaryOfpaths1Dxz488DictionaryArrayValidPutRequestbodyContentApplicationJsonSchemaAdditionalproperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutArrayValid(IDictionary<string, IList<string>> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutArrayValid");
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

        /// <summary> Get an dictionaries of dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, IDictionary<string, string>>>> GetDictionaryNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDictionaryNull");
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

        /// <summary> Get an dictionaries of dictionaries with value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, IDictionary<string, string>>> GetDictionaryNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDictionaryNull");
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

        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, IDictionary<string, string>>>> GetDictionaryEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDictionaryEmpty");
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

        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, IDictionary<string, string>>> GetDictionaryEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDictionaryEmpty");
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

        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {"0": {"1": "one", "2": "two", "3": "three"}, "1": null, "2": {"7": "seven", "8": "eight", "9": "nine"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, IDictionary<string, string>>>> GetDictionaryItemNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDictionaryItemNull");
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

        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {"0": {"1": "one", "2": "two", "3": "three"}, "1": null, "2": {"7": "seven", "8": "eight", "9": "nine"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, IDictionary<string, string>>> GetDictionaryItemNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDictionaryItemNull");
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

        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {"0": {"1": "one", "2": "two", "3": "three"}, "1": {}, "2": {"7": "seven", "8": "eight", "9": "nine"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, IDictionary<string, string>>>> GetDictionaryItemEmptyAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDictionaryItemEmpty");
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

        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {"0": {"1": "one", "2": "two", "3": "three"}, "1": {}, "2": {"7": "seven", "8": "eight", "9": "nine"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, IDictionary<string, string>>> GetDictionaryItemEmpty(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDictionaryItemEmpty");
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

        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {"0": {"1": "one", "2": "two", "3": "three"}, "1": {"4": "four", "5": "five", "6": "six"}, "2": {"7": "seven", "8": "eight", "9": "nine"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, IDictionary<string, string>>>> GetDictionaryValidAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDictionaryValid");
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

        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {"0": {"1": "one", "2": "two", "3": "three"}, "1": {"4": "four", "5": "five", "6": "six"}, "2": {"7": "seven", "8": "eight", "9": "nine"}}. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, IDictionary<string, string>>> GetDictionaryValid(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.GetDictionaryValid");
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

        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {"0": {"1": "one", "2": "two", "3": "three"}, "1": {"4": "four", "5": "five", "6": "six"}, "2": {"7": "seven", "8": "eight", "9": "nine"}}. </summary>
        /// <param name="arrayBody"> The DictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDictionaryValidAsync(IDictionary<string, IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDictionaryValid");
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

        /// <summary> Get an dictionaries of dictionaries of type &lt;string, string&gt; with value {"0": {"1": "one", "2": "two", "3": "three"}, "1": {"4": "four", "5": "five", "6": "six"}, "2": {"7": "seven", "8": "eight", "9": "nine"}}. </summary>
        /// <param name="arrayBody"> The DictionaryOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDictionaryValid(IDictionary<string, IDictionary<string, string>> arrayBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DictionaryClient.PutDictionaryValid");
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
