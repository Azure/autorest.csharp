// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Scm._Type.Model.Inheritance.SingleDiscriminator.Models
{
    /// <summary> Unknown version of Dinosaur. </summary>
    internal partial class UnknownDinosaur : Dinosaur
    {
        /// <summary> Initializes a new instance of <see cref="UnknownDinosaur"/>. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="size"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownDinosaur(string kind, int size, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(kind, size, serializedAdditionalRawData)
        {
        }

        /// <summary> Initializes a new instance of <see cref="UnknownDinosaur"/> for deserialization. </summary>
        internal UnknownDinosaur()
        {
        }
    }
}
