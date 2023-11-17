// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The EntitiesResult. </summary>
    public partial class EntitiesResult
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="EntitiesResult"/>. </summary>
        /// <param name="documents"> Response by document. </param>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="documents"/>, <paramref name="errors"/> or <paramref name="modelVersion"/> is null. </exception>
        internal EntitiesResult(IEnumerable<DocumentEntities> documents, IEnumerable<DocumentError> errors, string modelVersion)
        {
            Argument.AssertNotNull(documents, nameof(documents));
            Argument.AssertNotNull(errors, nameof(errors));
            Argument.AssertNotNull(modelVersion, nameof(modelVersion));

            Documents = documents.ToList();
            Errors = errors.ToList();
            ModelVersion = modelVersion;
        }

        /// <summary> Initializes a new instance of <see cref="EntitiesResult"/>. </summary>
        /// <param name="documents"> Response by document. </param>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal EntitiesResult(IReadOnlyList<DocumentEntities> documents, IReadOnlyList<DocumentError> errors, RequestStatistics statistics, string modelVersion, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Documents = documents;
            Errors = errors;
            Statistics = statistics;
            ModelVersion = modelVersion;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="EntitiesResult"/> for deserialization. </summary>
        internal EntitiesResult()
        {
        }

        /// <summary> Response by document. </summary>
        public IReadOnlyList<DocumentEntities> Documents { get; }
        /// <summary> Errors by document id. </summary>
        public IReadOnlyList<DocumentError> Errors { get; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the request payload. </summary>
        public RequestStatistics Statistics { get; }
        /// <summary> This field indicates which model is used for scoring. </summary>
        public string ModelVersion { get; }
    }
}
