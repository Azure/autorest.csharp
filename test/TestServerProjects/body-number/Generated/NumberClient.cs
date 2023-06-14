// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_number
{
    /// <summary> The Number service client. </summary>
    public partial class NumberClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal NumberRestClient RestClient { get; }

        /// <summary> Initializes a new instance of NumberClient for mocking. </summary>
        protected NumberClient()
        {
        }

        /// <summary> Initializes a new instance of NumberClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal NumberClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new NumberRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get null Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<float?>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetNull");
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

        /// <summary> Get null Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<float?> GetNull(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetNull");
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

        /// <summary> Get invalid float Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<float>> GetInvalidFloatAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetInvalidFloat");
            scope.Start();
            try
            {
                return await RestClient.GetInvalidFloatAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid float Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<float> GetInvalidFloat(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetInvalidFloat");
            scope.Start();
            try
            {
                return RestClient.GetInvalidFloat(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid double Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<double>> GetInvalidDoubleAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetInvalidDouble");
            scope.Start();
            try
            {
                return await RestClient.GetInvalidDoubleAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid double Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<double> GetInvalidDouble(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetInvalidDouble");
            scope.Start();
            try
            {
                return RestClient.GetInvalidDouble(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid decimal Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<decimal>> GetInvalidDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetInvalidDecimal");
            scope.Start();
            try
            {
                return await RestClient.GetInvalidDecimalAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get invalid decimal Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<decimal> GetInvalidDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetInvalidDecimal");
            scope.Start();
            try
            {
                return RestClient.GetInvalidDecimal(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big float value 3.402823e+20. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutBigFloatAsync(float numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigFloat");
            scope.Start();
            try
            {
                return await RestClient.PutBigFloatAsync(numberBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big float value 3.402823e+20. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutBigFloat(float numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigFloat");
            scope.Start();
            try
            {
                return RestClient.PutBigFloat(numberBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big float value 3.402823e+20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<float>> GetBigFloatAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigFloat");
            scope.Start();
            try
            {
                return await RestClient.GetBigFloatAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big float value 3.402823e+20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<float> GetBigFloat(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigFloat");
            scope.Start();
            try
            {
                return RestClient.GetBigFloat(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big double value 2.5976931e+101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutBigDoubleAsync(double numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDouble");
            scope.Start();
            try
            {
                return await RestClient.PutBigDoubleAsync(numberBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big double value 2.5976931e+101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutBigDouble(double numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDouble");
            scope.Start();
            try
            {
                return RestClient.PutBigDouble(numberBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big double value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<double>> GetBigDoubleAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDouble");
            scope.Start();
            try
            {
                return await RestClient.GetBigDoubleAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big double value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<double> GetBigDouble(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDouble");
            scope.Start();
            try
            {
                return RestClient.GetBigDouble(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutBigDoublePositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDoublePositiveDecimal");
            scope.Start();
            try
            {
                return await RestClient.PutBigDoublePositiveDecimalAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutBigDoublePositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDoublePositiveDecimal");
            scope.Start();
            try
            {
                return RestClient.PutBigDoublePositiveDecimal(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<double>> GetBigDoublePositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDoublePositiveDecimal");
            scope.Start();
            try
            {
                return await RestClient.GetBigDoublePositiveDecimalAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<double> GetBigDoublePositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDoublePositiveDecimal");
            scope.Start();
            try
            {
                return RestClient.GetBigDoublePositiveDecimal(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutBigDoubleNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDoubleNegativeDecimal");
            scope.Start();
            try
            {
                return await RestClient.PutBigDoubleNegativeDecimalAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutBigDoubleNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDoubleNegativeDecimal");
            scope.Start();
            try
            {
                return RestClient.PutBigDoubleNegativeDecimal(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<double>> GetBigDoubleNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDoubleNegativeDecimal");
            scope.Start();
            try
            {
                return await RestClient.GetBigDoubleNegativeDecimalAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<double> GetBigDoubleNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDoubleNegativeDecimal");
            scope.Start();
            try
            {
                return RestClient.GetBigDoubleNegativeDecimal(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big decimal value 2.5976931e+101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutBigDecimalAsync(decimal numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDecimal");
            scope.Start();
            try
            {
                return await RestClient.PutBigDecimalAsync(numberBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big decimal value 2.5976931e+101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutBigDecimal(decimal numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDecimal");
            scope.Start();
            try
            {
                return RestClient.PutBigDecimal(numberBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big decimal value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<decimal>> GetBigDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDecimal");
            scope.Start();
            try
            {
                return await RestClient.GetBigDecimalAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big decimal value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<decimal> GetBigDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDecimal");
            scope.Start();
            try
            {
                return RestClient.GetBigDecimal(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutBigDecimalPositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDecimalPositiveDecimal");
            scope.Start();
            try
            {
                return await RestClient.PutBigDecimalPositiveDecimalAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutBigDecimalPositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDecimalPositiveDecimal");
            scope.Start();
            try
            {
                return RestClient.PutBigDecimalPositiveDecimal(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<decimal>> GetBigDecimalPositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDecimalPositiveDecimal");
            scope.Start();
            try
            {
                return await RestClient.GetBigDecimalPositiveDecimalAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<decimal> GetBigDecimalPositiveDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDecimalPositiveDecimal");
            scope.Start();
            try
            {
                return RestClient.GetBigDecimalPositiveDecimal(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutBigDecimalNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDecimalNegativeDecimal");
            scope.Start();
            try
            {
                return await RestClient.PutBigDecimalNegativeDecimalAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutBigDecimalNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutBigDecimalNegativeDecimal");
            scope.Start();
            try
            {
                return RestClient.PutBigDecimalNegativeDecimal(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<decimal>> GetBigDecimalNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDecimalNegativeDecimal");
            scope.Start();
            try
            {
                return await RestClient.GetBigDecimalNegativeDecimalAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<decimal> GetBigDecimalNegativeDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetBigDecimalNegativeDecimal");
            scope.Start();
            try
            {
                return RestClient.GetBigDecimalNegativeDecimal(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put small float value 3.402823e-20. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutSmallFloatAsync(float numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutSmallFloat");
            scope.Start();
            try
            {
                return await RestClient.PutSmallFloatAsync(numberBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put small float value 3.402823e-20. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutSmallFloat(float numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutSmallFloat");
            scope.Start();
            try
            {
                return RestClient.PutSmallFloat(numberBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big double value 3.402823e-20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<double>> GetSmallFloatAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetSmallFloat");
            scope.Start();
            try
            {
                return await RestClient.GetSmallFloatAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big double value 3.402823e-20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<double> GetSmallFloat(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetSmallFloat");
            scope.Start();
            try
            {
                return RestClient.GetSmallFloat(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put small double value 2.5976931e-101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutSmallDoubleAsync(double numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutSmallDouble");
            scope.Start();
            try
            {
                return await RestClient.PutSmallDoubleAsync(numberBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put small double value 2.5976931e-101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutSmallDouble(double numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutSmallDouble");
            scope.Start();
            try
            {
                return RestClient.PutSmallDouble(numberBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big double value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<double>> GetSmallDoubleAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetSmallDouble");
            scope.Start();
            try
            {
                return await RestClient.GetSmallDoubleAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get big double value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<double> GetSmallDouble(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetSmallDouble");
            scope.Start();
            try
            {
                return RestClient.GetSmallDouble(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put small decimal value 2.5976931e-101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutSmallDecimalAsync(decimal numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutSmallDecimal");
            scope.Start();
            try
            {
                return await RestClient.PutSmallDecimalAsync(numberBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put small decimal value 2.5976931e-101. </summary>
        /// <param name="numberBody"> number body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutSmallDecimal(decimal numberBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.PutSmallDecimal");
            scope.Start();
            try
            {
                return RestClient.PutSmallDecimal(numberBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get small decimal value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<decimal>> GetSmallDecimalAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetSmallDecimal");
            scope.Start();
            try
            {
                return await RestClient.GetSmallDecimalAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get small decimal value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<decimal> GetSmallDecimal(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NumberClient.GetSmallDecimal");
            scope.Start();
            try
            {
                return RestClient.GetSmallDecimal(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
