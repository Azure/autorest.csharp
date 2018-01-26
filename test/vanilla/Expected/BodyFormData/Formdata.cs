// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.BodyFormData
{
    using Microsoft.Rest;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Formdata operations.
    /// </summary>
    public partial class Formdata : IServiceOperations<AutoRestSwaggerBATFormDataService>, IFormdata
    {
        /// <summary>
        /// Initializes a new instance of the Formdata class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public Formdata(AutoRestSwaggerBATFormDataService client)
        {
            if (client == null)
            {
                throw new System.ArgumentNullException("client");
            }
            Client = client;
        }

        /// <summary>
        /// Gets a reference to the AutoRestSwaggerBATFormDataService
        /// </summary>
        public AutoRestSwaggerBATFormDataService Client { get; private set; }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name='fileContent'>
        /// File to upload.
        /// </param>
        /// <param name='fileName'>
        /// File name to upload. Name has to be spelled exactly as written here.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<Stream>> UploadFileWithHttpMessagesAsync(Stream fileContent, string fileName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (fileContent == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "fileContent");
            }
            if (fileName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "fileName");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("fileContent", fileContent);
                tracingParameters.Add("fileName", fileName);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "UploadFile", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "formdata/stream/uploadfile").ToString();
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            MultipartFormDataContent _multiPartContent = new MultipartFormDataContent();
            if (fileContent != null)
            {
                StreamContent _fileContent = new StreamContent(fileContent);
                _fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                FileStream _fileContentAsFileStream = fileContent as FileStream;
                if (_fileContentAsFileStream != null)
                {
                    ContentDispositionHeaderValue _contentDispositionHeaderValue = new ContentDispositionHeaderValue("form-data");
                    _contentDispositionHeaderValue.Name = "fileContent";
                    _contentDispositionHeaderValue.FileName = _fileContentAsFileStream.Name;
                    _fileContent.Headers.ContentDisposition = _contentDispositionHeaderValue;
                }
                _multiPartContent.Add(_fileContent, "fileContent");
            }
            if (fileName != null)
            {
                StringContent _fileName = new StringContent(fileName, System.Text.Encoding.UTF8);
                _multiPartContent.Add(_fileName, "fileName");
            }
            _httpRequest.Content = _multiPartContent;
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)_statusCode != 200)
            {
                try
                {
                    await HandleDefaultErrorResponseForUploadFile(_httpRequest, _httpResponse, (int)_statusCode);
                }
                catch(RestException ex)
                {
                    if (_shouldTrace)
                    {
                        ServiceClientTracing.Error(_invocationId, ex);
                    }
                    throw;
                }
            }
            // Create Result
            var _result = new HttpOperationResponse<Stream>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _result.Body = await _httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Handle other unhandled status codes
        /// </summary>
        /// <exception cref="ErrorException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleDefaultErrorResponseForUploadFile(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            await HandleErrorResponseForUploadFile<Error>(_httpRequest, _httpResponse, statusCode, Client.DeserializationSettings);
        }

        /// <summary>
        /// Method that generates error message for status code
        /// </summary>
        private string GetErrorMessageForUploadFile(int statusCode)
        {
            return string.Format("Operation UploadFile returned status code: '{0}'", statusCode);
        }

        /// <summary>
        /// Handle error responses, deserialize errors of types V and throw exceptions of type T
        /// </summary>
        private async Task HandleErrorResponseForUploadFile<V>(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode, JsonSerializerSettings deserializationSettings)
            where V : IRestErrorModel
        {
            string errorMessage = GetErrorMessageForUploadFile(statusCode);
            string _responseContent = null;
            if (_httpResponse.Content != null)
            {
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var errorResponseModel = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<V>(_responseContent, deserializationSettings);
                    if(errorResponseModel!=null)
                    {
                        errorResponseModel.CreateAndThrowException(errorMessage, new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()), new HttpResponseMessageWrapper(_httpResponse, _responseContent));
                    }
                    else
                    {
                        throw new RestException<V>(errorMessage)
                            {
                                Request = new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()),
                                Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent)
                            };
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                    throw new RestException<V>(errorMessage)
                        {
                            Request = new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()),
                            Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent)
                        };
                }
            }
            _httpRequest.Dispose();
            if (_httpResponse != null)
            {
                _httpResponse.Dispose();
            }
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name='fileContent'>
        /// File to upload.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<Stream>> UploadFileViaBodyWithHttpMessagesAsync(Stream fileContent, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (fileContent == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "fileContent");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("fileContent", fileContent);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "UploadFileViaBody", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "formdata/stream/uploadfile").ToString();
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("PUT");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            if(fileContent == null)
            {
              throw new System.ArgumentNullException("fileContent");
            }
            if (fileContent != null && fileContent != Stream.Null)
            {
                _httpRequest.Content = new StreamContent(fileContent);
                _httpRequest.Content.Headers.ContentType =MediaTypeHeaderValue.Parse("application/octet-stream");
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)_statusCode != 200)
            {
                try
                {
                    await HandleDefaultErrorResponseForUploadFileViaBody(_httpRequest, _httpResponse, (int)_statusCode);
                }
                catch(RestException ex)
                {
                    if (_shouldTrace)
                    {
                        ServiceClientTracing.Error(_invocationId, ex);
                    }
                    throw;
                }
            }
            // Create Result
            var _result = new HttpOperationResponse<Stream>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _result.Body = await _httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Handle other unhandled status codes
        /// </summary>
        /// <exception cref="ErrorException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleDefaultErrorResponseForUploadFileViaBody(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            await HandleErrorResponseForUploadFileViaBody<Error>(_httpRequest, _httpResponse, statusCode, Client.DeserializationSettings);
        }

        /// <summary>
        /// Method that generates error message for status code
        /// </summary>
        private string GetErrorMessageForUploadFileViaBody(int statusCode)
        {
            return string.Format("Operation UploadFileViaBody returned status code: '{0}'", statusCode);
        }

        /// <summary>
        /// Handle error responses, deserialize errors of types V and throw exceptions of type T
        /// </summary>
        private async Task HandleErrorResponseForUploadFileViaBody<V>(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode, JsonSerializerSettings deserializationSettings)
            where V : IRestErrorModel
        {
            string errorMessage = GetErrorMessageForUploadFileViaBody(statusCode);
            string _responseContent = null;
            if (_httpResponse.Content != null)
            {
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var errorResponseModel = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<V>(_responseContent, deserializationSettings);
                    if(errorResponseModel!=null)
                    {
                        errorResponseModel.CreateAndThrowException(errorMessage, new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()), new HttpResponseMessageWrapper(_httpResponse, _responseContent));
                    }
                    else
                    {
                        throw new RestException<V>(errorMessage)
                            {
                                Request = new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()),
                                Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent)
                            };
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                    throw new RestException<V>(errorMessage)
                        {
                            Request = new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()),
                            Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent)
                        };
                }
            }
            _httpRequest.Dispose();
            if (_httpResponse != null)
            {
                _httpResponse.Dispose();
            }
        }

    }
}
