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
    public static class RecordSetsOperations
    {
        public static async ValueTask<Response<RecordSet>> UpdateAsync(HttpPipeline pipeline, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, string apiVersion, string subscriptionId, RecordSet parameters, string? ifMatch = default, CancellationToken cancellationToken = default)
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

        public static async ValueTask<Response<RecordSet>> CreateOrUpdateAsync(HttpPipeline pipeline, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, string apiVersion, string subscriptionId, RecordSet parameters, string? ifMatch = default, string? ifNoneMatch = default, CancellationToken cancellationToken = default)
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

        public static async ValueTask<Response<string>> DeleteAsync(HttpPipeline pipeline, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, string apiVersion, string subscriptionId, string? ifMatch = default, CancellationToken cancellationToken = default)
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

        public static async ValueTask<Response<RecordSet>> GetAsync(HttpPipeline pipeline, string resourceGroupName, string zoneName, string relativeRecordSetName, RecordType recordType, string apiVersion, string subscriptionId, CancellationToken cancellationToken = default)
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

        public static async ValueTask<Response<RecordSetListResult>> ListByTypeAsync(HttpPipeline pipeline, string resourceGroupName, string zoneName, RecordType recordType, string apiVersion, string subscriptionId, int? top = default, string? recordsetnamesuffix = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = pipeline.CreateScope("Azure.Dns.Operations.V20180501.ListByType");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                //request.Uri.Reset();
                if (top != null) { request.Uri.AppendQuery("$top", top.ToString() ?? string.Empty); }
                if (recordsetnamesuffix != null) { request.Uri.AppendQuery("$recordsetnamesuffix", recordsetnamesuffix.ToString() ?? string.Empty); }
                request.Uri.AppendQuery("api-version", apiVersion.ToString() ?? string.Empty);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
            throw new Exception();
        }

        public static async ValueTask<Response<RecordSetListResult>> ListByDnsZoneAsync(HttpPipeline pipeline, string resourceGroupName, string zoneName, string apiVersion, string subscriptionId, int? top = default, string? recordsetnamesuffix = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = pipeline.CreateScope("Azure.Dns.Operations.V20180501.ListByDnsZone");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                //request.Uri.Reset();
                if (top != null) { request.Uri.AppendQuery("$top", top.ToString() ?? string.Empty); }
                if (recordsetnamesuffix != null) { request.Uri.AppendQuery("$recordsetnamesuffix", recordsetnamesuffix.ToString() ?? string.Empty); }
                request.Uri.AppendQuery("api-version", apiVersion.ToString() ?? string.Empty);
            }
            catch
            {
                //scope.Failed(e);
                throw;
            }
            throw new Exception();
        }

        public static async ValueTask<Response<RecordSetListResult>> ListAllByDnsZoneAsync(HttpPipeline pipeline, string resourceGroupName, string zoneName, string apiVersion, string subscriptionId, int? top = default, string? recordsetnamesuffix = default, CancellationToken cancellationToken = default)
        {
            //using ClientDiagnostics scope = pipeline.CreateScope("Azure.Dns.Operations.V20180501.ListAllByDnsZone");
            //scope.AddAttribute("key", name)
            //scope.Start()
            try
            {
                var request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                //request.Uri.Reset();
                if (top != null) { request.Uri.AppendQuery("$top", top.ToString() ?? string.Empty); }
                if (recordsetnamesuffix != null) { request.Uri.AppendQuery("$recordsetnamesuffix", recordsetnamesuffix.ToString() ?? string.Empty); }
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
