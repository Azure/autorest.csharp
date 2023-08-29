// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Property.Nullable.Models
{
    /// <summary> Model with a datetime property. </summary>
    public partial class DatetimeProperty
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of DatetimeProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProperty"/> is null. </exception>
        internal DatetimeProperty(string requiredProperty, DateTimeOffset? nullableProperty)
        {
            Argument.AssertNotNull(requiredProperty, nameof(requiredProperty));

            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty;
        }

        /// <summary> Initializes a new instance of DatetimeProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DatetimeProperty(string requiredProperty, DateTimeOffset? nullableProperty, Dictionary<string, BinaryData> rawData)
        {
            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="DatetimeProperty"/> for deserialization. </summary>
        internal DatetimeProperty()
        {
        }

        /// <summary> Required property. </summary>
        public string RequiredProperty { get; }
        /// <summary> Property. </summary>
        public DateTimeOffset? NullableProperty { get; }
    }
}
