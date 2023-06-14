// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> SKU details. </summary>
    public partial class ManagedHsmSku
    {
        /// <summary> Initializes a new instance of ManagedHsmSku. </summary>
        /// <param name="family"> SKU Family of the managed HSM Pool. </param>
        /// <param name="name"> SKU of the managed HSM Pool. </param>
        public ManagedHsmSku(ManagedHsmSkuFamily family, ManagedHsmSkuName name)
        {
            Family = family;
            Name = name;
        }

        /// <summary> SKU Family of the managed HSM Pool. </summary>
        public ManagedHsmSkuFamily Family { get; set; }
        /// <summary> SKU of the managed HSM Pool. </summary>
        public ManagedHsmSkuName Name { get; set; }
    }
}
