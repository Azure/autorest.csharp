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
        internal HttpMessage CreateEntitiesRecognitionGeneralRequest(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{endpoint}/text/analytics/v3.0-preview.1"));
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
            return message;
        }
        public async ValueTask<Response<EntitiesResult>> EntitiesRecognitionGeneralAsync(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesRecognitionGeneral");
            scope.Start();
            try
            {
                using var message = CreateEntitiesRecognitionGeneralRequest(modelVersion, showStats, multiLanguageBatchInput);
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public Response<EntitiesResult> EntitiesRecognitionGeneral(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesRecognitionGeneral");
            scope.Start();
            try
            {
                using var message = CreateEntitiesRecognitionGeneralRequest(modelVersion, showStats, multiLanguageBatchInput);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = EntitiesResult.DeserializeEntitiesResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        internal HttpMessage CreateEntitiesRecognitionPiiRequest(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{endpoint}/text/analytics/v3.0-preview.1"));
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
            return message;
        }
        public async ValueTask<Response<EntitiesResult>> EntitiesRecognitionPiiAsync(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesRecognitionPii");
            scope.Start();
            try
            {
                using var message = CreateEntitiesRecognitionPiiRequest(modelVersion, showStats, multiLanguageBatchInput);
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public Response<EntitiesResult> EntitiesRecognitionPii(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesRecognitionPii");
            scope.Start();
            try
            {
                using var message = CreateEntitiesRecognitionPiiRequest(modelVersion, showStats, multiLanguageBatchInput);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = EntitiesResult.DeserializeEntitiesResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        internal HttpMessage CreateEntitiesLinkingRequest(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{endpoint}/text/analytics/v3.0-preview.1"));
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
            return message;
        }
        public async ValueTask<Response<EntityLinkingResult>> EntitiesLinkingAsync(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesLinking");
            scope.Start();
            try
            {
                using var message = CreateEntitiesLinkingRequest(modelVersion, showStats, multiLanguageBatchInput);
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public Response<EntityLinkingResult> EntitiesLinking(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesLinking");
            scope.Start();
            try
            {
                using var message = CreateEntitiesLinkingRequest(modelVersion, showStats, multiLanguageBatchInput);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = EntityLinkingResult.DeserializeEntityLinkingResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        internal HttpMessage CreateKeyPhrasesRequest(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{endpoint}/text/analytics/v3.0-preview.1"));
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
            return message;
        }
        public async ValueTask<Response<KeyPhraseResult>> KeyPhrasesAsync(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.KeyPhrases");
            scope.Start();
            try
            {
                using var message = CreateKeyPhrasesRequest(modelVersion, showStats, multiLanguageBatchInput);
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public Response<KeyPhraseResult> KeyPhrases(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.KeyPhrases");
            scope.Start();
            try
            {
                using var message = CreateKeyPhrasesRequest(modelVersion, showStats, multiLanguageBatchInput);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = KeyPhraseResult.DeserializeKeyPhraseResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        internal HttpMessage CreateLanguagesRequest(string? modelVersion, bool? showStats, LanguageBatchInput languageBatchInput)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{endpoint}/text/analytics/v3.0-preview.1"));
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
            return message;
        }
        public async ValueTask<Response<LanguageResult>> LanguagesAsync(string? modelVersion, bool? showStats, LanguageBatchInput languageBatchInput, CancellationToken cancellationToken = default)
        {
            if (languageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(languageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.Languages");
            scope.Start();
            try
            {
                using var message = CreateLanguagesRequest(modelVersion, showStats, languageBatchInput);
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public Response<LanguageResult> Languages(string? modelVersion, bool? showStats, LanguageBatchInput languageBatchInput, CancellationToken cancellationToken = default)
        {
            if (languageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(languageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.Languages");
            scope.Start();
            try
            {
                using var message = CreateLanguagesRequest(modelVersion, showStats, languageBatchInput);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = LanguageResult.DeserializeLanguageResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
        internal HttpMessage CreateSentimentRequest(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri("{endpoint}/text/analytics/v3.0-preview.1"));
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
            return message;
        }
        public async ValueTask<Response<SentimentResponse>> SentimentAsync(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.Sentiment");
            scope.Start();
            try
            {
                using var message = CreateSentimentRequest(modelVersion, showStats, multiLanguageBatchInput);
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public Response<SentimentResponse> Sentiment(string? modelVersion, bool? showStats, MultiLanguageBatchInput multiLanguageBatchInput, CancellationToken cancellationToken = default)
        {
            if (multiLanguageBatchInput == null)
            {
                throw new ArgumentNullException(nameof(multiLanguageBatchInput));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.Sentiment");
            scope.Start();
            try
            {
                using var message = CreateSentimentRequest(modelVersion, showStats, multiLanguageBatchInput);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = SentimentResponse.DeserializeSentimentResponse(document.RootElement);
                            return Response.FromValue(value, message.Response);
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
    }
}
