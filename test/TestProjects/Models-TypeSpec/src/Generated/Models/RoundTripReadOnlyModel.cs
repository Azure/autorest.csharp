// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Output model with readonly properties. </summary>
    public partial class RoundTripReadOnlyModel
    {
        /// <summary> Initializes a new instance of RoundTripReadOnlyModel. </summary>
        /// <param name="optionalReadOnlyIntRecord"> Optional int record. </param>
        /// <param name="optionalReadOnlyStringRecord"> Optional string record. </param>
        /// <param name="requiredCollectionWithNullableIntElement"> Required collection of which the element is a nullable int. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="optionalReadOnlyIntRecord"/>, <paramref name="optionalReadOnlyStringRecord"/> or <paramref name="requiredCollectionWithNullableIntElement"/> is null. </exception>
        internal RoundTripReadOnlyModel(IReadOnlyDictionary<string, int> optionalReadOnlyIntRecord, IReadOnlyDictionary<string, string> optionalReadOnlyStringRecord, IEnumerable<int?> requiredCollectionWithNullableIntElement)
        {
            Argument.AssertNotNull(optionalReadOnlyIntRecord, nameof(optionalReadOnlyIntRecord));
            Argument.AssertNotNull(optionalReadOnlyStringRecord, nameof(optionalReadOnlyStringRecord));
            Argument.AssertNotNull(requiredCollectionWithNullableIntElement, nameof(requiredCollectionWithNullableIntElement));

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
            RequiredCollectionWithNullableIntElement = requiredCollectionWithNullableIntElement.ToList();
            OptionalCollectionWithNullableBooleanElement = new ChangeTrackingList<bool?>();
        }

        /// <summary> Initializes a new instance of RoundTripReadOnlyModel. </summary>
        /// <param name="requiredReadonlyString"> Required string, illustrating a readonly reference type property. </param>
        /// <param name="requiredReadonlyInt"> Required int, illustrating a readonly value type property. </param>
        /// <param name="optionalReadonlyString"> Optional string, illustrating a readonly reference type property. </param>
        /// <param name="optionalReadonlyInt"> Optional int, illustrating a readonly value type property. </param>
        /// <param name="requiredReadonlyModel"> Required readonly model. </param>
        /// <param name="optionalReadonlyModel"> Optional readonly model. </param>
        /// <param name="requiredReadonlyFixedStringEnum"> Required readonly fixed string enum. </param>
        /// <param name="requiredReadonlyExtensibleEnum"> Required readonly extensible enum. </param>
        /// <param name="optionalReadonlyFixedStringEnum"> Optional readonly fixed string enum. </param>
        /// <param name="optionalReadonlyExtensibleEnum"> Optional readonly extensible enum. </param>
        /// <param name="requiredReadonlyStringList"> Required readonly string collection. </param>
        /// <param name="requiredReadonlyIntList"> Required readonly int collection. </param>
        /// <param name="requiredReadOnlyModelCollection"> Required model collection. </param>
        /// <param name="requiredReadOnlyIntRecord"> Required int record. </param>
        /// <param name="requiredStringRecord"> Required string record. </param>
        /// <param name="requiredReadOnlyModelRecord"> Required model record. </param>
        /// <param name="optionalReadonlyStringList"> Optional readonly string collection. </param>
        /// <param name="optionalReadonlyIntList"> Optional readonly int collection. </param>
        /// <param name="optionalReadOnlyModelCollection"> Optional model collection. </param>
        /// <param name="optionalReadOnlyIntRecord"> Optional int record. </param>
        /// <param name="optionalReadOnlyStringRecord"> Optional string record. </param>
        /// <param name="optionalModelRecord"> Optional model record. </param>
        /// <param name="requiredCollectionWithNullableIntElement"> Required collection of which the element is a nullable int. </param>
        /// <param name="optionalCollectionWithNullableBooleanElement"> Optional collection of which the element is a nullable boolean. </param>
        internal RoundTripReadOnlyModel(string requiredReadonlyString, int requiredReadonlyInt, string optionalReadonlyString, int? optionalReadonlyInt, DerivedModel requiredReadonlyModel, DerivedModel optionalReadonlyModel, FixedStringEnum requiredReadonlyFixedStringEnum, ExtensibleEnum requiredReadonlyExtensibleEnum, FixedStringEnum optionalReadonlyFixedStringEnum, ExtensibleEnum optionalReadonlyExtensibleEnum, IReadOnlyList<string> requiredReadonlyStringList, IReadOnlyList<int> requiredReadonlyIntList, IReadOnlyList<CollectionItem> requiredReadOnlyModelCollection, IReadOnlyDictionary<string, int> requiredReadOnlyIntRecord, IReadOnlyDictionary<string, string> requiredStringRecord, IReadOnlyDictionary<string, RecordItem> requiredReadOnlyModelRecord, IReadOnlyList<string> optionalReadonlyStringList, IReadOnlyList<int> optionalReadonlyIntList, IReadOnlyList<CollectionItem> optionalReadOnlyModelCollection, IReadOnlyDictionary<string, int> optionalReadOnlyIntRecord, IReadOnlyDictionary<string, string> optionalReadOnlyStringRecord, IReadOnlyDictionary<string, RecordItem> optionalModelRecord, IReadOnlyList<int?> requiredCollectionWithNullableIntElement, IReadOnlyList<bool?> optionalCollectionWithNullableBooleanElement)
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
            RequiredReadonlyStringList = requiredReadonlyStringList;
            RequiredReadonlyIntList = requiredReadonlyIntList;
            RequiredReadOnlyModelCollection = requiredReadOnlyModelCollection;
            RequiredReadOnlyIntRecord = requiredReadOnlyIntRecord;
            RequiredStringRecord = requiredStringRecord;
            RequiredReadOnlyModelRecord = requiredReadOnlyModelRecord;
            OptionalReadonlyStringList = optionalReadonlyStringList;
            OptionalReadonlyIntList = optionalReadonlyIntList;
            OptionalReadOnlyModelCollection = optionalReadOnlyModelCollection;
            OptionalReadOnlyIntRecord = optionalReadOnlyIntRecord;
            OptionalReadOnlyStringRecord = optionalReadOnlyStringRecord;
            OptionalModelRecord = optionalModelRecord;
            RequiredCollectionWithNullableIntElement = requiredCollectionWithNullableIntElement;
            OptionalCollectionWithNullableBooleanElement = optionalCollectionWithNullableBooleanElement;
        }

        /// <summary> Required string, illustrating a readonly reference type property. </summary>
        public string RequiredReadonlyString { get; }
        /// <summary> Required int, illustrating a readonly value type property. </summary>
        public int RequiredReadonlyInt { get; }
        /// <summary> Optional string, illustrating a readonly reference type property. </summary>
        public string OptionalReadonlyString { get; }
        /// <summary> Optional int, illustrating a readonly value type property. </summary>
        public int? OptionalReadonlyInt { get; }
        /// <summary> Required readonly model. </summary>
        public DerivedModel RequiredReadonlyModel { get; }
        /// <summary> Optional readonly model. </summary>
        public DerivedModel OptionalReadonlyModel { get; }
        /// <summary> Required readonly fixed string enum. </summary>
        public FixedStringEnum RequiredReadonlyFixedStringEnum { get; }
        /// <summary> Required readonly extensible enum. </summary>
        public ExtensibleEnum RequiredReadonlyExtensibleEnum { get; }
        /// <summary> Optional readonly fixed string enum. </summary>
        public FixedStringEnum OptionalReadonlyFixedStringEnum { get; }
        /// <summary> Optional readonly extensible enum. </summary>
        public ExtensibleEnum OptionalReadonlyExtensibleEnum { get; }
        /// <summary> Required readonly string collection. </summary>
        public IReadOnlyList<string> RequiredReadonlyStringList { get; }
        /// <summary> Required readonly int collection. </summary>
        public IReadOnlyList<int> RequiredReadonlyIntList { get; }
        /// <summary> Required model collection. </summary>
        public IReadOnlyList<CollectionItem> RequiredReadOnlyModelCollection { get; }
        /// <summary> Required int record. </summary>
        public IReadOnlyDictionary<string, int> RequiredReadOnlyIntRecord { get; }
        /// <summary> Required string record. </summary>
        public IReadOnlyDictionary<string, string> RequiredStringRecord { get; }
        /// <summary> Required model record. </summary>
        public IReadOnlyDictionary<string, RecordItem> RequiredReadOnlyModelRecord { get; }
        /// <summary> Optional readonly string collection. </summary>
        public IReadOnlyList<string> OptionalReadonlyStringList { get; }
        /// <summary> Optional readonly int collection. </summary>
        public IReadOnlyList<int> OptionalReadonlyIntList { get; }
        /// <summary> Optional model collection. </summary>
        public IReadOnlyList<CollectionItem> OptionalReadOnlyModelCollection { get; }
        /// <summary> Optional int record. </summary>
        public IReadOnlyDictionary<string, int> OptionalReadOnlyIntRecord { get; }
        /// <summary> Optional string record. </summary>
        public IReadOnlyDictionary<string, string> OptionalReadOnlyStringRecord { get; }
        /// <summary> Optional model record. </summary>
        public IReadOnlyDictionary<string, RecordItem> OptionalModelRecord { get; }
        /// <summary> Required collection of which the element is a nullable int. </summary>
        public IReadOnlyList<int?> RequiredCollectionWithNullableIntElement { get; }
        /// <summary> Optional collection of which the element is a nullable boolean. </summary>
        public IReadOnlyList<bool?> OptionalCollectionWithNullableBooleanElement { get; }
    }
}
