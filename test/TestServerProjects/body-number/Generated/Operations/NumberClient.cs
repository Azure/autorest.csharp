// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_number
{
    public partial class NumberClient
    {
        private NumberRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of NumberClient. </summary>
        internal NumberClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new NumberRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get null Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<float>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<float> GetNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetNull(cancellationToken);
        }
        /// <summary> Get invalid float Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<float>> GetInvalidFloatAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetInvalidFloatAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid float Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<float> GetInvalidFloat(CancellationToken cancellationToken = default)
        {
            return restClient.GetInvalidFloat(cancellationToken);
        }
        /// <summary> Get invalid double Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetInvalidDoubleAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetInvalidDoubleAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid double Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetInvalidDouble(CancellationToken cancellationToken = default)
        {
            return restClient.GetInvalidDouble(cancellationToken);
        }
        /// <summary> Get invalid decimal Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetInvalidDecimalAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetInvalidDecimalAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get invalid decimal Number value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetInvalidDecimal(CancellationToken cancellationToken = default)
        {
            return restClient.GetInvalidDecimal(cancellationToken);
        }
        /// <summary> Put big float value 3.402823e+20. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigFloatAsync(float numberBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutBigFloatAsync(numberBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put big float value 3.402823e+20. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigFloat(float numberBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutBigFloat(numberBody, cancellationToken);
        }
        /// <summary> Get big float value 3.402823e+20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<float>> GetBigFloatAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBigFloatAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get big float value 3.402823e+20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<float> GetBigFloat(CancellationToken cancellationToken = default)
        {
            return restClient.GetBigFloat(cancellationToken);
        }
        /// <summary> Put big double value 2.5976931e+101. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDoubleAsync(double numberBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutBigDoubleAsync(numberBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put big double value 2.5976931e+101. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDouble(double numberBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutBigDouble(numberBody, cancellationToken);
        }
        /// <summary> Get big double value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetBigDoubleAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBigDoubleAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get big double value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetBigDouble(CancellationToken cancellationToken = default)
        {
            return restClient.GetBigDouble(cancellationToken);
        }
        /// <summary> Put big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDoublePositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.PutBigDoublePositiveDecimalAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDoublePositiveDecimal(CancellationToken cancellationToken = default)
        {
            return restClient.PutBigDoublePositiveDecimal(cancellationToken);
        }
        /// <summary> Get big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetBigDoublePositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBigDoublePositiveDecimalAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get big double value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetBigDoublePositiveDecimal(CancellationToken cancellationToken = default)
        {
            return restClient.GetBigDoublePositiveDecimal(cancellationToken);
        }
        /// <summary> Put big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDoubleNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.PutBigDoubleNegativeDecimalAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDoubleNegativeDecimal(CancellationToken cancellationToken = default)
        {
            return restClient.PutBigDoubleNegativeDecimal(cancellationToken);
        }
        /// <summary> Get big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetBigDoubleNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBigDoubleNegativeDecimalAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get big double value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetBigDoubleNegativeDecimal(CancellationToken cancellationToken = default)
        {
            return restClient.GetBigDoubleNegativeDecimal(cancellationToken);
        }
        /// <summary> Put big decimal value 2.5976931e+101. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDecimalAsync(decimal numberBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutBigDecimalAsync(numberBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put big decimal value 2.5976931e+101. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDecimal(decimal numberBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutBigDecimal(numberBody, cancellationToken);
        }
        /// <summary> Get big decimal value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetBigDecimalAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBigDecimalAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get big decimal value 2.5976931e+101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetBigDecimal(CancellationToken cancellationToken = default)
        {
            return restClient.GetBigDecimal(cancellationToken);
        }
        /// <summary> Put big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDecimalPositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.PutBigDecimalPositiveDecimalAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDecimalPositiveDecimal(CancellationToken cancellationToken = default)
        {
            return restClient.PutBigDecimalPositiveDecimal(cancellationToken);
        }
        /// <summary> Get big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetBigDecimalPositiveDecimalAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBigDecimalPositiveDecimalAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get big decimal value 99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetBigDecimalPositiveDecimal(CancellationToken cancellationToken = default)
        {
            return restClient.GetBigDecimalPositiveDecimal(cancellationToken);
        }
        /// <summary> Put big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBigDecimalNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.PutBigDecimalNegativeDecimalAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBigDecimalNegativeDecimal(CancellationToken cancellationToken = default)
        {
            return restClient.PutBigDecimalNegativeDecimal(cancellationToken);
        }
        /// <summary> Get big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetBigDecimalNegativeDecimalAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBigDecimalNegativeDecimalAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get big decimal value -99999999.99. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetBigDecimalNegativeDecimal(CancellationToken cancellationToken = default)
        {
            return restClient.GetBigDecimalNegativeDecimal(cancellationToken);
        }
        /// <summary> Put small float value 3.402823e-20. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutSmallFloatAsync(float numberBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutSmallFloatAsync(numberBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put small float value 3.402823e-20. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSmallFloat(float numberBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutSmallFloat(numberBody, cancellationToken);
        }
        /// <summary> Get big double value 3.402823e-20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetSmallFloatAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetSmallFloatAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get big double value 3.402823e-20. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetSmallFloat(CancellationToken cancellationToken = default)
        {
            return restClient.GetSmallFloat(cancellationToken);
        }
        /// <summary> Put small double value 2.5976931e-101. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutSmallDoubleAsync(double numberBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutSmallDoubleAsync(numberBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put small double value 2.5976931e-101. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSmallDouble(double numberBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutSmallDouble(numberBody, cancellationToken);
        }
        /// <summary> Get big double value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<double>> GetSmallDoubleAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetSmallDoubleAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get big double value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<double> GetSmallDouble(CancellationToken cancellationToken = default)
        {
            return restClient.GetSmallDouble(cancellationToken);
        }
        /// <summary> Put small decimal value 2.5976931e-101. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutSmallDecimalAsync(decimal numberBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutSmallDecimalAsync(numberBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put small decimal value 2.5976931e-101. </summary>
        /// <param name="numberBody"> The Number to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSmallDecimal(decimal numberBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutSmallDecimal(numberBody, cancellationToken);
        }
        /// <summary> Get small decimal value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<decimal>> GetSmallDecimalAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetSmallDecimalAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get small decimal value 2.5976931e-101. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<decimal> GetSmallDecimal(CancellationToken cancellationToken = default)
        {
            return restClient.GetSmallDecimal(cancellationToken);
        }
    }
}
