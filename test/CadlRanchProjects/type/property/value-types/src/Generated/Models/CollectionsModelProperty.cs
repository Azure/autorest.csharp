// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="CollectionsModelProperty"/>. </summary>
        /// <param name="property"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        public CollectionsModelProperty(IEnumerable<InnerModel> property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property.ToList();
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="CollectionsModelProperty"/>. </summary>
        /// <param name="property"> Property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CollectionsModelProperty(IList<InnerModel> property, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Property = property;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CollectionsModelProperty"/> for deserialization. </summary>
        internal CollectionsModelProperty()
        {
        }

        /// <summary> Property. </summary>
        public IList<InnerModel> Property { get; }
    }
}
