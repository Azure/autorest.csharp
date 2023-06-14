// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Model used both as input and output. </summary>
    public partial class RoundTripModel : BaseModel
    {
        /// <summary> Initializes a new instance of RoundTripModel. </summary>
        /// <param name="requiredString"> Required string, illustrating a reference type property. </param>
        /// <param name="requiredInt"> Required int, illustrating a value type property. </param>
        /// <param name="requiredModel"> Required model with discriminator. </param>
        /// <param name="requiredFixedStringEnum"> Required fixed string enum. </param>
        /// <param name="requiredFixedIntEnum"> Required fixed int enum. </param>
        /// <param name="requiredExtensibleEnum"> Required extensible enum. </param>
        /// <param name="requiredCollection"> Required collection. </param>
        /// <param name="requiredIntRecord"> Required int record. </param>
        /// <param name="requiredStringRecord"> Required string record. </param>
        /// <param name="requiredModelRecord"> Required Model Record. </param>
        /// <param name="requiredBytes"> Required bytes. </param>
        /// <param name="requiredUint8Array"> Required uint8[]. </param>
        /// <param name="requiredUnknown"> Required unknown. </param>
        /// <param name="requiredInt8Array"> Required int8[]. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/>, <paramref name="requiredModel"/>, <paramref name="requiredCollection"/>, <paramref name="requiredIntRecord"/>, <paramref name="requiredStringRecord"/>, <paramref name="requiredModelRecord"/>, <paramref name="requiredBytes"/>, <paramref name="requiredUint8Array"/>, <paramref name="requiredUnknown"/> or <paramref name="requiredInt8Array"/> is null. </exception>
        public RoundTripModel(string requiredString, int requiredInt, BaseModelWithDiscriminator requiredModel, FixedStringEnum requiredFixedStringEnum, FixedIntEnum requiredFixedIntEnum, ExtensibleEnum requiredExtensibleEnum, IEnumerable<CollectionItem> requiredCollection, IDictionary<string, int> requiredIntRecord, IDictionary<string, string> requiredStringRecord, IDictionary<string, RecordItem> requiredModelRecord, BinaryData requiredBytes, IEnumerable<int> requiredUint8Array, BinaryData requiredUnknown, IEnumerable<int> requiredInt8Array)
        {
            Argument.AssertNotNull(requiredString, nameof(requiredString));
            Argument.AssertNotNull(requiredModel, nameof(requiredModel));
            Argument.AssertNotNull(requiredCollection, nameof(requiredCollection));
            Argument.AssertNotNull(requiredIntRecord, nameof(requiredIntRecord));
            Argument.AssertNotNull(requiredStringRecord, nameof(requiredStringRecord));
            Argument.AssertNotNull(requiredModelRecord, nameof(requiredModelRecord));
            Argument.AssertNotNull(requiredBytes, nameof(requiredBytes));
            Argument.AssertNotNull(requiredUint8Array, nameof(requiredUint8Array));
            Argument.AssertNotNull(requiredUnknown, nameof(requiredUnknown));
            Argument.AssertNotNull(requiredInt8Array, nameof(requiredInt8Array));

            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredModel = requiredModel;
            RequiredFixedStringEnum = requiredFixedStringEnum;
            RequiredFixedIntEnum = requiredFixedIntEnum;
            RequiredExtensibleEnum = requiredExtensibleEnum;
            RequiredCollection = requiredCollection.ToList();
            RequiredIntRecord = requiredIntRecord;
            RequiredStringRecord = requiredStringRecord;
            RequiredModelRecord = requiredModelRecord;
            RequiredBytes = requiredBytes;
            RequiredUint8Array = requiredUint8Array.ToList();
            OptionalUint8Array = new ChangeTrackingList<int>();
            RequiredUnknown = requiredUnknown;
            RequiredInt8Array = requiredInt8Array.ToList();
            OptionalInt8Array = new ChangeTrackingList<int>();
        }

        /// <summary> Initializes a new instance of RoundTripModel. </summary>
        /// <param name="requiredString"> Required string, illustrating a reference type property. </param>
        /// <param name="requiredInt"> Required int, illustrating a value type property. </param>
        /// <param name="requiredModel"> Required model with discriminator. </param>
        /// <param name="requiredFixedStringEnum"> Required fixed string enum. </param>
        /// <param name="requiredFixedIntEnum"> Required fixed int enum. </param>
        /// <param name="requiredExtensibleEnum"> Required extensible enum. </param>
        /// <param name="requiredCollection"> Required collection. </param>
        /// <param name="requiredIntRecord"> Required int record. </param>
        /// <param name="requiredStringRecord"> Required string record. </param>
        /// <param name="requiredModelRecord"> Required Model Record. </param>
        /// <param name="requiredBytes"> Required bytes. </param>
        /// <param name="optionalBytes"> Optional bytes. </param>
        /// <param name="requiredUint8Array"> Required uint8[]. </param>
        /// <param name="optionalUint8Array"> Optional uint8[]. </param>
        /// <param name="requiredUnknown"> Required unknown. </param>
        /// <param name="optionalUnknown"> Optional unknown. </param>
        /// <param name="requiredInt8Array"> Required int8[]. </param>
        /// <param name="optionalInt8Array"> Optional int8[]. </param>
        internal RoundTripModel(string requiredString, int requiredInt, BaseModelWithDiscriminator requiredModel, FixedStringEnum requiredFixedStringEnum, FixedIntEnum requiredFixedIntEnum, ExtensibleEnum requiredExtensibleEnum, IList<CollectionItem> requiredCollection, IDictionary<string, int> requiredIntRecord, IDictionary<string, string> requiredStringRecord, IDictionary<string, RecordItem> requiredModelRecord, BinaryData requiredBytes, BinaryData optionalBytes, IList<int> requiredUint8Array, IList<int> optionalUint8Array, BinaryData requiredUnknown, BinaryData optionalUnknown, IList<int> requiredInt8Array, IList<int> optionalInt8Array)
        {
            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredModel = requiredModel;
            RequiredFixedStringEnum = requiredFixedStringEnum;
            RequiredFixedIntEnum = requiredFixedIntEnum;
            RequiredExtensibleEnum = requiredExtensibleEnum;
            RequiredCollection = requiredCollection;
            RequiredIntRecord = requiredIntRecord;
            RequiredStringRecord = requiredStringRecord;
            RequiredModelRecord = requiredModelRecord;
            RequiredBytes = requiredBytes;
            OptionalBytes = optionalBytes;
            RequiredUint8Array = requiredUint8Array;
            OptionalUint8Array = optionalUint8Array;
            RequiredUnknown = requiredUnknown;
            OptionalUnknown = optionalUnknown;
            RequiredInt8Array = requiredInt8Array;
            OptionalInt8Array = optionalInt8Array;
        }

        /// <summary> Required string, illustrating a reference type property. </summary>
        public string RequiredString { get; set; }
        /// <summary> Required int, illustrating a value type property. </summary>
        public int RequiredInt { get; set; }
        /// <summary>
        /// Required model with discriminator
        /// Please note <see cref="BaseModelWithDiscriminator"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DerivedModelWithDiscriminatorA"/> and <see cref="DerivedModelWithDiscriminatorB"/>.
        /// </summary>
        public BaseModelWithDiscriminator RequiredModel { get; set; }
        /// <summary> Required fixed string enum. </summary>
        public FixedStringEnum RequiredFixedStringEnum { get; set; }
        /// <summary> Required fixed int enum. </summary>
        public FixedIntEnum RequiredFixedIntEnum { get; set; }
        /// <summary> Required extensible enum. </summary>
        public ExtensibleEnum RequiredExtensibleEnum { get; set; }
        /// <summary> Required collection. </summary>
        public IList<CollectionItem> RequiredCollection { get; }
        /// <summary> Required int record. </summary>
        public IDictionary<string, int> RequiredIntRecord { get; }
        /// <summary> Required string record. </summary>
        public IDictionary<string, string> RequiredStringRecord { get; }
        /// <summary> Required Model Record. </summary>
        public IDictionary<string, RecordItem> RequiredModelRecord { get; }
        /// <summary>
        /// Required bytes
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData RequiredBytes { get; set; }
        /// <summary>
        /// Optional bytes
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData OptionalBytes { get; set; }
        /// <summary> Required uint8[]. </summary>
        public IList<int> RequiredUint8Array { get; }
        /// <summary> Optional uint8[]. </summary>
        public IList<int> OptionalUint8Array { get; }
        /// <summary>
        /// Required unknown
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
        /// Optional unknown
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
        /// <summary> Required int8[]. </summary>
        public IList<int> RequiredInt8Array { get; }
        /// <summary> Optional int8[]. </summary>
        public IList<int> OptionalInt8Array { get; }
    }
}
