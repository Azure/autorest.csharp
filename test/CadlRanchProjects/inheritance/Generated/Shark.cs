// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Models.Inheritance
{
    /// <summary> The second level model in polymorphic multiple levels inheritance and it defines a new discriminator. </summary>
    public partial class Shark : Fish
    {
        /// <summary> Initializes a new instance of Shark. </summary>
        /// <param name="sharktype"></param>
        /// <param name="kind"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="sharktype"/> or <paramref name="kind"/> is null. </exception>
        public Shark(string sharktype, string kind)
        {
            Argument.AssertNotNull(sharktype, nameof(sharktype));
            Argument.AssertNotNull(kind, nameof(kind));

            Sharktype = sharktype;
            Kind = kind;
        }

        public string Sharktype { get; set; }

        public string Kind { get; set; }
    }
}
