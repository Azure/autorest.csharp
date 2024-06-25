// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace _Type.Property.Nullable.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class TypePropertyNullableModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.StringProperty"/>. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <returns> A new <see cref="Models.StringProperty"/> instance for mocking. </returns>
        public static StringProperty StringProperty(string requiredProperty = null, string nullableProperty = null)
        {
            return new StringProperty(requiredProperty, nullableProperty, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.BytesProperty"/>. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <returns> A new <see cref="Models.BytesProperty"/> instance for mocking. </returns>
        public static BytesProperty BytesProperty(string requiredProperty = null, BinaryData nullableProperty = null)
        {
            return new BytesProperty(requiredProperty, nullableProperty, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DatetimeProperty"/>. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <returns> A new <see cref="Models.DatetimeProperty"/> instance for mocking. </returns>
        public static DatetimeProperty DatetimeProperty(string requiredProperty = null, DateTimeOffset? nullableProperty = null)
        {
            return new DatetimeProperty(requiredProperty, nullableProperty, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DurationProperty"/>. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <returns> A new <see cref="Models.DurationProperty"/> instance for mocking. </returns>
        public static DurationProperty DurationProperty(string requiredProperty = null, TimeSpan? nullableProperty = null)
        {
            return new DurationProperty(requiredProperty, nullableProperty, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CollectionsByteProperty"/>. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <returns> A new <see cref="Models.CollectionsByteProperty"/> instance for mocking. </returns>
        public static CollectionsByteProperty CollectionsByteProperty(string requiredProperty = null, IEnumerable<BinaryData> nullableProperty = null)
        {
            nullableProperty ??= new List<BinaryData>();

            return new CollectionsByteProperty(requiredProperty, nullableProperty?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CollectionsModelProperty"/>. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <returns> A new <see cref="Models.CollectionsModelProperty"/> instance for mocking. </returns>
        public static CollectionsModelProperty CollectionsModelProperty(string requiredProperty = null, IEnumerable<InnerModel> nullableProperty = null)
        {
            nullableProperty ??= new List<InnerModel>();

            return new CollectionsModelProperty(requiredProperty, nullableProperty?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.InnerModel"/>. </summary>
        /// <param name="property"> Inner model property. </param>
        /// <returns> A new <see cref="Models.InnerModel"/> instance for mocking. </returns>
        public static InnerModel InnerModel(string property = null)
        {
            return new InnerModel(property, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CollectionsStringProperty"/>. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <returns> A new <see cref="Models.CollectionsStringProperty"/> instance for mocking. </returns>
        public static CollectionsStringProperty CollectionsStringProperty(string requiredProperty = null, IEnumerable<string> nullableProperty = null)
        {
            nullableProperty ??= new List<string>();

            return new CollectionsStringProperty(requiredProperty, nullableProperty?.ToList(), serializedAdditionalRawData: null);
        }
    }
}
