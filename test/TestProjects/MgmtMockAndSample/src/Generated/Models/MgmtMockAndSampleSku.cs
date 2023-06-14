// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> SKU details. </summary>
    public partial class MgmtMockAndSampleSku
    {
        /// <summary> Initializes a new instance of MgmtMockAndSampleSku. </summary>
        /// <param name="family"> SKU family name. </param>
        /// <param name="name"> SKU name to specify whether the key vault is a standard vault or a premium vault. </param>
        public MgmtMockAndSampleSku(MgmtMockAndSampleSkuFamily family, MgmtMockAndSampleSkuName name)
        {
            Family = family;
            Name = name;
        }

        /// <summary> SKU family name. </summary>
        public MgmtMockAndSampleSkuFamily Family { get; set; }
        /// <summary> SKU name to specify whether the key vault is a standard vault or a premium vault. </summary>
        public MgmtMockAndSampleSkuName Name { get; set; }
    }
}
