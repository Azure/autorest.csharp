// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AppConfiguration.Models.V10;
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
        /// <summary> Gets a list of keys. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyListResult, GetKeysHeaders>> GetKeysAsync(string? name, string? after, string? acceptDatetime, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.GetKeys");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/keys", false);
                if (syncToken != null)
                {
                    request.Headers.Add("Sync-Token", syncToken);
                }
                if (acceptDatetime != null)
                {
                    request.Headers.Add("Accept-Datetime", acceptDatetime);
                }
                if (name != null)
                {
                    request.Uri.AppendQuery("name", name, true);
                }
                request.Uri.AppendQuery("api-version", ApiVersion, true);
                if (after != null)
                {
                    request.Uri.AppendQuery("After", after, true);
                }
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
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<CheckKeysHeaders>> CheckKeysAsync(string? name, string? after, string? acceptDatetime, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.CheckKeys");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Head;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/keys", false);
                if (syncToken != null)
                {
                    request.Headers.Add("Sync-Token", syncToken);
                }
                if (acceptDatetime != null)
                {
                    request.Headers.Add("Accept-Datetime", acceptDatetime);
                }
                if (name != null)
                {
                    request.Uri.AppendQuery("name", name, true);
                }
                request.Uri.AppendQuery("api-version", ApiVersion, true);
                if (after != null)
                {
                    request.Uri.AppendQuery("After", after, true);
                }
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
        /// <summary> Gets a list of key-values. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyValueListResult, GetKeyValuesHeaders>> GetKeyValuesAsync(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Get6ItemsItem>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.GetKeyValues");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/kv", false);
                if (syncToken != null)
                {
                    request.Headers.Add("Sync-Token", syncToken);
                }
                if (acceptDatetime != null)
                {
                    request.Headers.Add("Accept-Datetime", acceptDatetime);
                }
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
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<CheckKeyValuesHeaders>> CheckKeyValuesAsync(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Head6ItemsItem>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.CheckKeyValues");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Head;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/kv", false);
                if (syncToken != null)
                {
                    request.Headers.Add("Sync-Token", syncToken);
                }
                if (acceptDatetime != null)
                {
                    request.Headers.Add("Accept-Datetime", acceptDatetime);
                }
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

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.GetKeyValue");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/kv/", false);
                request.Uri.AppendPath(key, true);
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
                if (label != null)
                {
                    request.Uri.AppendQuery("label", label, true);
                }
                request.Uri.AppendQuery("api-version", ApiVersion, true);
                if (select != null)
                {
                    request.Uri.AppendQueryDelimited("$Select", select, ",", true);
                }
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

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.PutKeyValue");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/kv/", false);
                request.Uri.AppendPath(key, true);
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
                if (label != null)
                {
                    request.Uri.AppendQuery("label", label, true);
                }
                request.Uri.AppendQuery("api-version", ApiVersion, true);
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(entity);
                request.Content = content;
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

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.DeleteKeyValue");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Delete;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/kv/", false);
                request.Uri.AppendPath(key, true);
                if (syncToken != null)
                {
                    request.Headers.Add("Sync-Token", syncToken);
                }
                if (ifMatch != null)
                {
                    request.Headers.Add("If-Match", ifMatch);
                }
                if (label != null)
                {
                    request.Uri.AppendQuery("label", label, true);
                }
                request.Uri.AppendQuery("api-version", ApiVersion, true);
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

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.CheckKeyValue");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Head;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/kv/", false);
                request.Uri.AppendPath(key, true);
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
                if (label != null)
                {
                    request.Uri.AppendQuery("label", label, true);
                }
                request.Uri.AppendQuery("api-version", ApiVersion, true);
                if (select != null)
                {
                    request.Uri.AppendQueryDelimited("$Select", select, ",", true);
                }
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
        /// <summary> Gets a list of labels. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<LabelListResult, GetLabelsHeaders>> GetLabelsAsync(string? name, string? after, string? acceptDatetime, IEnumerable<string>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.GetLabels");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/labels", false);
                if (syncToken != null)
                {
                    request.Headers.Add("Sync-Token", syncToken);
                }
                if (acceptDatetime != null)
                {
                    request.Headers.Add("Accept-Datetime", acceptDatetime);
                }
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
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="name"> A filter for the name of the returned keys. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<CheckLabelsHeaders>> CheckLabelsAsync(string? name, string? after, string? acceptDatetime, IEnumerable<string>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.CheckLabels");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Head;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/labels", false);
                if (syncToken != null)
                {
                    request.Headers.Add("Sync-Token", syncToken);
                }
                if (acceptDatetime != null)
                {
                    request.Headers.Add("Accept-Datetime", acceptDatetime);
                }
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

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.PutLock");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/locks/", false);
                request.Uri.AppendPath(key, true);
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
                if (label != null)
                {
                    request.Uri.AppendQuery("label", label, true);
                }
                request.Uri.AppendQuery("api-version", ApiVersion, true);
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

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.DeleteLock");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Delete;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/locks/", false);
                request.Uri.AppendPath(key, true);
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
                if (label != null)
                {
                    request.Uri.AppendQuery("label", label, true);
                }
                request.Uri.AppendQuery("api-version", ApiVersion, true);
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
        /// <summary> Gets a list of key-value revisions. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<KeyValueListResult, GetRevisionsHeaders>> GetRevisionsAsync(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Enum0>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.GetRevisions");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/revisions", false);
                if (syncToken != null)
                {
                    request.Headers.Add("Sync-Token", syncToken);
                }
                if (acceptDatetime != null)
                {
                    request.Headers.Add("Accept-Datetime", acceptDatetime);
                }
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
        /// <summary> Requests the headers and status of the given resource. </summary>
        /// <param name="key"> A filter used to match keys. </param>
        /// <param name="label"> A filter used to match labels. </param>
        /// <param name="after"> Instructs the server to return elements that appear after the element referred to by the specified token. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<CheckRevisionsHeaders>> CheckRevisionsAsync(string? key, string? label, string? after, string? acceptDatetime, IEnumerable<Enum0>? select, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AppConfiguration.CheckRevisions");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Head;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/revisions", false);
                if (syncToken != null)
                {
                    request.Headers.Add("Sync-Token", syncToken);
                }
                if (acceptDatetime != null)
                {
                    request.Headers.Add("Accept-Datetime", acceptDatetime);
                }
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
    }
}
