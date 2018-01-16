// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.UrlMultiCollectionFormat
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
    /// Queries operations.
    /// </summary>
    public partial class Queries : IServiceOperations<AutoRestUrlMutliCollectionFormatTestService>, IQueries
    {
        /// <summary>
        /// Initializes a new instance of the Queries class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public Queries(AutoRestUrlMutliCollectionFormatTestService client)
        {
            if (client == null)
            {
                throw new System.ArgumentNullException("client");
            }
            Client = client;
        }

        /// <summary>
        /// Gets a reference to the AutoRestUrlMutliCollectionFormatTestService
        /// </summary>
        public AutoRestUrlMutliCollectionFormatTestService Client { get; private set; }

        /// <summary>
        /// Get a null array of string using the multi-array format
        /// </summary>
        /// <param name='arrayQuery'>
        /// a null array of string using the multi-array format
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
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse> ArrayStringMultiNullWithHttpMessagesAsync(IList<string> arrayQuery = default(IList<string>), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("arrayQuery", arrayQuery);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "ArrayStringMultiNull", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "queries/array/multi/string/null").ToString();
            List<string> _queryParameters = new List<string>();
            if (arrayQuery != null)
            {
                if (arrayQuery.Count == 0)
                {
                    _queryParameters.Add(string.Format("arrayQuery={0}", System.Uri.EscapeDataString(string.Empty)));
                }
                else
                {
                    foreach (var _item in arrayQuery)
                    {
                        _queryParameters.Add(string.Format("arrayQuery={0}", System.Uri.EscapeDataString("" + _item)));
                    }
                }
            }
            if (_queryParameters.Count > 0)
            {
                _url += "?" + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
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
                    await HandleDefaultErrorResponseForArrayStringMultiNull(_httpRequest, _httpResponse, (int)_statusCode);
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                catch(RestExceptionBase ex)
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
        /// <exception cref="ErrorException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleDefaultErrorResponseForArrayStringMultiNull(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            await HandleErrorResponseForArrayStringMultiNull<Error>(_httpRequest, _httpResponse, statusCode, Client.DeserializationSettings);
        }

        /// <summary>
        /// Method that generates error message for status code
        /// </summary>
        private string GetErrorMessageForArrayStringMultiNull(int statusCode)
        {
            return string.Format("Operation ArrayStringMultiNull returned status code: '{0}'", statusCode);
        }

        /// <summary>
        /// Handle error responses, deserialize errors of types V and throw exceptions of type T
        /// </summary>
        private async Task HandleErrorResponseForArrayStringMultiNull<V>(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode, JsonSerializerSettings deserializationSettings)
            where V : IRestErrorModel
        {
            string errorMessage = GetErrorMessageForArrayStringMultiNull(statusCode);
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
                        throw new RestException<V>(errorMessage, new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()), new HttpResponseMessageWrapper(_httpResponse, _responseContent));
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                    throw new RestException<V>(errorMessage, new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()), new HttpResponseMessageWrapper(_httpResponse, _responseContent));
                }
            }
            _httpRequest.Dispose();
            if (_httpResponse != null)
            {
                _httpResponse.Dispose();
            }
        }

        /// <summary>
        /// Get an empty array [] of string using the multi-array format
        /// </summary>
        /// <param name='arrayQuery'>
        /// an empty array [] of string using the multi-array format
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
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse> ArrayStringMultiEmptyWithHttpMessagesAsync(IList<string> arrayQuery = default(IList<string>), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("arrayQuery", arrayQuery);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "ArrayStringMultiEmpty", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "queries/array/multi/string/empty").ToString();
            List<string> _queryParameters = new List<string>();
            if (arrayQuery != null)
            {
                if (arrayQuery.Count == 0)
                {
                    _queryParameters.Add(string.Format("arrayQuery={0}", System.Uri.EscapeDataString(string.Empty)));
                }
                else
                {
                    foreach (var _item in arrayQuery)
                    {
                        _queryParameters.Add(string.Format("arrayQuery={0}", System.Uri.EscapeDataString("" + _item)));
                    }
                }
            }
            if (_queryParameters.Count > 0)
            {
                _url += "?" + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
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
                    await HandleDefaultErrorResponseForArrayStringMultiEmpty(_httpRequest, _httpResponse, (int)_statusCode);
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                catch(RestExceptionBase ex)
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
        /// <exception cref="ErrorException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleDefaultErrorResponseForArrayStringMultiEmpty(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            await HandleErrorResponseForArrayStringMultiEmpty<Error>(_httpRequest, _httpResponse, statusCode, Client.DeserializationSettings);
        }

        /// <summary>
        /// Method that generates error message for status code
        /// </summary>
        private string GetErrorMessageForArrayStringMultiEmpty(int statusCode)
        {
            return string.Format("Operation ArrayStringMultiEmpty returned status code: '{0}'", statusCode);
        }

        /// <summary>
        /// Handle error responses, deserialize errors of types V and throw exceptions of type T
        /// </summary>
        private async Task HandleErrorResponseForArrayStringMultiEmpty<V>(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode, JsonSerializerSettings deserializationSettings)
            where V : IRestErrorModel
        {
            string errorMessage = GetErrorMessageForArrayStringMultiEmpty(statusCode);
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
                        throw new RestException<V>(errorMessage, new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()), new HttpResponseMessageWrapper(_httpResponse, _responseContent));
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                    throw new RestException<V>(errorMessage, new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()), new HttpResponseMessageWrapper(_httpResponse, _responseContent));
                }
            }
            _httpRequest.Dispose();
            if (_httpResponse != null)
            {
                _httpResponse.Dispose();
            }
        }

        /// <summary>
        /// Get an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' ,
        /// null, ''] using the mult-array format
        /// </summary>
        /// <param name='arrayQuery'>
        /// an array of string ['ArrayQuery1', 'begin!*'();:@ &amp;=+$,/?#[]end' ,
        /// null, ''] using the mult-array format
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
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse> ArrayStringMultiValidWithHttpMessagesAsync(IList<string> arrayQuery = default(IList<string>), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("arrayQuery", arrayQuery);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "ArrayStringMultiValid", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "queries/array/multi/string/valid").ToString();
            List<string> _queryParameters = new List<string>();
            if (arrayQuery != null)
            {
                if (arrayQuery.Count == 0)
                {
                    _queryParameters.Add(string.Format("arrayQuery={0}", System.Uri.EscapeDataString(string.Empty)));
                }
                else
                {
                    foreach (var _item in arrayQuery)
                    {
                        _queryParameters.Add(string.Format("arrayQuery={0}", System.Uri.EscapeDataString("" + _item)));
                    }
                }
            }
            if (_queryParameters.Count > 0)
            {
                _url += "?" + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
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
                    await HandleDefaultErrorResponseForArrayStringMultiValid(_httpRequest, _httpResponse, (int)_statusCode);
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                catch(RestExceptionBase ex)
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
        /// <exception cref="ErrorException">
        /// Deserialize error body returned by the operation
        /// </exception>
        private async Task HandleDefaultErrorResponseForArrayStringMultiValid(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode)
        {
            await HandleErrorResponseForArrayStringMultiValid<Error>(_httpRequest, _httpResponse, statusCode, Client.DeserializationSettings);
        }

        /// <summary>
        /// Method that generates error message for status code
        /// </summary>
        private string GetErrorMessageForArrayStringMultiValid(int statusCode)
        {
            return string.Format("Operation ArrayStringMultiValid returned status code: '{0}'", statusCode);
        }

        /// <summary>
        /// Handle error responses, deserialize errors of types V and throw exceptions of type T
        /// </summary>
        private async Task HandleErrorResponseForArrayStringMultiValid<V>(HttpRequestMessage _httpRequest, HttpResponseMessage _httpResponse, int statusCode, JsonSerializerSettings deserializationSettings)
            where V : IRestErrorModel
        {
            string errorMessage = GetErrorMessageForArrayStringMultiValid(statusCode);
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
                        throw new RestException<V>(errorMessage, new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()), new HttpResponseMessageWrapper(_httpResponse, _responseContent));
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                    throw new RestException<V>(errorMessage, new HttpRequestMessageWrapper(_httpRequest, _httpRequest.Content.AsString()), new HttpResponseMessageWrapper(_httpResponse, _responseContent));
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
