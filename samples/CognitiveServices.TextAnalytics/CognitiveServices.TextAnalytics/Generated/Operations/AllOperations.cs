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
        /// <summary>
        /// The API returns a list of general named entities in a given document. For the list of supported entity types, check &lt;a href=&quot;https://aka.ms/taner&quot;&gt;Supported Entity Types in Text Analytics API&lt;/a&gt;. For the list of enabled languages, check &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt;.
        /// .
        /// </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="multiLanguageBatchInput"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary>
        /// The API returns a list of entities with personal information (\&quot;SSN\&quot;, \&quot;Bank Account\&quot; etc) in the document. See the &amp;lt;a href=&quot;https://aka.ms/talangs&quot;&amp;gt;Supported languages in Text Analytics API&amp;lt;/a&amp;gt; for the list of enabled languages.
        /// .
        /// </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="multiLanguageBatchInput"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary>
        /// The API returns a list of recognized entities with links to a well-known knowledge base. See the &amp;lt;a href=&quot;https://aka.ms/talangs&quot;&amp;gt;Supported languages in Text Analytics API.
        /// .
        /// </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="multiLanguageBatchInput"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> The API returns a list of strings denoting the key phrases in the input text. See the &amp;lt;a href=&quot;https://aka.ms/talangs&quot;&amp;gt;Supported languages in Text Analytics API&amp;lt;/a&amp;gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="multiLanguageBatchInput"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> The API returns the detected language and a numeric score between 0 and 1. Scores close to 1 indicate 100% certainty that the identified language is true. See the &amp;lt;a href=&quot;https://aka.ms/talangs&quot;&amp;gt;Supported languages in Text Analytics API&amp;lt;/a&amp;gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="languageBatchInput"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> The API returns a sentiment prediction, as well as sentiment scores for each sentiment class (Positive, Negative, and Neutral) for the document and each sentence within it. See the &amp;lt;a href=&quot;https://aka.ms/talangs&quot;&amp;gt;Supported languages in Text Analytics API&amp;lt;/a&amp;gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <param name="multiLanguageBatchInput"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
