// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Language.Authoring.Models;

namespace Azure.Language.Authoring
{
    // Data plane generated client.
    /// <summary> The Authoring service client. </summary>
    public partial class AuthoringClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of AuthoringClient for mocking. </summary>
        protected AuthoringClient()
        {
        }

        /// <summary> Initializes a new instance of AuthoringClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public AuthoringClient(Uri endpoint) : this(endpoint, new AuthoringClientOptions())
        {
        }

        /// <summary> Initializes a new instance of AuthoringClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public AuthoringClient(Uri endpoint, AuthoringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new AuthoringClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// [Protocol Method] Creates a new project or updates an existing one.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='CreateOrUpdateAsync(string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> CreateOrUpdateAsync(string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.CreateOrUpdate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrUpdateRequest(projectName, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new project or updates an existing one.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='CreateOrUpdate(string,RequestContent,RequestContext)']/*" />
        public virtual Response CreateOrUpdate(string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.CreateOrUpdate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrUpdateRequest(projectName, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the details of a project.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetProjectAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> GetProjectAsync(string projectName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.GetProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetProjectRequest(projectName, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the details of a project.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetProject(string,RequestContext)']/*" />
        public virtual Response GetProject(string projectName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.GetProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetProjectRequest(projectName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Deletes a project.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='DeleteAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> DeleteAsync(string projectName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(projectName, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Deletes a project.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='Delete(string,RequestContext)']/*" />
        public virtual Response Delete(string projectName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(projectName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers a job to export a project's data.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="projectFileVersion"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="projectFileVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='ExportAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> ExportAsync(string projectName, string projectFileVersion, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(projectFileVersion, nameof(projectFileVersion));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.Export");
            scope.Start();
            try
            {
                using HttpMessage message = CreateExportRequest(projectName, projectFileVersion, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers a job to export a project's data.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="projectFileVersion"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="projectFileVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='Export(string,string,RequestContext)']/*" />
        public virtual Response Export(string projectName, string projectFileVersion, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(projectFileVersion, nameof(projectFileVersion));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.Export");
            scope.Start();
            try
            {
                using HttpMessage message = CreateExportRequest(projectName, projectFileVersion, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers a job to export a project's data.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='ImportxAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> ImportxAsync(string projectName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.Importx");
            scope.Start();
            try
            {
                using HttpMessage message = CreateImportxRequest(projectName, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers a job to export a project's data.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='Importx(string,RequestContext)']/*" />
        public virtual Response Importx(string projectName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.Importx");
            scope.Start();
            try
            {
                using HttpMessage message = CreateImportxRequest(projectName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers a training job for a project.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='TrainAsync(string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> TrainAsync(string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.Train");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTrainRequest(projectName, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Triggers a training job for a project.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='Train(string,RequestContent,RequestContext)']/*" />
        public virtual Response Train(string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.Train");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTrainRequest(projectName, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the details of a deployment.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetDeploymentAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetDeploymentAsync(string projectName, string deploymentName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.GetDeployment");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentRequest(projectName, deploymentName, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the details of a deployment.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetDeployment(string,string,RequestContext)']/*" />
        public virtual Response GetDeployment(string projectName, string deploymentName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.GetDeployment");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentRequest(projectName, deploymentName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new deployment or replaces an existing one.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='DeployProjectAsync(string,string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> DeployProjectAsync(string projectName, string deploymentName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.DeployProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeployProjectRequest(projectName, deploymentName, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a new deployment or replaces an existing one.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='DeployProject(string,string,RequestContent,RequestContext)']/*" />
        public virtual Response DeployProject(string projectName, string deploymentName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.DeployProject");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeployProjectRequest(projectName, deploymentName, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Deletes a project deployment.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='DeleteDeploymentAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> DeleteDeploymentAsync(string projectName, string deploymentName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.DeleteDeployment");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteDeploymentRequest(projectName, deploymentName, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Deletes a project deployment.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='DeleteDeployment(string,string,RequestContext)']/*" />
        public virtual Response DeleteDeployment(string projectName, string deploymentName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.DeleteDeployment");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteDeploymentRequest(projectName, deploymentName, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Swaps two existing deployments with each other.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='SwapDeploymentsAsync(string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SwapDeploymentsAsync(string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.SwapDeployments");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSwapDeploymentsRequest(projectName, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Swaps two existing deployments with each other.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='SwapDeployments(string,RequestContent,RequestContext)']/*" />
        public virtual Response SwapDeployments(string projectName, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.SwapDeployments");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSwapDeploymentsRequest(projectName, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the status of an existing deployment job. </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetDeploymentStatusAsync(string,string,string,CancellationToken)']/*" />
        public virtual async Task<Response<DeploymentJob>> GetDeploymentStatusAsync(string projectName, string deploymentName, string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetDeploymentStatusAsync(projectName, deploymentName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(DeploymentJob.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing deployment job. </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetDeploymentStatus(string,string,string,CancellationToken)']/*" />
        public virtual Response<DeploymentJob> GetDeploymentStatus(string projectName, string deploymentName, string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetDeploymentStatus(projectName, deploymentName, jobId, context);
            return Response.FromValue(DeploymentJob.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing deployment job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetDeploymentStatusAsync(string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetDeploymentStatusAsync(string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetDeploymentStatusAsync(string projectName, string deploymentName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.GetDeploymentStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentStatusRequest(projectName, deploymentName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing deployment job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetDeploymentStatus(string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetDeploymentStatus(string,string,string,RequestContext)']/*" />
        public virtual Response GetDeploymentStatus(string projectName, string deploymentName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.GetDeploymentStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetDeploymentStatusRequest(projectName, deploymentName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the status of an existing swap deployment job. </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetSwapDeploymentsStatusAsync(string,string,string,CancellationToken)']/*" />
        public virtual async Task<Response<SwapDeploymentsJob>> GetSwapDeploymentsStatusAsync(string projectName, string deploymentName, string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetSwapDeploymentsStatusAsync(projectName, deploymentName, jobId, context).ConfigureAwait(false);
            return Response.FromValue(SwapDeploymentsJob.FromResponse(response), response);
        }

        /// <summary> Gets the status of an existing swap deployment job. </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetSwapDeploymentsStatus(string,string,string,CancellationToken)']/*" />
        public virtual Response<SwapDeploymentsJob> GetSwapDeploymentsStatus(string projectName, string deploymentName, string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetSwapDeploymentsStatus(projectName, deploymentName, jobId, context);
            return Response.FromValue(SwapDeploymentsJob.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing swap deployment job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetSwapDeploymentsStatusAsync(string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetSwapDeploymentsStatusAsync(string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetSwapDeploymentsStatusAsync(string projectName, string deploymentName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.GetSwapDeploymentsStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSwapDeploymentsStatusRequest(projectName, deploymentName, jobId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the status of an existing swap deployment job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetSwapDeploymentsStatus(string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="deploymentName"> The String to use. </param>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/>, <paramref name="deploymentName"/> or <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetSwapDeploymentsStatus(string,string,string,RequestContext)']/*" />
        public virtual Response GetSwapDeploymentsStatus(string projectName, string deploymentName, string jobId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("AuthoringClient.GetSwapDeploymentsStatus");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetSwapDeploymentsStatusRequest(projectName, deploymentName, jobId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Lists the existing projects.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetProjectsAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetProjectsAsync(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetProjectsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetProjectsNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "AuthoringClient.GetProjects", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Lists the existing projects.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetProjects(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetProjects(RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetProjectsRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetProjectsNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "AuthoringClient.GetProjects", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Lists the existing deployments.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetDeploymentsAsync(string,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetDeploymentsAsync(string projectName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDeploymentsRequest(projectName, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDeploymentsNextPageRequest(nextLink, projectName, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "AuthoringClient.GetDeployments", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Lists the existing deployments.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="projectName"> The String to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetDeployments(string,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetDeployments(string projectName, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetDeploymentsRequest(projectName, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetDeploymentsNextPageRequest(nextLink, projectName, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "AuthoringClient.GetDeployments", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount"> The Int32 to use. </param>
        /// <param name="skip"> The Int32 to use. </param>
        /// <param name="maxpagesize"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetSupportedLanguagesAsync(int?,int?,int?,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetSupportedLanguagesAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSupportedLanguagesRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSupportedLanguagesNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "AuthoringClient.GetSupportedLanguages", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount"> The Int32 to use. </param>
        /// <param name="skip"> The Int32 to use. </param>
        /// <param name="maxpagesize"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetSupportedLanguages(int?,int?,int?,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetSupportedLanguages(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetSupportedLanguagesRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetSupportedLanguagesNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "AuthoringClient.GetSupportedLanguages", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount"> The Int32 to use. </param>
        /// <param name="skip"> The Int32 to use. </param>
        /// <param name="maxpagesize"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetTrainingConfigVersionsAsync(int?,int?,int?,RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetTrainingConfigVersionsAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTrainingConfigVersionsRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTrainingConfigVersionsNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "AuthoringClient.GetTrainingConfigVersions", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount"> The Int32 to use. </param>
        /// <param name="skip"> The Int32 to use. </param>
        /// <param name="maxpagesize"> The Int32 to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/AuthoringClient.xml" path="doc/members/member[@name='GetTrainingConfigVersions(int?,int?,int?,RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetTrainingConfigVersions(int? maxCount = null, int? skip = null, int? maxpagesize = null, RequestContext context = null)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetTrainingConfigVersionsRequest(maxCount, skip, maxpagesize, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetTrainingConfigVersionsNextPageRequest(nextLink, maxCount, skip, maxpagesize, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "AuthoringClient.GetTrainingConfigVersions", "value", "nextLink", context);
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string projectName, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201);
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/merge-patch+json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetProjectRequest(string projectName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDeleteRequest(string projectName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetProjectsRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateExportRequest(string projectName, string projectFileVersion, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendPath(":export", false);
            uri.AppendQuery("projectFileVersion", projectFileVersion, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateImportxRequest(string projectName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendPath(":importx", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateTrainRequest(string projectName, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendPath(":train", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetDeploymentRequest(string projectName, string deploymentName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendPath("/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDeployProjectRequest(string projectName, string deploymentName, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendPath("/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateDeleteDeploymentRequest(string projectName, string deploymentName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendPath("/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDeploymentsRequest(string projectName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendPath("/deployments", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateSwapDeploymentsRequest(string projectName, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendPath("/deployments:swap", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetDeploymentStatusRequest(string projectName, string deploymentName, string jobId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendPath("/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/jobs/", false);
            uri.AppendPath(jobId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSwapDeploymentsStatusRequest(string projectName, string deploymentName, string jobId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/", false);
            uri.AppendPath(projectName, true);
            uri.AppendPath("/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/swap/jobs/", false);
            uri.AppendPath(jobId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSupportedLanguagesRequest(int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/global/languages", false);
            if (maxCount != null)
            {
                uri.AppendQuery("top", maxCount.Value, true);
            }
            if (skip != null)
            {
                uri.AppendQuery("skip", skip.Value, true);
            }
            if (maxpagesize != null)
            {
                uri.AppendQuery("maxpagesize", maxpagesize.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetTrainingConfigVersionsRequest(int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendPath("/authoring/analyze-text/projects/global/training-config-versions", false);
            if (maxCount != null)
            {
                uri.AppendQuery("top", maxCount.Value, true);
            }
            if (skip != null)
            {
                uri.AppendQuery("skip", skip.Value, true);
            }
            if (maxpagesize != null)
            {
                uri.AppendQuery("maxpagesize", maxpagesize.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetProjectsNextPageRequest(string nextLink, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetDeploymentsNextPageRequest(string nextLink, string projectName, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetSupportedLanguagesNextPageRequest(string nextLink, int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetTrainingConfigVersionsNextPageRequest(string nextLink, int? maxCount, int? skip, int? maxpagesize, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/language", false);
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

        private static ResponseClassifier _responseClassifier200201;
        private static ResponseClassifier ResponseClassifier200201 => _responseClassifier200201 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 201 });
        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier202;
        private static ResponseClassifier ResponseClassifier202 => _responseClassifier202 ??= new StatusCodeClassifier(stackalloc ushort[] { 202 });
    }
}
