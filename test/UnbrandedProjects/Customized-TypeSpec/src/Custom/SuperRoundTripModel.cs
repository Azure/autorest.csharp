// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace CustomizedTypeSpec.Models
{
    /// <summary> this is a roundtrip model. </summary>
    [CodeGenType("RoundTripModel")]
    [CodeGenSerialization(nameof(RequiredString), "requiredSuperString")]
    public partial class SuperRoundTripModel
    {
        /// <summary> Required string, illustrating a reference type property. </summary>
        [CodeGenMember("RequiredInt")]
        public int RequiredSuperInt { get; set; }
    }
}
