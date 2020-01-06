// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace body_complex.Models.V20160229
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class Shark : Fish
    {
        /// <summary> Initializes a new instance of Shark. </summary>
        public Shark()
        {
            Fishtype = "shark";
        }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-INTEGER. </summary>
        public int? Age { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-DATETIME. </summary>
        public DateTimeOffset Birthday { get; set; }
    }
}
