// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTestTypeSpec.Models
{
    /// <summary> A model with a few properties of literal types. </summary>
    public partial class Thing
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

        /// <summary> Initializes a new instance of <see cref="Thing"/>. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="requiredUnion"> required Union. </param>
        /// <param name="requiredBadDescription"> description with xml &lt;|endoftext|&gt;. </param>
        /// <param name="requiredNullableList"> required nullable collection. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="requiredUnion"/> or <paramref name="requiredBadDescription"/> is null. </exception>
        public Thing(string name, BinaryData requiredUnion, string requiredBadDescription, IEnumerable<int> requiredNullableList)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(requiredUnion, nameof(requiredUnion));
            Argument.AssertNotNull(requiredBadDescription, nameof(requiredBadDescription));

            Name = name;
            RequiredUnion = requiredUnion;
            RequiredBadDescription = requiredBadDescription;
            OptionalNullableList = new ChangeTrackingList<int>();
            RequiredNullableList = requiredNullableList?.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="Thing"/>. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="requiredUnion"> required Union. </param>
        /// <param name="requiredLiteralString"> required literal string. </param>
        /// <param name="requiredLiteralInt"> required literal int. </param>
        /// <param name="requiredLiteralFloat"> required literal float. </param>
        /// <param name="requiredLiteralBool"> required literal bool. </param>
        /// <param name="optionalLiteralString"> optional literal string. </param>
        /// <param name="optionalLiteralInt"> optional literal int. </param>
        /// <param name="optionalLiteralFloat"> optional literal float. </param>
        /// <param name="optionalLiteralBool"> optional literal bool. </param>
        /// <param name="requiredBadDescription"> description with xml &lt;|endoftext|&gt;. </param>
        /// <param name="optionalNullableList"> optional nullable collection. </param>
        /// <param name="requiredNullableList"> required nullable collection. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Thing(string name, BinaryData requiredUnion, ThingRequiredLiteralString requiredLiteralString, ThingRequiredLiteralInt requiredLiteralInt, ThingRequiredLiteralFloat requiredLiteralFloat, bool requiredLiteralBool, ThingOptionalLiteralString? optionalLiteralString, ThingOptionalLiteralInt? optionalLiteralInt, ThingOptionalLiteralFloat? optionalLiteralFloat, bool? optionalLiteralBool, string requiredBadDescription, IList<int> optionalNullableList, IList<int> requiredNullableList, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            RequiredUnion = requiredUnion;
            RequiredLiteralString = requiredLiteralString;
            RequiredLiteralInt = requiredLiteralInt;
            RequiredLiteralFloat = requiredLiteralFloat;
            RequiredLiteralBool = requiredLiteralBool;
            OptionalLiteralString = optionalLiteralString;
            OptionalLiteralInt = optionalLiteralInt;
            OptionalLiteralFloat = optionalLiteralFloat;
            OptionalLiteralBool = optionalLiteralBool;
            RequiredBadDescription = requiredBadDescription;
            OptionalNullableList = optionalNullableList;
            RequiredNullableList = requiredNullableList;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Thing"/> for deserialization. </summary>
        internal Thing()
        {
        }

        /// <summary> name of the Thing. </summary>
        public string Name { get; }
        /// <summary>
        /// required Union
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// <remarks>
        /// Supported types:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="string"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="IList{T}"/> where <c>T</c> is of type <see cref="string"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="int"/></description>
        /// </item>
        /// </list>
        /// </remarks>
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
        public BinaryData RequiredUnion { get; }
        /// <summary> required literal string. </summary>
        public ThingRequiredLiteralString RequiredLiteralString { get; } = ThingRequiredLiteralString.Accept;

        /// <summary> required literal int. </summary>
        public ThingRequiredLiteralInt RequiredLiteralInt { get; } = ThingRequiredLiteralInt._123;

        /// <summary> required literal float. </summary>
        public ThingRequiredLiteralFloat RequiredLiteralFloat { get; } = ThingRequiredLiteralFloat._123;

        /// <summary> required literal bool. </summary>
        public bool RequiredLiteralBool { get; } = false;

        /// <summary> optional literal string. </summary>
        public ThingOptionalLiteralString? OptionalLiteralString { get; set; }
        /// <summary> optional literal int. </summary>
        public ThingOptionalLiteralInt? OptionalLiteralInt { get; set; }
        /// <summary> optional literal float. </summary>
        public ThingOptionalLiteralFloat? OptionalLiteralFloat { get; set; }
        /// <summary> optional literal bool. </summary>
        public bool? OptionalLiteralBool { get; set; }
        /// <summary> description with xml &lt;|endoftext|&gt;. </summary>
        public string RequiredBadDescription { get; }
        /// <summary> optional nullable collection. </summary>
        public IList<int> OptionalNullableList { get; set; }
        /// <summary> required nullable collection. </summary>
        public IList<int> RequiredNullableList { get; set; }
    }
}
