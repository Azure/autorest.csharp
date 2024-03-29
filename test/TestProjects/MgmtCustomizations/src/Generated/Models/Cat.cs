// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtCustomizations.Models
{
    /// <summary> A cat. </summary>
    public partial class Cat : Pet
    {
        /// <summary> Initializes a new instance of <see cref="Cat"/>. </summary>
        public Cat()
        {
            Kind = PetKind.Cat;
        }

        /// <summary> Initializes a new instance of <see cref="Cat"/>. </summary>
        /// <param name="kind"> The kind of the pet. </param>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="size">
        /// The size of the pet. This property here is mocking the following scenario:
        /// Despite in the swagger it has a type of string, in the real payload of this request, the service is actually sending using a number, therefore the type in this swagger here is wrong and we have to fix it using customization code.
        /// </param>
        /// <param name="dateOfBirth"> Pet date of birth. </param>
        /// <param name="color"></param>
        /// <param name="tags"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="sleep"> A cat can sleep. </param>
        /// <param name="jump"> A cat can jump. </param>
        /// <param name="meow"> A cat can meow. </param>
        internal Cat(PetKind kind, string name, int size, DateTimeOffset? dateOfBirth, string color, IDictionary<string, string> tags, IDictionary<string, BinaryData> serializedAdditionalRawData, string sleep, string jump, string meow) : base(kind, name, size, dateOfBirth, color, tags, serializedAdditionalRawData)
        {
            Sleep = sleep;
            Jump = jump;
            Meow = meow;
            Kind = kind;
        }

        /// <summary> A cat can sleep. </summary>
        public string Sleep { get; set; }
        /// <summary> A cat can jump. </summary>
        public string Jump { get; set; }
    }
}
