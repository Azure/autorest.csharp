// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Model used both as input and output with primitive types. </summary>
    public partial class RoundTripPrimitiveModel : BaseModel
    {
        /// <summary> Initializes a new instance of RoundTripPrimitiveModel. </summary>
        /// <param name="requiredString"> Required string, illustrating a reference type property. </param>
        /// <param name="requiredInt"> Required int, illustrating a value type property. </param>
        /// <param name="requiredInt64"> Required int64, illustrating a value type property. </param>
        /// <param name="requiredSafeInt"> Required safeint, illustrating a value type property. </param>
        /// <param name="requiredFloat"> Required float, illustrating a value type property. </param>
        /// <param name="requiredDouble"> Required double, illustrating a value type property. </param>
        /// <param name="requiredBoolean"> Required bolean, illustrating a value type property. </param>
        /// <param name="requiredDateTimeOffset"> Required date time offset, illustrating a reference type property. </param>
        /// <param name="requiredTimeSpan"> Required time span, illustrating a value type property. </param>
        /// <param name="requiredCollectionWithNullableFloatElement"> Required collection of which the element is a nullable float. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/> or <paramref name="requiredCollectionWithNullableFloatElement"/> is null. </exception>
        public RoundTripPrimitiveModel(string requiredString, int requiredInt, long requiredInt64, long requiredSafeInt, float requiredFloat, double requiredDouble, bool requiredBoolean, DateTimeOffset requiredDateTimeOffset, TimeSpan requiredTimeSpan, IEnumerable<float?> requiredCollectionWithNullableFloatElement)
        {
            Argument.AssertNotNull(requiredString, nameof(requiredString));
            Argument.AssertNotNull(requiredCollectionWithNullableFloatElement, nameof(requiredCollectionWithNullableFloatElement));

            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredInt64 = requiredInt64;
            RequiredSafeInt = requiredSafeInt;
            RequiredFloat = requiredFloat;
            RequiredDouble = requiredDouble;
            RequiredBoolean = requiredBoolean;
            RequiredDateTimeOffset = requiredDateTimeOffset;
            RequiredTimeSpan = requiredTimeSpan;
            RequiredCollectionWithNullableFloatElement = requiredCollectionWithNullableFloatElement.ToList();
        }

        /// <summary> Initializes a new instance of RoundTripPrimitiveModel. </summary>
        /// <param name="requiredString"> Required string, illustrating a reference type property. </param>
        /// <param name="requiredInt"> Required int, illustrating a value type property. </param>
        /// <param name="requiredInt64"> Required int64, illustrating a value type property. </param>
        /// <param name="requiredSafeInt"> Required safeint, illustrating a value type property. </param>
        /// <param name="requiredFloat"> Required float, illustrating a value type property. </param>
        /// <param name="requiredDouble"> Required double, illustrating a value type property. </param>
        /// <param name="requiredBoolean"> Required bolean, illustrating a value type property. </param>
        /// <param name="requiredDateTimeOffset"> Required date time offset, illustrating a reference type property. </param>
        /// <param name="requiredTimeSpan"> Required time span, illustrating a value type property. </param>
        /// <param name="requiredCollectionWithNullableFloatElement"> Required collection of which the element is a nullable float. </param>
        internal RoundTripPrimitiveModel(string requiredString, int requiredInt, long requiredInt64, long requiredSafeInt, float requiredFloat, double requiredDouble, bool requiredBoolean, DateTimeOffset requiredDateTimeOffset, TimeSpan requiredTimeSpan, IList<float?> requiredCollectionWithNullableFloatElement)
        {
            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredInt64 = requiredInt64;
            RequiredSafeInt = requiredSafeInt;
            RequiredFloat = requiredFloat;
            RequiredDouble = requiredDouble;
            RequiredBoolean = requiredBoolean;
            RequiredDateTimeOffset = requiredDateTimeOffset;
            RequiredTimeSpan = requiredTimeSpan;
            RequiredCollectionWithNullableFloatElement = requiredCollectionWithNullableFloatElement;
        }

        /// <summary> Required string, illustrating a reference type property. </summary>
        public string RequiredString { get; set; }
        /// <summary> Required int, illustrating a value type property. </summary>
        public int RequiredInt { get; set; }
        /// <summary> Required int64, illustrating a value type property. </summary>
        public long RequiredInt64 { get; set; }
        /// <summary> Required safeint, illustrating a value type property. </summary>
        public long RequiredSafeInt { get; set; }
        /// <summary> Required float, illustrating a value type property. </summary>
        public float RequiredFloat { get; set; }
        /// <summary> Required double, illustrating a value type property. </summary>
        public double RequiredDouble { get; set; }
        /// <summary> Required bolean, illustrating a value type property. </summary>
        public bool RequiredBoolean { get; set; }
        /// <summary> Required date time offset, illustrating a reference type property. </summary>
        public DateTimeOffset RequiredDateTimeOffset { get; set; }
        /// <summary> Required time span, illustrating a value type property. </summary>
        public TimeSpan RequiredTimeSpan { get; set; }
        /// <summary> Required collection of which the element is a nullable float. </summary>
        public IList<float?> RequiredCollectionWithNullableFloatElement { get; }
    }
}
