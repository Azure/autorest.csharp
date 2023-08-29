// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace _Type.Property.Nullable.Models
{
    /// <summary> Model with collection models properties. </summary>
    public partial class CollectionsModelProperty
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of CollectionsModelProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProperty"/> is null. </exception>
        internal CollectionsModelProperty(string requiredProperty, IEnumerable<InnerModel> nullableProperty)
        {
            Argument.AssertNotNull(requiredProperty, nameof(requiredProperty));

            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty?.ToList();
        }

        /// <summary> Initializes a new instance of CollectionsModelProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal CollectionsModelProperty(string requiredProperty, IReadOnlyList<InnerModel> nullableProperty, Dictionary<string, BinaryData> rawData)
        {
            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="CollectionsModelProperty"/> for deserialization. </summary>
        internal CollectionsModelProperty()
        {
        }

        /// <summary> Required property. </summary>
        public string RequiredProperty { get; }
        /// <summary> Property. </summary>
        public IReadOnlyList<InnerModel> NullableProperty { get; }
    }
}
