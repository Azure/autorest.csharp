// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AppConfiguration.Models;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AppConfiguration
{
    internal partial class AppConfigurationRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _endpoint;
        private readonly string _syncToken;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of AppConfigurationRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The endpoint of the App Configuration instance to send requests to. </param>
        /// <param name="syncToken"> Used to guarantee real-time consistency between requests. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        public AppConfigurationRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string syncToken = null, string apiVersion = "1.0")
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            _syncToken = syncToken;
            _apiVersion = apiVersion ?? throw new ArgumentNullException(nameof(apiVersion));
        }

        internal HttpMessage CreateGetKeysRequest(string name, string after, string acceptDatetime)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/keys", false);
            if (name != null)
            {
                uri.AppendQuery("name", name, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            if (after != null)
            {
                uri.AppendQuery("After", after, true);
            }
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.keyset+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Gets a list of keys. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<KeyListResult, AppConfigurationGetKeysHeaders>> GetKeysAsync(string name = null, string after = null, string acceptDatetime = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetKeysRequest(name, after, acceptDatetime);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationGetKeysHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyListResult.DeserializeKeyListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of keys. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyListResult, AppConfigurationGetKeysHeaders> GetKeys(string name = null, string after = null, string acceptDatetime = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetKeysRequest(name, after, acceptDatetime);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationGetKeysHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyListResult.DeserializeKeyListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCheckKeysRequest(string name, string after, string acceptDatetime)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/keys", false);
            if (name != null)
            {
                uri.AppendQuery("name", name, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            if (after != null)
            {
                uri.AppendQuery("After", after, true);
            }
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<AppConfigurationCheckKeysHeaders>> CheckKeysAsync(string name = null, string after = null, string acceptDatetime = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateCheckKeysRequest(name, after, acceptDatetime);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationCheckKeysHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<AppConfigurationCheckKeysHeaders> CheckKeys(string name = null, string after = null, string acceptDatetime = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateCheckKeysRequest(name, after, acceptDatetime);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationCheckKeysHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetKeyValuesRequest(string key, string label, string after, string acceptDatetime, IEnumerable<Get6ItemsItem> select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/kv", false);
            if (key != null)
            {
                uri.AppendQuery("key", key, true);
            }
            if (label != null)
            {
                uri.AppendQuery("label", label, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            if (after != null)
            {
                uri.AppendQuery("After", after, true);
            }
            if (select != null && Optional.IsCollectionDefined(select))
            {
                uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.kvset+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Gets a list of key-values. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<KeyValueListResult, AppConfigurationGetKeyValuesHeaders>> GetKeyValuesAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Get6ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetKeyValuesRequest(key, label, after, acceptDatetime, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationGetKeyValuesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValueListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of key-values. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyValueListResult, AppConfigurationGetKeyValuesHeaders> GetKeyValues(string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Get6ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetKeyValuesRequest(key, label, after, acceptDatetime, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationGetKeyValuesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValueListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCheckKeyValuesRequest(string key, string label, string after, string acceptDatetime, IEnumerable<Head6ItemsItem> select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/kv", false);
            if (key != null)
            {
                uri.AppendQuery("key", key, true);
            }
            if (label != null)
            {
                uri.AppendQuery("label", label, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            if (after != null)
            {
                uri.AppendQuery("After", after, true);
            }
            if (select != null && Optional.IsCollectionDefined(select))
            {
                uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<AppConfigurationCheckKeyValuesHeaders>> CheckKeyValuesAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Head6ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateCheckKeyValuesRequest(key, label, after, acceptDatetime, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationCheckKeyValuesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<AppConfigurationCheckKeyValuesHeaders> CheckKeyValues(string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Head6ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateCheckKeyValuesRequest(key, label, after, acceptDatetime, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationCheckKeyValuesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetKeyValueRequest(string key, string label, string acceptDatetime, string ifMatch, string ifNoneMatch, IEnumerable<Get7ItemsItem> select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/kv/", false);
            uri.AppendPath(key, true);
            if (label != null)
            {
                uri.AppendQuery("label", label, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            if (select != null && Optional.IsCollectionDefined(select))
            {
                uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.kv+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Gets a single key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource's etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async Task<ResponseWithHeaders<KeyValue, AppConfigurationGetKeyValueHeaders>> GetKeyValueAsync(string key, string label = null, string acceptDatetime = null, string ifMatch = null, string ifNoneMatch = null, IEnumerable<Get7ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateGetKeyValueRequest(key, label, acceptDatetime, ifMatch, ifNoneMatch, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationGetKeyValueHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValue value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyValue.DeserializeKeyValue(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a single key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource's etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public ResponseWithHeaders<KeyValue, AppConfigurationGetKeyValueHeaders> GetKeyValue(string key, string label = null, string acceptDatetime = null, string ifMatch = null, string ifNoneMatch = null, IEnumerable<Get7ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateGetKeyValueRequest(key, label, acceptDatetime, ifMatch, ifNoneMatch, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationGetKeyValueHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValue value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyValue.DeserializeKeyValue(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutKeyValueRequest(string key, string label, string ifMatch, string ifNoneMatch, KeyValue entity)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/kv/", false);
            uri.AppendPath(key, true);
            if (label != null)
            {
                uri.AppendQuery("label", label, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.kv+json, application/json, application/problem+json");
            if (entity != null)
            {
                request.Headers.Add("Content-Type", "application/vnd.microsoft.appconfig.kv+json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(entity);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Creates a key-value. </summary>
        /// <param name="key"> The key of the key-value to create. </param>
        /// <param name="label"> The label of the key-value to create. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource's etag does not match the value provided. </param>
        /// <param name="entity"> The key-value to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async Task<ResponseWithHeaders<KeyValue, AppConfigurationPutKeyValueHeaders>> PutKeyValueAsync(string key, string label = null, string ifMatch = null, string ifNoneMatch = null, KeyValue entity = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreatePutKeyValueRequest(key, label, ifMatch, ifNoneMatch, entity);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationPutKeyValueHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValue value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyValue.DeserializeKeyValue(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates a key-value. </summary>
        /// <param name="key"> The key of the key-value to create. </param>
        /// <param name="label"> The label of the key-value to create. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource's etag does not match the value provided. </param>
        /// <param name="entity"> The key-value to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public ResponseWithHeaders<KeyValue, AppConfigurationPutKeyValueHeaders> PutKeyValue(string key, string label = null, string ifMatch = null, string ifNoneMatch = null, KeyValue entity = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreatePutKeyValueRequest(key, label, ifMatch, ifNoneMatch, entity);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationPutKeyValueHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValue value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyValue.DeserializeKeyValue(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteKeyValueRequest(string key, string label, string ifMatch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/kv/", false);
            uri.AppendPath(key, true);
            if (label != null)
            {
                uri.AppendQuery("label", label, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.kv+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Deletes a key-value. </summary>
        /// <param name="key"> The key of the key-value to delete. </param>
        /// <param name="label"> The label of the key-value to delete. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async Task<ResponseWithHeaders<KeyValue, AppConfigurationDeleteKeyValueHeaders>> DeleteKeyValueAsync(string key, string label = null, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateDeleteKeyValueRequest(key, label, ifMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationDeleteKeyValueHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValue value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyValue.DeserializeKeyValue(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                case 204:
                    return ResponseWithHeaders.FromValue((KeyValue)null, headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Deletes a key-value. </summary>
        /// <param name="key"> The key of the key-value to delete. </param>
        /// <param name="label"> The label of the key-value to delete. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public ResponseWithHeaders<KeyValue, AppConfigurationDeleteKeyValueHeaders> DeleteKeyValue(string key, string label = null, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateDeleteKeyValueRequest(key, label, ifMatch);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationDeleteKeyValueHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValue value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyValue.DeserializeKeyValue(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                case 204:
                    return ResponseWithHeaders.FromValue((KeyValue)null, headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCheckKeyValueRequest(string key, string label, string acceptDatetime, string ifMatch, string ifNoneMatch, IEnumerable<Head7ItemsItem> select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/kv/", false);
            uri.AppendPath(key, true);
            if (label != null)
            {
                uri.AppendQuery("label", label, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            if (select != null && Optional.IsCollectionDefined(select))
            {
                uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            return message;
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource's etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async Task<ResponseWithHeaders<AppConfigurationCheckKeyValueHeaders>> CheckKeyValueAsync(string key, string label = null, string acceptDatetime = null, string ifMatch = null, string ifNoneMatch = null, IEnumerable<Head7ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateCheckKeyValueRequest(key, label, acceptDatetime, ifMatch, ifNoneMatch, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationCheckKeyValueHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource's etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public ResponseWithHeaders<AppConfigurationCheckKeyValueHeaders> CheckKeyValue(string key, string label = null, string acceptDatetime = null, string ifMatch = null, string ifNoneMatch = null, IEnumerable<Head7ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateCheckKeyValueRequest(key, label, acceptDatetime, ifMatch, ifNoneMatch, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationCheckKeyValueHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLabelsRequest(string name, string after, string acceptDatetime, IEnumerable<Get5ItemsItem> select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/labels", false);
            if (name != null)
            {
                uri.AppendQuery("name", name, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            if (after != null)
            {
                uri.AppendQuery("After", after, true);
            }
            if (select != null && Optional.IsCollectionDefined(select))
            {
                uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.labelset+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Gets a list of labels. </summary>
        /// <param name="name"> A filter for the name of the returned labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<LabelListResult, AppConfigurationGetLabelsHeaders>> GetLabelsAsync(string name = null, string after = null, string acceptDatetime = null, IEnumerable<Get5ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLabelsRequest(name, after, acceptDatetime, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationGetLabelsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        LabelListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = LabelListResult.DeserializeLabelListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of labels. </summary>
        /// <param name="name"> A filter for the name of the returned labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LabelListResult, AppConfigurationGetLabelsHeaders> GetLabels(string name = null, string after = null, string acceptDatetime = null, IEnumerable<Get5ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetLabelsRequest(name, after, acceptDatetime, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationGetLabelsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        LabelListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = LabelListResult.DeserializeLabelListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCheckLabelsRequest(string name, string after, string acceptDatetime, IEnumerable<Head5ItemsItem> select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/labels", false);
            if (name != null)
            {
                uri.AppendQuery("name", name, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            if (after != null)
            {
                uri.AppendQuery("After", after, true);
            }
            if (select != null && Optional.IsCollectionDefined(select))
            {
                uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<AppConfigurationCheckLabelsHeaders>> CheckLabelsAsync(string name = null, string after = null, string acceptDatetime = null, IEnumerable<Head5ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateCheckLabelsRequest(name, after, acceptDatetime, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationCheckLabelsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<AppConfigurationCheckLabelsHeaders> CheckLabels(string name = null, string after = null, string acceptDatetime = null, IEnumerable<Head5ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateCheckLabelsRequest(name, after, acceptDatetime, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationCheckLabelsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutLockRequest(string key, string label, string ifMatch, string ifNoneMatch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/locks/", false);
            uri.AppendPath(key, true);
            if (label != null)
            {
                uri.AppendQuery("label", label, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.kv+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Locks a key-value. </summary>
        /// <param name="key"> The key of the key-value to lock. </param>
        /// <param name="label"> The label, if any, of the key-value to lock. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource's etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async Task<ResponseWithHeaders<KeyValue, AppConfigurationPutLockHeaders>> PutLockAsync(string key, string label = null, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreatePutLockRequest(key, label, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationPutLockHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValue value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyValue.DeserializeKeyValue(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Locks a key-value. </summary>
        /// <param name="key"> The key of the key-value to lock. </param>
        /// <param name="label"> The label, if any, of the key-value to lock. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource's etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public ResponseWithHeaders<KeyValue, AppConfigurationPutLockHeaders> PutLock(string key, string label = null, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreatePutLockRequest(key, label, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationPutLockHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValue value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyValue.DeserializeKeyValue(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteLockRequest(string key, string label, string ifMatch, string ifNoneMatch)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/locks/", false);
            uri.AppendPath(key, true);
            if (label != null)
            {
                uri.AppendQuery("label", label, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.kv+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Unlocks a key-value. </summary>
        /// <param name="key"> The key of the key-value to unlock. </param>
        /// <param name="label"> The label, if any, of the key-value to unlock. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource's etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async Task<ResponseWithHeaders<KeyValue, AppConfigurationDeleteLockHeaders>> DeleteLockAsync(string key, string label = null, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateDeleteLockRequest(key, label, ifMatch, ifNoneMatch);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationDeleteLockHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValue value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyValue.DeserializeKeyValue(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Unlocks a key-value. </summary>
        /// <param name="key"> The key of the key-value to unlock. </param>
        /// <param name="label"> The label, if any, of the key-value to unlock. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource's etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource's etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public ResponseWithHeaders<KeyValue, AppConfigurationDeleteLockHeaders> DeleteLock(string key, string label = null, string ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateDeleteLockRequest(key, label, ifMatch, ifNoneMatch);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationDeleteLockHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValue value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyValue.DeserializeKeyValue(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRevisionsRequest(string key, string label, string after, string acceptDatetime, IEnumerable<Enum6> select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/revisions", false);
            if (key != null)
            {
                uri.AppendQuery("key", key, true);
            }
            if (label != null)
            {
                uri.AppendQuery("label", label, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            if (after != null)
            {
                uri.AppendQuery("After", after, true);
            }
            if (select != null && Optional.IsCollectionDefined(select))
            {
                uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.kvset+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<KeyValueListResult, AppConfigurationGetRevisionsHeaders>> GetRevisionsAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Enum6> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRevisionsRequest(key, label, after, acceptDatetime, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationGetRevisionsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValueListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyValueListResult, AppConfigurationGetRevisionsHeaders> GetRevisions(string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Enum6> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRevisionsRequest(key, label, after, acceptDatetime, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationGetRevisionsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValueListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCheckRevisionsRequest(string key, string label, string after, string acceptDatetime, IEnumerable<Enum7> select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/revisions", false);
            if (key != null)
            {
                uri.AppendQuery("key", key, true);
            }
            if (label != null)
            {
                uri.AppendQuery("label", label, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            if (after != null)
            {
                uri.AppendQuery("After", after, true);
            }
            if (select != null && Optional.IsCollectionDefined(select))
            {
                uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<AppConfigurationCheckRevisionsHeaders>> CheckRevisionsAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Enum7> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateCheckRevisionsRequest(key, label, after, acceptDatetime, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationCheckRevisionsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<AppConfigurationCheckRevisionsHeaders> CheckRevisions(string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Enum7> select = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateCheckRevisionsRequest(key, label, after, acceptDatetime, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationCheckRevisionsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetKeysNextPageRequest(string nextLink, string name, string after, string acceptDatetime)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.keyset+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Gets a list of keys. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<ResponseWithHeaders<KeyListResult, AppConfigurationGetKeysHeaders>> GetKeysNextPageAsync(string nextLink, string name = null, string after = null, string acceptDatetime = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetKeysNextPageRequest(nextLink, name, after, acceptDatetime);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationGetKeysHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyListResult.DeserializeKeyListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of keys. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public ResponseWithHeaders<KeyListResult, AppConfigurationGetKeysHeaders> GetKeysNextPage(string nextLink, string name = null, string after = null, string acceptDatetime = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetKeysNextPageRequest(nextLink, name, after, acceptDatetime);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationGetKeysHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyListResult.DeserializeKeyListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetKeyValuesNextPageRequest(string nextLink, string key, string label, string after, string acceptDatetime, IEnumerable<Get6ItemsItem> select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.kvset+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Gets a list of key-values. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<ResponseWithHeaders<KeyValueListResult, AppConfigurationGetKeyValuesHeaders>> GetKeyValuesNextPageAsync(string nextLink, string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Get6ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetKeyValuesNextPageRequest(nextLink, key, label, after, acceptDatetime, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationGetKeyValuesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValueListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of key-values. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public ResponseWithHeaders<KeyValueListResult, AppConfigurationGetKeyValuesHeaders> GetKeyValuesNextPage(string nextLink, string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Get6ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetKeyValuesNextPageRequest(nextLink, key, label, after, acceptDatetime, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationGetKeyValuesHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValueListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetLabelsNextPageRequest(string nextLink, string name, string after, string acceptDatetime, IEnumerable<Get5ItemsItem> select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.labelset+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Gets a list of labels. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="name"> A filter for the name of the returned labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<ResponseWithHeaders<LabelListResult, AppConfigurationGetLabelsHeaders>> GetLabelsNextPageAsync(string nextLink, string name = null, string after = null, string acceptDatetime = null, IEnumerable<Get5ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetLabelsNextPageRequest(nextLink, name, after, acceptDatetime, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationGetLabelsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        LabelListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = LabelListResult.DeserializeLabelListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of labels. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="name"> A filter for the name of the returned labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public ResponseWithHeaders<LabelListResult, AppConfigurationGetLabelsHeaders> GetLabelsNextPage(string nextLink, string name = null, string after = null, string acceptDatetime = null, IEnumerable<Get5ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetLabelsNextPageRequest(nextLink, name, after, acceptDatetime, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationGetLabelsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        LabelListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = LabelListResult.DeserializeLabelListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRevisionsNextPageRequest(string nextLink, string key, string label, string after, string acceptDatetime, IEnumerable<Enum6> select)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            if (_syncToken != null)
            {
                request.Headers.Add("Sync-Token", _syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            request.Headers.Add("Accept", "application/vnd.microsoft.appconfig.kvset+json, application/json, application/problem+json");
            return message;
        }

        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<ResponseWithHeaders<KeyValueListResult, AppConfigurationGetRevisionsHeaders>> GetRevisionsNextPageAsync(string nextLink, string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Enum6> select = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetRevisionsNextPageRequest(nextLink, key, label, after, acceptDatetime, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new AppConfigurationGetRevisionsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValueListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public ResponseWithHeaders<KeyValueListResult, AppConfigurationGetRevisionsHeaders> GetRevisionsNextPage(string nextLink, string key = null, string label = null, string after = null, string acceptDatetime = null, IEnumerable<Enum6> select = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateGetRevisionsNextPageRequest(nextLink, key, label, after, acceptDatetime, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new AppConfigurationGetRevisionsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyValueListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
