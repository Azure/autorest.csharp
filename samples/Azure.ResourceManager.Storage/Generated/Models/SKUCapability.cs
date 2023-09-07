// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </summary>
    public partial class SKUCapability
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="SKUCapability"/>. </summary>
        internal SKUCapability()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SKUCapability"/>. </summary>
        /// <param name="name"> The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </param>
        /// <param name="value"> A string value to indicate states of given capability. Possibly 'true' or 'false'. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SKUCapability(string name, string value, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Value = value;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </summary>
        public string Name { get; }
        /// <summary> A string value to indicate states of given capability. Possibly 'true' or 'false'. </summary>
        public string Value { get; }
    }
}
