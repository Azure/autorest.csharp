// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Models.Inheritance
{
    /// <summary> The third level model SawShark in polymorphic multiple levels inheritance. </summary>
    public partial class SawShark : Shark
    {
        /// <summary> Initializes a new instance of SawShark. </summary>
        /// <param name="kind"></param>
        /// <param name="age"></param>
        /// <param name="sharktype"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> or <paramref name="sharktype"/> is null. </exception>
        public SawShark(string kind, int age, string sharktype) : base(kind, age, sharktype)
        {
            Argument.AssertNotNull(kind, nameof(kind));
            Argument.AssertNotNull(sharktype, nameof(sharktype));
        }
    }
}
