// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace _Type.Property.Optional.Models
{
    /// <summary> Model with collection models properties. </summary>
    public partial class CollectionsModelProperty
    {
        /// <summary> Initializes a new instance of CollectionsModelProperty. </summary>
        public CollectionsModelProperty()
        {
            Property = new ChangeTrackingList<StringProperty>();
        }

        /// <summary> Initializes a new instance of CollectionsModelProperty. </summary>
        /// <param name="property"> Property. </param>
        internal CollectionsModelProperty(IList<StringProperty> property)
        {
            Property = property;
        }

        /// <summary> Property. </summary>
        public IList<StringProperty> Property { get; }
    }
}
