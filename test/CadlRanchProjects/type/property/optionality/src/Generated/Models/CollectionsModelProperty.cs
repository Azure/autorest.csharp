// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Property.Optionality.Models
{
    /// <summary> Model with collection models properties. </summary>
    public partial class CollectionsModelProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of CollectionsModelProperty. </summary>
        public CollectionsModelProperty()
        {
            Property = new ChangeTrackingList<StringProperty>();
        }

        /// <summary> Initializes a new instance of CollectionsModelProperty. </summary>
        /// <param name="property"> Property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CollectionsModelProperty(IList<StringProperty> property, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Property = property;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Property. </summary>
        public IList<StringProperty> Property { get; }
    }
}
