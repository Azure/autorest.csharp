// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> RoundTrip model with optional properties. </summary>
    [Obsolete("deprecated for test")]
    public partial class RoundTripOptionalModel
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of RoundTripOptionalModel. </summary>
        public RoundTripOptionalModel()
        {
            OptionalStringList = new ChangeTrackingList<string>();
            OptionalIntList = new ChangeTrackingList<int>();
            OptionalModelList = new ChangeTrackingList<CollectionItem>();
            OptionalIntRecord = new ChangeTrackingDictionary<string, int>();
            OptionalStringRecord = new ChangeTrackingDictionary<string, string>();
            OptionalModelRecord = new ChangeTrackingDictionary<string, RecordItem>();
            OptionalCollectionWithNullableIntElement = new ChangeTrackingList<int?>();
        }

        /// <summary> Initializes a new instance of RoundTripOptionalModel. </summary>
        /// <param name="optionalString"> Optional string, illustrating an optional reference type property. </param>
        /// <param name="optionalInt"> Optional int, illustrating an optional value type property. </param>
        /// <param name="optionalStringList"> Optional string collection. </param>
        /// <param name="optionalIntList"> Optional int collection. </param>
        /// <param name="optionalModelList"> Optional model collection. </param>
        /// <param name="optionalModel"> Optional model. </param>
        /// <param name="optionalModelWithPropertiesOnBase"> Optional model with properties on base. </param>
        /// <param name="optionalFixedStringEnum"> Optional fixed string enum. </param>
        /// <param name="optionalExtensibleEnum"> Optional extensible enum. </param>
        /// <param name="optionalIntRecord"> Optional int record. </param>
        /// <param name="optionalStringRecord"> Optional string record. </param>
        /// <param name="optionalModelRecord"> Optional model record. </param>
        /// <param name="optionalPlainDate"> Optional plainDate. </param>
        /// <param name="optionalPlainTime"> Optional plainTime. </param>
        /// <param name="optionalCollectionWithNullableIntElement"> Optional collection of which the element is a nullable int. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RoundTripOptionalModel(string optionalString, int? optionalInt, IList<string> optionalStringList, IList<int> optionalIntList, IList<CollectionItem> optionalModelList, DerivedModel optionalModel, DerivedModelWithProperties optionalModelWithPropertiesOnBase, FixedStringEnum? optionalFixedStringEnum, ExtensibleEnum? optionalExtensibleEnum, IDictionary<string, int> optionalIntRecord, IDictionary<string, string> optionalStringRecord, IDictionary<string, RecordItem> optionalModelRecord, DateTimeOffset? optionalPlainDate, TimeSpan? optionalPlainTime, IList<int?> optionalCollectionWithNullableIntElement, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            OptionalString = optionalString;
            OptionalInt = optionalInt;
            OptionalStringList = optionalStringList;
            OptionalIntList = optionalIntList;
            OptionalModelList = optionalModelList;
            OptionalModel = optionalModel;
            OptionalModelWithPropertiesOnBase = optionalModelWithPropertiesOnBase;
            OptionalFixedStringEnum = optionalFixedStringEnum;
            OptionalExtensibleEnum = optionalExtensibleEnum;
            OptionalIntRecord = optionalIntRecord;
            OptionalStringRecord = optionalStringRecord;
            OptionalModelRecord = optionalModelRecord;
            OptionalPlainDate = optionalPlainDate;
            OptionalPlainTime = optionalPlainTime;
            OptionalCollectionWithNullableIntElement = optionalCollectionWithNullableIntElement;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Optional string, illustrating an optional reference type property. </summary>
        public string OptionalString { get; set; }
        /// <summary> Optional int, illustrating an optional value type property. </summary>
        public int? OptionalInt { get; set; }
        /// <summary> Optional string collection. </summary>
        public IList<string> OptionalStringList { get; }
        /// <summary> Optional int collection. </summary>
        public IList<int> OptionalIntList { get; }
        /// <summary> Optional model collection. </summary>
        public IList<CollectionItem> OptionalModelList { get; }
        /// <summary> Optional model. </summary>
        public DerivedModel OptionalModel { get; set; }
        /// <summary> Optional model with properties on base. </summary>
        public DerivedModelWithProperties OptionalModelWithPropertiesOnBase { get; set; }
        /// <summary> Optional fixed string enum. </summary>
        public FixedStringEnum? OptionalFixedStringEnum { get; set; }
        /// <summary> Optional extensible enum. </summary>
        public ExtensibleEnum? OptionalExtensibleEnum { get; set; }
        /// <summary> Optional int record. </summary>
        public IDictionary<string, int> OptionalIntRecord { get; }
        /// <summary> Optional string record. </summary>
        public IDictionary<string, string> OptionalStringRecord { get; }
        /// <summary> Optional model record. </summary>
        public IDictionary<string, RecordItem> OptionalModelRecord { get; }
        /// <summary> Optional plainDate. </summary>
        public DateTimeOffset? OptionalPlainDate { get; set; }
        /// <summary> Optional plainTime. </summary>
        public TimeSpan? OptionalPlainTime { get; set; }
        /// <summary> Optional collection of which the element is a nullable int. </summary>
        public IList<int?> OptionalCollectionWithNullableIntElement { get; }
    }
}
