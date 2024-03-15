// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using UnbrandedTypeSpec;

namespace UnbrandedTypeSpec.Models
{
    /// <summary> this is a roundtrip model. </summary>
    public partial class RoundTripModel
    {
/// <summary> Required string, illustrating a reference type property. </summary>
        [CodeGenMember("RequiredString")]
        public string RequiredSuperString { get; set; }
    }
}
