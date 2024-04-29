// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Scm._Type.Property.AdditionalProperties
{
    // Data plane generated sub-client.
    /// <summary> The SpreadRecordNonDiscriminatedUnion sub-client. </summary>
    public partial class SpreadRecordNonDiscriminatedUnion
    {
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of SpreadRecordNonDiscriminatedUnion for mocking. </summary>
        protected SpreadRecordNonDiscriminatedUnion()
        {
        }

        /// <summary> Initializes a new instance of SpreadRecordNonDiscriminatedUnion. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        internal SpreadRecordNonDiscriminatedUnion(ClientPipeline pipeline, Uri endpoint)
        {
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        /// <summary> Get call. </summary>
        public virtual async Task<ClientResult<IReadOnlyDictionary<string, BinaryData>>> GetSpreadRecordNonDiscriminatedUnionAsync()
        {
            ClientResult result = await GetSpreadRecordNonDiscriminatedUnionAsync(null).ConfigureAwait(false);
            IReadOnlyDictionary<string, BinaryData> value = default;
            using var document = await JsonDocument.ParseAsync(result.GetRawResponse().ContentStream, default, default).ConfigureAwait(false);
            Dictionary<string, BinaryData> dictionary = new Dictionary<string, BinaryData>();
            foreach (var property in document.RootElement.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    dictionary.Add(property.Name, null);
                }
                else
                {
                    dictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            value = dictionary;
            return ClientResult.FromValue(value, result.GetRawResponse());
        }

        /// <summary> Get call. </summary>
        public virtual ClientResult<IReadOnlyDictionary<string, BinaryData>> GetSpreadRecordNonDiscriminatedUnion()
        {
            ClientResult result = GetSpreadRecordNonDiscriminatedUnion(null);
            IReadOnlyDictionary<string, BinaryData> value = default;
            using var document = JsonDocument.Parse(result.GetRawResponse().ContentStream);
            Dictionary<string, BinaryData> dictionary = new Dictionary<string, BinaryData>();
            foreach (var property in document.RootElement.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    dictionary.Add(property.Name, null);
                }
                else
                {
                    dictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            value = dictionary;
            return ClientResult.FromValue(value, result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Get call
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetSpreadRecordNonDiscriminatedUnionAsync()"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> GetSpreadRecordNonDiscriminatedUnionAsync(RequestOptions options)
        {
            using PipelineMessage message = CreateGetSpreadRecordNonDiscriminatedUnionRequest(options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Get call
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetSpreadRecordNonDiscriminatedUnion()"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult GetSpreadRecordNonDiscriminatedUnion(RequestOptions options)
        {
            using PipelineMessage message = CreateGetSpreadRecordNonDiscriminatedUnionRequest(options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Put operation. </summary>
        /// <param name="body"> body. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<ClientResult> PutAsync(IDictionary<string, BinaryData> body)
        {
            Argument.AssertNotNull(body, nameof(body));

            using BinaryContent content = BinaryContentHelper.FromDictionary(body);
            ClientResult result = await PutAsync(content, null).ConfigureAwait(false);
            return result;
        }

        /// <summary> Put operation. </summary>
        /// <param name="body"> body. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual ClientResult Put(IDictionary<string, BinaryData> body)
        {
            Argument.AssertNotNull(body, nameof(body));

            using BinaryContent content = BinaryContentHelper.FromDictionary(body);
            ClientResult result = Put(content, null);
            return result;
        }

        /// <summary>
        /// [Protocol Method] Put operation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="PutAsync(IDictionary{string,BinaryData})"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> PutAsync(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreatePutRequest(content, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Put operation
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Put(IDictionary{string,BinaryData})"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult Put(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreatePutRequest(content, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        internal PipelineMessage CreateGetSpreadRecordNonDiscriminatedUnionRequest(RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/property/additionalProperties/spreadRecordNonDiscriminatedUnion", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreatePutRequest(BinaryContent content, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier204;
            var request = message.Request;
            request.Method = "PUT";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/type/property/additionalProperties/spreadRecordNonDiscriminatedUnion", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        private static PipelineMessageClassifier _pipelineMessageClassifier200;
        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
        private static PipelineMessageClassifier _pipelineMessageClassifier204;
        private static PipelineMessageClassifier PipelineMessageClassifier204 => _pipelineMessageClassifier204 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });
    }
}
