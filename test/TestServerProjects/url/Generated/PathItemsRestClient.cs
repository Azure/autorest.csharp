// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace url
{
    internal partial class PathItemsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _globalStringPath;
        private readonly Uri _endpoint;
        private readonly string _globalStringQuery;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of PathItemsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="globalStringPath"> A string value 'globalItemStringPath' that appears in the path. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="globalStringQuery"> should contain value null. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="globalStringPath"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="globalStringPath"/> is an empty string, and was expected to be non-empty. </exception>
        public PathItemsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string globalStringPath, Uri endpoint = null, string globalStringQuery = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _globalStringPath = globalStringPath ?? throw new ArgumentNullException(nameof(globalStringPath));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
            _globalStringQuery = globalStringQuery;
        }

        internal HttpMessage CreateGetAllWithValuesRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(_globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/globalStringQuery/pathItemStringQuery/localStringQuery", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (_globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", _globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery='globalStringQuery', pathItemStringQuery='pathItemStringQuery', localStringQuery='localStringQuery'. </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value 'localStringQuery'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        public async Task<Response> GetAllWithValuesAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var message = CreateGetAllWithValuesRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery='globalStringQuery', pathItemStringQuery='pathItemStringQuery', localStringQuery='localStringQuery'. </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value 'localStringQuery'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        public Response GetAllWithValues(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var message = CreateGetAllWithValuesRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetGlobalQueryNullRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(_globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/null/pathItemStringQuery/localStringQuery", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (_globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", _globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery=null, pathItemStringQuery='pathItemStringQuery', localStringQuery='localStringQuery'. </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value 'localStringQuery'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        public async Task<Response> GetGlobalQueryNullAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var message = CreateGetGlobalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery=null, pathItemStringQuery='pathItemStringQuery', localStringQuery='localStringQuery'. </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain value 'localStringQuery'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        public Response GetGlobalQueryNull(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var message = CreateGetGlobalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetGlobalAndLocalQueryNullRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(_globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/null/pathItemStringQuery/null", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (_globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", _globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> send globalStringPath=globalStringPath, pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery=null, pathItemStringQuery='pathItemStringQuery', localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain null value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        public async Task<Response> GetGlobalAndLocalQueryNullAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var message = CreateGetGlobalAndLocalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> send globalStringPath=globalStringPath, pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery=null, pathItemStringQuery='pathItemStringQuery', localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> A string value 'pathItemStringQuery' that appears as a query parameter. </param>
        /// <param name="localStringQuery"> should contain null value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        public Response GetGlobalAndLocalQueryNull(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var message = CreateGetGlobalAndLocalQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLocalPathItemQueryNullRequest(string pathItemStringPath, string localStringPath, string pathItemStringQuery, string localStringQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(_globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/globalStringQuery/null/null", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (_globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", _globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery='globalStringQuery', pathItemStringQuery=null, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> should contain value null. </param>
        /// <param name="localStringQuery"> should contain value null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        public async Task<Response> GetLocalPathItemQueryNullAsync(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var message = CreateGetLocalPathItemQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> send globalStringPath='globalStringPath', pathItemStringPath='pathItemStringPath', localStringPath='localStringPath', globalStringQuery='globalStringQuery', pathItemStringQuery=null, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value 'pathItemStringPath' that appears in the path. </param>
        /// <param name="localStringPath"> should contain value 'localStringPath'. </param>
        /// <param name="pathItemStringQuery"> should contain value null. </param>
        /// <param name="localStringQuery"> should contain value null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pathItemStringPath"/> or <paramref name="localStringPath"/> is null. </exception>
        public Response GetLocalPathItemQueryNull(string pathItemStringPath, string localStringPath, string pathItemStringQuery = null, string localStringQuery = null, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var message = CreateGetLocalPathItemQueryNullRequest(pathItemStringPath, localStringPath, pathItemStringQuery, localStringQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
