// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using CognitiveServices.TextAnalytics.Models;

namespace CognitiveServices.TextAnalytics
{
    internal partial class AllOperations
    {
        private string endpoint;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of AllOperations. </summary>
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
        internal HttpMessage CreateEntitiesRecognitionGeneralRequest(MultiLanguageBatchInput input, string modelVersion, bool? showStats)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/text/analytics/v3.0-preview.1", false);
            uri.AppendPath("/entities/recognition/general", false);
            if (modelVersion != null)
            {
                uri.AppendQuery("model-version", modelVersion, true);
            }
            if (showStats != null)
            {
                uri.AppendQuery("showStats", showStats.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Content-Type", "text/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }
        /// <summary> The API returns a list of general named entities in a given document. For the list of supported entity types, check &lt;a href=&quot;https://aka.ms/taner&quot;&gt;Supported Entity Types in Text Analytics API&lt;/a&gt;. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<EntitiesResult>> EntitiesRecognitionGeneralAsync(MultiLanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesRecognitionGeneral");
            scope.Start();
            try
            {
                using var message = CreateEntitiesRecognitionGeneralRequest(input, modelVersion, showStats);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> The API returns a list of general named entities in a given document. For the list of supported entity types, check &lt;a href=&quot;https://aka.ms/taner&quot;&gt;Supported Entity Types in Text Analytics API&lt;/a&gt;. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<EntitiesResult> EntitiesRecognitionGeneral(MultiLanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesRecognitionGeneral");
            scope.Start();
            try
            {
                using var message = CreateEntitiesRecognitionGeneralRequest(input, modelVersion, showStats);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateEntitiesRecognitionPiiRequest(MultiLanguageBatchInput input, string modelVersion, bool? showStats)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/text/analytics/v3.0-preview.1", false);
            uri.AppendPath("/entities/recognition/pii", false);
            if (modelVersion != null)
            {
                uri.AppendQuery("model-version", modelVersion, true);
            }
            if (showStats != null)
            {
                uri.AppendQuery("showStats", showStats.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Content-Type", "text/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }
        /// <summary>
        /// The API returns a list of entities with personal information (\&quot;SSN\&quot;, \&quot;Bank Account\&quot; etc) in the document. For the list of supported entity types, check &lt;a href=&quot;https://aka.ms/tanerpii&quot;&gt;Supported Entity Types in Text Analytics API&lt;/a&gt;. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages.
        /// .
        /// </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<EntitiesResult>> EntitiesRecognitionPiiAsync(MultiLanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesRecognitionPii");
            scope.Start();
            try
            {
                using var message = CreateEntitiesRecognitionPiiRequest(input, modelVersion, showStats);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary>
        /// The API returns a list of entities with personal information (\&quot;SSN\&quot;, \&quot;Bank Account\&quot; etc) in the document. For the list of supported entity types, check &lt;a href=&quot;https://aka.ms/tanerpii&quot;&gt;Supported Entity Types in Text Analytics API&lt;/a&gt;. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages.
        /// .
        /// </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<EntitiesResult> EntitiesRecognitionPii(MultiLanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesRecognitionPii");
            scope.Start();
            try
            {
                using var message = CreateEntitiesRecognitionPiiRequest(input, modelVersion, showStats);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateEntitiesLinkingRequest(MultiLanguageBatchInput input, string modelVersion, bool? showStats)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/text/analytics/v3.0-preview.1", false);
            uri.AppendPath("/entities/linking", false);
            if (modelVersion != null)
            {
                uri.AppendQuery("model-version", modelVersion, true);
            }
            if (showStats != null)
            {
                uri.AppendQuery("showStats", showStats.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Content-Type", "text/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }
        /// <summary> The API returns a list of recognized entities with links to a well-known knowledge base. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<EntityLinkingResult>> EntitiesLinkingAsync(MultiLanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesLinking");
            scope.Start();
            try
            {
                using var message = CreateEntitiesLinkingRequest(input, modelVersion, showStats);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> The API returns a list of recognized entities with links to a well-known knowledge base. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<EntityLinkingResult> EntitiesLinking(MultiLanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.EntitiesLinking");
            scope.Start();
            try
            {
                using var message = CreateEntitiesLinkingRequest(input, modelVersion, showStats);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateKeyPhrasesRequest(MultiLanguageBatchInput input, string modelVersion, bool? showStats)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/text/analytics/v3.0-preview.1", false);
            uri.AppendPath("/keyPhrases", false);
            if (modelVersion != null)
            {
                uri.AppendQuery("model-version", modelVersion, true);
            }
            if (showStats != null)
            {
                uri.AppendQuery("showStats", showStats.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Content-Type", "text/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }
        /// <summary> The API returns a list of strings denoting the key phrases in the input text. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<KeyPhraseResult>> KeyPhrasesAsync(MultiLanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.KeyPhrases");
            scope.Start();
            try
            {
                using var message = CreateKeyPhrasesRequest(input, modelVersion, showStats);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> The API returns a list of strings denoting the key phrases in the input text. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<KeyPhraseResult> KeyPhrases(MultiLanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.KeyPhrases");
            scope.Start();
            try
            {
                using var message = CreateKeyPhrasesRequest(input, modelVersion, showStats);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateLanguagesRequest(LanguageBatchInput input, string modelVersion, bool? showStats)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/text/analytics/v3.0-preview.1", false);
            uri.AppendPath("/languages", false);
            if (modelVersion != null)
            {
                uri.AppendQuery("model-version", modelVersion, true);
            }
            if (showStats != null)
            {
                uri.AppendQuery("showStats", showStats.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Content-Type", "text/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }
        /// <summary> The API returns the detected language and a numeric score between 0 and 1. Scores close to 1 indicate 100% certainty that the identified language is true. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<LanguageResult>> LanguagesAsync(LanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.Languages");
            scope.Start();
            try
            {
                using var message = CreateLanguagesRequest(input, modelVersion, showStats);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> The API returns the detected language and a numeric score between 0 and 1. Scores close to 1 indicate 100% certainty that the identified language is true. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<LanguageResult> Languages(LanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.Languages");
            scope.Start();
            try
            {
                using var message = CreateLanguagesRequest(input, modelVersion, showStats);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateSentimentRequest(MultiLanguageBatchInput input, string modelVersion, bool? showStats)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/text/analytics/v3.0-preview.1", false);
            uri.AppendPath("/sentiment", false);
            if (modelVersion != null)
            {
                uri.AppendQuery("model-version", modelVersion, true);
            }
            if (showStats != null)
            {
                uri.AppendQuery("showStats", showStats.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Content-Type", "text/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }
        /// <summary> The API returns a sentiment prediction, as well as sentiment scores for each sentiment class (Positive, Negative, and Neutral) for the document and each sentence within it. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SentimentResponse>> SentimentAsync(MultiLanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.Sentiment");
            scope.Start();
            try
            {
                using var message = CreateSentimentRequest(input, modelVersion, showStats);
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
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> The API returns a sentiment prediction, as well as sentiment scores for each sentiment class (Positive, Negative, and Neutral) for the document and each sentence within it. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SentimentResponse> Sentiment(MultiLanguageBatchInput input, string modelVersion, bool? showStats, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.Sentiment");
            scope.Start();
            try
            {
                using var message = CreateSentimentRequest(input, modelVersion, showStats);
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
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
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
