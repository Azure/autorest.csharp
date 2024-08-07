// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelReaderWriterValidationTypeSpec.Models
{
    /// <summary> The availability set data. </summary>
    public partial class AvailabilitySetData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="AvailabilitySetData"/>. </summary>
        /// <param name="location"> The location property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        public AvailabilitySetData(string location) : base(location)
        {
            Argument.AssertNotNull(location, nameof(location));
        }

        /// <summary> Initializes a new instance of <see cref="AvailabilitySetData"/>. </summary>
        /// <param name="id"> The id property. </param>
        /// <param name="name"> The name property. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="location"> The location property. </param>
        /// <param name="tags"> The tags property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="sku"> The sku. </param>
        /// <param name="properties"> The properties property. </param>
        internal AvailabilitySetData(string id, string name, string resourceType, string location, IDictionary<string, string> tags, IDictionary<string, BinaryData> serializedAdditionalRawData, ComputeSku sku, AvailabilitySetProperties properties) : base(id, name, resourceType, location, tags, serializedAdditionalRawData)
        {
            Sku = sku;
            Properties = properties;
        }

        /// <summary> Initializes a new instance of <see cref="AvailabilitySetData"/> for deserialization. </summary>
        internal AvailabilitySetData()
        {
        }

        /// <summary> The sku. </summary>
        public ComputeSku Sku { get; set; }
        /// <summary> The properties property. </summary>
        public AvailabilitySetProperties Properties { get; set; }
    }
}
