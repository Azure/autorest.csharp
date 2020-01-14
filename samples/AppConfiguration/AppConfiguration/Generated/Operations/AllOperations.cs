// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AppConfiguration.Models.V10;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AppConfiguration
{
    internal partial class AllOperations
    {
        private string? syncToken;
        private string host;
        private string ApiVersion;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of AllOperations. </summary>
        public AllOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string? syncToken, string host = "", string ApiVersion = "1.0")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }
            if (ApiVersion == null)
            {
                throw new ArgumentNullException(nameof(ApiVersion));
            }

            this.syncToken = syncToken;
            this.host = host;
            this.ApiVersion = ApiVersion;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetKeysRequest(string? name, string? after, string? acceptDatetime)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/keys", false);
            if (name != null)
            {
                request.Uri.AppendQuery("name", name, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (after != null)
            {
                request.Uri.AppendQuery("After", after, true);
            }
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }
        /// <summary> Gets a list of keys. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyListResult, GetKeysHeaders>> GetKeysAsync(string? name, string? after, string? acceptDatetime, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetKeys");
            scope.Start();
            try
            {
                using var message = CreateGetKeysRequest(name, after, acceptDatetime);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyListResult.DeserializeKeyListResult(document.RootElement);
                            var headers = new GetKeysHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a list of keys. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyListResult, GetKeysHeaders> GetKeys(string? name, string? after, string? acceptDatetime, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetKeys");
            scope.Start();
            try
            {
                using var message = CreateGetKeysRequest(name, after, acceptDatetime);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyListResult.DeserializeKeyListResult(document.RootElement);
                            var headers = new GetKeysHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetKeysNextPageRequest(string? acceptDatetime, string nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{nextLinkUrl}"));
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }
        /// <summary> Gets a list of keys. </summary>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyListResult, GetKeysHeaders>> GetKeysNextPageAsync(string? acceptDatetime, string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetKeys");
            scope.Start();
            try
            {
                using var message = CreateGetKeysNextPageRequest(acceptDatetime, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyListResult.DeserializeKeyListResult(document.RootElement);
                            var headers = new GetKeysHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a list of keys. </summary>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyListResult, GetKeysHeaders> GetKeysNextPage(string? acceptDatetime, string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetKeys");
            scope.Start();
            try
            {
                using var message = CreateGetKeysNextPageRequest(acceptDatetime, nextLinkUrl);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyListResult.DeserializeKeyListResult(document.RootElement);
                            var headers = new GetKeysHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateCheckKeysRequest(string? name, string? after, string? acceptDatetime)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/keys", false);
            if (name != null)
            {
                request.Uri.AppendQuery("name", name, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (after != null)
            {
                request.Uri.AppendQuery("After", after, true);
            }
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
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
        public async ValueTask<ResponseWithHeaders<CheckKeysHeaders>> CheckKeysAsync(string? name, string? after, string? acceptDatetime, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.CheckKeys");
            scope.Start();
            try
            {
                using var message = CreateCheckKeysRequest(name, after, acceptDatetime);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new CheckKeysHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<CheckKeysHeaders> CheckKeys(string? name, string? after, string? acceptDatetime, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.CheckKeys");
            scope.Start();
            try
            {
                using var message = CreateCheckKeysRequest(name, after, acceptDatetime);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new CheckKeysHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetKeyValuesRequest(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Get6ItemsItem>? select)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/kv", false);
            if (key != null)
            {
                request.Uri.AppendQuery("key", key, true);
            }
            if (label != null)
            {
                request.Uri.AppendQuery("label", label, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (after != null)
            {
                request.Uri.AppendQuery("After", after, true);
            }
            if (select != null)
            {
                request.Uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }
        /// <summary> Gets a list of key-values. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyValueListResult, GetKeyValuesHeaders>> GetKeyValuesAsync(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Get6ItemsItem>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetKeyValues");
            scope.Start();
            try
            {
                using var message = CreateGetKeyValuesRequest(key, label, after, acceptDatetime, select);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                            var headers = new GetKeyValuesHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a list of key-values. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyValueListResult, GetKeyValuesHeaders> GetKeyValues(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Get6ItemsItem>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetKeyValues");
            scope.Start();
            try
            {
                using var message = CreateGetKeyValuesRequest(key, label, after, acceptDatetime, select);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                            var headers = new GetKeyValuesHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetKeyValuesNextPageRequest(string? acceptDatetime, string nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{nextLinkUrl}"));
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }
        /// <summary> Gets a list of key-values. </summary>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyValueListResult, GetKeyValuesHeaders>> GetKeyValuesNextPageAsync(string? acceptDatetime, string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetKeyValues");
            scope.Start();
            try
            {
                using var message = CreateGetKeyValuesNextPageRequest(acceptDatetime, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                            var headers = new GetKeyValuesHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a list of key-values. </summary>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyValueListResult, GetKeyValuesHeaders> GetKeyValuesNextPage(string? acceptDatetime, string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetKeyValues");
            scope.Start();
            try
            {
                using var message = CreateGetKeyValuesNextPageRequest(acceptDatetime, nextLinkUrl);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                            var headers = new GetKeyValuesHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateCheckKeyValuesRequest(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Head6ItemsItem>? select)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/kv", false);
            if (key != null)
            {
                request.Uri.AppendQuery("key", key, true);
            }
            if (label != null)
            {
                request.Uri.AppendQuery("label", label, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (after != null)
            {
                request.Uri.AppendQuery("After", after, true);
            }
            if (select != null)
            {
                request.Uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
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
        public async ValueTask<ResponseWithHeaders<CheckKeyValuesHeaders>> CheckKeyValuesAsync(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Head6ItemsItem>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.CheckKeyValues");
            scope.Start();
            try
            {
                using var message = CreateCheckKeyValuesRequest(key, label, after, acceptDatetime, select);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new CheckKeyValuesHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<CheckKeyValuesHeaders> CheckKeyValues(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Head6ItemsItem>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.CheckKeyValues");
            scope.Start();
            try
            {
                using var message = CreateCheckKeyValuesRequest(key, label, after, acceptDatetime, select);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new CheckKeyValuesHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetKeyValueRequest(string key, string? label, string? acceptDatetime, string? ifMatch, string? ifNoneMatch, IEnumerable<Get7ItemsItem>? select)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/kv/", false);
            request.Uri.AppendPath(key, true);
            if (label != null)
            {
                request.Uri.AppendQuery("label", label, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (select != null)
            {
                request.Uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
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
        /// <summary> Gets a single key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyValue, GetKeyValueHeaders>> GetKeyValueAsync(string key, string? label, string? acceptDatetime, string? ifMatch, string? ifNoneMatch, IEnumerable<Get7ItemsItem>? select, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetKeyValue");
            scope.Start();
            try
            {
                using var message = CreateGetKeyValueRequest(key, label, acceptDatetime, ifMatch, ifNoneMatch, select);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyValue.DeserializeKeyValue(document.RootElement);
                            var headers = new GetKeyValueHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a single key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyValue, GetKeyValueHeaders> GetKeyValue(string key, string? label, string? acceptDatetime, string? ifMatch, string? ifNoneMatch, IEnumerable<Get7ItemsItem>? select, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetKeyValue");
            scope.Start();
            try
            {
                using var message = CreateGetKeyValueRequest(key, label, acceptDatetime, ifMatch, ifNoneMatch, select);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyValue.DeserializeKeyValue(document.RootElement);
                            var headers = new GetKeyValueHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutKeyValueRequest(string key, string? label, string? ifMatch, string? ifNoneMatch, KeyValue? entity)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/kv/", false);
            request.Uri.AppendPath(key, true);
            if (label != null)
            {
                request.Uri.AppendQuery("label", label, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            request.Headers.Add("Content-Type", "application/vnd.microsoft.appconfig.kv+json");
            request.Headers.Add("Content-Type", "application/vnd.microsoft.appconfig.kvset+json");
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Content-Type", "text/json");
            request.Headers.Add("Content-Type", "application/*+json");
            request.Headers.Add("Content-Type", "application/json-patch+json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(entity);
            request.Content = content;
            return message;
        }
        /// <summary> Creates a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="entity"> The key-value to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyValue, PutKeyValueHeaders>> PutKeyValueAsync(string key, string? label, string? ifMatch, string? ifNoneMatch, KeyValue? entity, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.PutKeyValue");
            scope.Start();
            try
            {
                using var message = CreatePutKeyValueRequest(key, label, ifMatch, ifNoneMatch, entity);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyValue.DeserializeKeyValue(document.RootElement);
                            var headers = new PutKeyValueHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Creates a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="entity"> The key-value to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyValue, PutKeyValueHeaders> PutKeyValue(string key, string? label, string? ifMatch, string? ifNoneMatch, KeyValue? entity, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.PutKeyValue");
            scope.Start();
            try
            {
                using var message = CreatePutKeyValueRequest(key, label, ifMatch, ifNoneMatch, entity);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyValue.DeserializeKeyValue(document.RootElement);
                            var headers = new PutKeyValueHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteKeyValueRequest(string key, string? label, string? ifMatch)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/kv/", false);
            request.Uri.AppendPath(key, true);
            if (label != null)
            {
                request.Uri.AppendQuery("label", label, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            return message;
        }
        /// <summary> Deletes a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyValue, DeleteKeyValueHeaders>> DeleteKeyValueAsync(string key, string? label, string? ifMatch, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.DeleteKeyValue");
            scope.Start();
            try
            {
                using var message = CreateDeleteKeyValueRequest(key, label, ifMatch);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyValue.DeserializeKeyValue(document.RootElement);
                            var headers = new DeleteKeyValueHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Deletes a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyValue, DeleteKeyValueHeaders> DeleteKeyValue(string key, string? label, string? ifMatch, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.DeleteKeyValue");
            scope.Start();
            try
            {
                using var message = CreateDeleteKeyValueRequest(key, label, ifMatch);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyValue.DeserializeKeyValue(document.RootElement);
                            var headers = new DeleteKeyValueHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateCheckKeyValueRequest(string key, string? label, string? acceptDatetime, string? ifMatch, string? ifNoneMatch, IEnumerable<Head7ItemsItem>? select)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/kv/", false);
            request.Uri.AppendPath(key, true);
            if (label != null)
            {
                request.Uri.AppendQuery("label", label, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (select != null)
            {
                request.Uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
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
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<CheckKeyValueHeaders>> CheckKeyValueAsync(string key, string? label, string? acceptDatetime, string? ifMatch, string? ifNoneMatch, IEnumerable<Head7ItemsItem>? select, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.CheckKeyValue");
            scope.Start();
            try
            {
                using var message = CreateCheckKeyValueRequest(key, label, acceptDatetime, ifMatch, ifNoneMatch, select);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new CheckKeyValueHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<CheckKeyValueHeaders> CheckKeyValue(string key, string? label, string? acceptDatetime, string? ifMatch, string? ifNoneMatch, IEnumerable<Head7ItemsItem>? select, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.CheckKeyValue");
            scope.Start();
            try
            {
                using var message = CreateCheckKeyValueRequest(key, label, acceptDatetime, ifMatch, ifNoneMatch, select);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new CheckKeyValueHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetLabelsRequest(string? name, string? after, string? acceptDatetime, IEnumerable<string>? select)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/labels", false);
            if (name != null)
            {
                request.Uri.AppendQuery("name", name, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (after != null)
            {
                request.Uri.AppendQuery("After", after, true);
            }
            if (select != null)
            {
                request.Uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }
        /// <summary> Gets a list of labels. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<LabelListResult, GetLabelsHeaders>> GetLabelsAsync(string? name, string? after, string? acceptDatetime, IEnumerable<string>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetLabels");
            scope.Start();
            try
            {
                using var message = CreateGetLabelsRequest(name, after, acceptDatetime, select);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = LabelListResult.DeserializeLabelListResult(document.RootElement);
                            var headers = new GetLabelsHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a list of labels. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LabelListResult, GetLabelsHeaders> GetLabels(string? name, string? after, string? acceptDatetime, IEnumerable<string>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetLabels");
            scope.Start();
            try
            {
                using var message = CreateGetLabelsRequest(name, after, acceptDatetime, select);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = LabelListResult.DeserializeLabelListResult(document.RootElement);
                            var headers = new GetLabelsHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetLabelsNextPageRequest(string? acceptDatetime, string nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{nextLinkUrl}"));
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }
        /// <summary> Gets a list of labels. </summary>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<LabelListResult, GetLabelsHeaders>> GetLabelsNextPageAsync(string? acceptDatetime, string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetLabels");
            scope.Start();
            try
            {
                using var message = CreateGetLabelsNextPageRequest(acceptDatetime, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = LabelListResult.DeserializeLabelListResult(document.RootElement);
                            var headers = new GetLabelsHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a list of labels. </summary>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<LabelListResult, GetLabelsHeaders> GetLabelsNextPage(string? acceptDatetime, string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetLabels");
            scope.Start();
            try
            {
                using var message = CreateGetLabelsNextPageRequest(acceptDatetime, nextLinkUrl);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = LabelListResult.DeserializeLabelListResult(document.RootElement);
                            var headers = new GetLabelsHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateCheckLabelsRequest(string? name, string? after, string? acceptDatetime, IEnumerable<string>? select)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/labels", false);
            if (name != null)
            {
                request.Uri.AppendQuery("name", name, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (after != null)
            {
                request.Uri.AppendQuery("After", after, true);
            }
            if (select != null)
            {
                request.Uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
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
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<CheckLabelsHeaders>> CheckLabelsAsync(string? name, string? after, string? acceptDatetime, IEnumerable<string>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.CheckLabels");
            scope.Start();
            try
            {
                using var message = CreateCheckLabelsRequest(name, after, acceptDatetime, select);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new CheckLabelsHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<CheckLabelsHeaders> CheckLabels(string? name, string? after, string? acceptDatetime, IEnumerable<string>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.CheckLabels");
            scope.Start();
            try
            {
                using var message = CreateCheckLabelsRequest(name, after, acceptDatetime, select);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new CheckLabelsHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutLockRequest(string key, string? label, string? ifMatch, string? ifNoneMatch)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/locks/", false);
            request.Uri.AppendPath(key, true);
            if (label != null)
            {
                request.Uri.AppendQuery("label", label, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
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
        /// <summary> Locks a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyValue, PutLockHeaders>> PutLockAsync(string key, string? label, string? ifMatch, string? ifNoneMatch, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.PutLock");
            scope.Start();
            try
            {
                using var message = CreatePutLockRequest(key, label, ifMatch, ifNoneMatch);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyValue.DeserializeKeyValue(document.RootElement);
                            var headers = new PutLockHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Locks a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyValue, PutLockHeaders> PutLock(string key, string? label, string? ifMatch, string? ifNoneMatch, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.PutLock");
            scope.Start();
            try
            {
                using var message = CreatePutLockRequest(key, label, ifMatch, ifNoneMatch);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyValue.DeserializeKeyValue(document.RootElement);
                            var headers = new PutLockHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteLockRequest(string key, string? label, string? ifMatch, string? ifNoneMatch)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/locks/", false);
            request.Uri.AppendPath(key, true);
            if (label != null)
            {
                request.Uri.AppendQuery("label", label, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
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
        /// <summary> Unlocks a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyValue, DeleteLockHeaders>> DeleteLockAsync(string key, string? label, string? ifMatch, string? ifNoneMatch, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.DeleteLock");
            scope.Start();
            try
            {
                using var message = CreateDeleteLockRequest(key, label, ifMatch, ifNoneMatch);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyValue.DeserializeKeyValue(document.RootElement);
                            var headers = new DeleteLockHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Unlocks a key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyValue, DeleteLockHeaders> DeleteLock(string key, string? label, string? ifMatch, string? ifNoneMatch, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.DeleteLock");
            scope.Start();
            try
            {
                using var message = CreateDeleteLockRequest(key, label, ifMatch, ifNoneMatch);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyValue.DeserializeKeyValue(document.RootElement);
                            var headers = new DeleteLockHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetRevisionsRequest(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Enum0>? select)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/revisions", false);
            if (key != null)
            {
                request.Uri.AppendQuery("key", key, true);
            }
            if (label != null)
            {
                request.Uri.AppendQuery("label", label, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (after != null)
            {
                request.Uri.AppendQuery("After", after, true);
            }
            if (select != null)
            {
                request.Uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }
        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyValueListResult, GetRevisionsHeaders>> GetRevisionsAsync(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Enum0>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetRevisions");
            scope.Start();
            try
            {
                using var message = CreateGetRevisionsRequest(key, label, after, acceptDatetime, select);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                            var headers = new GetRevisionsHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyValueListResult, GetRevisionsHeaders> GetRevisions(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Enum0>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetRevisions");
            scope.Start();
            try
            {
                using var message = CreateGetRevisionsRequest(key, label, after, acceptDatetime, select);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                            var headers = new GetRevisionsHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetRevisionsNextPageRequest(string? acceptDatetime, string nextLinkUrl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri($"{nextLinkUrl}"));
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
            }
            if (acceptDatetime != null)
            {
                request.Headers.Add("Accept-Datetime", acceptDatetime);
            }
            return message;
        }
        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyValueListResult, GetRevisionsHeaders>> GetRevisionsNextPageAsync(string? acceptDatetime, string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetRevisions");
            scope.Start();
            try
            {
                using var message = CreateGetRevisionsNextPageRequest(acceptDatetime, nextLinkUrl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                            var headers = new GetRevisionsHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="nextLinkUrl"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<KeyValueListResult, GetRevisionsHeaders> GetRevisionsNextPage(string? acceptDatetime, string nextLinkUrl, CancellationToken cancellationToken = default)
        {
            if (nextLinkUrl == null)
            {
                throw new ArgumentNullException(nameof(nextLinkUrl));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetRevisions");
            scope.Start();
            try
            {
                using var message = CreateGetRevisionsNextPageRequest(acceptDatetime, nextLinkUrl);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyValueListResult.DeserializeKeyValueListResult(document.RootElement);
                            var headers = new GetRevisionsHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateCheckRevisionsRequest(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Enum0>? select)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            request.Uri.Reset(new Uri($"{host}"));
            request.Uri.AppendPath("/revisions", false);
            if (key != null)
            {
                request.Uri.AppendQuery("key", key, true);
            }
            if (label != null)
            {
                request.Uri.AppendQuery("label", label, true);
            }
            request.Uri.AppendQuery("api-version", ApiVersion, true);
            if (after != null)
            {
                request.Uri.AppendQuery("After", after, true);
            }
            if (select != null)
            {
                request.Uri.AppendQueryDelimited("$Select", select, ",", true);
            }
            if (syncToken != null)
            {
                request.Headers.Add("Sync-Token", syncToken);
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
        public async ValueTask<ResponseWithHeaders<CheckRevisionsHeaders>> CheckRevisionsAsync(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Enum0>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.CheckRevisions");
            scope.Start();
            try
            {
                using var message = CreateCheckRevisionsRequest(key, label, after, acceptDatetime, select);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new CheckRevisionsHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<CheckRevisionsHeaders> CheckRevisions(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Enum0>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.CheckRevisions");
            scope.Start();
            try
            {
                using var message = CreateCheckRevisionsRequest(key, label, after, acceptDatetime, select);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new CheckRevisionsHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a list of keys. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Key> GetKeysPageableAsync(string? name, string? after, string? acceptDatetime, CancellationToken cancellationToken = default)
        {

            async Task<Page<Key>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetKeysAsync(name, after, acceptDatetime, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Key>> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = await GetKeysNextPageAsync(acceptDatetime, nextLinkUrl, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of keys. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Key> GetKeysPageable(string? name, string? after, string? acceptDatetime, CancellationToken cancellationToken = default)
        {

            Page<Key> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetKeys(name, after, acceptDatetime, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Key> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = GetKeysNextPage(acceptDatetime, nextLinkUrl, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of key-values. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<KeyValue> GetKeyValuesPageableAsync(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Get6ItemsItem>? select, CancellationToken cancellationToken = default)
        {

            async Task<Page<KeyValue>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetKeyValuesAsync(key, label, after, acceptDatetime, select, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<KeyValue>> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = await GetKeyValuesNextPageAsync(acceptDatetime, nextLinkUrl, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of key-values. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<KeyValue> GetKeyValuesPageable(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Get6ItemsItem>? select, CancellationToken cancellationToken = default)
        {

            Page<KeyValue> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetKeyValues(key, label, after, acceptDatetime, select, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            Page<KeyValue> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = GetKeyValuesNextPage(acceptDatetime, nextLinkUrl, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of labels. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<Label> GetLabelsPageableAsync(string? name, string? after, string? acceptDatetime, IEnumerable<string>? select, CancellationToken cancellationToken = default)
        {

            async Task<Page<Label>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetLabelsAsync(name, after, acceptDatetime, select, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<Label>> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = await GetLabelsNextPageAsync(acceptDatetime, nextLinkUrl, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of labels. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<Label> GetLabelsPageable(string? name, string? after, string? acceptDatetime, IEnumerable<string>? select, CancellationToken cancellationToken = default)
        {

            Page<Label> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetLabels(name, after, acceptDatetime, select, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            Page<Label> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = GetLabelsNextPage(acceptDatetime, nextLinkUrl, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<KeyValue> GetRevisionsPageableAsync(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Enum0>? select, CancellationToken cancellationToken = default)
        {

            async Task<Page<KeyValue>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetRevisionsAsync(key, label, after, acceptDatetime, select, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<KeyValue>> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = await GetRevisionsNextPageAsync(acceptDatetime, nextLinkUrl, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<KeyValue> GetRevisionsPageable(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Enum0>? select, CancellationToken cancellationToken = default)
        {

            Page<KeyValue> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetRevisions(key, label, after, acceptDatetime, select, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            Page<KeyValue> NextPageFunc(string nextLinkUrl, int? pageSizeHint)
            {
                var response = GetRevisionsNextPage(acceptDatetime, nextLinkUrl, cancellationToken);
                return Page.FromValues(response.Value.Items, response.Value.NextLink, response.GetRawResponse());
            }
            return PageResponseEnumerator.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
