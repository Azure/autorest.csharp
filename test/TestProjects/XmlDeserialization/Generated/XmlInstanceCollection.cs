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
using Azure.ResourceManager.Resources;
using XmlDeserialization.Models;

namespace XmlDeserialization
{
    /// <summary>
    /// A class representing a collection of <see cref="XmlInstanceResource" /> and their operations.
    /// Each <see cref="XmlInstanceResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="XmlInstanceCollection" /> instance call the GetXmlInstances method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class XmlInstanceCollection : ArmCollection, IEnumerable<XmlInstanceResource>, IAsyncEnumerable<XmlInstanceResource>
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
            _xmlInstanceXmlDeserializationClientDiagnostics = new ClientDiagnostics("XmlDeserialization", XmlInstanceResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(XmlInstanceResource.ResourceType, out string xmlInstanceXmlDeserializationApiVersion);
            _xmlInstanceXmlDeserializationRestClient = new XmlDeserializationRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, xmlInstanceXmlDeserializationApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or Updates a Xml.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}
        /// Operation Id: XmlDeserialization_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="data"> Create or update parameters. </param>
        /// <param name="ifMatch"> ETag of the Entity. Not required when creating an entity, but required when updating an entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<XmlInstanceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string xmlName, XmlInstanceData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _xmlInstanceXmlDeserializationRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, xmlName, data, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new XmlDeserializationArmOperation<XmlInstanceResource>(Response.FromValue(new XmlInstanceResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
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
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="data"> Create or update parameters. </param>
        /// <param name="ifMatch"> ETag of the Entity. Not required when creating an entity, but required when updating an entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<XmlInstanceResource> CreateOrUpdate(WaitUntil waitUntil, string xmlName, XmlInstanceData data, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _xmlInstanceXmlDeserializationRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, xmlName, data, ifMatch, cancellationToken);
                var operation = new XmlDeserializationArmOperation<XmlInstanceResource>(Response.FromValue(new XmlInstanceResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
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
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public virtual async Task<Response<XmlInstanceResource>> GetAsync(string xmlName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.Get");
            scope.Start();
            try
            {
                var response = await _xmlInstanceXmlDeserializationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new XmlInstanceResource(Client, response.Value), response.GetRawResponse());
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
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public virtual Response<XmlInstanceResource> Get(string xmlName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.Get");
            scope.Start();
            try
            {
                var response = _xmlInstanceXmlDeserializationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new XmlInstanceResource(Client, response.Value), response.GetRawResponse());
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
        /// <param name="options"> A class representing the optional parameters in this method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="XmlInstanceResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<XmlInstanceResource> GetAllAsync(XmlDeserializationGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new XmlDeserializationGetAllOptions();

            async Task<Page<XmlInstanceResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _xmlInstanceXmlDeserializationRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, options.Filter, options.Top, options.Skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstanceResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<XmlInstanceResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _xmlInstanceXmlDeserializationRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, options.Filter, options.Top, options.Skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstanceResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <param name="options"> A class representing the optional parameters in this method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="XmlInstanceResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<XmlInstanceResource> GetAll(XmlDeserializationGetAllOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new XmlDeserializationGetAllOptions();

            Page<XmlInstanceResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _xmlInstanceXmlDeserializationRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, options.Filter, options.Top, options.Skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstanceResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<XmlInstanceResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _xmlInstanceXmlDeserializationRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, options.Filter, options.Top, options.Skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new XmlInstanceResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string xmlName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.Exists");
            scope.Start();
            try
            {
                var response = await _xmlInstanceXmlDeserializationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        public virtual Response<bool> Exists(string xmlName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(xmlName, nameof(xmlName));

            using var scope = _xmlInstanceXmlDeserializationClientDiagnostics.CreateScope("XmlInstanceCollection.Exists");
            scope.Start();
            try
            {
                var response = _xmlInstanceXmlDeserializationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, xmlName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<XmlInstanceResource> IEnumerable<XmlInstanceResource>.GetEnumerator()
        {
            return GetAll(null).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll(null).GetEnumerator();
        }

        IAsyncEnumerator<XmlInstanceResource> IAsyncEnumerable<XmlInstanceResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(null, cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
