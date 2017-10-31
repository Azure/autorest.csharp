// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsBodyComplex
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
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Inheritance operations.
    /// </summary>
    public partial class Inheritance : IServiceOperations<AutoRestComplexTestService>, IInheritance
    {
        /// <summary>
        /// Initializes a new instance of the Inheritance class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client
        /// </param>
        /// <exception cref='System.ArgumentNullException'>
        /// Thrown when a required parameter is null.
        /// </exception>
        public Inheritance(AutoRestComplexTestService client)
        {
            if (client == null)
            {
                throw new System.ArgumentNullException(nameof(client));
            }
            Client = client;
        }

        /// <summary>
        /// Gets a reference to the AutoRestComplexTestService.
        /// </summary>
        public AutoRestComplexTestService Client { get; private set; }

        /// <summary>
        /// Get complex types that extend others
        /// </summary>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref='ErrorException'>
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref='SerializationException'>
        /// Thrown when unable to deserialize the response.
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<Siamese>> GetValidWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetValid", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            string _url = new System.Uri(new System.Uri(_baseUrl.TrimEnd('/') + "/"), "complex/inheritance/valid").ToString();
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers


            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    _httpRequest.Headers.Remove(_header.Key);
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
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
            Stream _responseContent = _httpResponse.Content != null
                ? await _httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false)
                : new MemoryStream();
            Encoding _responseContentEncoding = _httpResponse.Content != null && _httpResponse.Content.Headers != null && _httpResponse.Content.Headers.ContentType != null && _httpResponse.Content.Headers.ContentType.CharSet != null
                ? Encoding.GetEncoding(_httpResponse.Content.Headers.ContentType.CharSet)
                : Encoding.UTF8;
            System.IO.TextReader _responseContentTextReader = new System.IO.StreamReader(_responseContent, _responseContentEncoding);
            if ((int)_statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    Error _errorBody = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<Error>(_responseContentTextReader.ReadToEnd(), Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContentTextReader.ReadToEnd());
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<Siamese>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                try
                {
                    _result.Body = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<Siamese>(_responseContentTextReader.ReadToEnd(), Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    string message = _responseContentTextReader.ReadToEnd();
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", message, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Put complex types that extend others
        /// </summary>
        /// <param name='complexBody'>
        /// Please put a siamese with id=2, name="Siameee", color=green, breed=persion, which hates 2 dogs, the 1st one named
        /// "Potato" with id=1 and food="tomato", and the 2nd one named "Tomato" with id=-1 and food="french fries".
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref='ErrorException'>
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref='ValidationException'>
        /// Thrown when a required parameter is null.
        /// </exception>
        /// <exception cref='System.ArgumentNullException'>
        /// Thrown when a required parameter is null.
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse> PutValidWithHttpMessagesAsync(Siamese complexBody, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (complexBody == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, nameof(complexBody));
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("complexBody", complexBody);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "PutValid", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            string _url = new System.Uri(new System.Uri(_baseUrl.TrimEnd('/') + "/"), "complex/inheritance/valid").ToString();
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("PUT");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers


            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    _httpRequest.Headers.Remove(_header.Key);
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            if (complexBody != null)
            {
                _requestContent = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(complexBody, Client.SerializationSettings);
                _httpRequest.Content = new StringContent(_requestContent, Encoding.UTF8);
                _httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
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
            Stream _responseContent = _httpResponse.Content != null
                ? await _httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false)
                : new MemoryStream();
            Encoding _responseContentEncoding = _httpResponse.Content != null && _httpResponse.Content.Headers != null && _httpResponse.Content.Headers.ContentType != null && _httpResponse.Content.Headers.ContentType.CharSet != null
                ? Encoding.GetEncoding(_httpResponse.Content.Headers.ContentType.CharSet)
                : Encoding.UTF8;
            System.IO.TextReader _responseContentTextReader = new System.IO.StreamReader(_responseContent, _responseContentEncoding);
            if ((int)_statusCode != 200)
            {
                var ex = new ErrorException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    Error _errorBody = Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<Error>(_responseContentTextReader.ReadToEnd(), Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContentTextReader.ReadToEnd());
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
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

    }
}
