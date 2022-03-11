// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtKeyvault.Models
{
    /// <summary> SKU details. </summary>
    public partial class MgmtKeyvaultSku
    {
        /// <summary> Initializes a new instance of MgmtKeyvaultSku. </summary>
        /// <param name="family"> SKU family name. </param>
        /// <param name="name"> SKU name to specify whether the key vault is a standard vault or a premium vault. </param>
        public MgmtKeyvaultSku(MgmtKeyvaultSkuFamily family, MgmtKeyvaultSkuName name)
        {
            Family = family;
            Name = name;
        }

        /// <summary> SKU family name. </summary>
        public MgmtKeyvaultSkuFamily Family { get; set; }
        /// <summary> SKU name to specify whether the key vault is a standard vault or a premium vault. </summary>
        public MgmtKeyvaultSkuName Name { get; set; }
    }
}
