// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace body_formdata_urlencoded.Models
{
    /// <summary> The PathsPvivzlFormsdataurlencodedPartialconstantbodyPostRequestbodyContentApplicationXWwwFormUrlencodedSchema. </summary>
    internal partial class PathsPvivzlFormsdataurlencodedPartialconstantbodyPostRequestbodyContentApplicationXWwwFormUrlencodedSchema
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

        /// <summary> Initializes a new instance of <see cref="PathsPvivzlFormsdataurlencodedPartialconstantbodyPostRequestbodyContentApplicationXWwwFormUrlencodedSchema"/>. </summary>
        /// <param name="service"> Indicates the name of your Azure container registry. </param>
        /// <param name="aadAccessToken"> AAD access token, mandatory when grant_type is access_token_refresh_token or access_token. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="service"/> or <paramref name="aadAccessToken"/> is null. </exception>
        internal PathsPvivzlFormsdataurlencodedPartialconstantbodyPostRequestbodyContentApplicationXWwwFormUrlencodedSchema(string service, string aadAccessToken)
        {
            Argument.AssertNotNull(service, nameof(service));
            Argument.AssertNotNull(aadAccessToken, nameof(aadAccessToken));

            GrantType = PostContentSchemaGrantType.AccessToken;
            Service = service;
            AadAccessToken = aadAccessToken;
        }

        /// <summary> Initializes a new instance of <see cref="PathsPvivzlFormsdataurlencodedPartialconstantbodyPostRequestbodyContentApplicationXWwwFormUrlencodedSchema"/>. </summary>
        /// <param name="grantType"> Constant part of a formdata body. </param>
        /// <param name="service"> Indicates the name of your Azure container registry. </param>
        /// <param name="aadAccessToken"> AAD access token, mandatory when grant_type is access_token_refresh_token or access_token. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal PathsPvivzlFormsdataurlencodedPartialconstantbodyPostRequestbodyContentApplicationXWwwFormUrlencodedSchema(PostContentSchemaGrantType grantType, string service, string aadAccessToken, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            GrantType = grantType;
            Service = service;
            AadAccessToken = aadAccessToken;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="PathsPvivzlFormsdataurlencodedPartialconstantbodyPostRequestbodyContentApplicationXWwwFormUrlencodedSchema"/> for deserialization. </summary>
        internal PathsPvivzlFormsdataurlencodedPartialconstantbodyPostRequestbodyContentApplicationXWwwFormUrlencodedSchema()
        {
        }

        /// <summary> Constant part of a formdata body. </summary>
        public PostContentSchemaGrantType GrantType { get; }
        /// <summary> Indicates the name of your Azure container registry. </summary>
        public string Service { get; }
        /// <summary> AAD access token, mandatory when grant_type is access_token_refresh_token or access_token. </summary>
        public string AadAccessToken { get; }
    }
}
