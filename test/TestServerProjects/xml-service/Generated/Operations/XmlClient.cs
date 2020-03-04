// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using xml_service.Models;

namespace xml_service
{
    public partial class XmlClient
    {
        private XmlRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of XmlClient. </summary>
        internal XmlClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new XmlRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Get a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<RootWithRefAndNoMeta>> GetComplexTypeRefNoMetaAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexTypeRefNoMetaAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RootWithRefAndNoMeta> GetComplexTypeRefNoMeta(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexTypeRefNoMeta(cancellationToken);
        }
        /// <summary> Puts a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="model"> The RootWithRefAndNoMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutComplexTypeRefNoMetaAsync(RootWithRefAndNoMeta model, CancellationToken cancellationToken = default)
        {
            return await restClient.PutComplexTypeRefNoMetaAsync(model, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Puts a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="model"> The RootWithRefAndNoMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutComplexTypeRefNoMeta(RootWithRefAndNoMeta model, CancellationToken cancellationToken = default)
        {
            return restClient.PutComplexTypeRefNoMeta(model, cancellationToken);
        }
        /// <summary> Get a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<RootWithRefAndMeta>> GetComplexTypeRefWithMetaAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetComplexTypeRefWithMetaAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RootWithRefAndMeta> GetComplexTypeRefWithMeta(CancellationToken cancellationToken = default)
        {
            return restClient.GetComplexTypeRefWithMeta(cancellationToken);
        }
        /// <summary> Puts a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="model"> The RootWithRefAndMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutComplexTypeRefWithMetaAsync(RootWithRefAndMeta model, CancellationToken cancellationToken = default)
        {
            return await restClient.PutComplexTypeRefWithMetaAsync(model, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Puts a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="model"> The RootWithRefAndMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutComplexTypeRefWithMeta(RootWithRefAndMeta model, CancellationToken cancellationToken = default)
        {
            return restClient.PutComplexTypeRefWithMeta(model, cancellationToken);
        }
        /// <summary> Get a simple XML document. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Slideshow>> GetSimpleAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetSimpleAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get a simple XML document. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Slideshow> GetSimple(CancellationToken cancellationToken = default)
        {
            return restClient.GetSimple(cancellationToken);
        }
        /// <summary> Put a simple XML document. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutSimpleAsync(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            return await restClient.PutSimpleAsync(slideshow, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put a simple XML document. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSimple(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            return restClient.PutSimple(slideshow, cancellationToken);
        }
        /// <summary> Get an XML document with multiple wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<AppleBarrel>> GetWrappedListsAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetWrappedListsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an XML document with multiple wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AppleBarrel> GetWrappedLists(CancellationToken cancellationToken = default)
        {
            return restClient.GetWrappedLists(cancellationToken);
        }
        /// <summary> Put an XML document with multiple wrapped lists. </summary>
        /// <param name="wrappedLists"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutWrappedListsAsync(AppleBarrel wrappedLists, CancellationToken cancellationToken = default)
        {
            return await restClient.PutWrappedListsAsync(wrappedLists, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put an XML document with multiple wrapped lists. </summary>
        /// <param name="wrappedLists"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutWrappedLists(AppleBarrel wrappedLists, CancellationToken cancellationToken = default)
        {
            return restClient.PutWrappedLists(wrappedLists, cancellationToken);
        }
        /// <summary> Get strongly-typed response headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> GetHeadersAsync(CancellationToken cancellationToken = default)
        {
            return (await restClient.GetHeadersAsync(cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Get strongly-typed response headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response GetHeaders(CancellationToken cancellationToken = default)
        {
            return restClient.GetHeaders(cancellationToken).GetRawResponse();
        }
        /// <summary> Get an empty list. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Slideshow>> GetEmptyListAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetEmptyListAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get an empty list. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Slideshow> GetEmptyList(CancellationToken cancellationToken = default)
        {
            return restClient.GetEmptyList(cancellationToken);
        }
        /// <summary> Puts an empty list. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyListAsync(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            return await restClient.PutEmptyListAsync(slideshow, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Puts an empty list. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmptyList(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            return restClient.PutEmptyList(slideshow, cancellationToken);
        }
        /// <summary> Gets some empty wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<AppleBarrel>> GetEmptyWrappedListsAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetEmptyWrappedListsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Gets some empty wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AppleBarrel> GetEmptyWrappedLists(CancellationToken cancellationToken = default)
        {
            return restClient.GetEmptyWrappedLists(cancellationToken);
        }
        /// <summary> Puts some empty wrapped lists. </summary>
        /// <param name="appleBarrel"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyWrappedListsAsync(AppleBarrel appleBarrel, CancellationToken cancellationToken = default)
        {
            return await restClient.PutEmptyWrappedListsAsync(appleBarrel, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Puts some empty wrapped lists. </summary>
        /// <param name="appleBarrel"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmptyWrappedLists(AppleBarrel appleBarrel, CancellationToken cancellationToken = default)
        {
            return restClient.PutEmptyWrappedLists(appleBarrel, cancellationToken);
        }
        /// <summary> Gets a list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Banana>>> GetRootListAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetRootListAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Gets a list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Banana>> GetRootList(CancellationToken cancellationToken = default)
        {
            return restClient.GetRootList(cancellationToken);
        }
        /// <summary> Puts a list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutRootListAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            return await restClient.PutRootListAsync(bananas, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Puts a list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutRootList(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            return restClient.PutRootList(bananas, cancellationToken);
        }
        /// <summary> Gets a list with a single item. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Banana>>> GetRootListSingleItemAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetRootListSingleItemAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Gets a list with a single item. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Banana>> GetRootListSingleItem(CancellationToken cancellationToken = default)
        {
            return restClient.GetRootListSingleItem(cancellationToken);
        }
        /// <summary> Puts a list with a single item. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutRootListSingleItemAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            return await restClient.PutRootListSingleItemAsync(bananas, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Puts a list with a single item. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutRootListSingleItem(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            return restClient.PutRootListSingleItem(bananas, cancellationToken);
        }
        /// <summary> Gets an empty list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Banana>>> GetEmptyRootListAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetEmptyRootListAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Gets an empty list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Banana>> GetEmptyRootList(CancellationToken cancellationToken = default)
        {
            return restClient.GetEmptyRootList(cancellationToken);
        }
        /// <summary> Puts an empty list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyRootListAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            return await restClient.PutEmptyRootListAsync(bananas, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Puts an empty list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmptyRootList(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            return restClient.PutEmptyRootList(bananas, cancellationToken);
        }
        /// <summary> Gets an XML document with an empty child element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Banana>> GetEmptyChildElementAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetEmptyChildElementAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Gets an XML document with an empty child element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Banana> GetEmptyChildElement(CancellationToken cancellationToken = default)
        {
            return restClient.GetEmptyChildElement(cancellationToken);
        }
        /// <summary> Puts a value with an empty child element. </summary>
        /// <param name="banana"> The Banana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyChildElementAsync(Banana banana, CancellationToken cancellationToken = default)
        {
            return await restClient.PutEmptyChildElementAsync(banana, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Puts a value with an empty child element. </summary>
        /// <param name="banana"> The Banana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmptyChildElement(Banana banana, CancellationToken cancellationToken = default)
        {
            return restClient.PutEmptyChildElement(banana, cancellationToken);
        }
        /// <summary> Lists containers in a storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ListContainersResponse>> ListContainersAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.ListContainersAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Lists containers in a storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListContainersResponse> ListContainers(CancellationToken cancellationToken = default)
        {
            return restClient.ListContainers(cancellationToken);
        }
        /// <summary> Gets storage service properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<StorageServiceProperties>> GetServicePropertiesAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetServicePropertiesAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Gets storage service properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<StorageServiceProperties> GetServiceProperties(CancellationToken cancellationToken = default)
        {
            return restClient.GetServiceProperties(cancellationToken);
        }
        /// <summary> Puts storage service properties. </summary>
        /// <param name="properties"> The StorageServiceProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutServicePropertiesAsync(StorageServiceProperties properties, CancellationToken cancellationToken = default)
        {
            return await restClient.PutServicePropertiesAsync(properties, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Puts storage service properties. </summary>
        /// <param name="properties"> The StorageServiceProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutServiceProperties(StorageServiceProperties properties, CancellationToken cancellationToken = default)
        {
            return restClient.PutServiceProperties(properties, cancellationToken);
        }
        /// <summary> Gets storage ACLs for a container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<SignedIdentifier>>> GetAclsAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetAclsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Gets storage ACLs for a container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<SignedIdentifier>> GetAcls(CancellationToken cancellationToken = default)
        {
            return restClient.GetAcls(cancellationToken);
        }
        /// <summary> Puts storage ACLs for a container. </summary>
        /// <param name="properties"> The SignedIdentifiers to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutAclsAsync(IEnumerable<SignedIdentifier> properties, CancellationToken cancellationToken = default)
        {
            return await restClient.PutAclsAsync(properties, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Puts storage ACLs for a container. </summary>
        /// <param name="properties"> The SignedIdentifiers to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutAcls(IEnumerable<SignedIdentifier> properties, CancellationToken cancellationToken = default)
        {
            return restClient.PutAcls(properties, cancellationToken);
        }
        /// <summary> Lists blobs in a storage container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ListBlobsResponse>> ListBlobsAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.ListBlobsAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Lists blobs in a storage container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListBlobsResponse> ListBlobs(CancellationToken cancellationToken = default)
        {
            return restClient.ListBlobs(cancellationToken);
        }
        /// <summary> A Swagger with XML that has one operation that takes JSON as input. You need to send the ID number 42. </summary>
        /// <param name="properties"> The JsonInput to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> JsonInputAsync(JsonInput properties, CancellationToken cancellationToken = default)
        {
            return await restClient.JsonInputAsync(properties, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> A Swagger with XML that has one operation that takes JSON as input. You need to send the ID number 42. </summary>
        /// <param name="properties"> The JsonInput to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response JsonInput(JsonInput properties, CancellationToken cancellationToken = default)
        {
            return restClient.JsonInput(properties, cancellationToken);
        }
        /// <summary> A Swagger with XML that has one operation that returns JSON. ID number 42. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<JsonOutput>> JsonOutputAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.JsonOutputAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> A Swagger with XML that has one operation that returns JSON. ID number 42. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<JsonOutput> JsonOutput(CancellationToken cancellationToken = default)
        {
            return restClient.JsonOutput(cancellationToken);
        }
    }
}
