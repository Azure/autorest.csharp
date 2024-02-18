// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for RequestMethod match conditions. </summary>
    public partial class RequestMethodMatchConditionParameters
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

        /// <summary> Initializes a new instance of <see cref="RequestMethodMatchConditionParameters"/>. </summary>
        /// <param name="typeName"></param>
        /// <param name="operator"> Describes operator to be matched. </param>
        public RequestMethodMatchConditionParameters(RequestMethodMatchConditionParametersTypeName typeName, RequestMethodOperator @operator)
        {
            TypeName = typeName;
            Operator = @operator;
            Transforms = new ChangeTrackingList<Transform>();
            MatchValues = new ChangeTrackingList<RequestMethodMatchConditionParametersMatchValuesItem>();
        }

        /// <summary> Initializes a new instance of <see cref="RequestMethodMatchConditionParameters"/>. </summary>
        /// <param name="typeName"></param>
        /// <param name="operator"> Describes operator to be matched. </param>
        /// <param name="negateCondition"> Describes if this is negate condition or not. </param>
        /// <param name="transforms"> List of transforms. </param>
        /// <param name="matchValues"> The match value for the condition of the delivery rule. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RequestMethodMatchConditionParameters(RequestMethodMatchConditionParametersTypeName typeName, RequestMethodOperator @operator, bool? negateCondition, IList<Transform> transforms, IList<RequestMethodMatchConditionParametersMatchValuesItem> matchValues, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TypeName = typeName;
            Operator = @operator;
            NegateCondition = negateCondition;
            Transforms = transforms;
            MatchValues = matchValues;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="RequestMethodMatchConditionParameters"/> for deserialization. </summary>
        internal RequestMethodMatchConditionParameters()
        {
        }

        /// <summary> Gets or sets the type name. </summary>
        [WirePath("typeName")]
        public RequestMethodMatchConditionParametersTypeName TypeName { get; set; }
        /// <summary> Describes operator to be matched. </summary>
        [WirePath("operator")]
        public RequestMethodOperator Operator { get; set; }
        /// <summary> Describes if this is negate condition or not. </summary>
        [WirePath("negateCondition")]
        public bool? NegateCondition { get; set; }
        /// <summary> List of transforms. </summary>
        [WirePath("transforms")]
        public IList<Transform> Transforms { get; }
        /// <summary> The match value for the condition of the delivery rule. </summary>
        [WirePath("matchValues")]
        public IList<RequestMethodMatchConditionParametersMatchValuesItem> MatchValues { get; }
    }
}
