// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace body_complex.Models.V20160229
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class Sawshark : Shark
    {
        /// <summary> Initializes a new instance of Sawshark. </summary>
        public Sawshark()
        {
            Fishtype = "sawshark";
        }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BYTEARRAY. </summary>
        public byte[]? Picture { get; set; }
    }
}
