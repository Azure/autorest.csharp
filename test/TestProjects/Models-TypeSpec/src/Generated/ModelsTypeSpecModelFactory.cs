// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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

        /// <summary> Initializes a new instance of RoundTripModel. </summary>
        /// <param name="requiredString"> Required string, illustrating a reference type property. </param>
        /// <param name="requiredInt"> Required int, illustrating a value type property. </param>
        /// <param name="nonRequiredString"> Optional string. </param>
        /// <param name="nonRequiredInt"> Optional int. </param>
        /// <param name="requiredNullableInt"> Required nullable int. </param>
        /// <param name="requiredNullableString"> Required nullable string. </param>
        /// <param name="nonRequiredNullableInt"> Optional nullable int. </param>
        /// <param name="nonRequiredNullableString"> Optional nullable string. </param>
        /// <param name="requiredReadonlyInt"> Required readonly int. </param>
        /// <param name="nonRequiredReadonlyInt"> Optional readonly int. </param>
        /// <param name="requiredModel">
        /// Required model with discriminator
        /// Please note <see cref="BaseModelWithDiscriminator"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DerivedModelWithDiscriminatorA"/> and <see cref="DerivedModelWithDiscriminatorB"/>.
        /// </param>
        /// <param name="requiredFixedStringEnum"> Required fixed string enum. </param>
        /// <param name="requiredFixedIntEnum"> Required fixed int enum. </param>
        /// <param name="requiredExtensibleEnum"> Required extensible enum. </param>
        /// <param name="requiredList"> Required collection. </param>
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
        /// <param name="requiredNullableIntList"> Required nullable int list. </param>
        /// <param name="requiredNullableStringList"> Required nullable string list. </param>
        /// <param name="nonRequiredNullableIntList"> Optional nullable model list. </param>
        /// <param name="nonRequiredNullableStringList"> Optional nullable string list. </param>
        /// <returns> A new <see cref="Models.RoundTripModel"/> instance for mocking. </returns>
        public static RoundTripModel RoundTripModel(string requiredString = null, int requiredInt = default, string nonRequiredString = null, int? nonRequiredInt = null, int? requiredNullableInt = null, string requiredNullableString = null, int? nonRequiredNullableInt = null, string nonRequiredNullableString = null, int requiredReadonlyInt = default, int? nonRequiredReadonlyInt = null, BaseModelWithDiscriminator requiredModel = null, FixedStringEnum requiredFixedStringEnum = default, FixedIntEnum requiredFixedIntEnum = default, ExtensibleEnum requiredExtensibleEnum = default, IEnumerable<CollectionItem> requiredList = null, IDictionary<string, int> requiredIntRecord = null, IDictionary<string, string> requiredStringRecord = null, IDictionary<string, RecordItem> requiredModelRecord = null, BinaryData requiredBytes = null, BinaryData optionalBytes = null, IEnumerable<int> requiredUint8Array = null, IEnumerable<int> optionalUint8Array = null, BinaryData requiredUnknown = null, BinaryData optionalUnknown = null, IEnumerable<int> requiredInt8Array = null, IEnumerable<int> optionalInt8Array = null, IEnumerable<int> requiredNullableIntList = null, IEnumerable<string> requiredNullableStringList = null, IEnumerable<int> nonRequiredNullableIntList = null, IEnumerable<string> nonRequiredNullableStringList = null)
        {
            requiredList ??= new List<CollectionItem>();
            requiredIntRecord ??= new Dictionary<string, int>();
            requiredStringRecord ??= new Dictionary<string, string>();
            requiredModelRecord ??= new Dictionary<string, RecordItem>();
            requiredUint8Array ??= new List<int>();
            optionalUint8Array ??= new List<int>();
            requiredInt8Array ??= new List<int>();
            optionalInt8Array ??= new List<int>();
            requiredNullableIntList ??= new List<int>();
            requiredNullableStringList ??= new List<string>();
            nonRequiredNullableIntList ??= new List<int>();
            nonRequiredNullableStringList ??= new List<string>();

            return new RoundTripModel(requiredString, requiredInt, nonRequiredString, nonRequiredInt, requiredNullableInt, requiredNullableString, nonRequiredNullableInt, nonRequiredNullableString, requiredReadonlyInt, nonRequiredReadonlyInt, requiredModel, requiredFixedStringEnum, requiredFixedIntEnum, requiredExtensibleEnum, requiredList?.ToList(), requiredIntRecord, requiredStringRecord, requiredModelRecord, requiredBytes, optionalBytes, requiredUint8Array?.ToList(), optionalUint8Array?.ToList(), requiredUnknown, optionalUnknown, requiredInt8Array?.ToList(), optionalInt8Array?.ToList(), requiredNullableIntList?.ToList(), requiredNullableStringList?.ToList(), nonRequiredNullableIntList?.ToList(), nonRequiredNullableStringList?.ToList());
        }

        /// <summary> Initializes a new instance of DerivedModelWithProperties. </summary>
        /// <param name="optionalPropertyOnBase"> Optional properties on base. </param>
        /// <param name="requiredList"> Required collection. </param>
        /// <returns> A new <see cref="Models.DerivedModelWithProperties"/> instance for mocking. </returns>
        public static DerivedModelWithProperties DerivedModelWithProperties(string optionalPropertyOnBase = null, IEnumerable<CollectionItem> requiredList = null)
        {
            requiredList ??= new List<CollectionItem>();

            return new DerivedModelWithProperties(optionalPropertyOnBase, requiredList?.ToList());
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
        /// <param name="requiredReadOnlyModelList"> Required model collection. </param>
        /// <param name="requiredReadOnlyIntRecord"> Required int record. </param>
        /// <param name="requiredStringRecord"> Required string record. </param>
        /// <param name="requiredReadOnlyModelRecord"> Required model record. </param>
        /// <param name="optionalReadonlyStringList"> Optional readonly string collection. </param>
        /// <param name="optionalReadonlyIntList"> Optional readonly int collection. </param>
        /// <param name="optionalReadOnlyModelList"> Optional model collection. </param>
        /// <param name="optionalReadOnlyIntRecord"> Optional int record. </param>
        /// <param name="optionalReadOnlyStringRecord"> Optional string record. </param>
        /// <param name="optionalModelRecord"> Optional model record. </param>
        /// <param name="requiredCollectionWithNullableIntElement"> Required collection of which the element is a nullable int. </param>
        /// <param name="optionalCollectionWithNullableBooleanElement"> Optional collection of which the element is a nullable boolean. </param>
        /// <returns> A new <see cref="Models.RoundTripReadOnlyModel"/> instance for mocking. </returns>
        public static RoundTripReadOnlyModel RoundTripReadOnlyModel(string requiredReadonlyString = null, int requiredReadonlyInt = default, string optionalReadonlyString = null, int? optionalReadonlyInt = null, DerivedModel requiredReadonlyModel = null, DerivedModel optionalReadonlyModel = null, FixedStringEnum requiredReadonlyFixedStringEnum = default, ExtensibleEnum requiredReadonlyExtensibleEnum = default, FixedStringEnum optionalReadonlyFixedStringEnum = default, ExtensibleEnum optionalReadonlyExtensibleEnum = default, IEnumerable<string> requiredReadonlyStringList = null, IEnumerable<int> requiredReadonlyIntList = null, IEnumerable<CollectionItem> requiredReadOnlyModelList = null, IReadOnlyDictionary<string, int> requiredReadOnlyIntRecord = null, IReadOnlyDictionary<string, string> requiredStringRecord = null, IReadOnlyDictionary<string, RecordItem> requiredReadOnlyModelRecord = null, IEnumerable<string> optionalReadonlyStringList = null, IEnumerable<int> optionalReadonlyIntList = null, IEnumerable<CollectionItem> optionalReadOnlyModelList = null, IReadOnlyDictionary<string, int> optionalReadOnlyIntRecord = null, IReadOnlyDictionary<string, string> optionalReadOnlyStringRecord = null, IReadOnlyDictionary<string, RecordItem> optionalModelRecord = null, IEnumerable<int?> requiredCollectionWithNullableIntElement = null, IEnumerable<bool?> optionalCollectionWithNullableBooleanElement = null)
        {
            requiredReadonlyStringList ??= new List<string>();
            requiredReadonlyIntList ??= new List<int>();
            requiredReadOnlyModelList ??= new List<CollectionItem>();
            requiredReadOnlyIntRecord ??= new Dictionary<string, int>();
            requiredStringRecord ??= new Dictionary<string, string>();
            requiredReadOnlyModelRecord ??= new Dictionary<string, RecordItem>();
            optionalReadonlyStringList ??= new List<string>();
            optionalReadonlyIntList ??= new List<int>();
            optionalReadOnlyModelList ??= new List<CollectionItem>();
            optionalReadOnlyIntRecord ??= new Dictionary<string, int>();
            optionalReadOnlyStringRecord ??= new Dictionary<string, string>();
            optionalModelRecord ??= new Dictionary<string, RecordItem>();
            requiredCollectionWithNullableIntElement ??= new List<int?>();
            optionalCollectionWithNullableBooleanElement ??= new List<bool?>();

            return new RoundTripReadOnlyModel(requiredReadonlyString, requiredReadonlyInt, optionalReadonlyString, optionalReadonlyInt, requiredReadonlyModel, optionalReadonlyModel, requiredReadonlyFixedStringEnum, requiredReadonlyExtensibleEnum, optionalReadonlyFixedStringEnum, optionalReadonlyExtensibleEnum, requiredReadonlyStringList?.ToList(), requiredReadonlyIntList?.ToList(), requiredReadOnlyModelList?.ToList(), requiredReadOnlyIntRecord, requiredStringRecord, requiredReadOnlyModelRecord, optionalReadonlyStringList?.ToList(), optionalReadonlyIntList?.ToList(), optionalReadOnlyModelList?.ToList(), optionalReadOnlyIntRecord, optionalReadOnlyStringRecord, optionalModelRecord, requiredCollectionWithNullableIntElement?.ToList(), optionalCollectionWithNullableBooleanElement?.ToList());
        }

        /// <summary> Initializes a new instance of OutputModel. </summary>
        /// <param name="requiredString"> Required string. </param>
        /// <param name="requiredInt"> Required int. </param>
        /// <param name="requiredModel"> Required model. </param>
        /// <param name="requiredList"> Required collection. </param>
        /// <param name="requiredModelRecord"> Required model record. </param>
        /// <param name="optionalList"> Optional model collection. </param>
        /// <param name="optionalNullableList"> Optional model nullable collection. </param>
        /// <param name="optionalRecord"> Optional model record. </param>
        /// <param name="optionalNullableRecord"> Optional model nullable record. </param>
        /// <returns> A new <see cref="Models.OutputModel"/> instance for mocking. </returns>
        public static OutputModel OutputModel(string requiredString = null, int requiredInt = default, DerivedModel requiredModel = null, IEnumerable<CollectionItem> requiredList = null, IReadOnlyDictionary<string, RecordItem> requiredModelRecord = null, IEnumerable<CollectionItem> optionalList = null, IEnumerable<CollectionItem> optionalNullableList = null, IReadOnlyDictionary<string, RecordItem> optionalRecord = null, IReadOnlyDictionary<string, RecordItem> optionalNullableRecord = null)
        {
            requiredList ??= new List<CollectionItem>();
            requiredModelRecord ??= new Dictionary<string, RecordItem>();
            optionalList ??= new List<CollectionItem>();
            optionalNullableList ??= new List<CollectionItem>();
            optionalRecord ??= new Dictionary<string, RecordItem>();
            optionalNullableRecord ??= new Dictionary<string, RecordItem>();

            return new OutputModel(requiredString, requiredInt, requiredModel, requiredList?.ToList(), requiredModelRecord, optionalList?.ToList(), optionalNullableList?.ToList(), optionalRecord, optionalNullableRecord);
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
