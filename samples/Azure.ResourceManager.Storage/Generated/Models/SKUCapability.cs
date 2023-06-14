// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </summary>
    public partial class SKUCapability
    {
        /// <summary> Initializes a new instance of SKUCapability. </summary>
        internal SKUCapability()
        {
        }

        /// <summary> Initializes a new instance of SKUCapability. </summary>
        /// <param name="name"> The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </param>
        /// <param name="value"> A string value to indicate states of given capability. Possibly 'true' or 'false'. </param>
        internal SKUCapability(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary> The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </summary>
        public string Name { get; }
        /// <summary> A string value to indicate states of given capability. Possibly 'true' or 'false'. </summary>
        public string Value { get; }
    }
}
