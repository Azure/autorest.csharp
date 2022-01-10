// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using XmlDeserialization.Models;

namespace XmlDeserialization
{
    /// <summary> A class representing collection of XmlInstance and their operations over its parent. </summary>
    public partial class XmlInstanceCollection : ArmCollection, IEnumerable<XmlInstance>, IAsyncEnumerable<XmlInstance>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly XmlDeserializationRestOperations _xmlDeserializationRestClient;

        /// <summary> Initializes a new instance of the <see cref="XmlInstanceCollection"/> class for mocking. </summary>
        protected XmlInstanceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="XmlInstanceCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal XmlInstanceCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _xmlDeserializationRestClient = new XmlDeserializationRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: XmlDeserialization_CreateOrUpdate
        /// <summary> Creates or Updates a Xml. </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="parameters"> Create or update parameters. </param>
        /// <param name="ifMatch"> ETag of the Entity. Not required when creating an entity, but required when updating an entity. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual XmlDeserializationCreateOrUpdateOperation CreateOrUpdate(string xmlName, XmlInstanceData parameters, string ifMatch = null, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (xmlName == null)
            {
                throw new ArgumentNullException(nameof(xmlName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _xmlDeserializationRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, xmlName, parameters, ifMatch, cancellationToken);
                var operation = new XmlDeserializationCreateOrUpdateOperation(Parent, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: XmlDeserialization_CreateOrUpdate
        /// <summary> Creates or Updates a Xml. </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="parameters"> Create or update parameters. </param>
        /// <param name="ifMatch"> ETag of the Entity. Not required when creating an entity, but required when updating an entity. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<XmlDeserializationCreateOrUpdateOperation> CreateOrUpdateAsync(string xmlName, XmlInstanceData parameters, string ifMatch = null, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (xmlName == null)
            {
                throw new ArgumentNullException(nameof(xmlName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _xmlDeserializationRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, xmlName, parameters, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new XmlDeserializationCreateOrUpdateOperation(Parent, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: XmlDeserialization_Get
        /// <summary> Gets the details of the Xml specified by its identifier. </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public virtual Response<XmlInstance> Get(string xmlName, CancellationToken cancellationToken = default)
        {
            if (xmlName == null)
            {
                throw new ArgumentNullException(nameof(xmlName));
            }

            using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.Get");
            scope.Start();
            try
            {
                var response = _xmlDeserializationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new XmlInstance(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: XmlDeserialization_Get
        /// <summary> Gets the details of the Xml specified by its identifier. </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public async virtual Task<Response<XmlInstance>> GetAsync(string xmlName, CancellationToken cancellationToken = default)
        {
            if (xmlName == null)
            {
                throw new ArgumentNullException(nameof(xmlName));
            }

            using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.Get");
            scope.Start();
            try
            {
                var response = await _xmlDeserializationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new XmlInstance(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public virtual Response<XmlInstance> GetIfExists(string xmlName, CancellationToken cancellationToken = default)
        {
            if (xmlName == null)
            {
                throw new ArgumentNullException(nameof(xmlName));
            }

            using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _xmlDeserializationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<XmlInstance>(null, response.GetRawResponse())
                    : Response.FromValue(new XmlInstance(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public async virtual Task<Response<XmlInstance>> GetIfExistsAsync(string xmlName, CancellationToken cancellationToken = default)
        {
            if (xmlName == null)
            {
                throw new ArgumentNullException(nameof(xmlName));
            }

            using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.GetIfExistsAsync");
            scope.Start();
            try
            {
                var response = await _xmlDeserializationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<XmlInstance>(null, response.GetRawResponse())
                    : Response.FromValue(new XmlInstance(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public virtual Response<bool> Exists(string xmlName, CancellationToken cancellationToken = default)
        {
            if (xmlName == null)
            {
                throw new ArgumentNullException(nameof(xmlName));
            }

            using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(xmlName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string xmlName, CancellationToken cancellationToken = default)
        {
            if (xmlName == null)
            {
                throw new ArgumentNullException(nameof(xmlName));
            }

            using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.ExistsAsync");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(xmlName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: XmlDeserialization_List
        /// <summary> Lists a collection of Xmls in the specified resource group instance. </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="XmlInstance" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<XmlInstance> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<XmlInstance> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _xmlDeserializationRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstance(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<XmlInstance> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _xmlDeserializationRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstance(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: XmlDeserialization_List
        /// <summary> Lists a collection of Xmls in the specified resource group instance. </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="XmlInstance" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<XmlInstance> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<XmlInstance>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _xmlDeserializationRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstance(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<XmlInstance>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _xmlDeserializationRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstance(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="XmlInstance" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(XmlInstance.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="XmlInstance" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlInstanceCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(XmlInstance.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<XmlInstance> IEnumerable<XmlInstance>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<XmlInstance> IAsyncEnumerable<XmlInstance>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, XmlInstance, XmlInstanceData> Construct() { }
    }
}
