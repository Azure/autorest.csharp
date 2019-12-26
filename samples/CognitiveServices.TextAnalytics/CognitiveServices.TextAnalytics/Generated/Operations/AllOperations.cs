// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using CognitiveServices.TextAnalytics.Models.VV30Preview1;

namespace CognitiveServices.TextAnalytics
{
    internal partial class AllOperations
    {
        private string endpoint;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        public AllOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }

            this.endpoint = endpoint;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        public async ValueTask<Response<EntitiesResult>> EntitiesRecognitionGeneralAsync(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("CognitiveServices.TextAnalytics.EntitiesRecognitionGeneral");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{endpoint}/text/analytics/v3.0-preview.1"));
                request.Uri.AppendPath("/entities/recognition/general", false);
                request.Headers.Add("Content-Type", "application/json");
                request.Headers.Add("Content-Type", "text/json");
                if (modelVersion != null)
                {
                    request.Uri.AppendQuery("model-version", modelVersion, true);
                }
                if (showStats != null)
                {
                    request.Uri.AppendQuery("showStats", showStats.Value, true);
                }
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(multiLanguageBatchInput);
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = EntitiesResult.DeserializeEntitiesResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<EntitiesResult>> EntitiesRecognitionPiiAsync(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("CognitiveServices.TextAnalytics.EntitiesRecognitionPii");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{endpoint}/text/analytics/v3.0-preview.1"));
                request.Uri.AppendPath("/entities/recognition/pii", false);
                request.Headers.Add("Content-Type", "application/json");
                request.Headers.Add("Content-Type", "text/json");
                if (modelVersion != null)
                {
                    request.Uri.AppendQuery("model-version", modelVersion, true);
                }
                if (showStats != null)
                {
                    request.Uri.AppendQuery("showStats", showStats.Value, true);
                }
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(multiLanguageBatchInput);
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = EntitiesResult.DeserializeEntitiesResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<EntityLinkingResult>> EntitiesLinkingAsync(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("CognitiveServices.TextAnalytics.EntitiesLinking");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{endpoint}/text/analytics/v3.0-preview.1"));
                request.Uri.AppendPath("/entities/linking", false);
                request.Headers.Add("Content-Type", "application/json");
                request.Headers.Add("Content-Type", "text/json");
                if (modelVersion != null)
                {
                    request.Uri.AppendQuery("model-version", modelVersion, true);
                }
                if (showStats != null)
                {
                    request.Uri.AppendQuery("showStats", showStats.Value, true);
                }
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(multiLanguageBatchInput);
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = EntityLinkingResult.DeserializeEntityLinkingResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<KeyPhraseResult>> KeyPhrasesAsync(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("CognitiveServices.TextAnalytics.KeyPhrases");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{endpoint}/text/analytics/v3.0-preview.1"));
                request.Uri.AppendPath("/keyPhrases", false);
                request.Headers.Add("Content-Type", "application/json");
                request.Headers.Add("Content-Type", "text/json");
                if (modelVersion != null)
                {
                    request.Uri.AppendQuery("model-version", modelVersion, true);
                }
                if (showStats != null)
                {
                    request.Uri.AppendQuery("showStats", showStats.Value, true);
                }
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(multiLanguageBatchInput);
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = KeyPhraseResult.DeserializeKeyPhraseResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<LanguageResult>> LanguagesAsync(string? modelVersion, bool? showStats, LanguageBatchInput languageBatchInput, CancellationToken cancellationToken = default)
        {
            if (languageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(languageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("CognitiveServices.TextAnalytics.Languages");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{endpoint}/text/analytics/v3.0-preview.1"));
                request.Uri.AppendPath("/languages", false);
                request.Headers.Add("Content-Type", "application/json");
                request.Headers.Add("Content-Type", "text/json");
                if (modelVersion != null)
                {
                    request.Uri.AppendQuery("model-version", modelVersion, true);
                }
                if (showStats != null)
                {
                    request.Uri.AppendQuery("showStats", showStats.Value, true);
                }
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(languageBatchInput);
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = LanguageResult.DeserializeLanguageResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<SentimentResponse>> SentimentAsync(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("CognitiveServices.TextAnalytics.Sentiment");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Post;
                request.Uri.Reset(new Uri($"{endpoint}/text/analytics/v3.0-preview.1"));
                request.Uri.AppendPath("/sentiment", false);
                request.Headers.Add("Content-Type", "application/json");
                request.Headers.Add("Content-Type", "text/json");
                if (modelVersion != null)
                {
                    request.Uri.AppendQuery("model-version", modelVersion, true);
                }
                if (showStats != null)
                {
                    request.Uri.AppendQuery("showStats", showStats.Value, true);
                }
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(multiLanguageBatchInput);
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = SentimentResponse.DeserializeSentimentResponse(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
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
