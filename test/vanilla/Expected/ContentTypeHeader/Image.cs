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
    /// Image operations.
    /// </summary>
    public partial class Image : IServiceOperations<CowbellModerator>, IImage
    {
        /// <summary>
        /// Initializes a new instance of the Image class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public Image(CowbellModerator client)
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

        /// <param name='image'>
        /// An image stream.
        /// </param>
        /// <param name='imageContentType'>
        /// The content type of the image. Possible values include: 'image/gif',
        /// 'image/jpeg', 'image/png', 'image/bmp', 'image/tiff'
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="T:Microsoft.Rest.HttpRestException">
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
        public async Task<HttpOperationResponse> AWithHttpMessagesAsync(Stream image, ImageType imageContentType, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (image == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "image");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("image", image);
                tracingParameters.Add("imageContentType", imageContentType);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "A", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "ProcessImage/FunctionA").ToString();
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

            if(image == null)
            {
              throw new System.ArgumentNullException("image");
            }
            if (image != null && image != Stream.Null)
            {
                _httpRequest.Content = new StreamContent(image);
                _httpRequest.Content.Headers.ContentType =System.Net.Http.Headers.MediaTypeHeaderValue.Parse(imageContentType.ToSerializedValue());
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
                catch (JsonException)
                {
                    // Ignore the exception
                }
                catch(RestException ex)
                {
                    if (_shouldTrace)
                    {
                        ServiceClientTracing.Error(_invocationId, ex);
                    }
                    throw ex;
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
        /// Creates a HttpRestException object and throws it
        /// </summary>
        /// <exception cref="T:Microsoft.Rest.HttpRestException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleErrorResponseWithKnownTypeForA<T>(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            string _responseContent = null;
            var ex = new HttpRestException<T>(GetErrorMessageForA(statusCode));
            if (_httpResponse.Content != null)
            {
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var errorResponseModel = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<T>(_responseContent);
                    ex.SetErrorModel(errorResponseModel);
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


        /// <param name='image'>
        /// An image stream.
        /// </param>
        /// <param name='imageContentType'>
        /// The content type of the image. Possible values include: 'image/gif',
        /// 'image/jpeg', 'image/png', 'image/bmp', 'image/tiff'
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="T:Microsoft.Rest.HttpRestException">
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
        public async Task<HttpOperationResponse> BWithHttpMessagesAsync(Stream image, ImageType imageContentType, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (image == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "image");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("image", image);
                tracingParameters.Add("imageContentType", imageContentType);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "B", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "ProcessImage/FunctionB").ToString();
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

            if(image == null)
            {
              throw new System.ArgumentNullException("image");
            }
            if (image != null && image != Stream.Null)
            {
                _httpRequest.Content = new StreamContent(image);
                _httpRequest.Content.Headers.ContentType =System.Net.Http.Headers.MediaTypeHeaderValue.Parse(imageContentType.ToSerializedValue());
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
                catch (JsonException)
                {
                    // Ignore the exception
                }
                catch(RestException ex)
                {
                    if (_shouldTrace)
                    {
                        ServiceClientTracing.Error(_invocationId, ex);
                    }
                    throw ex;
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
        /// Creates a HttpRestException object and throws it
        /// </summary>
        /// <exception cref="T:Microsoft.Rest.HttpRestException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleErrorResponseWithKnownTypeForB<T>(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            string _responseContent = null;
            var ex = new HttpRestException<T>(GetErrorMessageForB(statusCode));
            if (_httpResponse.Content != null)
            {
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var errorResponseModel = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<T>(_responseContent);
                    ex.SetErrorModel(errorResponseModel);
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


        /// <param name='image'>
        /// An image stream.
        /// </param>
        /// <param name='imageContentType'>
        /// The content type of the image. Possible values include: 'image/png',
        /// 'image/tiff'
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="T:Microsoft.Rest.HttpRestException">
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
        public async Task<HttpOperationResponse> CWithHttpMessagesAsync(Stream image, ImageTypeRestricted imageContentType, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (image == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "image");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("image", image);
                tracingParameters.Add("imageContentType", imageContentType);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "C", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "ProcessImage/FunctionC").ToString();
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

            if(image == null)
            {
              throw new System.ArgumentNullException("image");
            }
            if (image != null && image != Stream.Null)
            {
                _httpRequest.Content = new StreamContent(image);
                _httpRequest.Content.Headers.ContentType =System.Net.Http.Headers.MediaTypeHeaderValue.Parse(imageContentType.ToSerializedValue());
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
                    await HandleDefaultErrorResponseForC(_httpRequest, _httpResponse, (int)_statusCode);
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                catch(RestException ex)
                {
                    if (_shouldTrace)
                    {
                        ServiceClientTracing.Error(_invocationId, ex);
                    }
                    throw ex;
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
        private async Task HandleDefaultErrorResponseForC(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            await HandleErrorResponseWithKnownTypeForC<string>(_httpRequest, _httpResponse, statusCode);
        }

        /// <summary>
        /// Method that generates error message for status code
        /// </summary>
        private string GetErrorMessageForC(int statusCode)
        {
            return string.Format("Operation C returned status code: '{0}'", statusCode);
        }

        /// <summary>
        /// Handle responses where error model is a known primary type
        /// Creates a HttpRestException object and throws it
        /// </summary>
        /// <exception cref="T:Microsoft.Rest.HttpRestException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleErrorResponseWithKnownTypeForC<T>(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            string _responseContent = null;
            var ex = new HttpRestException<T>(GetErrorMessageForC(statusCode));
            if (_httpResponse.Content != null)
            {
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var errorResponseModel = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<T>(_responseContent);
                    ex.SetErrorModel(errorResponseModel);
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


        /// <param name='image'>
        /// An image stream.
        /// </param>
        /// <param name='imageContentType'>
        /// The content type of the image. Possible values include: 'image/png',
        /// 'image/tiff'
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="T:Microsoft.Rest.HttpRestException">
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
        public async Task<HttpOperationResponse> DWithHttpMessagesAsync(Stream image, string imageContentType, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (image == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "image");
            }
            if (imageContentType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "imageContentType");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("image", image);
                tracingParameters.Add("imageContentType", imageContentType);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "D", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "ProcessImage/FunctionD").ToString();
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

            if(image == null)
            {
              throw new System.ArgumentNullException("image");
            }
            if (image != null && image != Stream.Null)
            {
                _httpRequest.Content = new StreamContent(image);
                _httpRequest.Content.Headers.ContentType =System.Net.Http.Headers.MediaTypeHeaderValue.Parse(imageContentType);
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
                    await HandleDefaultErrorResponseForD(_httpRequest, _httpResponse, (int)_statusCode);
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                catch(RestException ex)
                {
                    if (_shouldTrace)
                    {
                        ServiceClientTracing.Error(_invocationId, ex);
                    }
                    throw ex;
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
        private async Task HandleDefaultErrorResponseForD(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            await HandleErrorResponseWithKnownTypeForD<string>(_httpRequest, _httpResponse, statusCode);
        }

        /// <summary>
        /// Method that generates error message for status code
        /// </summary>
        private string GetErrorMessageForD(int statusCode)
        {
            return string.Format("Operation D returned status code: '{0}'", statusCode);
        }

        /// <summary>
        /// Handle responses where error model is a known primary type
        /// Creates a HttpRestException object and throws it
        /// </summary>
        /// <exception cref="T:Microsoft.Rest.HttpRestException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleErrorResponseWithKnownTypeForD<T>(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            string _responseContent = null;
            var ex = new HttpRestException<T>(GetErrorMessageForD(statusCode));
            if (_httpResponse.Content != null)
            {
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var errorResponseModel = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<T>(_responseContent);
                    ex.SetErrorModel(errorResponseModel);
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
