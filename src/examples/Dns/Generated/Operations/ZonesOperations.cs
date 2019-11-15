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
    public static class ZonesOperations
    {
        public static async ValueTask<Response<Zone>> CreateOrUpdateAsync(HttpPipeline pipeline, string resourceGroupName, string zoneName, string apiVersion, string subscriptionId, Zone parameters, string? ifMatch = default, string? ifNoneMatch = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = pipeline.CreateScope("Azure.Dns.Operations.V20180501.CreateOrUpdate");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Put;
                //request.Uri.Reset();
                if (ifMatch != null) { request.Headers.SetValue("If-Match", ifMatch.ToString() ?? string.Empty); }
                if (ifNoneMatch != null) { request.Headers.SetValue("If-None-Match", ifNoneMatch.ToString() ?? string.Empty); }
                request.Uri.AppendQuery("api-version", apiVersion.ToString() ?? string.Empty);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
            throw new Exception();
        }

        public static async ValueTask<Response<string>> DeleteAsync(HttpPipeline pipeline, string resourceGroupName, string zoneName, string apiVersion, string subscriptionId, string? ifMatch = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = pipeline.CreateScope("Azure.Dns.Operations.V20180501.Delete");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Delete;
                //request.Uri.Reset();
                if (ifMatch != null) { request.Headers.SetValue("If-Match", ifMatch.ToString() ?? string.Empty); }
                request.Uri.AppendQuery("api-version", apiVersion.ToString() ?? string.Empty);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
            throw new Exception();
        }

        public static async ValueTask<Response<Zone>> GetAsync(HttpPipeline pipeline, string resourceGroupName, string zoneName, string apiVersion, string subscriptionId, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = pipeline.CreateScope("Azure.Dns.Operations.V20180501.Get");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
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

        public static async ValueTask<Response<Zone>> UpdateAsync(HttpPipeline pipeline, string resourceGroupName, string zoneName, string apiVersion, string subscriptionId, ZoneUpdate parameters, string? ifMatch = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = pipeline.CreateScope("Azure.Dns.Operations.V20180501.Update");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Patch;
                //request.Uri.Reset();
                if (ifMatch != null) { request.Headers.SetValue("If-Match", ifMatch.ToString() ?? string.Empty); }
                request.Uri.AppendQuery("api-version", apiVersion.ToString() ?? string.Empty);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
            throw new Exception();
        }

        public static async ValueTask<Response<ZoneListResult>> ListByResourceGroupAsync(HttpPipeline pipeline, string resourceGroupName, string apiVersion, string subscriptionId, int? top = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = pipeline.CreateScope("Azure.Dns.Operations.V20180501.ListByResourceGroup");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                //request.Uri.Reset();
                if (top != null) { request.Uri.AppendQuery("$top", top.ToString() ?? string.Empty); }
                request.Uri.AppendQuery("api-version", apiVersion.ToString() ?? string.Empty);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
            throw new Exception();
        }

        public static async ValueTask<Response<ZoneListResult>> ListAsync(HttpPipeline pipeline, string apiVersion, string subscriptionId, int? top = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = pipeline.CreateScope("Azure.Dns.Operations.V20180501.List");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                //request.Uri.Reset();
                if (top != null) { request.Uri.AppendQuery("$top", top.ToString() ?? string.Empty); }
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
