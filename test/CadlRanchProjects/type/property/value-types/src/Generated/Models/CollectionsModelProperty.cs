// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with collection model properties. </summary>
    public partial class CollectionsModelProperty
    {
        /// <summary> Initializes a new instance of CollectionsModelProperty. </summary>
        /// <param name="property"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        public CollectionsModelProperty(IEnumerable<InnerModel> property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property.ToList();
        }

        /// <summary> Initializes a new instance of CollectionsModelProperty. </summary>
        /// <param name="property"> Property. </param>
        internal CollectionsModelProperty(IList<InnerModel> property)
        {
            Property = property;
        }

        /// <summary> Property. </summary>
        public IList<InnerModel> Property { get; }
    }
}
