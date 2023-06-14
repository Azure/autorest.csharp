// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace FirstTestTypeSpec.Models
{
    /// <summary> this is a roundtrip model. </summary>
    public partial class RoundTripModel
    {
        /// <summary> Initializes a new instance of RoundTripModel. </summary>
        /// <param name="requiredString"> Required string, illustrating a reference type property. </param>
        /// <param name="requiredInt"> Required int, illustrating a value type property. </param>
        /// <param name="requiredCollection"> Required collection of enums. </param>
        /// <param name="requiredDictionary"> Required dictionary of enums. </param>
        /// <param name="requiredModel"> Required model. </param>
        /// <param name="requiredUnknown"> required unknown. </param>
        /// <param name="requiredRecordUnknown"> required record of unknown. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/>, <paramref name="requiredCollection"/>, <paramref name="requiredDictionary"/>, <paramref name="requiredModel"/>, <paramref name="requiredUnknown"/> or <paramref name="requiredRecordUnknown"/> is null. </exception>
        public RoundTripModel(string requiredString, int requiredInt, IEnumerable<StringFixedEnum> requiredCollection, IDictionary<string, StringExtensibleEnum> requiredDictionary, Thing requiredModel, BinaryData requiredUnknown, IDictionary<string, BinaryData> requiredRecordUnknown)
        {
            Argument.AssertNotNull(requiredString, nameof(requiredString));
            Argument.AssertNotNull(requiredCollection, nameof(requiredCollection));
            Argument.AssertNotNull(requiredDictionary, nameof(requiredDictionary));
            Argument.AssertNotNull(requiredModel, nameof(requiredModel));
            Argument.AssertNotNull(requiredUnknown, nameof(requiredUnknown));
            Argument.AssertNotNull(requiredRecordUnknown, nameof(requiredRecordUnknown));

            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredCollection = requiredCollection.ToList();
            RequiredDictionary = requiredDictionary;
            RequiredModel = requiredModel;
            IntExtensibleEnumCollection = new ChangeTrackingList<IntExtensibleEnum>();
            FloatExtensibleEnumCollection = new ChangeTrackingList<FloatExtensibleEnum>();
            FloatFixedEnumCollection = new ChangeTrackingList<FloatFixedEnum>();
            IntFixedEnumCollection = new ChangeTrackingList<IntFixedEnum>();
            RequiredUnknown = requiredUnknown;
            RequiredRecordUnknown = requiredRecordUnknown;
            OptionalRecordUnknown = new ChangeTrackingDictionary<string, BinaryData>();
            ReadOnlyRequiredRecordUnknown = new ChangeTrackingDictionary<string, BinaryData>();
            ReadOnlyOptionalRecordUnknown = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of RoundTripModel. </summary>
        /// <param name="requiredString"> Required string, illustrating a reference type property. </param>
        /// <param name="requiredInt"> Required int, illustrating a value type property. </param>
        /// <param name="requiredCollection"> Required collection of enums. </param>
        /// <param name="requiredDictionary"> Required dictionary of enums. </param>
        /// <param name="requiredModel"> Required model. </param>
        /// <param name="intExtensibleEnum"> this is an int based extensible enum. </param>
        /// <param name="intExtensibleEnumCollection"> this is a collection of int based extensible enum. </param>
        /// <param name="floatExtensibleEnum"> this is a float based extensible enum. </param>
        /// <param name="floatExtensibleEnumCollection"> this is a collection of float based extensible enum. </param>
        /// <param name="floatFixedEnum"> this is a float based fixed enum. </param>
        /// <param name="floatFixedEnumCollection"> this is a collection of float based fixed enum. </param>
        /// <param name="intFixedEnum"> this is a int based fixed enum. </param>
        /// <param name="intFixedEnumCollection"> this is a collection of int based fixed enum. </param>
        /// <param name="stringFixedEnum"> this is a string based fixed enum. </param>
        /// <param name="requiredUnknown"> required unknown. </param>
        /// <param name="optionalUnknown"> optional unknown. </param>
        /// <param name="requiredRecordUnknown"> required record of unknown. </param>
        /// <param name="optionalRecordUnknown"> optional record of unknown. </param>
        /// <param name="readOnlyRequiredRecordUnknown"> required readonly record of unknown. </param>
        /// <param name="readOnlyOptionalRecordUnknown"> optional readonly record of unknown. </param>
        internal RoundTripModel(string requiredString, int requiredInt, IList<StringFixedEnum> requiredCollection, IDictionary<string, StringExtensibleEnum> requiredDictionary, Thing requiredModel, IntExtensibleEnum? intExtensibleEnum, IList<IntExtensibleEnum> intExtensibleEnumCollection, FloatExtensibleEnum? floatExtensibleEnum, IList<FloatExtensibleEnum> floatExtensibleEnumCollection, FloatFixedEnum? floatFixedEnum, IList<FloatFixedEnum> floatFixedEnumCollection, IntFixedEnum? intFixedEnum, IList<IntFixedEnum> intFixedEnumCollection, StringFixedEnum? stringFixedEnum, BinaryData requiredUnknown, BinaryData optionalUnknown, IDictionary<string, BinaryData> requiredRecordUnknown, IDictionary<string, BinaryData> optionalRecordUnknown, IReadOnlyDictionary<string, BinaryData> readOnlyRequiredRecordUnknown, IReadOnlyDictionary<string, BinaryData> readOnlyOptionalRecordUnknown)
        {
            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredCollection = requiredCollection;
            RequiredDictionary = requiredDictionary;
            RequiredModel = requiredModel;
            IntExtensibleEnum = intExtensibleEnum;
            IntExtensibleEnumCollection = intExtensibleEnumCollection;
            FloatExtensibleEnum = floatExtensibleEnum;
            FloatExtensibleEnumCollection = floatExtensibleEnumCollection;
            FloatFixedEnum = floatFixedEnum;
            FloatFixedEnumCollection = floatFixedEnumCollection;
            IntFixedEnum = intFixedEnum;
            IntFixedEnumCollection = intFixedEnumCollection;
            StringFixedEnum = stringFixedEnum;
            RequiredUnknown = requiredUnknown;
            OptionalUnknown = optionalUnknown;
            RequiredRecordUnknown = requiredRecordUnknown;
            OptionalRecordUnknown = optionalRecordUnknown;
            ReadOnlyRequiredRecordUnknown = readOnlyRequiredRecordUnknown;
            ReadOnlyOptionalRecordUnknown = readOnlyOptionalRecordUnknown;
        }

        /// <summary> Required string, illustrating a reference type property. </summary>
        public string RequiredString { get; set; }
        /// <summary> Required int, illustrating a value type property. </summary>
        public int RequiredInt { get; set; }
        /// <summary> Required collection of enums. </summary>
        public IList<StringFixedEnum> RequiredCollection { get; }
        /// <summary> Required dictionary of enums. </summary>
        public IDictionary<string, StringExtensibleEnum> RequiredDictionary { get; }
        /// <summary> Required model. </summary>
        public Thing RequiredModel { get; set; }
        /// <summary> this is an int based extensible enum. </summary>
        public IntExtensibleEnum? IntExtensibleEnum { get; set; }
        /// <summary> this is a collection of int based extensible enum. </summary>
        public IList<IntExtensibleEnum> IntExtensibleEnumCollection { get; }
        /// <summary> this is a float based extensible enum. </summary>
        public FloatExtensibleEnum? FloatExtensibleEnum { get; set; }
        /// <summary> this is a collection of float based extensible enum. </summary>
        public IList<FloatExtensibleEnum> FloatExtensibleEnumCollection { get; }
        /// <summary> this is a float based fixed enum. </summary>
        public FloatFixedEnum? FloatFixedEnum { get; set; }
        /// <summary> this is a collection of float based fixed enum. </summary>
        public IList<FloatFixedEnum> FloatFixedEnumCollection { get; }
        /// <summary> this is a int based fixed enum. </summary>
        public IntFixedEnum? IntFixedEnum { get; set; }
        /// <summary> this is a collection of int based fixed enum. </summary>
        public IList<IntFixedEnum> IntFixedEnumCollection { get; }
        /// <summary> this is a string based fixed enum. </summary>
        public StringFixedEnum? StringFixedEnum { get; set; }
        /// <summary>
        /// required unknown
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
        public BinaryData RequiredUnknown { get; set; }
        /// <summary>
        /// optional unknown
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
        public BinaryData OptionalUnknown { get; set; }
        /// <summary>
        /// required record of unknown
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        public IDictionary<string, BinaryData> RequiredRecordUnknown { get; }
        /// <summary>
        /// optional record of unknown
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        public IDictionary<string, BinaryData> OptionalRecordUnknown { get; }
        /// <summary>
        /// required readonly record of unknown
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        public IReadOnlyDictionary<string, BinaryData> ReadOnlyRequiredRecordUnknown { get; }
        /// <summary>
        /// optional readonly record of unknown
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        public IReadOnlyDictionary<string, BinaryData> ReadOnlyOptionalRecordUnknown { get; }
    }
}
