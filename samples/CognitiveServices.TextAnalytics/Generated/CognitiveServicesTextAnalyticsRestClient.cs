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
    internal partial class CognitiveServicesTextAnalyticsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of CognitiveServicesTextAnalyticsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> Supported Cognitive Services endpoints (protocol and hostname, for example: https://westus.api.cognitive.microsoft.com). </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/> or <paramref name="endpoint"/> is null. </exception>
        public CognitiveServicesTextAnalyticsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }

        internal HttpMessage CreateEntitiesRecognitionGeneralRequest(MultiLanguageBatchInput input, string modelVersion, bool? showStats)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/text/analytics/v3.0", false);
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
            request.Headers.Add("Accept", "application/json, text/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }

        /// <summary> Named Entity Recognition. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <remarks> The API returns a list of general named entities in a given document. For the list of supported entity types, check &lt;a href="https://aka.ms/taner"&gt;Supported Entity Types in Text Analytics API&lt;/a&gt;. See the &lt;a href="https://aka.ms/talangs"&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </remarks>
        public async Task<Response<EntitiesResult>> EntitiesRecognitionGeneralAsync(MultiLanguageBatchInput input, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var message = CreateEntitiesRecognitionGeneralRequest(input, modelVersion, showStats);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        EntitiesResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = EntitiesResult.DeserializeEntitiesResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Named Entity Recognition. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <remarks> The API returns a list of general named entities in a given document. For the list of supported entity types, check &lt;a href="https://aka.ms/taner"&gt;Supported Entity Types in Text Analytics API&lt;/a&gt;. See the &lt;a href="https://aka.ms/talangs"&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </remarks>
        public Response<EntitiesResult> EntitiesRecognitionGeneral(MultiLanguageBatchInput input, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var message = CreateEntitiesRecognitionGeneralRequest(input, modelVersion, showStats);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        EntitiesResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = EntitiesResult.DeserializeEntitiesResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateEntitiesLinkingRequest(MultiLanguageBatchInput input, string modelVersion, bool? showStats)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/text/analytics/v3.0", false);
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
            request.Headers.Add("Accept", "application/json, text/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }

        /// <summary> Linked entities from a well-known knowledge base. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <remarks> The API returns a list of recognized entities with links to a well-known knowledge base. See the &lt;a href="https://aka.ms/talangs"&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </remarks>
        public async Task<Response<EntityLinkingResult>> EntitiesLinkingAsync(MultiLanguageBatchInput input, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var message = CreateEntitiesLinkingRequest(input, modelVersion, showStats);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        EntityLinkingResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = EntityLinkingResult.DeserializeEntityLinkingResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Linked entities from a well-known knowledge base. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <remarks> The API returns a list of recognized entities with links to a well-known knowledge base. See the &lt;a href="https://aka.ms/talangs"&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </remarks>
        public Response<EntityLinkingResult> EntitiesLinking(MultiLanguageBatchInput input, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var message = CreateEntitiesLinkingRequest(input, modelVersion, showStats);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        EntityLinkingResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = EntityLinkingResult.DeserializeEntityLinkingResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateKeyPhrasesRequest(MultiLanguageBatchInput input, string modelVersion, bool? showStats)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/text/analytics/v3.0", false);
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
            request.Headers.Add("Accept", "application/json, text/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }

        /// <summary> Key Phrases. </summary>
        /// <param name="input"> Collection of documents to analyze. Documents can now contain a language field to indicate the text language. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <remarks> The API returns a list of strings denoting the key phrases in the input text. See the &lt;a href="https://aka.ms/talangs"&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </remarks>
        public async Task<Response<KeyPhraseResult>> KeyPhrasesAsync(MultiLanguageBatchInput input, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var message = CreateKeyPhrasesRequest(input, modelVersion, showStats);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyPhraseResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = KeyPhraseResult.DeserializeKeyPhraseResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Key Phrases. </summary>
        /// <param name="input"> Collection of documents to analyze. Documents can now contain a language field to indicate the text language. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <remarks> The API returns a list of strings denoting the key phrases in the input text. See the &lt;a href="https://aka.ms/talangs"&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </remarks>
        public Response<KeyPhraseResult> KeyPhrases(MultiLanguageBatchInput input, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var message = CreateKeyPhrasesRequest(input, modelVersion, showStats);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        KeyPhraseResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = KeyPhraseResult.DeserializeKeyPhraseResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateLanguagesRequest(LanguageBatchInput input, string modelVersion, bool? showStats)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/text/analytics/v3.0", false);
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
            request.Headers.Add("Accept", "application/json, text/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }

        /// <summary> Detect Language. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <remarks> The API returns the detected language and a numeric score between 0 and 1. Scores close to 1 indicate 100% certainty that the identified language is true. See the &lt;a href="https://aka.ms/talangs"&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </remarks>
        public async Task<Response<LanguageResult>> LanguagesAsync(LanguageBatchInput input, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var message = CreateLanguagesRequest(input, modelVersion, showStats);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        LanguageResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = LanguageResult.DeserializeLanguageResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Detect Language. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <remarks> The API returns the detected language and a numeric score between 0 and 1. Scores close to 1 indicate 100% certainty that the identified language is true. See the &lt;a href="https://aka.ms/talangs"&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </remarks>
        public Response<LanguageResult> Languages(LanguageBatchInput input, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var message = CreateLanguagesRequest(input, modelVersion, showStats);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        LanguageResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = LanguageResult.DeserializeLanguageResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateSentimentRequest(MultiLanguageBatchInput input, string modelVersion, bool? showStats)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRaw("/text/analytics/v3.0", false);
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
            request.Headers.Add("Accept", "application/json, text/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            request.Content = content;
            return message;
        }

        /// <summary> Sentiment. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <remarks> The API returns a sentiment prediction, as well as sentiment scores for each sentiment class (Positive, Negative, and Neutral) for the document and each sentence within it. See the &lt;a href="https://aka.ms/talangs"&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </remarks>
        public async Task<Response<SentimentResponse>> SentimentAsync(MultiLanguageBatchInput input, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var message = CreateSentimentRequest(input, modelVersion, showStats);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SentimentResponse value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = SentimentResponse.DeserializeSentimentResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Sentiment. </summary>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        /// <remarks> The API returns a sentiment prediction, as well as sentiment scores for each sentiment class (Positive, Negative, and Neutral) for the document and each sentence within it. See the &lt;a href="https://aka.ms/talangs"&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </remarks>
        public Response<SentimentResponse> Sentiment(MultiLanguageBatchInput input, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            using var message = CreateSentimentRequest(input, modelVersion, showStats);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SentimentResponse value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = SentimentResponse.DeserializeSentimentResponse(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
