// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Type.Enum.Extensible.Models;

namespace Type.Enum.Extensible
{
    // Data plane generated sub-client.
    /// <summary> The String sub-client. </summary>
    public partial class String
    {
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of String for mocking. </summary>
        protected String()
        {
        }

        /// <summary> Initializes a new instance of String. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        internal String(ClientPipeline pipeline, Uri endpoint)
        {
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> Get known value. </summary>
        public virtual async Task<ClientResult<DaysOfWeekExtensibleEnum>> GetKnownValueAsync()
        {
            ClientResult result = await GetKnownValueAsync(null).ConfigureAwait(false);
            return ClientResult.FromValue(new DaysOfWeekExtensibleEnum(result.GetRawResponse().Content.ToObjectFromJson<string>()), result.GetRawResponse());
        }

        /// <summary> Get known value. </summary>
        public virtual ClientResult<DaysOfWeekExtensibleEnum> GetKnownValue()
        {
            ClientResult result = GetKnownValue(null);
            return ClientResult.FromValue(new DaysOfWeekExtensibleEnum(result.GetRawResponse().Content.ToObjectFromJson<string>()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Get known value.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetKnownValueAsync()"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> GetKnownValueAsync(RequestOptions options)
        {
            using PipelineMessage message = CreateGetKnownValueRequest(options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Get known value.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetKnownValue()"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult GetKnownValue(RequestOptions options)
        {
            using PipelineMessage message = CreateGetKnownValueRequest(options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Get unknown value. </summary>
        public virtual async Task<ClientResult<DaysOfWeekExtensibleEnum>> GetUnknownValueAsync()
        {
            ClientResult result = await GetUnknownValueAsync(null).ConfigureAwait(false);
            return ClientResult.FromValue(new DaysOfWeekExtensibleEnum(result.GetRawResponse().Content.ToObjectFromJson<string>()), result.GetRawResponse());
        }

        /// <summary> Get unknown value. </summary>
        public virtual ClientResult<DaysOfWeekExtensibleEnum> GetUnknownValue()
        {
            ClientResult result = GetUnknownValue(null);
            return ClientResult.FromValue(new DaysOfWeekExtensibleEnum(result.GetRawResponse().Content.ToObjectFromJson<string>()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Get unknown value.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetUnknownValueAsync()"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> GetUnknownValueAsync(RequestOptions options)
        {
            using PipelineMessage message = CreateGetUnknownValueRequest(options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Get unknown value.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetUnknownValue()"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult GetUnknownValue(RequestOptions options)
        {
            using PipelineMessage message = CreateGetUnknownValueRequest(options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Put known value. </summary>
        /// <param name="body"> The <see cref="DaysOfWeekExtensibleEnum"/> to use. </param>
        public virtual async Task<ClientResult> PutKnownValueAsync(DaysOfWeekExtensibleEnum body)
        {
            using BinaryContent content = BinaryContent.Create(BinaryData.FromObjectAsJson(body.ToString()));
            ClientResult result = await PutKnownValueAsync(content, null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Put known value. </summary>
        /// <param name="body"> The <see cref="DaysOfWeekExtensibleEnum"/> to use. </param>
        public virtual ClientResult PutKnownValue(DaysOfWeekExtensibleEnum body)
        {
            using BinaryContent content = BinaryContent.Create(BinaryData.FromObjectAsJson(body.ToString()));
            ClientResult result = PutKnownValue(content, null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Put known value.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PutKnownValueAsync(DaysOfWeekExtensibleEnum)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> PutKnownValueAsync(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreatePutKnownValueRequest(content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Put known value.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PutKnownValue(DaysOfWeekExtensibleEnum)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult PutKnownValue(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreatePutKnownValueRequest(content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Put unknown value. </summary>
        /// <param name="body"> The <see cref="DaysOfWeekExtensibleEnum"/> to use. </param>
        public virtual async Task<ClientResult> PutUnknownValueAsync(DaysOfWeekExtensibleEnum body)
        {
            using BinaryContent content = BinaryContent.Create(BinaryData.FromObjectAsJson(body.ToString()));
            ClientResult result = await PutUnknownValueAsync(content, null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Put unknown value. </summary>
        /// <param name="body"> The <see cref="DaysOfWeekExtensibleEnum"/> to use. </param>
        public virtual ClientResult PutUnknownValue(DaysOfWeekExtensibleEnum body)
        {
            using BinaryContent content = BinaryContent.Create(BinaryData.FromObjectAsJson(body.ToString()));
            ClientResult result = PutUnknownValue(content, null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Put unknown value.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PutUnknownValueAsync(DaysOfWeekExtensibleEnum)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> PutUnknownValueAsync(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreatePutUnknownValueRequest(content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Put unknown value.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PutUnknownValue(DaysOfWeekExtensibleEnum)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult PutUnknownValue(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreatePutUnknownValueRequest(content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        internal PipelineMessage CreateGetKnownValueRequest(RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/enum/extensible/string/known-value", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            if (options != null)
            {
                message.Apply(options);
            }
            return message;
        }

        internal PipelineMessage CreateGetUnknownValueRequest(RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/enum/extensible/string/unknown-value", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            if (options != null)
            {
                message.Apply(options);
            }
            return message;
        }

        internal PipelineMessage CreatePutKnownValueRequest(BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "PUT";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/enum/extensible/string/known-value", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            if (options != null)
            {
                message.Apply(options);
            }
            return message;
        }

        internal PipelineMessage CreatePutUnknownValueRequest(BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "PUT";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/enum/extensible/string/unknown-value", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            if (options != null)
            {
                message.Apply(options);
            }
            return message;
        }

        private static PipelineMessageClassifier _pipelineMessageClassifier200;
        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
        private static PipelineMessageClassifier _pipelineMessageClassifier204;
        private static PipelineMessageClassifier PipelineMessageClassifier204 => _pipelineMessageClassifier204 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });
    }
}
