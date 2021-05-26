// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace ExactMatchInheritance
{
    /// <summary> A class representing the operations that can be performed over a specific ExactMatchModel5. </summary>
    public partial class ExactMatchModel5Operations : ResourceOperationsBase<ResourceGroupResourceIdentifier, ExactMatchModel5>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ExactMatchModel5SRestOperations RestClient { get; }

        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel5Operations"/> class for mocking. </summary>
        protected ExactMatchModel5Operations()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel5Operations"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected internal ExactMatchModel5Operations(ResourceOperationsBase options, ResourceGroupResourceIdentifier id) : base(options, id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = Pipeline;
            RestClient = new ExactMatchModel5SRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId, BaseUri);
        }

        public static readonly ResourceType ResourceType = "Microsoft.Compute/exactMatchModel5s";
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc />
        public async override Task<Response<ExactMatchModel5>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.Get");
            scope.Start();
            try
            {
                var response = await RestClient.GetAsync(Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ExactMatchModel5(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public override Response<ExactMatchModel5> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.Get");
            scope.Start();
            try
            {
                var response = RestClient.Get(Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new ExactMatchModel5(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P: System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P: System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Response<ExactMatchModel5>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.AddTag");
            scope.Start();
            try
            {
                var operation = await StartAddTagAsync(key, value, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public Response<ExactMatchModel5> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.AddTag");
            scope.Start();
            try
            {
                var operation = StartAddTag(key, value, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<ExactMatchModel5SPutOperation> StartAddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.StartAddTag");
            scope.Start();
            try
            {
                var resource = GetResource();
                Id.TryGetLocation(out LocationData locationData);
                var patchable = new ExactMatchModel5Data(locationData);
                patchable.Tags.ReplaceWith(resource.Data.Tags);
                patchable.Tags[key] = value;
                var response = await RestClient.PutAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).ConfigureAwait(false);
                return new ExactMatchModel5SPutOperation(this, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public ExactMatchModel5SPutOperation StartAddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.StartAddTag");
            scope.Start();
            try
            {
                var resource = GetResource();
                Id.TryGetLocation(out LocationData locationData);
                var patchable = new ExactMatchModel5Data(locationData);
                patchable.Tags.ReplaceWith(resource.Data.Tags);
                patchable.Tags[key] = value;
                var response = RestClient.Put(Id.ResourceGroupName, Id.Name, patchable, cancellationToken);
                return new ExactMatchModel5SPutOperation(this, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<Response<ExactMatchModel5>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.SetTags");
            scope.Start();
            try
            {
                var operation = await StartSetTagsAsync(tags, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public Response<ExactMatchModel5> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.SetTags");
            scope.Start();
            try
            {
                var operation = StartSetTags(tags, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<ExactMatchModel5SPutOperation> StartSetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.StartSetTags");
            scope.Start();
            try
            {
                Id.TryGetLocation(out LocationData locationData);
                var patchable = new ExactMatchModel5Data(locationData);
                patchable.Tags.ReplaceWith(tags);
                var response = await RestClient.PutAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).ConfigureAwait(false);
                return new ExactMatchModel5SPutOperation(this, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public ExactMatchModel5SPutOperation StartSetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.StartSetTags");
            scope.Start();
            try
            {
                Id.TryGetLocation(out LocationData locationData);
                var patchable = new ExactMatchModel5Data(locationData);
                patchable.Tags.ReplaceWith(tags);
                var response = RestClient.Put(Id.ResourceGroupName, Id.Name, patchable, cancellationToken);
                return new ExactMatchModel5SPutOperation(this, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<Response<ExactMatchModel5>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.RemoveTag");
            scope.Start();
            try
            {
                var operation = await StartRemoveTagAsync(key, cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public Response<ExactMatchModel5> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.RemoveTag");
            scope.Start();
            try
            {
                var operation = StartRemoveTag(key, cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<ExactMatchModel5SPutOperation> StartRemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.StartRemoveTag");
            scope.Start();
            try
            {
                var resource = GetResource();
                Id.TryGetLocation(out LocationData locationData);
                var patchable = new ExactMatchModel5Data(locationData);
                patchable.Tags.ReplaceWith(resource.Data.Tags);
                patchable.Tags.Remove(key);
                var response = await RestClient.PutAsync(Id.ResourceGroupName, Id.Name, patchable, cancellationToken).ConfigureAwait(false);
                return new ExactMatchModel5SPutOperation(this, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        public ExactMatchModel5SPutOperation StartRemoveTag(string key, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Operations.StartRemoveTag");
            scope.Start();
            try
            {
                var resource = GetResource();
                Id.TryGetLocation(out LocationData locationData);
                var patchable = new ExactMatchModel5Data(locationData);
                patchable.Tags.ReplaceWith(resource.Data.Tags);
                patchable.Tags.Remove(key);
                var response = RestClient.Put(Id.ResourceGroupName, Id.Name, patchable, cancellationToken);
                return new ExactMatchModel5SPutOperation(this, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
