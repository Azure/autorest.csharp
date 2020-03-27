// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using model_flattening.Models;

namespace model_flattening
{
    public partial class ServiceClient
    {
        private readonly ClientDiagnostics clientDiagnostics;
        private readonly HttpPipeline pipeline;
        internal ServiceRestClient RestClient { get; }
        /// <summary> Initializes a new instance of ServiceClient for mocking. </summary>
        protected ServiceClient()
        {
        }
        /// <summary> Initializes a new instance of ServiceClient. </summary>
        internal ServiceClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            RestClient = new ServiceRestClient(clientDiagnostics, pipeline, host);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }

        /// <summary> Put External Resource as an Array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutArrayAsync(IEnumerable<Resource> resourceArray, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutArrayAsync(resourceArray, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put External Resource as an Array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutArray(IEnumerable<Resource> resourceArray, CancellationToken cancellationToken = default)
        {
            return RestClient.PutArray(resourceArray, cancellationToken);
        }

        /// <summary> Get External Resource as an Array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<FlattenedProduct>>> GetArrayAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetArrayAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get External Resource as an Array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<FlattenedProduct>> GetArray(CancellationToken cancellationToken = default)
        {
            return RestClient.GetArray(cancellationToken);
        }

        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it&apos;s referenced in an array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutWrappedArrayAsync(IEnumerable<WrappedProduct> resourceArray, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutWrappedArrayAsync(resourceArray, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it&apos;s referenced in an array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutWrappedArray(IEnumerable<WrappedProduct> resourceArray, CancellationToken cancellationToken = default)
        {
            return RestClient.PutWrappedArray(resourceArray, cancellationToken);
        }

        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it&apos;s referenced in an array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<ProductWrapper>>> GetWrappedArrayAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetWrappedArrayAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it&apos;s referenced in an array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<ProductWrapper>> GetWrappedArray(CancellationToken cancellationToken = default)
        {
            return RestClient.GetWrappedArray(cancellationToken);
        }

        /// <summary> Put External Resource as a Dictionary. </summary>
        /// <param name="resourceDictionary"> External Resource as a Dictionary to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDictionaryAsync(IDictionary<string, FlattenedProduct> resourceDictionary, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutDictionaryAsync(resourceDictionary, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put External Resource as a Dictionary. </summary>
        /// <param name="resourceDictionary"> External Resource as a Dictionary to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDictionary(IDictionary<string, FlattenedProduct> resourceDictionary, CancellationToken cancellationToken = default)
        {
            return RestClient.PutDictionary(resourceDictionary, cancellationToken);
        }

        /// <summary> Get External Resource as a Dictionary. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, FlattenedProduct>>> GetDictionaryAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetDictionaryAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get External Resource as a Dictionary. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, FlattenedProduct>> GetDictionary(CancellationToken cancellationToken = default)
        {
            return RestClient.GetDictionary(cancellationToken);
        }

        /// <summary> Put External Resource as a ResourceCollection. </summary>
        /// <param name="resourceComplexObject"> External Resource as a ResourceCollection to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutResourceCollectionAsync(ResourceCollection resourceComplexObject, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutResourceCollectionAsync(resourceComplexObject, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put External Resource as a ResourceCollection. </summary>
        /// <param name="resourceComplexObject"> External Resource as a ResourceCollection to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutResourceCollection(ResourceCollection resourceComplexObject, CancellationToken cancellationToken = default)
        {
            return RestClient.PutResourceCollection(resourceComplexObject, cancellationToken);
        }

        /// <summary> Get External Resource as a ResourceCollection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ResourceCollection>> GetResourceCollectionAsync(CancellationToken cancellationToken = default)
        {
            return await RestClient.GetResourceCollectionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get External Resource as a ResourceCollection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ResourceCollection> GetResourceCollection(CancellationToken cancellationToken = default)
        {
            return RestClient.GetResourceCollection(cancellationToken);
        }

        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="simpleBodyProduct"> Simple body product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SimpleProduct>> PutSimpleProductAsync(SimpleProduct simpleBodyProduct, CancellationToken cancellationToken = default)
        {
            return await RestClient.PutSimpleProductAsync(simpleBodyProduct, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="simpleBodyProduct"> Simple body product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SimpleProduct> PutSimpleProduct(SimpleProduct simpleBodyProduct, CancellationToken cancellationToken = default)
        {
            return RestClient.PutSimpleProduct(simpleBodyProduct, cancellationToken);
        }

        /// <summary> Put Flattened Simple Product with client flattening true on the parameter. </summary>
        /// <param name="productId"> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </param>
        /// <param name="description"> Description of product. </param>
        /// <param name="maxProductDisplayName"> Display name of product. </param>
        /// <param name="genericValue"> Generic URL value. </param>
        /// <param name="odataValue"> URL value. </param>
        /// <param name="capacity"> Capacity of product. For example, 4 people. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SimpleProduct>> PostFlattenedSimpleProductAsync(string productId, string description, string maxProductDisplayName, string genericValue, string odataValue, string capacity = "Large", CancellationToken cancellationToken = default)
        {
            return await RestClient.PostFlattenedSimpleProductAsync(productId, description, maxProductDisplayName, genericValue, odataValue, capacity, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put Flattened Simple Product with client flattening true on the parameter. </summary>
        /// <param name="productId"> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </param>
        /// <param name="description"> Description of product. </param>
        /// <param name="maxProductDisplayName"> Display name of product. </param>
        /// <param name="genericValue"> Generic URL value. </param>
        /// <param name="odataValue"> URL value. </param>
        /// <param name="capacity"> Capacity of product. For example, 4 people. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SimpleProduct> PostFlattenedSimpleProduct(string productId, string description, string maxProductDisplayName, string genericValue, string odataValue, string capacity = "Large", CancellationToken cancellationToken = default)
        {
            return RestClient.PostFlattenedSimpleProduct(productId, description, maxProductDisplayName, genericValue, odataValue, capacity, cancellationToken);
        }

        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="flattenParameterGroup"> Parameter group. </param>
        /// <param name="capacity"> Capacity of product. For example, 4 people. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SimpleProduct>> PutSimpleProductWithGroupingAsync(FlattenParameterGroup flattenParameterGroup, string capacity = "Large", CancellationToken cancellationToken = default)
        {
            return await RestClient.PutSimpleProductWithGroupingAsync(flattenParameterGroup, capacity, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="flattenParameterGroup"> Parameter group. </param>
        /// <param name="capacity"> Capacity of product. For example, 4 people. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SimpleProduct> PutSimpleProductWithGrouping(FlattenParameterGroup flattenParameterGroup, string capacity = "Large", CancellationToken cancellationToken = default)
        {
            return RestClient.PutSimpleProductWithGrouping(flattenParameterGroup, capacity, cancellationToken);
        }
    }
}
