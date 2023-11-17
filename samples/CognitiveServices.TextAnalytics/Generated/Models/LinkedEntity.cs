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
    /// <summary> The LinkedEntity. </summary>
    public partial class LinkedEntity
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

        /// <summary> Initializes a new instance of <see cref="LinkedEntity"/>. </summary>
        /// <param name="name"> Entity Linking formal name. </param>
        /// <param name="matches"> List of instances this entity appears in the text. </param>
        /// <param name="language"> Language used in the data source. </param>
        /// <param name="url"> URL for the entity's page from the data source. </param>
        /// <param name="dataSource"> Data source used to extract entity linking, such as Wiki/Bing etc. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="matches"/>, <paramref name="language"/>, <paramref name="url"/> or <paramref name="dataSource"/> is null. </exception>
        internal LinkedEntity(string name, IEnumerable<Match> matches, string language, string url, string dataSource)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(matches, nameof(matches));
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(url, nameof(url));
            Argument.AssertNotNull(dataSource, nameof(dataSource));

            Name = name;
            Matches = matches.ToList();
            Language = language;
            Url = url;
            DataSource = dataSource;
        }

        /// <summary> Initializes a new instance of <see cref="LinkedEntity"/>. </summary>
        /// <param name="name"> Entity Linking formal name. </param>
        /// <param name="matches"> List of instances this entity appears in the text. </param>
        /// <param name="language"> Language used in the data source. </param>
        /// <param name="id"> Unique identifier of the recognized entity from the data source. </param>
        /// <param name="url"> URL for the entity's page from the data source. </param>
        /// <param name="dataSource"> Data source used to extract entity linking, such as Wiki/Bing etc. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal LinkedEntity(string name, IReadOnlyList<Match> matches, string language, string id, string url, string dataSource, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Matches = matches;
            Language = language;
            Id = id;
            Url = url;
            DataSource = dataSource;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="LinkedEntity"/> for deserialization. </summary>
        internal LinkedEntity()
        {
        }

        /// <summary> Entity Linking formal name. </summary>
        public string Name { get; }
        /// <summary> List of instances this entity appears in the text. </summary>
        public IReadOnlyList<Match> Matches { get; }
        /// <summary> Language used in the data source. </summary>
        public string Language { get; }
        /// <summary> Unique identifier of the recognized entity from the data source. </summary>
        public string Id { get; }
        /// <summary> URL for the entity's page from the data source. </summary>
        public string Url { get; }
        /// <summary> Data source used to extract entity linking, such as Wiki/Bing etc. </summary>
        public string DataSource { get; }
    }
}
