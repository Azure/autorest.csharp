// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Type.Model.Inheritance.SingleDiscriminator.Models
{
    /// <summary> The second level model in polymorphic single level inheritance. </summary>
    public partial class SeaGull : Bird
    {
        /// <summary> Initializes a new instance of <see cref="SeaGull"/>. </summary>
        /// <param name="wingspan"></param>
        public SeaGull(int wingspan) : base(wingspan)
        {
            Kind = "seagull";
        }

        /// <summary> Initializes a new instance of <see cref="SeaGull"/>. </summary>
        /// <param name="kind"></param>
        /// <param name="wingspan"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SeaGull(string kind, int wingspan, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(kind, wingspan, serializedAdditionalRawData)
        {
        }

        /// <summary> Initializes a new instance of <see cref="SeaGull"/> for deserialization. </summary>
        internal SeaGull()
        {
        }
    }
}
