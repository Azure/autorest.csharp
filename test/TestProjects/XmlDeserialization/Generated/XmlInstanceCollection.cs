// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace XmlDeserialization
{
    /// <summary> A class representing collection of XmlInstance and their operations over its parent. </summary>
    public partial class XmlInstanceCollection : ArmCollection, IEnumerable<XmlInstance>, IAsyncEnumerable<XmlInstance>
    {
        private readonly ClientDiagnostics _xmlInstanceXmlDeserializationClientDiagnostics;
        private readonly XmlDeserializationRestOperations _xmlInstanceXmlDeserializationRestClient;

        /// <summary> Initializes a new instance of the <see cref="XmlInstanceCollection"/> class for mocking. </summary>
        protected XmlInstanceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="XmlInstanceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal XmlInstanceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _xmlInstanceXmlDeserializationClientDiagnostics = new ClientDiagnostics("XmlDeserialization", XmlInstance.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(XmlInstance.ResourceType, out string xmlInstanceXmlDeserializationApiVersion);
            _xmlInstanceXmlDeserializationRestClient = new XmlDeserializationRestOperations(_xmlInstanceXmlDeserializationClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, xmlInstanceXmlDeserializationApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or Updates a Xml.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// Operation Id: XmlDeserialization_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="parameters"> Create or update parameters. </param>
        /// <param name="ifMatch"> ETag of the Entity. Not required when creating an entity, but required when updating an entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<XmlInstance>> CreateOrUpdateAsync(bool waitForCompletion, string xmlName, XmlInstanceData parameters, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _xmlInstanceXmlDeserializationRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, xmlName, parameters, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new XmlDeserializationArmOperation<XmlInstance>(Response.FromValue(new XmlInstance(Client, response), response.GetRawResponse()));
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

        /// <summary>
        /// Creates or Updates a Xml.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// Operation Id: XmlDeserialization_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="parameters"> Create or update parameters. </param>
        /// <param name="ifMatch"> ETag of the Entity. Not required when creating an entity, but required when updating an entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<XmlInstance> CreateOrUpdate(bool waitForCompletion, string xmlName, XmlInstanceData parameters, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _xmlInstanceXmlDeserializationRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, xmlName, parameters, ifMatch, cancellationToken);
                var operation = new XmlDeserializationArmOperation<XmlInstance>(Response.FromValue(new XmlInstance(Client, response), response.GetRawResponse()));
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

        /// <summary>
        /// Gets the details of the Xml specified by its identifier.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// Operation Id: XmlDeserialization_Get
        /// </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public async virtual Task<Response<XmlInstance>> GetAsync(string xmlName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.Get");
            scope.Start();
            try
            {
                var response = await _xmlInstanceXmlDeserializationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _xmlInstanceXmlDeserializationClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new XmlInstance(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the details of the Xml specified by its identifier.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// Operation Id: XmlDeserialization_Get
        /// </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public virtual Response<XmlInstance> Get(string xmlName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.Get");
            scope.Start();
            try
            {
                var response = _xmlInstanceXmlDeserializationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken);
                if (response.Value == null)
                    throw _xmlInstanceXmlDeserializationClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new XmlInstance(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists a collection of Xmls in the specified resource group instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls
        /// Operation Id: XmlDeserialization_List
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="XmlInstance" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<XmlInstance> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<XmlInstance>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _xmlInstanceXmlDeserializationRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstance(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<XmlInstance>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _xmlInstanceXmlDeserializationRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstance(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists a collection of Xmls in the specified resource group instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls
        /// Operation Id: XmlDeserialization_List
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="XmlInstance" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<XmlInstance> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<XmlInstance> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _xmlInstanceXmlDeserializationRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstance(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<XmlInstance> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _xmlInstanceXmlDeserializationRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstance(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// Operation Id: XmlDeserialization_Get
        /// </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string xmlName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.Exists");
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

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// Operation Id: XmlDeserialization_Get
        /// </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public virtual Response<bool> Exists(string xmlName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.Exists");
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

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// Operation Id: XmlDeserialization_Get
        /// </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public async virtual Task<Response<XmlInstance>> GetIfExistsAsync(string xmlName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _xmlInstanceXmlDeserializationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<XmlInstance>(null, response.GetRawResponse());
                return Response.FromValue(new XmlInstance(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// Operation Id: XmlDeserialization_Get
        /// </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public virtual Response<XmlInstance> GetIfExists(string xmlName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _xmlInstanceXmlDeserializationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<XmlInstance>(null, response.GetRawResponse());
                return Response.FromValue(new XmlInstance(Client, response.Value), response.GetRawResponse());
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
    }
}
