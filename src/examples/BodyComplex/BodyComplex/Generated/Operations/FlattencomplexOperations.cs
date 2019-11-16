// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using BodyComplex.Models.V20160229;

namespace BodyComplex.Operations
{
    public static class FlattencomplexOperations
    {
        public static async ValueTask<Response<MyBaseType>> GetValidAsync(Uri uri, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = clientDiagnostics.CreateScope("BodyComplex.Operations.GetValid");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(uri);
                var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(MyBaseType.Deserialize(document.RootElement), response);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
        }
    }
}
