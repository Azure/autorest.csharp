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
    internal partial class PathItemsOperations
    {
        private string globalStringPath;
        private string globalStringQuery;
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of PathItemsOperations. </summary>
        public PathItemsOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string globalStringPath, string globalStringQuery, string host = "http://localhost:3000")
        {
            if (globalStringPath == null)
            {
                throw new ArgumentNullException(nameof(globalStringPath));
            }
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.globalStringPath = globalStringPath;
            this.globalStringQuery = globalStringQuery;
            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetAllWithValuesRequest(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/globalStringQuery/pathItemStringQuery/localStringQuery", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetAllWithValuesAsync(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathItemsOperations.GetAllWithValues");
            scope.Start();
            try
            {
                using var message = CreateGetAllWithValuesRequest(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetAllWithValues(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathItemsOperations.GetAllWithValues");
            scope.Start();
            try
            {
                using var message = CreateGetAllWithValuesRequest(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetGlobalQueryNullRequest(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/null/pathItemStringQuery/localStringQuery", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetGlobalQueryNullAsync(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathItemsOperations.GetGlobalQueryNull");
            scope.Start();
            try
            {
                using var message = CreateGetGlobalQueryNullRequest(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=&apos;localStringQuery&apos;. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetGlobalQueryNull(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathItemsOperations.GetGlobalQueryNull");
            scope.Start();
            try
            {
                using var message = CreateGetGlobalQueryNullRequest(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetGlobalAndLocalQueryNullRequest(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/null/pathItemStringQuery/null", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> send globalStringPath=globalStringPath, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetGlobalAndLocalQueryNullAsync(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathItemsOperations.GetGlobalAndLocalQueryNull");
            scope.Start();
            try
            {
                using var message = CreateGetGlobalAndLocalQueryNullRequest(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> send globalStringPath=globalStringPath, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=null, pathItemStringQuery=&apos;pathItemStringQuery&apos;, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetGlobalAndLocalQueryNull(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathItemsOperations.GetGlobalAndLocalQueryNull");
            scope.Start();
            try
            {
                using var message = CreateGetGlobalAndLocalQueryNullRequest(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetLocalPathItemQueryNullRequest(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
            uri.AppendPath(globalStringPath, true);
            uri.AppendPath("/pathItemStringPath/", false);
            uri.AppendPath(pathItemStringPath, true);
            uri.AppendPath("/localStringPath/", false);
            uri.AppendPath(localStringPath, true);
            uri.AppendPath("/globalStringQuery/null/null", false);
            if (pathItemStringQuery != null)
            {
                uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
            }
            if (globalStringQuery != null)
            {
                uri.AppendQuery("globalStringQuery", globalStringQuery, true);
            }
            if (localStringQuery != null)
            {
                uri.AppendQuery("localStringQuery", localStringQuery, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=null, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetLocalPathItemQueryNullAsync(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathItemsOperations.GetLocalPathItemQueryNull");
            scope.Start();
            try
            {
                using var message = CreateGetLocalPathItemQueryNullRequest(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> send globalStringPath=&apos;globalStringPath&apos;, pathItemStringPath=&apos;pathItemStringPath&apos;, localStringPath=&apos;localStringPath&apos;, globalStringQuery=&apos;globalStringQuery&apos;, pathItemStringQuery=null, localStringQuery=null. </summary>
        /// <param name="pathItemStringPath"> A string value &apos;pathItemStringPath&apos; that appears in the path. </param>
        /// <param name="pathItemStringQuery"> A string value &apos;pathItemStringQuery&apos; that appears as a query parameter. </param>
        /// <param name="localStringPath"> should contain value &apos;localStringPath&apos;. </param>
        /// <param name="localStringQuery"> should contain value &apos;localStringQuery&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetLocalPathItemQueryNull(string pathItemStringPath, string pathItemStringQuery, string localStringPath, string localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("PathItemsOperations.GetLocalPathItemQueryNull");
            scope.Start();
            try
            {
                using var message = CreateGetLocalPathItemQueryNullRequest(pathItemStringPath, pathItemStringQuery, localStringPath, localStringQuery);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
