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
    internal partial class FakePolicyAssignmentsRestOperations
    {
        private readonly TelemetryDetails _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of FakePolicyAssignmentsRestOperations. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pipeline"/> or <paramref name="apiVersion"/> is null. </exception>
        public FakePolicyAssignmentsRestOperations(HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2020-09-01";
            _userAgent = new TelemetryDetails(GetType().Assembly, applicationId);
        }

        internal Azure.Core.HttpMessage CreateDeleteRequest(string scope, string policyAssignmentName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(scope, false);
            uri.AppendPath("/providers/Microsoft.Authorization/policyAssignments/", false);
            uri.AppendPath(policyAssignmentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> This operation deletes a policy assignment, given its name and the scope it was created in. The scope of a policy assignment is the part of its ID preceding '/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'. </summary>
        /// <param name="scope"> The scope of the policy assignment. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="policyAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakePolicyAssignmentData>> DeleteAsync(string scope, string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));

            using var message = CreateDeleteRequest(scope, policyAssignmentName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((FakePolicyAssignmentData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> This operation deletes a policy assignment, given its name and the scope it was created in. The scope of a policy assignment is the part of its ID preceding '/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'. </summary>
        /// <param name="scope"> The scope of the policy assignment. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="policyAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakePolicyAssignmentData> Delete(string scope, string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));

            using var message = CreateDeleteRequest(scope, policyAssignmentName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 204:
                    return Response.FromValue((FakePolicyAssignmentData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateCreateRequest(string scope, string policyAssignmentName, FakePolicyAssignmentData data)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(scope, false);
            uri.AppendPath("/providers/Microsoft.Authorization/policyAssignments/", false);
            uri.AppendPath(policyAssignmentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> This operation creates or updates a policy assignment with the given scope and name. Policy assignments apply to all resources contained within their scope. For example, when you assign a policy at resource group scope, that policy applies to all resources in the group. </summary>
        /// <param name="scope"> The scope of the policy assignment. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment. </param>
        /// <param name="data"> Parameters for the policy assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/>, <paramref name="policyAssignmentName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakePolicyAssignmentData>> CreateAsync(string scope, string policyAssignmentName, FakePolicyAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateRequest(scope, policyAssignmentName, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        FakePolicyAssignmentData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> This operation creates or updates a policy assignment with the given scope and name. Policy assignments apply to all resources contained within their scope. For example, when you assign a policy at resource group scope, that policy applies to all resources in the group. </summary>
        /// <param name="scope"> The scope of the policy assignment. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment. </param>
        /// <param name="data"> Parameters for the policy assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/>, <paramref name="policyAssignmentName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakePolicyAssignmentData> Create(string scope, string policyAssignmentName, FakePolicyAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateCreateRequest(scope, policyAssignmentName, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    {
                        FakePolicyAssignmentData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateGetRequest(string scope, string policyAssignmentName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(scope, false);
            uri.AppendPath("/providers/Microsoft.Authorization/policyAssignments/", false);
            uri.AppendPath(policyAssignmentName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> This operation retrieves a single policy assignment, given its name and the scope it was created at. </summary>
        /// <param name="scope"> The scope of the policy assignment. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="policyAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakePolicyAssignmentData>> GetAsync(string scope, string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));

            using var message = CreateGetRequest(scope, policyAssignmentName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((FakePolicyAssignmentData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> This operation retrieves a single policy assignment, given its name and the scope it was created at. </summary>
        /// <param name="scope"> The scope of the policy assignment. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="policyAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakePolicyAssignmentData> Get(string scope, string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(policyAssignmentName, nameof(policyAssignmentName));

            using var message = CreateGetRequest(scope, policyAssignmentName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakePolicyAssignmentData.DeserializeFakePolicyAssignmentData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((FakePolicyAssignmentData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateListForResourceGroupRequest(string subscriptionId, string resourceGroupName, string filter, int? top)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Authorization/policyAssignments", false);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, false);
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

        /// <summary> This operation retrieves the list of all policy assignments associated with the given resource group in the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource group, including those that apply directly or apply from containing scopes, as well as any applied to resources contained within the resource group. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource group, which is everything in the unfiltered list except those applied to resources contained within the resource group. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource group. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group that contains policy assignments. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakePolicyAssignmentListResult>> ListForResourceGroupAsync(string subscriptionId, string resourceGroupName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var message = CreateListForResourceGroupRequest(subscriptionId, resourceGroupName, filter, top);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> This operation retrieves the list of all policy assignments associated with the given resource group in the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource group, including those that apply directly or apply from containing scopes, as well as any applied to resources contained within the resource group. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource group, which is everything in the unfiltered list except those applied to resources contained within the resource group. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource group. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group that contains policy assignments. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakePolicyAssignmentListResult> ListForResourceGroup(string subscriptionId, string resourceGroupName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var message = CreateListForResourceGroupRequest(subscriptionId, resourceGroupName, filter, top);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateListForResourceRequest(string subscriptionId, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter, int? top)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/", false);
            uri.AppendPath(resourceProviderNamespace, true);
            uri.AppendPath("/", false);
            uri.AppendPath(parentResourcePath, false);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceType, false);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceName, true);
            uri.AppendPath("/providers/Microsoft.Authorization/policyAssignments", false);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, false);
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

        /// <summary> This operation retrieves the list of all policy assignments associated with the specified resource in the given resource group and subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource, including those that apply directly or from all containing scopes, as well as any applied to resources contained within the resource. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource, which is everything in the unfiltered list except those applied to resources contained within the resource. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource level. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource. Three parameters plus the resource name are used to identify a specific resource. If the resource is not part of a parent resource (the more common case), the parent resource path should not be provided (or provided as ''). For example a web app could be specified as ({resourceProviderNamespace} == 'Microsoft.Web', {parentResourcePath} == '', {resourceType} == 'sites', {resourceName} == 'MyWebApp'). If the resource is part of a parent resource, then all parameters should be provided. For example a virtual machine DNS name could be specified as ({resourceProviderNamespace} == 'Microsoft.Compute', {parentResourcePath} == 'virtualMachines/MyVirtualMachine', {resourceType} == 'domainNames', {resourceName} == 'MyComputerName'). A convenient alternative to providing the namespace and type name separately is to provide both in the {resourceType} parameter, format: ({resourceProviderNamespace} == '', {parentResourcePath} == '', {resourceType} == 'Microsoft.Web/sites', {resourceName} == 'MyWebApp'). </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group containing the resource. </param>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines). </param>
        /// <param name="parentResourcePath"> The parent resource path. Use empty string if there is none. </param>
        /// <param name="resourceType"> The resource type name. For example the type name of a web app is 'sites' (from Microsoft.Web/sites). </param>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceProviderNamespace"/>, <paramref name="parentResourcePath"/>, <paramref name="resourceType"/> or <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceProviderNamespace"/> or <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakePolicyAssignmentListResult>> ListForResourceAsync(string subscriptionId, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));
            Argument.AssertNotNull(parentResourcePath, nameof(parentResourcePath));
            Argument.AssertNotNull(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using var message = CreateListForResourceRequest(subscriptionId, resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, filter, top);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> This operation retrieves the list of all policy assignments associated with the specified resource in the given resource group and subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource, including those that apply directly or from all containing scopes, as well as any applied to resources contained within the resource. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource, which is everything in the unfiltered list except those applied to resources contained within the resource. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource level. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource. Three parameters plus the resource name are used to identify a specific resource. If the resource is not part of a parent resource (the more common case), the parent resource path should not be provided (or provided as ''). For example a web app could be specified as ({resourceProviderNamespace} == 'Microsoft.Web', {parentResourcePath} == '', {resourceType} == 'sites', {resourceName} == 'MyWebApp'). If the resource is part of a parent resource, then all parameters should be provided. For example a virtual machine DNS name could be specified as ({resourceProviderNamespace} == 'Microsoft.Compute', {parentResourcePath} == 'virtualMachines/MyVirtualMachine', {resourceType} == 'domainNames', {resourceName} == 'MyComputerName'). A convenient alternative to providing the namespace and type name separately is to provide both in the {resourceType} parameter, format: ({resourceProviderNamespace} == '', {parentResourcePath} == '', {resourceType} == 'Microsoft.Web/sites', {resourceName} == 'MyWebApp'). </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group containing the resource. </param>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines). </param>
        /// <param name="parentResourcePath"> The parent resource path. Use empty string if there is none. </param>
        /// <param name="resourceType"> The resource type name. For example the type name of a web app is 'sites' (from Microsoft.Web/sites). </param>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceProviderNamespace"/>, <paramref name="parentResourcePath"/>, <paramref name="resourceType"/> or <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceProviderNamespace"/> or <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakePolicyAssignmentListResult> ListForResource(string subscriptionId, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));
            Argument.AssertNotNull(parentResourcePath, nameof(parentResourcePath));
            Argument.AssertNotNull(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using var message = CreateListForResourceRequest(subscriptionId, resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, filter, top);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateListForManagementGroupRequest(string managementGroupId, string filter, int? top)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(managementGroupId, true);
            uri.AppendPath("/providers/Microsoft.Authorization/policyAssignments", false);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, false);
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

        /// <summary> This operation retrieves the list of all policy assignments applicable to the management group that match the given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter=atScope() is provided, the returned list includes all policy assignments that are assigned to the management group or the management group's ancestors. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the management group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the management group. </summary>
        /// <param name="managementGroupId"> The ID of the management group. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managementGroupId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="managementGroupId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakePolicyAssignmentListResult>> ListForManagementGroupAsync(string managementGroupId, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managementGroupId, nameof(managementGroupId));

            using var message = CreateListForManagementGroupRequest(managementGroupId, filter, top);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> This operation retrieves the list of all policy assignments applicable to the management group that match the given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter=atScope() is provided, the returned list includes all policy assignments that are assigned to the management group or the management group's ancestors. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the management group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the management group. </summary>
        /// <param name="managementGroupId"> The ID of the management group. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managementGroupId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="managementGroupId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakePolicyAssignmentListResult> ListForManagementGroup(string managementGroupId, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(managementGroupId, nameof(managementGroupId));

            using var message = CreateListForManagementGroupRequest(managementGroupId, filter, top);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateListRequest(string subscriptionId, string filter, int? top)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Authorization/policyAssignments", false);
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, false);
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

        /// <summary> This operation retrieves the list of all policy assignments associated with the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the subscription, including those that apply directly or from management groups that contain the given subscription, as well as any applied to objects contained within the subscription. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the subscription, which is everything in the unfiltered list except those applied to objects contained within the subscription. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the subscription. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakePolicyAssignmentListResult>> ListAsync(string subscriptionId, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListRequest(subscriptionId, filter, top);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> This operation retrieves the list of all policy assignments associated with the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the subscription, including those that apply directly or from management groups that contain the given subscription, as well as any applied to objects contained within the subscription. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the subscription, which is everything in the unfiltered list except those applied to objects contained within the subscription. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the subscription. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakePolicyAssignmentListResult> List(string subscriptionId, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListRequest(subscriptionId, filter, top);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateListForResourceGroupNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string filter, int? top)
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

        /// <summary> This operation retrieves the list of all policy assignments associated with the given resource group in the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource group, including those that apply directly or apply from containing scopes, as well as any applied to resources contained within the resource group. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource group, which is everything in the unfiltered list except those applied to resources contained within the resource group. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group that contains policy assignments. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakePolicyAssignmentListResult>> ListForResourceGroupNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var message = CreateListForResourceGroupNextPageRequest(nextLink, subscriptionId, resourceGroupName, filter, top);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> This operation retrieves the list of all policy assignments associated with the given resource group in the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource group, including those that apply directly or apply from containing scopes, as well as any applied to resources contained within the resource group. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource group, which is everything in the unfiltered list except those applied to resources contained within the resource group. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group that contains policy assignments. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> or <paramref name="resourceGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakePolicyAssignmentListResult> ListForResourceGroupNextPage(string nextLink, string subscriptionId, string resourceGroupName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));

            using var message = CreateListForResourceGroupNextPageRequest(nextLink, subscriptionId, resourceGroupName, filter, top);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateListForResourceNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter, int? top)
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

        /// <summary> This operation retrieves the list of all policy assignments associated with the specified resource in the given resource group and subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource, including those that apply directly or from all containing scopes, as well as any applied to resources contained within the resource. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource, which is everything in the unfiltered list except those applied to resources contained within the resource. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource level. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource. Three parameters plus the resource name are used to identify a specific resource. If the resource is not part of a parent resource (the more common case), the parent resource path should not be provided (or provided as ''). For example a web app could be specified as ({resourceProviderNamespace} == 'Microsoft.Web', {parentResourcePath} == '', {resourceType} == 'sites', {resourceName} == 'MyWebApp'). If the resource is part of a parent resource, then all parameters should be provided. For example a virtual machine DNS name could be specified as ({resourceProviderNamespace} == 'Microsoft.Compute', {parentResourcePath} == 'virtualMachines/MyVirtualMachine', {resourceType} == 'domainNames', {resourceName} == 'MyComputerName'). A convenient alternative to providing the namespace and type name separately is to provide both in the {resourceType} parameter, format: ({resourceProviderNamespace} == '', {parentResourcePath} == '', {resourceType} == 'Microsoft.Web/sites', {resourceName} == 'MyWebApp'). </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group containing the resource. </param>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines). </param>
        /// <param name="parentResourcePath"> The parent resource path. Use empty string if there is none. </param>
        /// <param name="resourceType"> The resource type name. For example the type name of a web app is 'sites' (from Microsoft.Web/sites). </param>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceProviderNamespace"/>, <paramref name="parentResourcePath"/>, <paramref name="resourceType"/> or <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceProviderNamespace"/> or <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakePolicyAssignmentListResult>> ListForResourceNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));
            Argument.AssertNotNull(parentResourcePath, nameof(parentResourcePath));
            Argument.AssertNotNull(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using var message = CreateListForResourceNextPageRequest(nextLink, subscriptionId, resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, filter, top);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> This operation retrieves the list of all policy assignments associated with the specified resource in the given resource group and subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the resource, including those that apply directly or from all containing scopes, as well as any applied to resources contained within the resource. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the resource, which is everything in the unfiltered list except those applied to resources contained within the resource. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the resource level. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the resource. Three parameters plus the resource name are used to identify a specific resource. If the resource is not part of a parent resource (the more common case), the parent resource path should not be provided (or provided as ''). For example a web app could be specified as ({resourceProviderNamespace} == 'Microsoft.Web', {parentResourcePath} == '', {resourceType} == 'sites', {resourceName} == 'MyWebApp'). If the resource is part of a parent resource, then all parameters should be provided. For example a virtual machine DNS name could be specified as ({resourceProviderNamespace} == 'Microsoft.Compute', {parentResourcePath} == 'virtualMachines/MyVirtualMachine', {resourceType} == 'domainNames', {resourceName} == 'MyComputerName'). A convenient alternative to providing the namespace and type name separately is to provide both in the {resourceType} parameter, format: ({resourceProviderNamespace} == '', {parentResourcePath} == '', {resourceType} == 'Microsoft.Web/sites', {resourceName} == 'MyWebApp'). </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="resourceGroupName"> The name of the resource group containing the resource. </param>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines). </param>
        /// <param name="parentResourcePath"> The parent resource path. Use empty string if there is none. </param>
        /// <param name="resourceType"> The resource type name. For example the type name of a web app is 'sites' (from Microsoft.Web/sites). </param>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceProviderNamespace"/>, <paramref name="parentResourcePath"/>, <paramref name="resourceType"/> or <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="resourceProviderNamespace"/> or <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakePolicyAssignmentListResult> ListForResourceNextPage(string nextLink, string subscriptionId, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(resourceProviderNamespace, nameof(resourceProviderNamespace));
            Argument.AssertNotNull(parentResourcePath, nameof(parentResourcePath));
            Argument.AssertNotNull(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using var message = CreateListForResourceNextPageRequest(nextLink, subscriptionId, resourceGroupName, resourceProviderNamespace, parentResourcePath, resourceType, resourceName, filter, top);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateListForManagementGroupNextPageRequest(string nextLink, string managementGroupId, string filter, int? top)
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

        /// <summary> This operation retrieves the list of all policy assignments applicable to the management group that match the given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter=atScope() is provided, the returned list includes all policy assignments that are assigned to the management group or the management group's ancestors. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the management group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the management group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="managementGroupId"> The ID of the management group. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="managementGroupId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="managementGroupId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakePolicyAssignmentListResult>> ListForManagementGroupNextPageAsync(string nextLink, string managementGroupId, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(managementGroupId, nameof(managementGroupId));

            using var message = CreateListForManagementGroupNextPageRequest(nextLink, managementGroupId, filter, top);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> This operation retrieves the list of all policy assignments applicable to the management group that match the given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter=atScope() is provided, the returned list includes all policy assignments that are assigned to the management group or the management group's ancestors. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the management group. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value} that apply to the management group. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="managementGroupId"> The ID of the management group. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="managementGroupId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="managementGroupId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakePolicyAssignmentListResult> ListForManagementGroupNextPage(string nextLink, string managementGroupId, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(managementGroupId, nameof(managementGroupId));

            using var message = CreateListForManagementGroupNextPageRequest(nextLink, managementGroupId, filter, top);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Azure.Core.HttpMessage CreateListNextPageRequest(string nextLink, string subscriptionId, string filter, int? top)
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

        /// <summary> This operation retrieves the list of all policy assignments associated with the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the subscription, including those that apply directly or from management groups that contain the given subscription, as well as any applied to objects contained within the subscription. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the subscription, which is everything in the unfiltered list except those applied to objects contained within the subscription. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the subscription. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<FakePolicyAssignmentListResult>> ListNextPageAsync(string nextLink, string subscriptionId, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListNextPageRequest(nextLink, subscriptionId, filter, top);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> This operation retrieves the list of all policy assignments associated with the given subscription that match the optional given $filter. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, the unfiltered list includes all policy assignments associated with the subscription, including those that apply directly or from management groups that contain the given subscription, as well as any applied to objects contained within the subscription. If $filter=atScope() is provided, the returned list includes all policy assignments that apply to the subscription, which is everything in the unfiltered list except those applied to objects contained within the subscription. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the subscription. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. </param>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope. If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope. If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> or <paramref name="subscriptionId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<FakePolicyAssignmentListResult> ListNextPage(string nextLink, string subscriptionId, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));

            using var message = CreateListNextPageRequest(nextLink, subscriptionId, filter, top);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        FakePolicyAssignmentListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = FakePolicyAssignmentListResult.DeserializeFakePolicyAssignmentListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
