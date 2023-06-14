// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    internal partial class DeploymentsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of DeploymentsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public DeploymentsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2021-04-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal Azure.Core.HttpMessage CreateDeleteAtScopeRequest(string scope, string deploymentName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(scope, false);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> A template deployment that is currently running cannot be deleted. Deleting a template deployment removes the associated deployment operations. This is an asynchronous operation that returns a status of 202 until the template deployment is successfully deleted. The Location response header contains the URI that is used to obtain the status of the process. While the process is running, a call to the URI in the Location header returns a status of 202. When the process finishes, the URI in the Location header returns a status of 204 on success. If the asynchronous request failed, the URI in the Location header returns an error-level status code. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> DeleteAtScopeAsync(string scope, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var message = CreateDeleteAtScopeRequest(scope, deploymentName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A template deployment that is currently running cannot be deleted. Deleting a template deployment removes the associated deployment operations. This is an asynchronous operation that returns a status of 202 until the template deployment is successfully deleted. The Location response header contains the URI that is used to obtain the status of the process. While the process is running, a call to the URI in the Location header returns a status of 202. When the process finishes, the URI in the Location header returns a status of 204 on success. If the asynchronous request failed, the URI in the Location header returns an error-level status code. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response DeleteAtScope(string scope, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var message = CreateDeleteAtScopeRequest(scope, deploymentName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateCheckExistenceAtScopeRequest(string scope, string deploymentName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(scope, false);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Checks whether the deployment exists. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<bool>> CheckExistenceAtScopeAsync(string scope, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var message = CreateCheckExistenceAtScopeRequest(scope, deploymentName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case int s when s >= 200 && s < 300:
                    {
                        bool value = true;
                        return Response.FromValue(value, message.Response);
                    }
                case int s when s >= 400 && s < 500:
                    {
                        bool value = false;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Checks whether the deployment exists. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<bool> CheckExistenceAtScope(string scope, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var message = CreateCheckExistenceAtScopeRequest(scope, deploymentName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case int s when s >= 200 && s < 300:
                    {
                        bool value = true;
                        return Response.FromValue(value, message.Response);
                    }
                case int s when s >= 400 && s < 500:
                    {
                        bool value = false;
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateCreateOrUpdateAtScopeRequest(string scope, string deploymentName, Deployment deployment)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(scope, false);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(deployment);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> You can provide the template and parameters directly in the request or link to JSON files. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deployment"> Additional parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/>, <paramref name="deploymentName"/> or <paramref name="deployment"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> CreateOrUpdateAtScopeAsync(string scope, string deploymentName, Deployment deployment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deployment, nameof(deployment));

            using var message = CreateCreateOrUpdateAtScopeRequest(scope, deploymentName, deployment);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> You can provide the template and parameters directly in the request or link to JSON files. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deployment"> Additional parameters supplied to the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/>, <paramref name="deploymentName"/> or <paramref name="deployment"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response CreateOrUpdateAtScope(string scope, string deploymentName, Deployment deployment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deployment, nameof(deployment));

            using var message = CreateCreateOrUpdateAtScopeRequest(scope, deploymentName, deployment);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateGetAtScopeRequest(string scope, string deploymentName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(scope, false);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets a deployment. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<DeploymentExtendedData>> GetAtScopeAsync(string scope, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var message = CreateGetAtScopeRequest(scope, deploymentName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DeploymentExtendedData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DeploymentExtendedData.DeserializeDeploymentExtendedData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((DeploymentExtendedData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a deployment. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<DeploymentExtendedData> GetAtScope(string scope, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var message = CreateGetAtScopeRequest(scope, deploymentName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DeploymentExtendedData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DeploymentExtendedData.DeserializeDeploymentExtendedData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((DeploymentExtendedData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateCancelAtScopeRequest(string scope, string deploymentName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(scope, false);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/cancel", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> You can cancel a deployment only if the provisioningState is Accepted or Running. After the deployment is canceled, the provisioningState is set to Canceled. Canceling a template deployment stops the currently running template deployment and leaves the resources partially deployed. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> CancelAtScopeAsync(string scope, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var message = CreateCancelAtScopeRequest(scope, deploymentName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> You can cancel a deployment only if the provisioningState is Accepted or Running. After the deployment is canceled, the provisioningState is set to Canceled. Canceling a template deployment stops the currently running template deployment and leaves the resources partially deployed. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response CancelAtScope(string scope, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var message = CreateCancelAtScopeRequest(scope, deploymentName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateValidateAtScopeRequest(string scope, string deploymentName, Deployment deployment)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(scope, false);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/validate", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(deployment);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Validates whether the specified template is syntactically correct and will be accepted by Azure Resource Manager.. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deployment"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/>, <paramref name="deploymentName"/> or <paramref name="deployment"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> ValidateAtScopeAsync(string scope, string deploymentName, Deployment deployment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deployment, nameof(deployment));

            using var message = CreateValidateAtScopeRequest(scope, deploymentName, deployment);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Validates whether the specified template is syntactically correct and will be accepted by Azure Resource Manager.. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deployment"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/>, <paramref name="deploymentName"/> or <paramref name="deployment"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response ValidateAtScope(string scope, string deploymentName, Deployment deployment, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deployment, nameof(deployment));

            using var message = CreateValidateAtScopeRequest(scope, deploymentName, deployment);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                case 400:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateExportTemplateAtScopeRequest(string scope, string deploymentName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(scope, false);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/exportTemplate", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Exports the template used for specified deployment. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<DeploymentExportResult>> ExportTemplateAtScopeAsync(string scope, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var message = CreateExportTemplateAtScopeRequest(scope, deploymentName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DeploymentExportResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DeploymentExportResult.DeserializeDeploymentExportResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Exports the template used for specified deployment. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="deploymentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<DeploymentExportResult> ExportTemplateAtScope(string scope, string deploymentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));

            using var message = CreateExportTemplateAtScopeRequest(scope, deploymentName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DeploymentExportResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DeploymentExportResult.DeserializeDeploymentExportResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateListAtScopeRequest(string scope, string filter, int? top)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(scope, false);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
            }
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Get all the deployments at the given scope. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="filter"> The filter to apply on the operation. For example, you can use $filter=provisioningState eq '{state}'. </param>
        /// <param name="top"> The number of results to get. If null is passed, returns all deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        public async Task<Response<DeploymentListResult>> ListAtScopeAsync(string scope, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));

            using var message = CreateListAtScopeRequest(scope, filter, top);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DeploymentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DeploymentListResult.DeserializeDeploymentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get all the deployments at the given scope. </summary>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="filter"> The filter to apply on the operation. For example, you can use $filter=provisioningState eq '{state}'. </param>
        /// <param name="top"> The number of results to get. If null is passed, returns all deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        public Response<DeploymentListResult> ListAtScope(string scope, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));

            using var message = CreateListAtScopeRequest(scope, filter, top);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DeploymentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DeploymentListResult.DeserializeDeploymentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateWhatIfAtTenantScopeRequest(string deploymentName, DeploymentWhatIf deploymentWhatIf)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/whatIf", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(deploymentWhatIf);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Returns changes that will be made by the deployment if executed at the scope of the tenant group. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deploymentWhatIf"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> or <paramref name="deploymentWhatIf"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> WhatIfAtTenantScopeAsync(string deploymentName, DeploymentWhatIf deploymentWhatIf, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deploymentWhatIf, nameof(deploymentWhatIf));

            using var message = CreateWhatIfAtTenantScopeRequest(deploymentName, deploymentWhatIf);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Returns changes that will be made by the deployment if executed at the scope of the tenant group. </summary>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deploymentWhatIf"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> or <paramref name="deploymentWhatIf"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response WhatIfAtTenantScope(string deploymentName, DeploymentWhatIf deploymentWhatIf, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deploymentWhatIf, nameof(deploymentWhatIf));

            using var message = CreateWhatIfAtTenantScopeRequest(deploymentName, deploymentWhatIf);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateWhatIfAtManagementGroupScopeRequest(string groupId, string deploymentName, DeploymentWhatIf deploymentWhatIf)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(groupId, true);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/whatIf", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(deploymentWhatIf);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Returns changes that will be made by the deployment if executed at the scope of the management group. </summary>
        /// <param name="groupId"> The management group ID. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deploymentWhatIf"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/>, <paramref name="deploymentName"/> or <paramref name="deploymentWhatIf"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> WhatIfAtManagementGroupScopeAsync(string groupId, string deploymentName, DeploymentWhatIf deploymentWhatIf, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deploymentWhatIf, nameof(deploymentWhatIf));

            using var message = CreateWhatIfAtManagementGroupScopeRequest(groupId, deploymentName, deploymentWhatIf);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Returns changes that will be made by the deployment if executed at the scope of the management group. </summary>
        /// <param name="groupId"> The management group ID. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deploymentWhatIf"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupId"/>, <paramref name="deploymentName"/> or <paramref name="deploymentWhatIf"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupId"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response WhatIfAtManagementGroupScope(string groupId, string deploymentName, DeploymentWhatIf deploymentWhatIf, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deploymentWhatIf, nameof(deploymentWhatIf));

            using var message = CreateWhatIfAtManagementGroupScopeRequest(groupId, deploymentName, deploymentWhatIf);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateWhatIfAtSubscriptionScopeRequest(string subscriptionId, string deploymentName, DeploymentWhatIf deploymentWhatIf)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/whatIf", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(deploymentWhatIf);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Returns changes that will be made by the deployment if executed at the scope of the subscription. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deploymentWhatIf"> Parameters to What If. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="deploymentName"/> or <paramref name="deploymentWhatIf"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> WhatIfAtSubscriptionScopeAsync(string subscriptionId, string deploymentName, DeploymentWhatIf deploymentWhatIf, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deploymentWhatIf, nameof(deploymentWhatIf));

            using var message = CreateWhatIfAtSubscriptionScopeRequest(subscriptionId, deploymentName, deploymentWhatIf);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Returns changes that will be made by the deployment if executed at the scope of the subscription. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deploymentWhatIf"> Parameters to What If. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="deploymentName"/> or <paramref name="deploymentWhatIf"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response WhatIfAtSubscriptionScope(string subscriptionId, string deploymentName, DeploymentWhatIf deploymentWhatIf, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deploymentWhatIf, nameof(deploymentWhatIf));

            using var message = CreateWhatIfAtSubscriptionScopeRequest(subscriptionId, deploymentName, deploymentWhatIf);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateWhatIfRequest(string subscriptionId, string resourceGroupName, string deploymentName, DeploymentWhatIf deploymentWhatIf)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourcegroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/whatIf", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(deploymentWhatIf);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Returns changes that will be made by the deployment if executed at the scope of the resource group. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group the template will be deployed to. The name is case insensitive. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deploymentWhatIf"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="deploymentName"/> or <paramref name="deploymentWhatIf"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response> WhatIfAsync(string subscriptionId, string resourceGroupName, string deploymentName, DeploymentWhatIf deploymentWhatIf, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deploymentWhatIf, nameof(deploymentWhatIf));

            using var message = CreateWhatIfRequest(subscriptionId, resourceGroupName, deploymentName, deploymentWhatIf);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Returns changes that will be made by the deployment if executed at the scope of the resource group. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group the template will be deployed to. The name is case insensitive. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="deploymentWhatIf"> Parameters to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="deploymentName"/> or <paramref name="deploymentWhatIf"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response WhatIf(string subscriptionId, string resourceGroupName, string deploymentName, DeploymentWhatIf deploymentWhatIf, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(deploymentWhatIf, nameof(deploymentWhatIf));

            using var message = CreateWhatIfRequest(subscriptionId, resourceGroupName, deploymentName, deploymentWhatIf);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateCalculateTemplateHashRequest(BinaryData template)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Resources/calculateTemplateHash", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
#if NET6_0_OR_GREATER
				content.JsonWriter.WriteRawValue(template);
#else
            JsonSerializer.Serialize(content.JsonWriter, JsonDocument.Parse(template.ToString()).RootElement);
#endif
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Calculate the hash of the given template. </summary>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> is null. </exception>
        public async Task<Response<TemplateHashResult>> CalculateTemplateHashAsync(BinaryData template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(template, nameof(template));

            using var message = CreateCalculateTemplateHashRequest(template);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TemplateHashResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = TemplateHashResult.DeserializeTemplateHashResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Calculate the hash of the given template. </summary>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> is null. </exception>
        public Response<TemplateHashResult> CalculateTemplateHash(BinaryData template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(template, nameof(template));

            using var message = CreateCalculateTemplateHashRequest(template);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        TemplateHashResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = TemplateHashResult.DeserializeTemplateHashResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateListAtScopeNextPageRequest(string nextLink, string scope, string filter, int? top)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Get all the deployments at the given scope. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="filter"> The filter to apply on the operation. For example, you can use $filter=provisioningState eq '{state}'. </param>
        /// <param name="top"> The number of results to get. If null is passed, returns all deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="scope"/> is null. </exception>
        public async Task<Response<DeploymentListResult>> ListAtScopeNextPageAsync(string nextLink, string scope, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(scope, nameof(scope));

            using var message = CreateListAtScopeNextPageRequest(nextLink, scope, filter, top);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DeploymentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DeploymentListResult.DeserializeDeploymentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get all the deployments at the given scope. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="scope"> The resource scope. </param>
        /// <param name="filter"> The filter to apply on the operation. For example, you can use $filter=provisioningState eq '{state}'. </param>
        /// <param name="top"> The number of results to get. If null is passed, returns all deployments. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="scope"/> is null. </exception>
        public Response<DeploymentListResult> ListAtScopeNextPage(string nextLink, string scope, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNull(scope, nameof(scope));

            using var message = CreateListAtScopeNextPageRequest(nextLink, scope, filter, top);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DeploymentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DeploymentListResult.DeserializeDeploymentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
