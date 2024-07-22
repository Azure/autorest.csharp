// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using OpenAI.Models;

namespace OpenAI
{
    // Data plane generated sub-client.
    /// <summary> The Files sub-client. </summary>
    public partial class Files
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Files for mocking. </summary>
        protected Files()
        {
        }

        /// <summary> Initializes a new instance of Files. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> The <see cref="string"/> to use. </param>
        internal Files(ClientPipeline pipeline, ApiKeyCredential keyCredential, Uri endpoint)
        {
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        /// <summary> Returns a list of files that belong to the user's organization. </summary>
        /// <remarks> List. </remarks>
        public virtual async Task<ClientResult<ListFilesResponse>> GetFilesAsync()
        {
            ClientResult result = await GetFilesAsync(null).ConfigureAwait(false);
            return ClientResult.FromValue(ListFilesResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Returns a list of files that belong to the user's organization. </summary>
        /// <remarks> List. </remarks>
        public virtual ClientResult<ListFilesResponse> GetFiles()
        {
            ClientResult result = GetFiles(null);
            return ClientResult.FromValue(ListFilesResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Returns a list of files that belong to the user's organization.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFilesAsync()"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> GetFilesAsync(RequestOptions options)
        {
            using PipelineMessage message = CreateGetFilesRequest(options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Returns a list of files that belong to the user's organization.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFiles()"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult GetFiles(RequestOptions options)
        {
            using PipelineMessage message = CreateGetFilesRequest(options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Returns a list of files that belong to the user's organization. </summary>
        /// <param name="file"> The <see cref="CreateFileRequest"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
        /// <remarks> Create. </remarks>
        public virtual async Task<ClientResult<OpenAIFile>> CreateAsync(CreateFileRequest file)
        {
            Argument.AssertNotNull(file, nameof(file));

            using MultipartFormDataBinaryContent content = file.ToMultipartBinaryBody();
            ClientResult result = await CreateAsync(content, content.ContentType, null).ConfigureAwait(false);
            return ClientResult.FromValue(OpenAIFile.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Returns a list of files that belong to the user's organization. </summary>
        /// <param name="file"> The <see cref="CreateFileRequest"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
        /// <remarks> Create. </remarks>
        public virtual ClientResult<OpenAIFile> Create(CreateFileRequest file)
        {
            Argument.AssertNotNull(file, nameof(file));

            using MultipartFormDataBinaryContent content = file.ToMultipartBinaryBody();
            ClientResult result = Create(content, content.ContentType, null);
            return ClientResult.FromValue(OpenAIFile.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Returns a list of files that belong to the user's organization.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateAsync(CreateFileRequest)"/> convenience overload with strongly typed models first.
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
        public virtual async Task<ClientResult> CreateAsync(BinaryContent content, string contentType, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateRequest(content, contentType, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Returns a list of files that belong to the user's organization.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Create(CreateFileRequest)"/> convenience overload with strongly typed models first.
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
        public virtual ClientResult Create(BinaryContent content, string contentType, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateRequest(content, contentType, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Returns information about a specific file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Retrieve. </remarks>
        public virtual async Task<ClientResult<OpenAIFile>> RetrieveAsync(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = await RetrieveAsync(fileId, null).ConfigureAwait(false);
            return ClientResult.FromValue(OpenAIFile.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Returns information about a specific file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Retrieve. </remarks>
        public virtual ClientResult<OpenAIFile> Retrieve(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = Retrieve(fileId, null);
            return ClientResult.FromValue(OpenAIFile.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Returns information about a specific file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RetrieveAsync(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> RetrieveAsync(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateRetrieveRequest(fileId, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Returns information about a specific file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Retrieve(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult Retrieve(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateRetrieveRequest(fileId, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Delete a file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Delete. </remarks>
        public virtual async Task<ClientResult<DeleteFileResponse>> DeleteAsync(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = await DeleteAsync(fileId, null).ConfigureAwait(false);
            return ClientResult.FromValue(DeleteFileResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Delete a file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Delete. </remarks>
        public virtual ClientResult<DeleteFileResponse> Delete(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = Delete(fileId, null);
            return ClientResult.FromValue(DeleteFileResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Delete a file
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DeleteAsync(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> DeleteAsync(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateDeleteRequest(fileId, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Delete a file
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Delete(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult Delete(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateDeleteRequest(fileId, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Returns the contents of the specified file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Download. </remarks>
        public virtual async Task<ClientResult<string>> DownloadAsync(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = await DownloadAsync(fileId, null).ConfigureAwait(false);
            return ClientResult.FromValue(result.GetRawResponse().Content.ToObjectFromJson<string>(), result.GetRawResponse());
        }

        /// <summary> Returns the contents of the specified file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Download. </remarks>
        public virtual ClientResult<string> Download(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = Download(fileId, null);
            return ClientResult.FromValue(result.GetRawResponse().Content.ToObjectFromJson<string>(), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Returns the contents of the specified file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DownloadAsync(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> DownloadAsync(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateDownloadRequest(fileId, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Returns the contents of the specified file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Download(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult Download(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateDownloadRequest(fileId, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        internal PipelineMessage CreateGetFilesRequest(RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/files", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateCreateRequest(BinaryContent content, string contentType, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/files", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("content-type", contentType);
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateRetrieveRequest(string fileId, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/files/files/", false);
            uri.AppendPath(fileId, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateDeleteRequest(string fileId, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "DELETE";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/files/files/", false);
            uri.AppendPath(fileId, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateDownloadRequest(string fileId, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/files/files/", false);
            uri.AppendPath(fileId, true);
            uri.AppendPath("/content", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        private static PipelineMessageClassifier _pipelineMessageClassifier200;
        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
    }
}
