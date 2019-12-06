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
        public static async ValueTask<Response> GetAllWithValuesAsync(HttpPipeline pipeline, string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath("globalStringPath", true);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath.ToString()!, true);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath.ToString()!, true);
                request.Uri.AppendPath("/globalStringQuery/pathItemStringQuery/localStringQuery", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery.ToString()!, true);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery.ToString()!, true);
                }
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch
            {
                throw;
            }
        }
        public static async ValueTask<Response> GetGlobalQueryNullAsync(HttpPipeline pipeline, string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath("globalStringPath", true);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath.ToString()!, true);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath.ToString()!, true);
                request.Uri.AppendPath("/null/pathItemStringQuery/localStringQuery", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery.ToString()!, true);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery.ToString()!, true);
                }
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch
            {
                throw;
            }
        }
        public static async ValueTask<Response> GetGlobalAndLocalQueryNullAsync(HttpPipeline pipeline, string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath("globalStringPath", true);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath.ToString()!, true);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath.ToString()!, true);
                request.Uri.AppendPath("/null/pathItemStringQuery/null", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery.ToString()!, true);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery.ToString()!, true);
                }
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch
            {
                throw;
            }
        }
        public static async ValueTask<Response> GetLocalPathItemQueryNullAsync(HttpPipeline pipeline, string pathItemStringPath, string? pathItemStringQuery, string localStringPath, string? localStringQuery, string host = "http://localhost:3000", CancellationToken cancellationToken = default)
        {
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/pathitem/nullable/globalStringPath/", false);
                request.Uri.AppendPath("globalStringPath", true);
                request.Uri.AppendPath("/pathItemStringPath/", false);
                request.Uri.AppendPath(pathItemStringPath.ToString()!, true);
                request.Uri.AppendPath("/localStringPath/", false);
                request.Uri.AppendPath(localStringPath.ToString()!, true);
                request.Uri.AppendPath("/globalStringQuery/null/null", false);
                if (pathItemStringQuery != null)
                {
                    request.Uri.AppendQuery("pathItemStringQuery", pathItemStringQuery.ToString()!, true);
                }
                if (localStringQuery != null)
                {
                    request.Uri.AppendQuery("localStringQuery", localStringQuery.ToString()!, true);
                }
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
