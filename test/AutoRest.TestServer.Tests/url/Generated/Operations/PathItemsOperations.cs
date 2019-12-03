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
    public static class PathItemsOperations
    {
        public static async ValueTask<Response> GetAllWithValuesAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("url.GetAllWithValues");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath("globalStringPath", false);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath.ToString()!);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath.ToString()!);
                request.Uri.AppendPath("/globalStringQuery/pathItemStringQuery/localStringQuery", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery.ToString()!);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery.ToString()!);
                }
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public static async ValueTask<Response> GetGlobalQueryNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("url.GetGlobalQueryNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath("globalStringPath", false);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath.ToString()!);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath.ToString()!);
                request.Uri.AppendPath("/null/pathItemStringQuery/localStringQuery", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery.ToString()!);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery.ToString()!);
                }
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public static async ValueTask<Response> GetGlobalAndLocalQueryNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("url.GetGlobalAndLocalQueryNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath("globalStringPath", false);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath.ToString()!);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath.ToString()!);
                request.Uri.AppendPath("/null/pathItemStringQuery/null", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery.ToString()!);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery.ToString()!);
                }
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public static async ValueTask<Response> GetLocalPathItemQueryNullAsync(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("url.GetLocalPathItemQueryNull");
            scope.Start();
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath("globalStringPath", false);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath.ToString()!);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath.ToString()!);
                request.Uri.AppendPath("/globalStringQuery/null/null", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery.ToString()!);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery.ToString()!);
                }
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
