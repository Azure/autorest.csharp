// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.ContentTypeHeader
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
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Text operations.
    /// </summary>
    public partial class Text : IServiceOperations<CowbellModerator>, IText
    {
        /// <summary>
        /// Initializes a new instance of the Text class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public Text(CowbellModerator client)
        {
            if (client == null)
            {
                throw new System.ArgumentNullException("client");
            }
            Client = client;
        }

        /// <summary>
        /// Gets a reference to the CowbellModerator
        /// </summary>
        public CowbellModerator Client { get; private set; }

        /// <param name='text'>
        /// A text stream.
        /// </param>
        /// <param name='contentType'>
        /// The content type of the image. Possible values include: 'text/plain',
        /// 'text/json'
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="T:Microsoft.Rest.RestException">
        /// Thrown when the operation returned an invalid status code
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
        public async Task<HttpOperationResponse> AWithHttpMessagesAsync(Stream text, string contentType, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (text == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "text");
            }
            if (contentType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "contentType");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("text", text);
                tracingParameters.Add("contentType", contentType);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "A", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "ProcessImage/FunctionTA").ToString();
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

            if(text == null)
            {
              throw new System.ArgumentNullException("text");
            }
            if (text != null && text != Stream.Null)
            {
                _httpRequest.Content = new StreamContent(text);
                _httpRequest.Content.Headers.ContentType =System.Net.Http.Headers.MediaTypeHeaderValue.Parse(contentType);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
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
                    await HandleDefaultErrorResponseForA(_httpRequest, _httpResponse, (int)_statusCode);
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
            var _result = new HttpOperationResponse();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Handle other unhandled status codes
        /// </summary>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleDefaultErrorResponseForA(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            await HandleErrorResponseWithKnownTypeForA<string>(_httpRequest, _httpResponse, statusCode);
        }

        /// <summary>
        /// Method that generates error message for status code
        /// </summary>
        private string GetErrorMessageForA(int statusCode)
        {
            return string.Format("Operation A returned status code: '{0}'", statusCode);
        }

        /// <summary>
        /// Handle responses where error model is a known primary type
        /// Creates a RestException object and throws it
        /// </summary>
        /// <exception cref="T:Microsoft.Rest.RestException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleErrorResponseWithKnownTypeForA<T>(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            string _responseContent = null;
            var ex = new RestException<T>(GetErrorMessageForA(statusCode));
            if (_httpResponse.Content != null)
            {
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var errorResponseModel = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<T>(_responseContent);
                    ex.Body = errorResponseModel;
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
            }
            else
            {
                _responseContent = string.Empty;
            }

            ex.Request = new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString());
            ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
            _httpRequest.Dispose();
            if (_httpResponse != null)
            {
                _httpResponse.Dispose();
            }
            throw ex;
        }

        /// <param name='text'>
        /// A text stream.
        /// </param>
        /// <param name='contentType'>
        /// The content type of the image. Possible values include: 'text/plain',
        /// 'text/json'
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="T:Microsoft.Rest.RestException">
        /// Thrown when the operation returned an invalid status code
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
        public async Task<HttpOperationResponse> BWithHttpMessagesAsync(Stream text, string contentType = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (text == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "text");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("text", text);
                tracingParameters.Add("contentType", contentType);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "B", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "ProcessImage/FunctionTB").ToString();
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

            if(text == null)
            {
              throw new System.ArgumentNullException("text");
            }
            if (text != null && text != Stream.Null)
            {
                _httpRequest.Content = new StreamContent(text);
                _httpRequest.Content.Headers.ContentType =System.Net.Http.Headers.MediaTypeHeaderValue.Parse(contentType);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
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
                    await HandleDefaultErrorResponseForB(_httpRequest, _httpResponse, (int)_statusCode);
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
            var _result = new HttpOperationResponse();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Handle other unhandled status codes
        /// </summary>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleDefaultErrorResponseForB(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            await HandleErrorResponseWithKnownTypeForB<string>(_httpRequest, _httpResponse, statusCode);
        }

        /// <summary>
        /// Method that generates error message for status code
        /// </summary>
        private string GetErrorMessageForB(int statusCode)
        {
            return string.Format("Operation B returned status code: '{0}'", statusCode);
        }

        /// <summary>
        /// Handle responses where error model is a known primary type
        /// Creates a RestException object and throws it
        /// </summary>
        /// <exception cref="T:Microsoft.Rest.RestException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleErrorResponseWithKnownTypeForB<T>(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            string _responseContent = null;
            var ex = new RestException<T>(GetErrorMessageForB(statusCode));
            if (_httpResponse.Content != null)
            {
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var errorResponseModel = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<T>(_responseContent);
                    ex.Body = errorResponseModel;
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
            }
            else
            {
                _responseContent = string.Empty;
            }

            ex.Request = new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString());
            ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
            _httpRequest.Dispose();
            if (_httpResponse != null)
            {
                _httpResponse.Dispose();
            }
            throw ex;
        }

    }
}
