// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Models.Inheritance
{
    /// <summary> The third level model GoblinShark in polymorphic multiple levels inheritance. </summary>
    public partial class GoblinShark : Shark
    {
        /// <summary> Initializes a new instance of GoblinShark. </summary>
        /// <param name="kind"></param>
        /// <param name="age"></param>
        /// <param name="sharktype"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> or <paramref name="sharktype"/> is null. </exception>
        public GoblinShark(string kind, int age, string sharktype) : base(kind, age, sharktype)
        {
            Argument.AssertNotNull(kind, nameof(kind));
            Argument.AssertNotNull(sharktype, nameof(sharktype));
        }
    }
}
