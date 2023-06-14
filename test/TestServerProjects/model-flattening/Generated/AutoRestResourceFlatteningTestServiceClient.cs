// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using model_flattening.Models;

namespace model_flattening
{
    /// <summary> The AutoRestResourceFlatteningTestService service client. </summary>
    public partial class AutoRestResourceFlatteningTestServiceClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal AutoRestResourceFlatteningTestServiceRestClient RestClient { get; }

        /// <summary> Initializes a new instance of AutoRestResourceFlatteningTestServiceClient for mocking. </summary>
        protected AutoRestResourceFlatteningTestServiceClient()
        {
        }

        /// <summary> Initializes a new instance of AutoRestResourceFlatteningTestServiceClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal AutoRestResourceFlatteningTestServiceClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new AutoRestResourceFlatteningTestServiceRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Put External Resource as an Array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutArrayAsync(IEnumerable<Resource> resourceArray = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutArray");
            scope.Start();
            try
            {
                return await RestClient.PutArrayAsync(resourceArray, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put External Resource as an Array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutArray(IEnumerable<Resource> resourceArray = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutArray");
            scope.Start();
            try
            {
                return RestClient.PutArray(resourceArray, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get External Resource as an Array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<FlattenedProduct>>> GetArrayAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.GetArray");
            scope.Start();
            try
            {
                return await RestClient.GetArrayAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get External Resource as an Array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<FlattenedProduct>> GetArray(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.GetArray");
            scope.Start();
            try
            {
                return RestClient.GetArray(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it's referenced in an array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutWrappedArrayAsync(IEnumerable<WrappedProduct> resourceArray = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutWrappedArray");
            scope.Start();
            try
            {
                return await RestClient.PutWrappedArrayAsync(resourceArray, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it's referenced in an array. </summary>
        /// <param name="resourceArray"> External Resource as an Array to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutWrappedArray(IEnumerable<WrappedProduct> resourceArray = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutWrappedArray");
            scope.Start();
            try
            {
                return RestClient.PutWrappedArray(resourceArray, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it's referenced in an array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<ProductWrapper>>> GetWrappedArrayAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.GetWrappedArray");
            scope.Start();
            try
            {
                return await RestClient.GetWrappedArrayAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> No need to have a route in Express server for this operation. Used to verify the type flattened is not removed if it's referenced in an array. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<ProductWrapper>> GetWrappedArray(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.GetWrappedArray");
            scope.Start();
            try
            {
                return RestClient.GetWrappedArray(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put External Resource as a Dictionary. </summary>
        /// <param name="resourceDictionary"> External Resource as a Dictionary to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutDictionaryAsync(IDictionary<string, FlattenedProduct> resourceDictionary = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutDictionary");
            scope.Start();
            try
            {
                return await RestClient.PutDictionaryAsync(resourceDictionary, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put External Resource as a Dictionary. </summary>
        /// <param name="resourceDictionary"> External Resource as a Dictionary to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutDictionary(IDictionary<string, FlattenedProduct> resourceDictionary = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutDictionary");
            scope.Start();
            try
            {
                return RestClient.PutDictionary(resourceDictionary, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get External Resource as a Dictionary. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyDictionary<string, FlattenedProduct>>> GetDictionaryAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.GetDictionary");
            scope.Start();
            try
            {
                return await RestClient.GetDictionaryAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get External Resource as a Dictionary. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyDictionary<string, FlattenedProduct>> GetDictionary(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.GetDictionary");
            scope.Start();
            try
            {
                return RestClient.GetDictionary(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put External Resource as a ResourceCollection. </summary>
        /// <param name="resourceComplexObject"> External Resource as a ResourceCollection to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutResourceCollectionAsync(ResourceCollection resourceComplexObject = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutResourceCollection");
            scope.Start();
            try
            {
                return await RestClient.PutResourceCollectionAsync(resourceComplexObject, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put External Resource as a ResourceCollection. </summary>
        /// <param name="resourceComplexObject"> External Resource as a ResourceCollection to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutResourceCollection(ResourceCollection resourceComplexObject = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutResourceCollection");
            scope.Start();
            try
            {
                return RestClient.PutResourceCollection(resourceComplexObject, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get External Resource as a ResourceCollection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ResourceCollection>> GetResourceCollectionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.GetResourceCollection");
            scope.Start();
            try
            {
                return await RestClient.GetResourceCollectionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get External Resource as a ResourceCollection. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ResourceCollection> GetResourceCollection(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.GetResourceCollection");
            scope.Start();
            try
            {
                return RestClient.GetResourceCollection(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="simpleBodyProduct"> Simple body product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SimpleProduct>> PutSimpleProductAsync(SimpleProduct simpleBodyProduct = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutSimpleProduct");
            scope.Start();
            try
            {
                return await RestClient.PutSimpleProductAsync(simpleBodyProduct, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="simpleBodyProduct"> Simple body product to put. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SimpleProduct> PutSimpleProduct(SimpleProduct simpleBodyProduct = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutSimpleProduct");
            scope.Start();
            try
            {
                return RestClient.PutSimpleProduct(simpleBodyProduct, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put Flattened Simple Product with client flattening true on the parameter. </summary>
        /// <param name="productId"> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </param>
        /// <param name="description"> Description of product. </param>
        /// <param name="maxProductDisplayName"> Display name of product. </param>
        /// <param name="capacity"> Capacity of product. For example, 4 people. </param>
        /// <param name="genericValue"> Generic URL value. </param>
        /// <param name="odataValue"> URL value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SimpleProduct>> PostFlattenedSimpleProductAsync(string productId, string description = null, string maxProductDisplayName = null, SimpleProductPropertiesMaxProductCapacity? capacity = null, string genericValue = null, string odataValue = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PostFlattenedSimpleProduct");
            scope.Start();
            try
            {
                return await RestClient.PostFlattenedSimpleProductAsync(productId, description, maxProductDisplayName, capacity, genericValue, odataValue, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put Flattened Simple Product with client flattening true on the parameter. </summary>
        /// <param name="productId"> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </param>
        /// <param name="description"> Description of product. </param>
        /// <param name="maxProductDisplayName"> Display name of product. </param>
        /// <param name="capacity"> Capacity of product. For example, 4 people. </param>
        /// <param name="genericValue"> Generic URL value. </param>
        /// <param name="odataValue"> URL value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SimpleProduct> PostFlattenedSimpleProduct(string productId, string description = null, string maxProductDisplayName = null, SimpleProductPropertiesMaxProductCapacity? capacity = null, string genericValue = null, string odataValue = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PostFlattenedSimpleProduct");
            scope.Start();
            try
            {
                return RestClient.PostFlattenedSimpleProduct(productId, description, maxProductDisplayName, capacity, genericValue, odataValue, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="flattenParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SimpleProduct>> PutSimpleProductWithGroupingAsync(FlattenParameterGroup flattenParameterGroup, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutSimpleProductWithGrouping");
            scope.Start();
            try
            {
                return await RestClient.PutSimpleProductWithGroupingAsync(flattenParameterGroup, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put Simple Product with client flattening true on the model. </summary>
        /// <param name="flattenParameterGroup"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SimpleProduct> PutSimpleProductWithGrouping(FlattenParameterGroup flattenParameterGroup, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AutoRestResourceFlatteningTestServiceClient.PutSimpleProductWithGrouping");
            scope.Start();
            try
            {
                return RestClient.PutSimpleProductWithGrouping(flattenParameterGroup, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
