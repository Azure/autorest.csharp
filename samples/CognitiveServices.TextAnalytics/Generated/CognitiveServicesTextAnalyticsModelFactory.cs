// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class CognitiveServicesTextAnalyticsModelFactory
    {
        /// <summary> Initializes a new instance of EntitiesResult. </summary>
        /// <param name="documents"> Response by document. </param>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        /// <returns> A new <see cref="Models.EntitiesResult"/> instance for mocking. </returns>
        public static EntitiesResult EntitiesResult(IEnumerable<DocumentEntities> documents = null, IEnumerable<DocumentError> errors = null, RequestStatistics statistics = null, string modelVersion = null)
        {
            documents ??= new List<DocumentEntities>();
            errors ??= new List<DocumentError>();

            return new EntitiesResult(documents?.ToList(), errors?.ToList(), statistics, modelVersion);
        }

        /// <summary> Initializes a new instance of DocumentEntities. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="entities"> Recognized entities in the document. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        /// <returns> A new <see cref="Models.DocumentEntities"/> instance for mocking. </returns>
        public static DocumentEntities DocumentEntities(string id = null, IEnumerable<Entity> entities = null, IEnumerable<TextAnalyticsWarning> warnings = null, DocumentStatistics statistics = null)
        {
            entities ??= new List<Entity>();
            warnings ??= new List<TextAnalyticsWarning>();

            return new DocumentEntities(id, entities?.ToList(), warnings?.ToList(), statistics);
        }

        /// <summary> Initializes a new instance of Entity. </summary>
        /// <param name="text"> Entity text as appears in the request. </param>
        /// <param name="category"> Entity type, such as Person/Location/Org/SSN etc. </param>
        /// <param name="subcategory"> Entity sub type, such as Age/Year/TimeRange etc. </param>
        /// <param name="offset"> Start position (in Unicode characters) for the entity text. </param>
        /// <param name="length"> Length (in Unicode characters) for the entity text. </param>
        /// <param name="confidenceScore"> Confidence score between 0 and 1 of the extracted entity. </param>
        /// <returns> A new <see cref="Models.Entity"/> instance for mocking. </returns>
        public static Entity Entity(string text = null, string category = null, string subcategory = null, int offset = default, int length = default, double confidenceScore = default)
        {
            return new Entity(text, category, subcategory, offset, length, confidenceScore);
        }

        /// <summary> Initializes a new instance of TextAnalyticsWarning. </summary>
        /// <param name="code"> Error code. </param>
        /// <param name="message"> Warning message. </param>
        /// <param name="targetRef"> A JSON pointer reference indicating the target object. </param>
        /// <returns> A new <see cref="Models.TextAnalyticsWarning"/> instance for mocking. </returns>
        public static TextAnalyticsWarning TextAnalyticsWarning(WarningCodeValue code = default, string message = null, string targetRef = null)
        {
            return new TextAnalyticsWarning(code, message, targetRef);
        }

        /// <summary> Initializes a new instance of DocumentStatistics. </summary>
        /// <param name="charactersCount"> Number of text elements recognized in the document. </param>
        /// <param name="transactionsCount"> Number of transactions for the document. </param>
        /// <returns> A new <see cref="Models.DocumentStatistics"/> instance for mocking. </returns>
        public static DocumentStatistics DocumentStatistics(int charactersCount = default, int transactionsCount = default)
        {
            return new DocumentStatistics(charactersCount, transactionsCount);
        }

        /// <summary> Initializes a new instance of DocumentError. </summary>
        /// <param name="id"> Document Id. </param>
        /// <param name="error"> Document Error. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="error"/> is null. </exception>
        /// <returns> A new <see cref="Models.DocumentError"/> instance for mocking. </returns>
        public static DocumentError DocumentError(string id = null, TextAnalyticsError error = null)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            return new DocumentError(id, error);
        }

        /// <summary> Initializes a new instance of TextAnalyticsError. </summary>
        /// <param name="code"> Error code. </param>
        /// <param name="message"> Error message. </param>
        /// <param name="target"> Error target. </param>
        /// <param name="innererror"> Inner error contains more specific information. </param>
        /// <param name="details"> Details about specific errors that led to this reported error. </param>
        /// <returns> A new <see cref="Models.TextAnalyticsError"/> instance for mocking. </returns>
        public static TextAnalyticsError TextAnalyticsError(ErrorCodeValue code = default, string message = null, string target = null, InnerError innererror = null, IEnumerable<TextAnalyticsError> details = null)
        {
            details ??= new List<TextAnalyticsError>();

            return new TextAnalyticsError(code, message, target, innererror, details?.ToList());
        }

        /// <summary> Initializes a new instance of InnerError. </summary>
        /// <param name="code"> Error code. </param>
        /// <param name="message"> Error message. </param>
        /// <param name="details"> Error details. </param>
        /// <param name="target"> Error target. </param>
        /// <param name="innererror"> Inner error contains more specific information. </param>
        /// <returns> A new <see cref="Models.InnerError"/> instance for mocking. </returns>
        public static InnerError InnerError(InnerErrorCodeValue code = default, string message = null, IReadOnlyDictionary<string, string> details = null, string target = null, InnerError innererror = null)
        {
            details ??= new Dictionary<string, string>();

            return new InnerError(code, message, details, target, innererror);
        }

        /// <summary> Initializes a new instance of RequestStatistics. </summary>
        /// <param name="documentsCount"> Number of documents submitted in the request. </param>
        /// <param name="validDocumentsCount"> Number of valid documents. This excludes empty, over-size limit or non-supported languages documents. </param>
        /// <param name="erroneousDocumentsCount"> Number of invalid documents. This includes empty, over-size limit or non-supported languages documents. </param>
        /// <param name="transactionsCount"> Number of transactions for the request. </param>
        /// <returns> A new <see cref="Models.RequestStatistics"/> instance for mocking. </returns>
        public static RequestStatistics RequestStatistics(int documentsCount = default, int validDocumentsCount = default, int erroneousDocumentsCount = default, long transactionsCount = default)
        {
            return new RequestStatistics(documentsCount, validDocumentsCount, erroneousDocumentsCount, transactionsCount);
        }

        /// <summary> Initializes a new instance of EntityLinkingResult. </summary>
        /// <param name="documents"> Response by document. </param>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        /// <returns> A new <see cref="Models.EntityLinkingResult"/> instance for mocking. </returns>
        public static EntityLinkingResult EntityLinkingResult(IEnumerable<DocumentLinkedEntities> documents = null, IEnumerable<DocumentError> errors = null, RequestStatistics statistics = null, string modelVersion = null)
        {
            documents ??= new List<DocumentLinkedEntities>();
            errors ??= new List<DocumentError>();

            return new EntityLinkingResult(documents?.ToList(), errors?.ToList(), statistics, modelVersion);
        }

        /// <summary> Initializes a new instance of DocumentLinkedEntities. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="entities"> Recognized well-known entities in the document. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        /// <returns> A new <see cref="Models.DocumentLinkedEntities"/> instance for mocking. </returns>
        public static DocumentLinkedEntities DocumentLinkedEntities(string id = null, IEnumerable<LinkedEntity> entities = null, IEnumerable<TextAnalyticsWarning> warnings = null, DocumentStatistics statistics = null)
        {
            entities ??= new List<LinkedEntity>();
            warnings ??= new List<TextAnalyticsWarning>();

            return new DocumentLinkedEntities(id, entities?.ToList(), warnings?.ToList(), statistics);
        }

        /// <summary> Initializes a new instance of LinkedEntity. </summary>
        /// <param name="name"> Entity Linking formal name. </param>
        /// <param name="matches"> List of instances this entity appears in the text. </param>
        /// <param name="language"> Language used in the data source. </param>
        /// <param name="id"> Unique identifier of the recognized entity from the data source. </param>
        /// <param name="url"> URL for the entity's page from the data source. </param>
        /// <param name="dataSource"> Data source used to extract entity linking, such as Wiki/Bing etc. </param>
        /// <returns> A new <see cref="Models.LinkedEntity"/> instance for mocking. </returns>
        public static LinkedEntity LinkedEntity(string name = null, IEnumerable<Match> matches = null, string language = null, string id = null, string url = null, string dataSource = null)
        {
            matches ??= new List<Match>();

            return new LinkedEntity(name, matches?.ToList(), language, id, url, dataSource);
        }

        /// <summary> Initializes a new instance of Match. </summary>
        /// <param name="confidenceScore"> If a well-known item is recognized, a decimal number denoting the confidence level between 0 and 1 will be returned. </param>
        /// <param name="text"> Entity text as appears in the request. </param>
        /// <param name="offset"> Start position (in Unicode characters) for the entity match text. </param>
        /// <param name="length"> Length (in Unicode characters) for the entity match text. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        /// <returns> A new <see cref="Models.Match"/> instance for mocking. </returns>
        public static Match Match(double confidenceScore = default, string text = null, int offset = default, int length = default)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return new Match(confidenceScore, text, offset, length);
        }

        /// <summary> Initializes a new instance of KeyPhraseResult. </summary>
        /// <param name="documents"> Response by document. </param>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        /// <returns> A new <see cref="Models.KeyPhraseResult"/> instance for mocking. </returns>
        public static KeyPhraseResult KeyPhraseResult(IEnumerable<DocumentKeyPhrases> documents = null, IEnumerable<DocumentError> errors = null, RequestStatistics statistics = null, string modelVersion = null)
        {
            documents ??= new List<DocumentKeyPhrases>();
            errors ??= new List<DocumentError>();

            return new KeyPhraseResult(documents?.ToList(), errors?.ToList(), statistics, modelVersion);
        }

        /// <summary> Initializes a new instance of DocumentKeyPhrases. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="keyPhrases"> A list of representative words or phrases. The number of key phrases returned is proportional to the number of words in the input document. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        /// <returns> A new <see cref="Models.DocumentKeyPhrases"/> instance for mocking. </returns>
        public static DocumentKeyPhrases DocumentKeyPhrases(string id = null, IEnumerable<string> keyPhrases = null, IEnumerable<TextAnalyticsWarning> warnings = null, DocumentStatistics statistics = null)
        {
            keyPhrases ??= new List<string>();
            warnings ??= new List<TextAnalyticsWarning>();

            return new DocumentKeyPhrases(id, keyPhrases?.ToList(), warnings?.ToList(), statistics);
        }

        /// <summary> Initializes a new instance of LanguageResult. </summary>
        /// <param name="documents"> Response by document. </param>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        /// <returns> A new <see cref="Models.LanguageResult"/> instance for mocking. </returns>
        public static LanguageResult LanguageResult(IEnumerable<DocumentLanguage> documents = null, IEnumerable<DocumentError> errors = null, RequestStatistics statistics = null, string modelVersion = null)
        {
            documents ??= new List<DocumentLanguage>();
            errors ??= new List<DocumentError>();

            return new LanguageResult(documents?.ToList(), errors?.ToList(), statistics, modelVersion);
        }

        /// <summary> Initializes a new instance of DocumentLanguage. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="detectedLanguage"> Detected Language. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        /// <returns> A new <see cref="Models.DocumentLanguage"/> instance for mocking. </returns>
        public static DocumentLanguage DocumentLanguage(string id = null, DetectedLanguage detectedLanguage = null, IEnumerable<TextAnalyticsWarning> warnings = null, DocumentStatistics statistics = null)
        {
            warnings ??= new List<TextAnalyticsWarning>();

            return new DocumentLanguage(id, detectedLanguage, warnings?.ToList(), statistics);
        }

        /// <summary> Initializes a new instance of DetectedLanguage. </summary>
        /// <param name="name"> Long name of a detected language (e.g. English, French). </param>
        /// <param name="iso6391Name"> A two letter representation of the detected language according to the ISO 639-1 standard (e.g. en, fr). </param>
        /// <param name="confidenceScore"> A confidence score between 0 and 1. Scores close to 1 indicate 100% certainty that the identified language is true. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="iso6391Name"/> is null. </exception>
        /// <returns> A new <see cref="Models.DetectedLanguage"/> instance for mocking. </returns>
        public static DetectedLanguage DetectedLanguage(string name = null, string iso6391Name = null, double confidenceScore = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (iso6391Name == null)
            {
                throw new ArgumentNullException(nameof(iso6391Name));
            }

            return new DetectedLanguage(name, iso6391Name, confidenceScore);
        }

        /// <summary> Initializes a new instance of SentimentResponse. </summary>
        /// <param name="documents"> Sentiment analysis per document. </param>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        /// <returns> A new <see cref="Models.SentimentResponse"/> instance for mocking. </returns>
        public static SentimentResponse SentimentResponse(IEnumerable<DocumentSentiment> documents = null, IEnumerable<DocumentError> errors = null, RequestStatistics statistics = null, string modelVersion = null)
        {
            documents ??= new List<DocumentSentiment>();
            errors ??= new List<DocumentError>();

            return new SentimentResponse(documents?.ToList(), errors?.ToList(), statistics, modelVersion);
        }

        /// <summary> Initializes a new instance of DocumentSentiment. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="sentiment"> Predicted sentiment for document (Negative, Neutral, Positive, or Mixed). </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the document payload. </param>
        /// <param name="confidenceScores"> Document level sentiment confidence scores between 0 and 1 for each sentiment class. </param>
        /// <param name="sentences"> Sentence level sentiment analysis. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <returns> A new <see cref="Models.DocumentSentiment"/> instance for mocking. </returns>
        public static DocumentSentiment DocumentSentiment(string id = null, DocumentSentimentValue sentiment = default, DocumentStatistics statistics = null, SentimentConfidenceScorePerLabel confidenceScores = null, IEnumerable<SentenceSentiment> sentences = null, IEnumerable<TextAnalyticsWarning> warnings = null)
        {
            sentences ??= new List<SentenceSentiment>();
            warnings ??= new List<TextAnalyticsWarning>();

            return new DocumentSentiment(id, sentiment, statistics, confidenceScores, sentences?.ToList(), warnings?.ToList());
        }

        /// <summary> Initializes a new instance of SentimentConfidenceScorePerLabel. </summary>
        /// <param name="positive"></param>
        /// <param name="neutral"></param>
        /// <param name="negative"></param>
        /// <returns> A new <see cref="Models.SentimentConfidenceScorePerLabel"/> instance for mocking. </returns>
        public static SentimentConfidenceScorePerLabel SentimentConfidenceScorePerLabel(double positive = default, double neutral = default, double negative = default)
        {
            return new SentimentConfidenceScorePerLabel(positive, neutral, negative);
        }

        /// <summary> Initializes a new instance of SentenceSentiment. </summary>
        /// <param name="text"> The sentence text. </param>
        /// <param name="sentiment"> The predicted Sentiment for the sentence. </param>
        /// <param name="confidenceScores"> The sentiment confidence score between 0 and 1 for the sentence for all classes. </param>
        /// <param name="offset"> The sentence offset from the start of the document. </param>
        /// <param name="length"> The length of the sentence by Unicode standard. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="confidenceScores"/> is null. </exception>
        /// <returns> A new <see cref="Models.SentenceSentiment"/> instance for mocking. </returns>
        public static SentenceSentiment SentenceSentiment(string text = null, SentenceSentimentValue sentiment = default, SentimentConfidenceScorePerLabel confidenceScores = null, int offset = default, int length = default)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (confidenceScores == null)
            {
                throw new ArgumentNullException(nameof(confidenceScores));
            }

            return new SentenceSentiment(text, sentiment, confidenceScores, offset, length);
        }
    }
}
