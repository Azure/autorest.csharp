// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppConfiguration.Models;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AppConfiguration
{
    public partial class AllClient
    {
        private AllRestClient restClient;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of AllClient. </summary>
        internal AllClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string syncToken, string host = "", string ApiVersion = "1.0")
        {
            restClient = new AllRestClient(clientDiagnostics, pipeline, syncToken, host, ApiVersion);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> CheckKeysAsync(string name, string after, string acceptDatetime, CancellationToken cancellationToken = default)
        {
            return (await restClient.CheckKeysAsync(name, after, acceptDatetime, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response CheckKeys(string name, string after, string acceptDatetime, CancellationToken cancellationToken = default)
        {
            return restClient.CheckKeys(name, after, acceptDatetime, cancellationToken).GetRawResponse();
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> CheckKeyValuesAsync(string key, string label, string after, string acceptDatetime, IEnumerable<Head6ItemsItem> select, CancellationToken cancellationToken = default)
        {
            return (await restClient.CheckKeyValuesAsync(key, label, after, acceptDatetime, select, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response CheckKeyValues(string key, string label, string after, string acceptDatetime, IEnumerable<Head6ItemsItem> select, CancellationToken cancellationToken = default)
        {
            return restClient.CheckKeyValues(key, label, after, acceptDatetime, select, cancellationToken).GetRawResponse();
        }
        /// <summary> Gets a single key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<KeyValue>> GetKeyValueAsync(string key, string label, string acceptDatetime, string ifMatch, string ifNoneMatch, IEnumerable<Get7ItemsItem> select, CancellationToken cancellationToken = default)
        {
            return await restClient.GetKeyValueAsync(key, label, acceptDatetime, ifMatch, ifNoneMatch, select, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Gets a single key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<KeyValue> GetKeyValue(string key, string label, string acceptDatetime, string ifMatch, string ifNoneMatch, IEnumerable<Get7ItemsItem> select, CancellationToken cancellationToken = default)
        {
            return restClient.GetKeyValue(key, label, acceptDatetime, ifMatch, ifNoneMatch, select, cancellationToken);
        }
        /// <summary> Creates a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="entity"> The key-value to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<KeyValue>> PutKeyValueAsync(string key, string label, string ifMatch, string ifNoneMatch, KeyValue entity, CancellationToken cancellationToken = default)
        {
            return await restClient.PutKeyValueAsync(key, label, ifMatch, ifNoneMatch, entity, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Creates a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="entity"> The key-value to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<KeyValue> PutKeyValue(string key, string label, string ifMatch, string ifNoneMatch, KeyValue entity, CancellationToken cancellationToken = default)
        {
            return restClient.PutKeyValue(key, label, ifMatch, ifNoneMatch, entity, cancellationToken);
        }
        /// <summary> Deletes a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<KeyValue>> DeleteKeyValueAsync(string key, string label, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await restClient.DeleteKeyValueAsync(key, label, ifMatch, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Deletes a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<KeyValue> DeleteKeyValue(string key, string label, string ifMatch, CancellationToken cancellationToken = default)
        {
            return restClient.DeleteKeyValue(key, label, ifMatch, cancellationToken);
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> CheckKeyValueAsync(string key, string label, string acceptDatetime, string ifMatch, string ifNoneMatch, IEnumerable<Head7ItemsItem> select, CancellationToken cancellationToken = default)
        {
            return (await restClient.CheckKeyValueAsync(key, label, acceptDatetime, ifMatch, ifNoneMatch, select, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response CheckKeyValue(string key, string label, string acceptDatetime, string ifMatch, string ifNoneMatch, IEnumerable<Head7ItemsItem> select, CancellationToken cancellationToken = default)
        {
            return restClient.CheckKeyValue(key, label, acceptDatetime, ifMatch, ifNoneMatch, select, cancellationToken).GetRawResponse();
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> CheckLabelsAsync(string name, string after, string acceptDatetime, IEnumerable<string> select, CancellationToken cancellationToken = default)
        {
            return (await restClient.CheckLabelsAsync(name, after, acceptDatetime, select, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response CheckLabels(string name, string after, string acceptDatetime, IEnumerable<string> select, CancellationToken cancellationToken = default)
        {
            return restClient.CheckLabels(name, after, acceptDatetime, select, cancellationToken).GetRawResponse();
        }
        /// <summary> Locks a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<KeyValue>> PutLockAsync(string key, string label, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await restClient.PutLockAsync(key, label, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Locks a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<KeyValue> PutLock(string key, string label, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return restClient.PutLock(key, label, ifMatch, ifNoneMatch, cancellationToken);
        }
        /// <summary> Unlocks a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<KeyValue>> DeleteLockAsync(string key, string label, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await restClient.DeleteLockAsync(key, label, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> Unlocks a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<KeyValue> DeleteLock(string key, string label, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return restClient.DeleteLock(key, label, ifMatch, ifNoneMatch, cancellationToken);
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> CheckRevisionsAsync(string key, string label, string after, string acceptDatetime, IEnumerable<Enum4> select, CancellationToken cancellationToken = default)
        {
            return (await restClient.CheckRevisionsAsync(key, label, after, acceptDatetime, select, cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response CheckRevisions(string key, string label, string after, string acceptDatetime, IEnumerable<Enum4> select, CancellationToken cancellationToken = default)
        {
            return restClient.CheckRevisions(key, label, after, acceptDatetime, select, cancellationToken).GetRawResponse();
        }
        /// <summary> Gets a list of keys. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Key> GetKeysAsync(string name, string after, string acceptDatetime, CancellationToken cancellationToken = default)
        {

            async Task<Page<Key>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await restClient.GetKeysAsync(name, after, acceptDatetime, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Key>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await restClient.GetKeysNextPageAsync(acceptDatetime, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of keys. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Key> GetKeys(string name, string after, string acceptDatetime, CancellationToken cancellationToken = default)
        {

            Page<Key> FirstPageFunc(int? pageSizeHint)
            {
                var response = restClient.GetKeys(name, after, acceptDatetime, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Key> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = restClient.GetKeysNextPage(acceptDatetime, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of key-values. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<KeyValue> GetKeyValuesAsync(string key, string label, string after, string acceptDatetime, IEnumerable<Get6ItemsItem> select, CancellationToken cancellationToken = default)
        {

            async Task<Page<KeyValue>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await restClient.GetKeyValuesAsync(key, label, after, acceptDatetime, select, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<KeyValue>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await restClient.GetKeyValuesNextPageAsync(acceptDatetime, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of key-values. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<KeyValue> GetKeyValues(string key, string label, string after, string acceptDatetime, IEnumerable<Get6ItemsItem> select, CancellationToken cancellationToken = default)
        {

            Page<KeyValue> FirstPageFunc(int? pageSizeHint)
            {
                var response = restClient.GetKeyValues(key, label, after, acceptDatetime, select, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            Page<KeyValue> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = restClient.GetKeyValuesNextPage(acceptDatetime, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of labels. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Label> GetLabelsAsync(string name, string after, string acceptDatetime, IEnumerable<string> select, CancellationToken cancellationToken = default)
        {

            async Task<Page<Label>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await restClient.GetLabelsAsync(name, after, acceptDatetime, select, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Label>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await restClient.GetLabelsNextPageAsync(acceptDatetime, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of labels. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Label> GetLabels(string name, string after, string acceptDatetime, IEnumerable<string> select, CancellationToken cancellationToken = default)
        {

            Page<Label> FirstPageFunc(int? pageSizeHint)
            {
                var response = restClient.GetLabels(name, after, acceptDatetime, select, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Label> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = restClient.GetLabelsNextPage(acceptDatetime, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<KeyValue> GetRevisionsAsync(string key, string label, string after, string acceptDatetime, IEnumerable<Enum4> select, CancellationToken cancellationToken = default)
        {

            async Task<Page<KeyValue>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await restClient.GetRevisionsAsync(key, label, after, acceptDatetime, select, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<KeyValue>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await restClient.GetRevisionsNextPageAsync(acceptDatetime, nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<KeyValue> GetRevisions(string key, string label, string after, string acceptDatetime, IEnumerable<Enum4> select, CancellationToken cancellationToken = default)
        {

            Page<KeyValue> FirstPageFunc(int? pageSizeHint)
            {
                var response = restClient.GetRevisions(key, label, after, acceptDatetime, select, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            Page<KeyValue> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = restClient.GetRevisionsNextPage(acceptDatetime, nextLink, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
