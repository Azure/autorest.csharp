// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtDiscriminator.Models
{
    /// <summary> A dog. </summary>
    public partial class Dog : Pet
    {
        /// <summary>
        /// Initializes a new instance of global::MgmtDiscriminator.Models.Dog
        ///
        /// </summary>
        public Dog()
        {
            Kind = PetKind.Dog;
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtDiscriminator.Models.Dog
        ///
        /// </summary>
        /// <param name="kind"> The kind of the pet. </param>
        /// <param name="id"> The Id of the pet. </param>
        /// <param name="bark"> A dog can bark. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Dog(PetKind kind, string id, string bark, Dictionary<string, BinaryData> rawData) : base(kind, id, rawData)
        {
            Bark = bark;
            Kind = kind;
        }

        /// <summary> A dog can bark. </summary>
        public string Bark { get; set; }
    }
}
