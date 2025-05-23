// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Scm.Payload.Multipart.Models;

namespace Scm.Payload.Multipart
{
    // Data plane generated sub-client.
    /// <summary> The FormDataHttpParts sub-client. </summary>
    public partial class FormDataHttpParts
    {
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of FormDataHttpParts for mocking. </summary>
        protected FormDataHttpParts()
        {
        }

        /// <summary> Initializes a new instance of FormDataHttpParts. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> Service host. </param>
        internal FormDataHttpParts(ClientPipeline pipeline, Uri endpoint)
        {
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> Test content-type: multipart/form-data for mixed scenarios. </summary>
        /// <param name="body"> The <see cref="ComplexHttpPartsModelRequest"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<ClientResult> JsonArrayAndFileArrayAsync(ComplexHttpPartsModelRequest body)
        {
            Argument.AssertNotNull(body, nameof(body));

            using MultipartFormDataBinaryContent content = body.ToMultipartBinaryBody();
            ClientResult result = await JsonArrayAndFileArrayAsync(content, content.ContentType, null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Test content-type: multipart/form-data for mixed scenarios. </summary>
        /// <param name="body"> The <see cref="ComplexHttpPartsModelRequest"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual ClientResult JsonArrayAndFileArray(ComplexHttpPartsModelRequest body)
        {
            Argument.AssertNotNull(body, nameof(body));

            using MultipartFormDataBinaryContent content = body.ToMultipartBinaryBody();
            ClientResult result = JsonArrayAndFileArray(content, content.ContentType, null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Test content-type: multipart/form-data for mixed scenarios
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="JsonArrayAndFileArrayAsync(ComplexHttpPartsModelRequest)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> The <see cref="string"/> to use. Allowed values: "multipart/form-data". </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> JsonArrayAndFileArrayAsync(BinaryContent content, string contentType, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateJsonArrayAndFileArrayRequest(content, contentType, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Test content-type: multipart/form-data for mixed scenarios
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="JsonArrayAndFileArray(ComplexHttpPartsModelRequest)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> The <see cref="string"/> to use. Allowed values: "multipart/form-data". </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult JsonArrayAndFileArray(BinaryContent content, string contentType, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateJsonArrayAndFileArrayRequest(content, contentType, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        private FormDataHttpPartsContentType _cachedFormDataHttpPartsContentType;
        private FormDataHttpPartsNonString _cachedFormDataHttpPartsNonString;

        /// <summary> Initializes a new instance of FormDataHttpPartsContentType. </summary>
        public virtual FormDataHttpPartsContentType GetFormDataHttpPartsContentTypeClient()
        {
            return Volatile.Read(ref _cachedFormDataHttpPartsContentType) ?? Interlocked.CompareExchange(ref _cachedFormDataHttpPartsContentType, new FormDataHttpPartsContentType(_pipeline, _endpoint), null) ?? _cachedFormDataHttpPartsContentType;
        }

        /// <summary> Initializes a new instance of FormDataHttpPartsNonString. </summary>
        public virtual FormDataHttpPartsNonString GetFormDataHttpPartsNonStringClient()
        {
            return Volatile.Read(ref _cachedFormDataHttpPartsNonString) ?? Interlocked.CompareExchange(ref _cachedFormDataHttpPartsNonString, new FormDataHttpPartsNonString(_pipeline, _endpoint), null) ?? _cachedFormDataHttpPartsNonString;
        }

        internal PipelineMessage CreateJsonArrayAndFileArrayRequest(BinaryContent content, string contentType, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/multipart/form-data/complex-parts-with-httppart", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Content-Type", contentType);
            request.Content = content;
            message.Apply(options);
            return message;
        }

        private static PipelineMessageClassifier _pipelineMessageClassifier204;
        private static PipelineMessageClassifier PipelineMessageClassifier204 => _pipelineMessageClassifier204 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });
    }
}
