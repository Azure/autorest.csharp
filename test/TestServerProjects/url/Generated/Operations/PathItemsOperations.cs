// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        private string? globalStringQuery;
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        public PathItemsOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string globalStringPath, string? globalStringQuery, string host = "http://localhost:3000")
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
        public async ValueTask<Response> GetAllWithValuesAsync(string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("url.GetAllWithValues");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath(globalStringPath, true);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath, true);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath, true);
                request.Uri.AppendPath("/globalStringQuery/pathItemStringQuery/localStringQuery", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
                }
                if (globalStringQuery != null)
                {
                    request.Uri.AppendQuery("globalStringQuery", globalStringQuery, true);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery, true);
                }
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> GetGlobalQueryNullAsync(string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("url.GetGlobalQueryNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath(globalStringPath, true);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath, true);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath, true);
                request.Uri.AppendPath("/null/pathItemStringQuery/localStringQuery", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
                }
                if (globalStringQuery != null)
                {
                    request.Uri.AppendQuery("globalStringQuery", globalStringQuery, true);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery, true);
                }
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> GetGlobalAndLocalQueryNullAsync(string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("url.GetGlobalAndLocalQueryNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath(globalStringPath, true);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath, true);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath, true);
                request.Uri.AppendPath("/null/pathItemStringQuery/null", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
                }
                if (globalStringQuery != null)
                {
                    request.Uri.AppendQuery("globalStringQuery", globalStringQuery, true);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery, true);
                }
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> GetLocalPathItemQueryNullAsync(string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, CancellationToken cancellationToken = default)
        {
            if (pathItemStringPath == null)
            {
                throw new ArgumentNullException(nameof(pathItemStringPath));
            }
            if (localStringPath == null)
            {
                throw new ArgumentNullException(nameof(localStringPath));
            }

            using var scope = clientDiagnostics.CreateScope("url.GetLocalPathItemQueryNull");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath(globalStringPath, true);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath, true);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath, true);
                request.Uri.AppendPath("/globalStringQuery/null/null", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery, true);
                }
                if (globalStringQuery != null)
                {
                    request.Uri.AppendQuery("globalStringQuery", globalStringQuery, true);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery, true);
                }
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
