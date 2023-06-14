// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace _Type.Property.Nullable.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class TypePropertyNullableModelFactory
    {
        /// <summary> Initializes a new instance of StringProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProperty"/> is null. </exception>
        /// <returns> A new <see cref="Models.StringProperty"/> instance for mocking. </returns>
        public static StringProperty StringProperty(string requiredProperty = null, string nullableProperty = null)
        {
            if (requiredProperty == null)
            {
                throw new ArgumentNullException(nameof(requiredProperty));
            }

            return new StringProperty(requiredProperty, nullableProperty);
        }

        /// <summary> Initializes a new instance of BytesProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProperty"/> is null. </exception>
        /// <returns> A new <see cref="Models.BytesProperty"/> instance for mocking. </returns>
        public static BytesProperty BytesProperty(string requiredProperty = null, BinaryData nullableProperty = null)
        {
            if (requiredProperty == null)
            {
                throw new ArgumentNullException(nameof(requiredProperty));
            }

            return new BytesProperty(requiredProperty, nullableProperty);
        }

        /// <summary> Initializes a new instance of DatetimeProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProperty"/> is null. </exception>
        /// <returns> A new <see cref="Models.DatetimeProperty"/> instance for mocking. </returns>
        public static DatetimeProperty DatetimeProperty(string requiredProperty = null, DateTimeOffset? nullableProperty = null)
        {
            if (requiredProperty == null)
            {
                throw new ArgumentNullException(nameof(requiredProperty));
            }

            return new DatetimeProperty(requiredProperty, nullableProperty);
        }

        /// <summary> Initializes a new instance of DurationProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProperty"/> is null. </exception>
        /// <returns> A new <see cref="Models.DurationProperty"/> instance for mocking. </returns>
        public static DurationProperty DurationProperty(string requiredProperty = null, TimeSpan? nullableProperty = null)
        {
            if (requiredProperty == null)
            {
                throw new ArgumentNullException(nameof(requiredProperty));
            }

            return new DurationProperty(requiredProperty, nullableProperty);
        }

        /// <summary> Initializes a new instance of CollectionsByteProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <returns> A new <see cref="Models.CollectionsByteProperty"/> instance for mocking. </returns>
        public static CollectionsByteProperty CollectionsByteProperty(string requiredProperty = null, IEnumerable<BinaryData> nullableProperty = null)
        {
            nullableProperty ??= new List<BinaryData>();

            return new CollectionsByteProperty(requiredProperty, nullableProperty?.ToList());
        }

        /// <summary> Initializes a new instance of CollectionsModelProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <returns> A new <see cref="Models.CollectionsModelProperty"/> instance for mocking. </returns>
        public static CollectionsModelProperty CollectionsModelProperty(string requiredProperty = null, IEnumerable<InnerModel> nullableProperty = null)
        {
            nullableProperty ??= new List<InnerModel>();

            return new CollectionsModelProperty(requiredProperty, nullableProperty?.ToList());
        }

        /// <summary> Initializes a new instance of InnerModel. </summary>
        /// <param name="property"> Inner model property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        /// <returns> A new <see cref="Models.InnerModel"/> instance for mocking. </returns>
        public static InnerModel InnerModel(string property = null)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return new InnerModel(property);
        }
    }
}
