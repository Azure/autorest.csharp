// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary> Initializes a new instance of CollectionsModelProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProperty"/> or <paramref name="nullableProperty"/> is null. </exception>
        internal CollectionsModelProperty(string requiredProperty, IEnumerable<InnerModel> nullableProperty)
        {
            Argument.AssertNotNull(requiredProperty, nameof(requiredProperty));
            Argument.AssertNotNull(nullableProperty, nameof(nullableProperty));

            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty.ToList();
        }

        /// <summary> Initializes a new instance of CollectionsModelProperty. </summary>
        /// <param name="requiredProperty"> Required property. </param>
        /// <param name="nullableProperty"> Property. </param>
        internal CollectionsModelProperty(string requiredProperty, IReadOnlyList<InnerModel> nullableProperty)
        {
            RequiredProperty = requiredProperty;
            NullableProperty = nullableProperty;
        }

        /// <summary> Required property. </summary>
        public string RequiredProperty { get; }
        /// <summary> Property. </summary>
        public IReadOnlyList<InnerModel> NullableProperty { get; }
    }
}
