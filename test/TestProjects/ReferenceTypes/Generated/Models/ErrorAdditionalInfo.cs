// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> The resource management error additional info. </summary>
    [PropertyReferenceType]
    public partial class ErrorAdditionalInfo
    {
        /// <summary> Initializes a new instance of ErrorAdditionalInfo. </summary>
        [InitializationConstructor]
        public ErrorAdditionalInfo()
        {
        }

        /// <summary> Initializes a new instance of ErrorAdditionalInfo. </summary>
        /// <param name="errorAdditionalInfoType"> The additional info type. </param>
        /// <param name="info"> The additional info. </param>
        [SerializationConstructor]
        internal ErrorAdditionalInfo(string errorAdditionalInfoType, BinaryData info)
        {
            ErrorAdditionalInfoType = errorAdditionalInfoType;
            Info = info;
        }

        /// <summary> The additional info type. </summary>
        public string ErrorAdditionalInfoType { get; }
        /// <summary>
        /// The additional info..
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        public BinaryData Info { get; }
    }
}
