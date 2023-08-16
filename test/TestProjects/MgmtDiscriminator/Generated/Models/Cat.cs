// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtDiscriminator.Models
{
    /// <summary> A cat. </summary>
    public partial class Cat : Pet
    {
        /// <summary>
        /// Initializes a new instance of global::MgmtDiscriminator.Models.Cat
        ///
        /// </summary>
        public Cat()
        {
            Kind = PetKind.Cat;
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtDiscriminator.Models.Cat
        ///
        /// </summary>
        /// <param name="kind"> The kind of the pet. </param>
        /// <param name="id"> The Id of the pet. </param>
        /// <param name="meow"> A cat can meow. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Cat(PetKind kind, string id, string meow, Dictionary<string, BinaryData> rawData) : base(kind, id, rawData)
        {
            Meow = meow;
            Kind = kind;
        }

        /// <summary> A cat can meow. </summary>
        public string Meow { get; set; }
    }
}
