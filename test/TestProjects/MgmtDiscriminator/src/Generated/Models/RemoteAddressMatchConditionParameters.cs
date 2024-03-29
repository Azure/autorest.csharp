// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for RemoteAddress match conditions. </summary>
    public partial class RemoteAddressMatchConditionParameters
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

        /// <summary> Initializes a new instance of <see cref="RemoteAddressMatchConditionParameters"/>. </summary>
        /// <param name="typeName"></param>
        /// <param name="operator"> Describes operator to be matched. </param>
        public RemoteAddressMatchConditionParameters(RemoteAddressMatchConditionParametersTypeName typeName, RemoteAddressOperator @operator)
        {
            TypeName = typeName;
            Operator = @operator;
            MatchValues = new ChangeTrackingList<string>();
            Transforms = new ChangeTrackingList<Transform>();
        }

        /// <summary> Initializes a new instance of <see cref="RemoteAddressMatchConditionParameters"/>. </summary>
        /// <param name="typeName"></param>
        /// <param name="operator"> Describes operator to be matched. </param>
        /// <param name="negateCondition"> Describes if this is negate condition or not. </param>
        /// <param name="matchValues"> Match values to match against. The operator will apply to each value in here with OR semantics. If any of them match the variable with the given operator this match condition is considered a match. </param>
        /// <param name="transforms"> List of transforms. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RemoteAddressMatchConditionParameters(RemoteAddressMatchConditionParametersTypeName typeName, RemoteAddressOperator @operator, bool? negateCondition, IList<string> matchValues, IList<Transform> transforms, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TypeName = typeName;
            Operator = @operator;
            NegateCondition = negateCondition;
            MatchValues = matchValues;
            Transforms = transforms;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="RemoteAddressMatchConditionParameters"/> for deserialization. </summary>
        internal RemoteAddressMatchConditionParameters()
        {
        }

        /// <summary> Gets or sets the type name. </summary>
        [WirePath("typeName")]
        public RemoteAddressMatchConditionParametersTypeName TypeName { get; set; }
        /// <summary> Describes operator to be matched. </summary>
        [WirePath("operator")]
        public RemoteAddressOperator Operator { get; set; }
        /// <summary> Describes if this is negate condition or not. </summary>
        [WirePath("negateCondition")]
        public bool? NegateCondition { get; set; }
        /// <summary> Match values to match against. The operator will apply to each value in here with OR semantics. If any of them match the variable with the given operator this match condition is considered a match. </summary>
        [WirePath("matchValues")]
        public IList<string> MatchValues { get; }
        /// <summary> List of transforms. </summary>
        [WirePath("transforms")]
        public IList<Transform> Transforms { get; }
    }
}
