// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace body_string
{
    public partial class StringClient
    {
        private StringRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of StringClient. </summary>
        internal StringClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new StringRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get null string value value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<string>> GetNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null string value value. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<string> GetNull(CancellationToken cancellationToken = default)
        {
            return restClient.GetNull(cancellationToken);
        }
        /// <summary> Set string value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutNullAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.PutNullAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set string value null. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutNull(CancellationToken cancellationToken = default)
        {
            return restClient.PutNull(cancellationToken);
        }
        /// <summary> Get empty string value value &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<string>> GetEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get empty string value value &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<string> GetEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.GetEmpty(cancellationToken);
        }
        /// <summary> Set string value empty &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.PutEmptyAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set string value empty &apos;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmpty(CancellationToken cancellationToken = default)
        {
            return restClient.PutEmpty(cancellationToken);
        }
        /// <summary> Get mbcs string value &apos;啊齄丂狛狜隣郎隣兀﨩ˊ〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<string>> GetMbcsAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetMbcsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get mbcs string value &apos;啊齄丂狛狜隣郎隣兀﨩ˊ〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<string> GetMbcs(CancellationToken cancellationToken = default)
        {
            return restClient.GetMbcs(cancellationToken);
        }
        /// <summary> Set string value mbcs &apos;啊齄丂狛狜隣郎隣兀﨩ˊ〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutMbcsAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.PutMbcsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set string value mbcs &apos;啊齄丂狛狜隣郎隣兀﨩ˊ〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutMbcs(CancellationToken cancellationToken = default)
        {
            return restClient.PutMbcs(cancellationToken);
        }
        /// <summary> Get string value with leading and trailing whitespace &apos;&lt;tab&gt;&lt;space&gt;&lt;space&gt;Now is the time for all good men to come to the aid of their country&lt;tab&gt;&lt;space&gt;&lt;space&gt;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<string>> GetWhitespaceAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetWhitespaceAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get string value with leading and trailing whitespace &apos;&lt;tab&gt;&lt;space&gt;&lt;space&gt;Now is the time for all good men to come to the aid of their country&lt;tab&gt;&lt;space&gt;&lt;space&gt;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<string> GetWhitespace(CancellationToken cancellationToken = default)
        {
            return restClient.GetWhitespace(cancellationToken);
        }
        /// <summary> Set String value with leading and trailing whitespace &apos;&lt;tab&gt;&lt;space&gt;&lt;space&gt;Now is the time for all good men to come to the aid of their country&lt;tab&gt;&lt;space&gt;&lt;space&gt;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutWhitespaceAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.PutWhitespaceAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Set String value with leading and trailing whitespace &apos;&lt;tab&gt;&lt;space&gt;&lt;space&gt;Now is the time for all good men to come to the aid of their country&lt;tab&gt;&lt;space&gt;&lt;space&gt;&apos;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutWhitespace(CancellationToken cancellationToken = default)
        {
            return restClient.PutWhitespace(cancellationToken);
        }
        /// <summary> Get String value when no string value is sent in response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<string>> GetNotProvidedAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNotProvidedAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get String value when no string value is sent in response payload. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<string> GetNotProvided(CancellationToken cancellationToken = default)
        {
            return restClient.GetNotProvided(cancellationToken);
        }
        /// <summary> Get value that is base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<byte[]>> GetBase64EncodedAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBase64EncodedAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get value that is base64 encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetBase64Encoded(CancellationToken cancellationToken = default)
        {
            return restClient.GetBase64Encoded(cancellationToken);
        }
        /// <summary> Get value that is base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<byte[]>> GetBase64UrlEncodedAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetBase64UrlEncodedAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get value that is base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetBase64UrlEncoded(CancellationToken cancellationToken = default)
        {
            return restClient.GetBase64UrlEncoded(cancellationToken);
        }
        /// <summary> Put value that is base64url encoded. </summary>
        /// <param name="stringBody"> The ByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutBase64UrlEncodedAsync(byte[] stringBody, CancellationToken cancellationToken = default)
        {
            return await restClient.PutBase64UrlEncodedAsync(stringBody, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put value that is base64url encoded. </summary>
        /// <param name="stringBody"> The ByteArray to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutBase64UrlEncoded(byte[] stringBody, CancellationToken cancellationToken = default)
        {
            return restClient.PutBase64UrlEncoded(stringBody, cancellationToken);
        }
        /// <summary> Get null value that is expected to be base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<byte[]>> GetNullBase64UrlEncodedAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetNullBase64UrlEncodedAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get null value that is expected to be base64url encoded. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<byte[]> GetNullBase64UrlEncoded(CancellationToken cancellationToken = default)
        {
            return restClient.GetNullBase64UrlEncoded(cancellationToken);
        }
    }
}
