// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using TypeSpec.Versioning.Latest.Models;

namespace TypeSpec.Versioning.Latest
{
    // Data plane generated sub-client.
    /// <summary> The VersioningOp sub-client. </summary>
    public partial class VersioningOp
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of VersioningOp for mocking. </summary>
        protected VersioningOp()
        {
        }

        /// <summary> Initializes a new instance of VersioningOp. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> Service host. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        internal VersioningOp(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }

        /// <summary> Resource list operation template. </summary>
        /// <param name="select"> Select the specified fields to be included in the response. </param>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='GetResourcesAsync(IEnumerable{string},string,CancellationToken)']/*" />
        public virtual AsyncPageable<Models.Resource> GetResourcesAsync(IEnumerable<string> select = null, string filter = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetResourcesRequest(select, filter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetResourcesNextPageRequest(nextLink, select, filter, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => Models.Resource.DeserializeResource(e), ClientDiagnostics, _pipeline, "VersioningOp.GetResources", "value", "nextLink", context);
        }

        /// <summary> Resource list operation template. </summary>
        /// <param name="select"> Select the specified fields to be included in the response. </param>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='GetResources(IEnumerable{string},string,CancellationToken)']/*" />
        public virtual Pageable<Models.Resource> GetResources(IEnumerable<string> select = null, string filter = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetResourcesRequest(select, filter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetResourcesNextPageRequest(nextLink, select, filter, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => Models.Resource.DeserializeResource(e), ClientDiagnostics, _pipeline, "VersioningOp.GetResources", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Resource list operation template.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetResourcesAsync(IEnumerable{string},string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="select"> Select the specified fields to be included in the response. </param>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='GetResourcesAsync(IEnumerable{string},string,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetResourcesAsync(IEnumerable<string> select, string filter, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetResourcesRequest(select, filter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetResourcesNextPageRequest(nextLink, select, filter, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "VersioningOp.GetResources", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Resource list operation template.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetResources(IEnumerable{string},string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="select"> Select the specified fields to be included in the response. </param>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='GetResources(IEnumerable{string},string,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetResources(IEnumerable<string> select, string filter, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetResourcesRequest(select, filter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetResourcesNextPageRequest(nextLink, select, filter, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "VersioningOp.GetResources", "value", "nextLink", context);
        }

        /// <summary> Long-running resource action operation template. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="projectFileVersion"> The <see cref="string"/> to use. </param>
        /// <param name="projectedFileFormat"> The <see cref="string"/> to use. </param>
        /// <param name="maxLines"> The <see cref="int"/>? to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='ExportAsync(WaitUntil,string,string,string,int?,CancellationToken)']/*" />
        public virtual async Task<Operation<ExportedResource>> ExportAsync(WaitUntil waitUntil, string name, string projectFileVersion = null, string projectedFileFormat = null, int? maxLines = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = await ExportAsync(waitUntil, name, projectFileVersion, projectedFileFormat, maxLines, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, FetchExportedResourceFromResourceOperationStatusResourceExportedResourceError, ClientDiagnostics, "VersioningOp.Export");
        }

        /// <summary> Long-running resource action operation template. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="projectFileVersion"> The <see cref="string"/> to use. </param>
        /// <param name="projectedFileFormat"> The <see cref="string"/> to use. </param>
        /// <param name="maxLines"> The <see cref="int"/>? to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='Export(WaitUntil,string,string,string,int?,CancellationToken)']/*" />
        public virtual Operation<ExportedResource> Export(WaitUntil waitUntil, string name, string projectFileVersion = null, string projectedFileFormat = null, int? maxLines = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = Export(waitUntil, name, projectFileVersion, projectedFileFormat, maxLines, context);
            return ProtocolOperationHelpers.Convert(response, FetchExportedResourceFromResourceOperationStatusResourceExportedResourceError, ClientDiagnostics, "VersioningOp.Export");
        }

        /// <summary>
        /// [Protocol Method] Long-running resource action operation template.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ExportAsync(WaitUntil,string,string,string,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="projectFileVersion"> The <see cref="string"/> to use. </param>
        /// <param name="projectedFileFormat"> The <see cref="string"/> to use. </param>
        /// <param name="maxLines"> The <see cref="int"/>? to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='ExportAsync(WaitUntil,string,string,string,int?,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> ExportAsync(WaitUntil waitUntil, string name, string projectFileVersion, string projectedFileFormat, int? maxLines, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("VersioningOp.Export");
            scope.Start();
            try
            {
                using HttpMessage message = CreateExportRequest(name, projectFileVersion, projectedFileFormat, maxLines, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "VersioningOp.Export", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long-running resource action operation template.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Export(WaitUntil,string,string,string,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="projectFileVersion"> The <see cref="string"/> to use. </param>
        /// <param name="projectedFileFormat"> The <see cref="string"/> to use. </param>
        /// <param name="maxLines"> The <see cref="int"/>? to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='Export(WaitUntil,string,string,string,int?,RequestContext)']/*" />
        public virtual Operation<BinaryData> Export(WaitUntil waitUntil, string name, string projectFileVersion, string projectedFileFormat, int? maxLines, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = ClientDiagnostics.CreateScope("VersioningOp.Export");
            scope.Start();
            try
            {
                using HttpMessage message = CreateExportRequest(name, projectFileVersion, projectedFileFormat, maxLines, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "VersioningOp.Export", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long-running resource create or replace operation template. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="resource"> The resource instance. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="resource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='CreateLongRunningAsync(WaitUntil,string,Resource,CancellationToken)']/*" />
        public virtual async Task<Operation<Models.Resource>> CreateLongRunningAsync(WaitUntil waitUntil, string name, Models.Resource resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(resource, nameof(resource));

            using RequestContent content = resource.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = await CreateLongRunningAsync(waitUntil, name, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, Models.Resource.FromResponse, ClientDiagnostics, "VersioningOp.CreateLongRunning");
        }

        /// <summary> Long-running resource create or replace operation template. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="resource"> The resource instance. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="resource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='CreateLongRunning(WaitUntil,string,Resource,CancellationToken)']/*" />
        public virtual Operation<Models.Resource> CreateLongRunning(WaitUntil waitUntil, string name, Models.Resource resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(resource, nameof(resource));

            using RequestContent content = resource.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = CreateLongRunning(waitUntil, name, content, context);
            return ProtocolOperationHelpers.Convert(response, Models.Resource.FromResponse, ClientDiagnostics, "VersioningOp.CreateLongRunning");
        }

        /// <summary>
        /// [Protocol Method] Long-running resource create or replace operation template.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateLongRunningAsync(WaitUntil,string,Models.Resource,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='CreateLongRunningAsync(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> CreateLongRunningAsync(WaitUntil waitUntil, string name, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("VersioningOp.CreateLongRunning");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateLongRunningRequest(name, content, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "VersioningOp.CreateLongRunning", OperationFinalStateVia.OriginalUri, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Long-running resource create or replace operation template.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateLongRunning(WaitUntil,string,Models.Resource,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> The <see cref="string"/> to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/VersioningOp.xml" path="doc/members/member[@name='CreateLongRunning(WaitUntil,string,RequestContent,RequestContext)']/*" />
        public virtual Operation<BinaryData> CreateLongRunning(WaitUntil waitUntil, string name, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("VersioningOp.CreateLongRunning");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateLongRunningRequest(name, content, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "VersioningOp.CreateLongRunning", OperationFinalStateVia.OriginalUri, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateExportRequest(string name, string projectFileVersion, string projectedFileFormat, int? maxLines, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/versioning/resources/", false);
            uri.AppendPath(name, true);
            uri.AppendPath(":export", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (projectFileVersion != null)
            {
                uri.AppendQuery("projectFileVersion", projectFileVersion, true);
            }
            if (projectedFileFormat != null)
            {
                uri.AppendQuery("projectedFileFormat", projectedFileFormat, true);
            }
            if (maxLines != null)
            {
                uri.AppendQuery("maxLines", maxLines.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetResourcesRequest(IEnumerable<string> select, string filter, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/versioning/resources", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (select != null && !(select is ChangeTrackingList<string> changeTrackingList && changeTrackingList.IsUndefined))
            {
                foreach (var param in select)
                {
                    uri.AppendQuery("select", param, true);
                }
            }
            if (filter != null)
            {
                uri.AppendQuery("filter", filter, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateCreateLongRunningRequest(string name, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/versioning/resources/", false);
            uri.AppendPath(name, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetResourcesNextPageRequest(string nextLink, IEnumerable<string> select, string filter, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }

        private static ResponseClassifier _responseClassifier202;
        private static ResponseClassifier ResponseClassifier202 => _responseClassifier202 ??= new StatusCodeClassifier(stackalloc ushort[] { 202 });
        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier200201;
        private static ResponseClassifier ResponseClassifier200201 => _responseClassifier200201 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 201 });

        private ExportedResource FetchExportedResourceFromResourceOperationStatusResourceExportedResourceError(Response response)
        {
            var resultJsonElement = JsonDocument.Parse(response.Content).RootElement.GetProperty("result");
            return ExportedResource.DeserializeExportedResource(resultJsonElement);
        }
    }
}
