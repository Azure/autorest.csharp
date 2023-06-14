// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace ModelsTypeSpec.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ModelsTypeSpecModelFactory
    {
        /// <summary> Initializes a new instance of FirstDerivedOutputModel. </summary>
        /// <param name="first"></param>
        /// <returns> A new <see cref="Models.FirstDerivedOutputModel"/> instance for mocking. </returns>
        public static FirstDerivedOutputModel FirstDerivedOutputModel(bool first = default)
        {
            return new FirstDerivedOutputModel("first", first);
        }

        /// <summary> Initializes a new instance of SecondDerivedOutputModel. </summary>
        /// <param name="second"></param>
        /// <returns> A new <see cref="Models.SecondDerivedOutputModel"/> instance for mocking. </returns>
        public static SecondDerivedOutputModel SecondDerivedOutputModel(bool second = default)
        {
            return new SecondDerivedOutputModel("second", second);
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
        /// <returns> A new <see cref="Models.RoundTripReadOnlyModel"/> instance for mocking. </returns>
        public static RoundTripReadOnlyModel RoundTripReadOnlyModel(string requiredReadonlyString = null, int requiredReadonlyInt = default, string optionalReadonlyString = null, int? optionalReadonlyInt = null, DerivedModel requiredReadonlyModel = null, DerivedModel optionalReadonlyModel = null, FixedStringEnum requiredReadonlyFixedStringEnum = default, ExtensibleEnum requiredReadonlyExtensibleEnum = default, FixedStringEnum optionalReadonlyFixedStringEnum = default, ExtensibleEnum optionalReadonlyExtensibleEnum = default, IEnumerable<string> requiredReadonlyStringList = null, IEnumerable<int> requiredReadonlyIntList = null, IEnumerable<CollectionItem> requiredReadOnlyModelCollection = null, IReadOnlyDictionary<string, int> requiredReadOnlyIntRecord = null, IReadOnlyDictionary<string, string> requiredStringRecord = null, IReadOnlyDictionary<string, RecordItem> requiredReadOnlyModelRecord = null, IEnumerable<string> optionalReadonlyStringList = null, IEnumerable<int> optionalReadonlyIntList = null, IEnumerable<CollectionItem> optionalReadOnlyModelCollection = null, IReadOnlyDictionary<string, int> optionalReadOnlyIntRecord = null, IReadOnlyDictionary<string, string> optionalReadOnlyStringRecord = null, IReadOnlyDictionary<string, RecordItem> optionalModelRecord = null, IEnumerable<int?> requiredCollectionWithNullableIntElement = null, IEnumerable<bool?> optionalCollectionWithNullableBooleanElement = null)
        {
            requiredReadonlyStringList ??= new List<string>();
            requiredReadonlyIntList ??= new List<int>();
            requiredReadOnlyModelCollection ??= new List<CollectionItem>();
            requiredReadOnlyIntRecord ??= new Dictionary<string, int>();
            requiredStringRecord ??= new Dictionary<string, string>();
            requiredReadOnlyModelRecord ??= new Dictionary<string, RecordItem>();
            optionalReadonlyStringList ??= new List<string>();
            optionalReadonlyIntList ??= new List<int>();
            optionalReadOnlyModelCollection ??= new List<CollectionItem>();
            optionalReadOnlyIntRecord ??= new Dictionary<string, int>();
            optionalReadOnlyStringRecord ??= new Dictionary<string, string>();
            optionalModelRecord ??= new Dictionary<string, RecordItem>();
            requiredCollectionWithNullableIntElement ??= new List<int?>();
            optionalCollectionWithNullableBooleanElement ??= new List<bool?>();

            return new RoundTripReadOnlyModel(requiredReadonlyString, requiredReadonlyInt, optionalReadonlyString, optionalReadonlyInt, requiredReadonlyModel, optionalReadonlyModel, requiredReadonlyFixedStringEnum, requiredReadonlyExtensibleEnum, optionalReadonlyFixedStringEnum, optionalReadonlyExtensibleEnum, requiredReadonlyStringList?.ToList(), requiredReadonlyIntList?.ToList(), requiredReadOnlyModelCollection?.ToList(), requiredReadOnlyIntRecord, requiredStringRecord, requiredReadOnlyModelRecord, optionalReadonlyStringList?.ToList(), optionalReadonlyIntList?.ToList(), optionalReadOnlyModelCollection?.ToList(), optionalReadOnlyIntRecord, optionalReadOnlyStringRecord, optionalModelRecord, requiredCollectionWithNullableIntElement?.ToList(), optionalCollectionWithNullableBooleanElement?.ToList());
        }

        /// <summary> Initializes a new instance of OutputModel. </summary>
        /// <param name="requiredString"> Required string. </param>
        /// <param name="requiredInt"> Required int. </param>
        /// <param name="requiredModel"> Required model. </param>
        /// <param name="requiredCollection"> Required collection. </param>
        /// <param name="requiredModelRecord"> Required model record. </param>
        /// <returns> A new <see cref="Models.OutputModel"/> instance for mocking. </returns>
        public static OutputModel OutputModel(string requiredString = null, int requiredInt = default, DerivedModel requiredModel = null, IEnumerable<CollectionItem> requiredCollection = null, IReadOnlyDictionary<string, RecordItem> requiredModelRecord = null)
        {
            requiredCollection ??= new List<CollectionItem>();
            requiredModelRecord ??= new Dictionary<string, RecordItem>();

            return new OutputModel(requiredString, requiredInt, requiredModel, requiredCollection?.ToList(), requiredModelRecord);
        }

        /// <summary> Initializes a new instance of ErrorModel. </summary>
        /// <param name="message"> Error message. </param>
        /// <param name="innerError"> Required Record. </param>
        /// <returns> A new <see cref="Models.ErrorModel"/> instance for mocking. </returns>
        public static ErrorModel ErrorModel(string message = null, ErrorModel innerError = null)
        {
            return new ErrorModel(message, innerError);
        }
    }
}
