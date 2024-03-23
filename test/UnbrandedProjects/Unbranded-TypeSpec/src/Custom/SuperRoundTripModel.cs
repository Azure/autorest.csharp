// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System;

namespace UnbrandedTypeSpec.Models
{
    /// <summary> this is a roundtrip model. </summary>
    //[CodeGenSuppress("SuperRoundTripModel", typeof(string), typeof(int), typeof(IEnumerable<StringFixedEnum?>), typeof(IDictionary<string, StringExtensibleEnum?>), typeof(Thing), typeof(BinaryData), typeof(IDictionary<string, BinaryData>), typeof(ModelWithRequiredNullableProperties))]
    [CodeGenType("RoundTripModel")]
    [CodeGenSerialization(nameof(RequiredModel), "requiredSuperModel")]
    public partial class SuperRoundTripModel
    {
        /// <summary> Required string, illustrating a reference type property. </summary>
        [CodeGenMember("RequiredString")]
        public string RequiredSuperString { get; set; }
    }
}
