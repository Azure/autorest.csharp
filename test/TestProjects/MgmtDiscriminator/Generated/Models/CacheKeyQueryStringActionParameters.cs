// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the cache-key query string action. </summary>
    public partial class CacheKeyQueryStringActionParameters
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

        /// <summary> Initializes a new instance of <see cref="CacheKeyQueryStringActionParameters"/>. </summary>
        /// <param name="typeName"></param>
        /// <param name="queryStringBehavior"> Caching behavior for the requests. </param>
        public CacheKeyQueryStringActionParameters(CacheKeyQueryStringActionParametersTypeName typeName, QueryStringBehavior queryStringBehavior)
        {
            TypeName = typeName;
            QueryStringBehavior = queryStringBehavior;
        }

        /// <summary> Initializes a new instance of <see cref="CacheKeyQueryStringActionParameters"/>. </summary>
        /// <param name="typeName"></param>
        /// <param name="queryStringBehavior"> Caching behavior for the requests. </param>
        /// <param name="queryParameters"> query parameters to include or exclude (comma separated). </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CacheKeyQueryStringActionParameters(CacheKeyQueryStringActionParametersTypeName typeName, QueryStringBehavior queryStringBehavior, string queryParameters, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TypeName = typeName;
            QueryStringBehavior = queryStringBehavior;
            QueryParameters = queryParameters;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CacheKeyQueryStringActionParameters"/> for deserialization. </summary>
        internal CacheKeyQueryStringActionParameters()
        {
        }

        /// <summary> Gets or sets the type name. </summary>
        [WirePath("typeName")]
        public CacheKeyQueryStringActionParametersTypeName TypeName { get; set; }
        /// <summary> Caching behavior for the requests. </summary>
        [WirePath("queryStringBehavior")]
        public QueryStringBehavior QueryStringBehavior { get; set; }
        /// <summary> query parameters to include or exclude (comma separated). </summary>
        [WirePath("queryParameters")]
        public string QueryParameters { get; set; }
    }
}
