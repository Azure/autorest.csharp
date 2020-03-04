// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using model_flattening.Models;

namespace model_flattening
{
    public partial class AllClient
    {
        private AllRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of AllClient. </summary>
        internal AllClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            restClient = new AllRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Put External Resource as an Array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutArrayAsync(IEnumerable<Resource> resourceArray, CancellationToken cancellationToken = default)
        {
            return await restClient.PutArrayAsync(resourceArray, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put External Resource as an Array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutArray(IEnumerable<Resource> resourceArray, CancellationToken cancellationToken = default)
        {
            return restClient.PutArray(resourceArray, cancellationToken);
        }
        /// <summary> Get External Resource as an Array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<FlattenedProduct>>> GetArrayAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetArrayAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get External Resource as an Array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<FlattenedProduct>> GetArray(CancellationToken cancellationToken = default)
        {
            return restClient.GetArray(cancellationToken);
        }
        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it&apos;s referenced in an array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutWrappedArrayAsync(IEnumerable<WrappedProduct> resourceArray, CancellationToken cancellationToken = default)
        {
            return await restClient.PutWrappedArrayAsync(resourceArray, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it&apos;s referenced in an array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutWrappedArray(IEnumerable<WrappedProduct> resourceArray, CancellationToken cancellationToken = default)
        {
            return restClient.PutWrappedArray(resourceArray, cancellationToken);
        }
        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it&apos;s referenced in an array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<ProductWrapper>>> GetWrappedArrayAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetWrappedArrayAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it&apos;s referenced in an array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<ProductWrapper>> GetWrappedArray(CancellationToken cancellationToken = default)
        {
            return restClient.GetWrappedArray(cancellationToken);
        }
        /// <summary> Put External Resource as a Dictionary. </summary>
        /// <param name="resourceDictionary"> External Resource as a Dictionary to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutDictionaryAsync(IDictionary<string, FlattenedProduct> resourceDictionary, CancellationToken cancellationToken = default)
        {
            return await restClient.PutDictionaryAsync(resourceDictionary, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put External Resource as a Dictionary. </summary>
        /// <param name="resourceDictionary"> External Resource as a Dictionary to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutDictionary(IDictionary<string, FlattenedProduct> resourceDictionary, CancellationToken cancellationToken = default)
        {
            return restClient.PutDictionary(resourceDictionary, cancellationToken);
        }
        /// <summary> Get External Resource as a Dictionary. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<IDictionary<string, FlattenedProduct>>> GetDictionaryAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetDictionaryAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get External Resource as a Dictionary. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IDictionary<string, FlattenedProduct>> GetDictionary(CancellationToken cancellationToken = default)
        {
            return restClient.GetDictionary(cancellationToken);
        }
        /// <summary> Put External Resource as a ResourceCollection. </summary>
        /// <param name="resourceComplexObject"> External Resource as a ResourceCollection to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutResourceCollectionAsync(ResourceCollection resourceComplexObject, CancellationToken cancellationToken = default)
        {
            return await restClient.PutResourceCollectionAsync(resourceComplexObject, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put External Resource as a ResourceCollection. </summary>
        /// <param name="resourceComplexObject"> External Resource as a ResourceCollection to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutResourceCollection(ResourceCollection resourceComplexObject, CancellationToken cancellationToken = default)
        {
            return restClient.PutResourceCollection(resourceComplexObject, cancellationToken);
        }
        /// <summary> Get External Resource as a ResourceCollection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ResourceCollection>> GetResourceCollectionAsync(CancellationToken cancellationToken = default)
        {
            return await restClient.GetResourceCollectionAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Get External Resource as a ResourceCollection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ResourceCollection> GetResourceCollection(CancellationToken cancellationToken = default)
        {
            return restClient.GetResourceCollection(cancellationToken);
        }
        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="simpleBodyProduct"> Simple body product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SimpleProduct>> PutSimpleProductAsync(SimpleProduct simpleBodyProduct, CancellationToken cancellationToken = default)
        {
            return await restClient.PutSimpleProductAsync(simpleBodyProduct, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="simpleBodyProduct"> Simple body product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SimpleProduct> PutSimpleProduct(SimpleProduct simpleBodyProduct, CancellationToken cancellationToken = default)
        {
            return restClient.PutSimpleProduct(simpleBodyProduct, cancellationToken);
        }
        /// <summary> Put Flattened Simple Product with client flattening true on the parameter. </summary>
        /// <param name="simpleBodyProduct"> Simple body product to post. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SimpleProduct>> PostFlattenedSimpleProductAsync(SimpleProduct simpleBodyProduct, CancellationToken cancellationToken = default)
        {
            return await restClient.PostFlattenedSimpleProductAsync(simpleBodyProduct, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put Flattened Simple Product with client flattening true on the parameter. </summary>
        /// <param name="simpleBodyProduct"> Simple body product to post. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SimpleProduct> PostFlattenedSimpleProduct(SimpleProduct simpleBodyProduct, CancellationToken cancellationToken = default)
        {
            return restClient.PostFlattenedSimpleProduct(simpleBodyProduct, cancellationToken);
        }
        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="name"> Product name with value &apos;groupproduct&apos;. </param>
        /// <param name="simpleBodyProduct"> Simple body product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SimpleProduct>> PutSimpleProductWithGroupingAsync(string name, SimpleProduct simpleBodyProduct, CancellationToken cancellationToken = default)
        {
            return await restClient.PutSimpleProductWithGroupingAsync(name, simpleBodyProduct, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="name"> Product name with value &apos;groupproduct&apos;. </param>
        /// <param name="simpleBodyProduct"> Simple body product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SimpleProduct> PutSimpleProductWithGrouping(string name, SimpleProduct simpleBodyProduct, CancellationToken cancellationToken = default)
        {
            return restClient.PutSimpleProductWithGrouping(name, simpleBodyProduct, cancellationToken);
        }
    }
}
