// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtTypeSpec.Models
{
    /// <summary> The FooProperties. </summary>
    public partial class FooProperties
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

        /// <summary> Initializes a new instance of <see cref="FooProperties"/>. </summary>
        public FooProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FooProperties"/>. </summary>
        /// <param name="serviceUri"> the service url. </param>
        /// <param name="something"> something. </param>
        /// <param name="boolValue"> boolean value. </param>
        /// <param name="floatValue"> float value. </param>
        /// <param name="doubleValue"> double value. </param>
        /// <param name="testResource"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FooProperties(Uri serviceUri, string something, bool? boolValue, float? floatValue, double? doubleValue, ResourceType? testResource, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ServiceUri = serviceUri;
            Something = something;
            BoolValue = boolValue;
            FloatValue = floatValue;
            DoubleValue = doubleValue;
            TestResource = testResource;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> the service url. </summary>
        [WirePath("serviceUrl")]
        public Uri ServiceUri { get; set; }
        /// <summary> something. </summary>
        [WirePath("something")]
        public string Something { get; set; }
        /// <summary> boolean value. </summary>
        [WirePath("boolValue")]
        public bool? BoolValue { get; set; }
        /// <summary> float value. </summary>
        [WirePath("floatValue")]
        public float? FloatValue { get; set; }
        /// <summary> double value. </summary>
        [WirePath("doubleValue")]
        public double? DoubleValue { get; set; }
        /// <summary> Gets or sets the test resource. </summary>
        [WirePath("testResource")]
        public ResourceType? TestResource { get; set; }
    }
}
