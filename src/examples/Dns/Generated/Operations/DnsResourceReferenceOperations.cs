// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Dns.Models.V20180501;

namespace Azure.Dns.Operations.V20180501
{
    public static class DnsResourceReferenceOperations
    {
        public static async ValueTask<Response<DnsResourceReferenceResult>> GetByTargetResourcesAsync(HttpPipeline pipeline, string apiVersion, string subscriptionId, DnsResourceReferenceRequest parameters, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = pipeline.CreateScope("Azure.Dns.Operations.V20180501.GetByTargetResources");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                //request.Uri.Reset();
                request.Uri.AppendQuery("api-version", apiVersion.ToString() ?? string.Empty);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
            throw new Exception();
        }
    }
}
