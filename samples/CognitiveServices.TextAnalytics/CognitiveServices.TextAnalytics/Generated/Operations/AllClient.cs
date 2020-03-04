// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using CognitiveServices.TextAnalytics.Models;

namespace CognitiveServices.TextAnalytics
{
    public partial class AllClient
    {
        internal AllRestClient RestClient
        { get; }
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of AllClient. </summary>
        internal AllClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint)
        {
            RestClient = new AllRestClient(clientDiagnostics, pipeline, endpoint);
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        /// <summary> The API returns a list of general named entities in a given document. For the list of supported entity types, check &lt;a href=&quot;https://aka.ms/taner&quot;&gt;Supported Entity Types in Text Analytics API&lt;/a&gt;. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<EntitiesResult>> EntitiesRecognitionGeneralAsync(string modelVersion, bool? showStats, MultiLanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return await RestClient.EntitiesRecognitionGeneralAsync(modelVersion, showStats, input, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> The API returns a list of general named entities in a given document. For the list of supported entity types, check &lt;a href=&quot;https://aka.ms/taner&quot;&gt;Supported Entity Types in Text Analytics API&lt;/a&gt;. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<EntitiesResult> EntitiesRecognitionGeneral(string modelVersion, bool? showStats, MultiLanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return RestClient.EntitiesRecognitionGeneral(modelVersion, showStats, input, cancellationToken);
        }
        /// <summary>
        /// The API returns a list of entities with personal information (\&quot;SSN\&quot;, \&quot;Bank Account\&quot; etc) in the document. For the list of supported entity types, check &lt;a href=&quot;https://aka.ms/tanerpii&quot;&gt;Supported Entity Types in Text Analytics API&lt;/a&gt;. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages.
        /// .
        /// </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<EntitiesResult>> EntitiesRecognitionPiiAsync(string modelVersion, bool? showStats, MultiLanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return await RestClient.EntitiesRecognitionPiiAsync(modelVersion, showStats, input, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// The API returns a list of entities with personal information (\&quot;SSN\&quot;, \&quot;Bank Account\&quot; etc) in the document. For the list of supported entity types, check &lt;a href=&quot;https://aka.ms/tanerpii&quot;&gt;Supported Entity Types in Text Analytics API&lt;/a&gt;. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages.
        /// .
        /// </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<EntitiesResult> EntitiesRecognitionPii(string modelVersion, bool? showStats, MultiLanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return RestClient.EntitiesRecognitionPii(modelVersion, showStats, input, cancellationToken);
        }
        /// <summary> The API returns a list of recognized entities with links to a well-known knowledge base. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<EntityLinkingResult>> EntitiesLinkingAsync(string modelVersion, bool? showStats, MultiLanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return await RestClient.EntitiesLinkingAsync(modelVersion, showStats, input, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> The API returns a list of recognized entities with links to a well-known knowledge base. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<EntityLinkingResult> EntitiesLinking(string modelVersion, bool? showStats, MultiLanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return RestClient.EntitiesLinking(modelVersion, showStats, input, cancellationToken);
        }
        /// <summary> The API returns a list of strings denoting the key phrases in the input text. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<KeyPhraseResult>> KeyPhrasesAsync(string modelVersion, bool? showStats, MultiLanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return await RestClient.KeyPhrasesAsync(modelVersion, showStats, input, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> The API returns a list of strings denoting the key phrases in the input text. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<KeyPhraseResult> KeyPhrases(string modelVersion, bool? showStats, MultiLanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return RestClient.KeyPhrases(modelVersion, showStats, input, cancellationToken);
        }
        /// <summary> The API returns the detected language and a numeric score between 0 and 1. Scores close to 1 indicate 100% certainty that the identified language is true. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<LanguageResult>> LanguagesAsync(string modelVersion, bool? showStats, LanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return await RestClient.LanguagesAsync(modelVersion, showStats, input, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> The API returns the detected language and a numeric score between 0 and 1. Scores close to 1 indicate 100% certainty that the identified language is true. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<LanguageResult> Languages(string modelVersion, bool? showStats, LanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return RestClient.Languages(modelVersion, showStats, input, cancellationToken);
        }
        /// <summary> The API returns a sentiment prediction, as well as sentiment scores for each sentiment class (Positive, Negative, and Neutral) for the document and each sentence within it. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SentimentResponse>> SentimentAsync(string modelVersion, bool? showStats, MultiLanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return await RestClient.SentimentAsync(modelVersion, showStats, input, cancellationToken).ConfigureAwait(false);
        }
        /// <summary> The API returns a sentiment prediction, as well as sentiment scores for each sentiment class (Positive, Negative, and Neutral) for the document and each sentence within it. See the &lt;a href=&quot;https://aka.ms/talangs&quot;&gt;Supported languages in Text Analytics API&lt;/a&gt; for the list of enabled languages. </summary>
        /// <param name="modelVersion"> (Optional) This value indicates which model will be used for scoring. If a model-version is not specified, the API should default to the latest, non-preview version. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain input and document level statistics. </param>
        /// <param name="input"> Collection of documents to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SentimentResponse> Sentiment(string modelVersion, bool? showStats, MultiLanguageBatchInput input, CancellationToken cancellationToken = default)
        {
            return RestClient.Sentiment(modelVersion, showStats, input, cancellationToken);
        }
    }
}
