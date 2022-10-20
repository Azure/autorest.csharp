// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelsInCadl
{
    /// <summary> Output model with readonly properties. </summary>
    public partial class RoundTripReadOnlyModel
    {
        /// <summary> Initializes a new instance of RoundTripReadOnlyModel. </summary>
        /// <param name="optionalReadOnlyIntRecord"></param>
        /// <param name="optionalReadOnlyStringRecord"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="optionalReadOnlyIntRecord"/> or <paramref name="optionalReadOnlyStringRecord"/> is null. </exception>
        public RoundTripReadOnlyModel(IDictionary<string, int> optionalReadOnlyIntRecord, IDictionary<string, string> optionalReadOnlyStringRecord)
        {
            Argument.AssertNotNull(optionalReadOnlyIntRecord, nameof(optionalReadOnlyIntRecord));
            Argument.AssertNotNull(optionalReadOnlyStringRecord, nameof(optionalReadOnlyStringRecord));

            RequiredReadonlyStringList = new ChangeTrackingList<string>();
            RequiredReadonlyIntList = new ChangeTrackingList<int>();
            RequiredReadOnlyModelCollection = new ChangeTrackingList<CollectionItem>();
            RequiredReadOnlyIntRecord = new ChangeTrackingDictionary<string, int>();
            RequiredStringRecord = new ChangeTrackingDictionary<string, string>();
            RequiredReadOnlyModelRecord = new ChangeTrackingDictionary<string, RecordItem>();
            OptionalReadonlyStringList = new ChangeTrackingList<string>();
            OptionalReadonlyIntList = new ChangeTrackingList<int>();
            OptionalReadOnlyModelCollection = new ChangeTrackingList<CollectionItem>();
            OptionalReadOnlyIntRecord = optionalReadOnlyIntRecord;
            OptionalReadOnlyStringRecord = optionalReadOnlyStringRecord;
            OptionalModelRecord = new ChangeTrackingDictionary<string, RecordItem>();
        }

        /// <summary> Initializes a new instance of RoundTripReadOnlyModel. </summary>
        /// <param name="requiredReadonlyString"></param>
        /// <param name="requiredReadonlyInt"></param>
        /// <param name="optionalReadonlyString"></param>
        /// <param name="optionalReadonlyInt"></param>
        /// <param name="requiredReadonlyModel"></param>
        /// <param name="optionalReadonlyModel"></param>
        /// <param name="requiredReadonlyFixedStringEnum"></param>
        /// <param name="requiredReadonlyExtensibleEnum"></param>
        /// <param name="optionalReadonlyFixedStringEnum"></param>
        /// <param name="optionalReadonlyExtensibleEnum"></param>
        /// <param name="requiredReadonlyStringList"></param>
        /// <param name="requiredReadonlyIntList"></param>
        /// <param name="requiredReadOnlyModelCollection"></param>
        /// <param name="requiredReadOnlyIntRecord"></param>
        /// <param name="requiredStringRecord"></param>
        /// <param name="requiredReadOnlyModelRecord"></param>
        /// <param name="optionalReadonlyStringList"></param>
        /// <param name="optionalReadonlyIntList"></param>
        /// <param name="optionalReadOnlyModelCollection"></param>
        /// <param name="optionalReadOnlyIntRecord"></param>
        /// <param name="optionalReadOnlyStringRecord"></param>
        /// <param name="optionalModelRecord"></param>
        internal RoundTripReadOnlyModel(string requiredReadonlyString, int requiredReadonlyInt, string optionalReadonlyString, int? optionalReadonlyInt, DerivedModel requiredReadonlyModel, DerivedModel optionalReadonlyModel, FixedStringEnum requiredReadonlyFixedStringEnum, ExtensibleEnum requiredReadonlyExtensibleEnum, FixedStringEnum optionalReadonlyFixedStringEnum, ExtensibleEnum optionalReadonlyExtensibleEnum, IReadOnlyList<string> requiredReadonlyStringList, IReadOnlyList<int> requiredReadonlyIntList, IReadOnlyList<CollectionItem> requiredReadOnlyModelCollection, IReadOnlyDictionary<string, int> requiredReadOnlyIntRecord, IReadOnlyDictionary<string, string> requiredStringRecord, IReadOnlyDictionary<string, RecordItem> requiredReadOnlyModelRecord, IReadOnlyList<string> optionalReadonlyStringList, IReadOnlyList<int> optionalReadonlyIntList, IReadOnlyList<CollectionItem> optionalReadOnlyModelCollection, IDictionary<string, int> optionalReadOnlyIntRecord, IDictionary<string, string> optionalReadOnlyStringRecord, IReadOnlyDictionary<string, RecordItem> optionalModelRecord)
        {
            RequiredReadonlyString = requiredReadonlyString;
            RequiredReadonlyInt = requiredReadonlyInt;
            OptionalReadonlyString = optionalReadonlyString;
            OptionalReadonlyInt = optionalReadonlyInt;
            RequiredReadonlyModel = requiredReadonlyModel;
            OptionalReadonlyModel = optionalReadonlyModel;
            RequiredReadonlyFixedStringEnum = requiredReadonlyFixedStringEnum;
            RequiredReadonlyExtensibleEnum = requiredReadonlyExtensibleEnum;
            OptionalReadonlyFixedStringEnum = optionalReadonlyFixedStringEnum;
            OptionalReadonlyExtensibleEnum = optionalReadonlyExtensibleEnum;
            RequiredReadonlyStringList = requiredReadonlyStringList.ToList();
            RequiredReadonlyIntList = requiredReadonlyIntList.ToList();
            RequiredReadOnlyModelCollection = requiredReadOnlyModelCollection.ToList();
            RequiredReadOnlyIntRecord = requiredReadOnlyIntRecord;
            RequiredStringRecord = requiredStringRecord;
            RequiredReadOnlyModelRecord = requiredReadOnlyModelRecord;
            OptionalReadonlyStringList = optionalReadonlyStringList.ToList();
            OptionalReadonlyIntList = optionalReadonlyIntList.ToList();
            OptionalReadOnlyModelCollection = optionalReadOnlyModelCollection.ToList();
            OptionalReadOnlyIntRecord = optionalReadOnlyIntRecord;
            OptionalReadOnlyStringRecord = optionalReadOnlyStringRecord;
            OptionalModelRecord = optionalModelRecord;
        }

        /// <summary> Gets the required readonly string. </summary>
        public string RequiredReadonlyString { get; }
        /// <summary> Gets the required readonly int. </summary>
        public int RequiredReadonlyInt { get; }
        /// <summary> Gets the optional readonly string. </summary>
        public string OptionalReadonlyString { get; }
        /// <summary> Gets the optional readonly int. </summary>
        public int? OptionalReadonlyInt { get; }
        /// <summary> Gets the required readonly model. </summary>
        public DerivedModel RequiredReadonlyModel { get; }
        /// <summary> Gets the optional readonly model. </summary>
        public DerivedModel OptionalReadonlyModel { get; }
        /// <summary> Gets the required readonly fixed string enum. </summary>
        public FixedStringEnum RequiredReadonlyFixedStringEnum { get; }
        /// <summary> Gets the required readonly extensible enum. </summary>
        public ExtensibleEnum RequiredReadonlyExtensibleEnum { get; }
        /// <summary> Gets the optional readonly fixed string enum. </summary>
        public FixedStringEnum OptionalReadonlyFixedStringEnum { get; }
        /// <summary> Gets the optional readonly extensible enum. </summary>
        public ExtensibleEnum OptionalReadonlyExtensibleEnum { get; }
        /// <summary> Gets the required readonly string list. </summary>
        public IReadOnlyList<string> RequiredReadonlyStringList { get; }
        /// <summary> Gets the required readonly int list. </summary>
        public IReadOnlyList<int> RequiredReadonlyIntList { get; }
        /// <summary> Gets the required read only model collection. </summary>
        public IReadOnlyList<CollectionItem> RequiredReadOnlyModelCollection { get; }
        /// <summary> Gets the required read only int record. </summary>
        public IReadOnlyDictionary<string, int> RequiredReadOnlyIntRecord { get; }
        /// <summary> Gets the required string record. </summary>
        public IReadOnlyDictionary<string, string> RequiredStringRecord { get; }
        /// <summary> Gets the required read only model record. </summary>
        public IReadOnlyDictionary<string, RecordItem> RequiredReadOnlyModelRecord { get; }
        /// <summary> Gets the optional readonly string list. </summary>
        public IReadOnlyList<string> OptionalReadonlyStringList { get; }
        /// <summary> Gets the optional readonly int list. </summary>
        public IReadOnlyList<int> OptionalReadonlyIntList { get; }
        /// <summary> Gets the optional read only model collection. </summary>
        public IReadOnlyList<CollectionItem> OptionalReadOnlyModelCollection { get; }
        /// <summary> Gets the optional read only int record. </summary>
        public IDictionary<string, int> OptionalReadOnlyIntRecord { get; }
        /// <summary> Gets the optional read only string record. </summary>
        public IDictionary<string, string> OptionalReadOnlyStringRecord { get; }
        /// <summary> Gets the optional model record. </summary>
        public IReadOnlyDictionary<string, RecordItem> OptionalModelRecord { get; }
    }
}
