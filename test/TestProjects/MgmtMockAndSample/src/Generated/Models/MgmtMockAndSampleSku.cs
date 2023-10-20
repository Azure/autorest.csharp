// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary> SKU details. </summary>
    public partial class MgmtMockAndSampleSku
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="MgmtMockAndSampleSku"/>. </summary>
        /// <param name="family"> SKU family name. </param>
        /// <param name="name"> SKU name to specify whether the key vault is a standard vault or a premium vault. </param>
        public MgmtMockAndSampleSku(MgmtMockAndSampleSkuFamily family, MgmtMockAndSampleSkuName name)
        {
            Family = family;
            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="MgmtMockAndSampleSku"/>. </summary>
        /// <param name="family"> SKU family name. </param>
        /// <param name="name"> SKU name to specify whether the key vault is a standard vault or a premium vault. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MgmtMockAndSampleSku(MgmtMockAndSampleSkuFamily family, MgmtMockAndSampleSkuName name, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Family = family;
            Name = name;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MgmtMockAndSampleSku"/> for deserialization. </summary>
        internal MgmtMockAndSampleSku()
        {
        }

        /// <summary> SKU family name. </summary>
        public MgmtMockAndSampleSkuFamily Family { get; set; }
        /// <summary> SKU name to specify whether the key vault is a standard vault or a premium vault. </summary>
        public MgmtMockAndSampleSkuName Name { get; set; }
    }
}
